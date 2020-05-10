using System.Collections.Generic;
using System.Threading.Tasks;
using NirvanaHqApi.Models;

namespace NirvanaHqApi.Projects
{
    public interface IProjectService
    {
        public Task<List<NirvanaTask>> GetProjects();

        public Task<List<NirvanaTask>> GetActiveProjects();

        Task<bool> AddNewProjects(List<NirvanaTask> tasks);
    }
}
