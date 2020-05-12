using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NirvanaHqApi.Api;
using NirvanaHqApi.Models;

namespace NirvanaHqApi
{
    internal class TaskService : ITaskService
    {
        private readonly ITaskApiService _taskApiService;

        public TaskService(IConnection connection) : this(new TaskApiService(connection))
        {
        }

        public TaskService(ITaskApiService taskApiService)
        {
            _taskApiService = taskApiService;
        }

        public async Task<List<NirvanaTask>> GetTasks()
        {
            var tasks = await _taskApiService.GetTasksFromServer().ConfigureAwait(false);

            return tasks.ToList();
        }

        public async Task<bool> CreateTask(NirvanaTask task)
        {
            var result = await _taskApiService.CreateTask(task).ConfigureAwait(false);

            return result;
        }

        public async Task<bool> CreateTasks(List<NirvanaTask> tasks)
        {
            var result = await _taskApiService.CreateTasks(tasks).ConfigureAwait(false);

            return result;
        }
    }
}
