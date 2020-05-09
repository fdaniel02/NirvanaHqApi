using System.Collections.Generic;
using System.Threading.Tasks;
using NirvanaHqApi.Models;

namespace NirvanaHqApi
{
    public interface ITaskService
    {
        public Task<List<NirvanaTask>> GetTasks();

        Task<bool> CreateTasks(List<NirvanaTask> tasks);
    }
}
