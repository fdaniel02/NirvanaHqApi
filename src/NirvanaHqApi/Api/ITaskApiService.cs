using System.Collections.Generic;
using System.Threading.Tasks;
using NirvanaHqApi.Models;

namespace NirvanaHqApi.Api
{
    public interface ITaskApiService
    {
        Task<List<NirvanaTask>> GetTasksFromServer();

        Task<bool> CreateTasks(List<NirvanaTask> tasks);
    }
}
