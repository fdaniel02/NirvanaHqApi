using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using NirvanaHqApi.Api;
using NirvanaHqApi.Models;

namespace NirvanaHqApi.Test.Tasks
{
    internal class FakeTaskApi : ITaskApiService
    {
        private List<NirvanaTask> _tasks;

        public FakeTaskApi(List<NirvanaTask> tasks)
        {
            _tasks = new List<NirvanaTask>(tasks);
        }

        public Task<bool> CreateTask(NirvanaTask task)
        {
            Guard.Against.Null(task, nameof(task));
            _tasks.Add(task);

            return Task.FromResult(true);
        }

        public Task<bool> CreateTasks(List<NirvanaTask> tasks)
        {
            Guard.Against.Null(tasks, nameof(tasks));
            _tasks.AddRange(tasks);

            return Task.FromResult(true);
        }

        public Task<List<NirvanaTask>> GetTasksFromServer()
        {
            return Task.FromResult(_tasks);
        }
    }
}
