using System.Collections.Generic;
using System.Threading.Tasks;
using NirvanaHqApi.Api;
using NirvanaHqApi.Models;

namespace NirvanaHqApi.Test.Tasks
{
    internal class FakeTaskApi : ITaskApiService
    {
        private List<NirvanaTask> _tasks;

        public FakeTaskApi(List<NirvanaTask> tasks)
        {
            _tasks = tasks;
        }

        public Task<bool> CreateTask(NirvanaTask task)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CreateTasks(List<NirvanaTask> tasks)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<NirvanaTask>> GetTasksFromServer()
        {
            return Task.FromResult(_tasks);
        }
    }
}
