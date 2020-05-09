using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NirvanaHqApi.Enums;
using NirvanaHqApi.Models;

namespace NirvanaHqApi.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly ITaskService _taskService;

        public ProjectService(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public ProjectService(IConnection connection) : this(new TaskService(connection))
        {
        }

        public async Task<List<NirvanaTask>> GetProjects()
        {
            var tasks = await _taskService.GetTasks().ConfigureAwait(false);
            var projects = tasks.Where(t => t.Type == TaskType.Project);

            return projects.ToList();
        }

        public async Task<List<NirvanaTask>> GetActiveProjects()
        {
            var projects = await GetProjects().ConfigureAwait(false);
            var activeProjects = projects.Where(p => p.State == TaskState.Active);

            return activeProjects.ToList();
        }

        public async Task<bool> AddNewProject(List<NirvanaTask> tasks)
        {
            var result = await _taskService.CreateTasks(tasks).ConfigureAwait(false);

            return result;
        }
    }
}
