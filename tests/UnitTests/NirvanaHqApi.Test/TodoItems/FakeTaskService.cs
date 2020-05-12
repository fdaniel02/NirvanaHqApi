using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NirvanaHqApi.Models;

namespace NirvanaHqApi.Test.TodoItems
{
    internal class FakeTaskService : ITaskService
    {
        private List<NirvanaTask> _tasks;

        public FakeTaskService(List<NirvanaTask> tasks)
        {
            _tasks = new List<NirvanaTask>(tasks);
        }

        public Task<bool> CreateTask(NirvanaTask task)
        {
            _tasks.Add(task);

            return Task.FromResult(true);
        }

        public Task<bool> CreateTasks(List<NirvanaTask> tasks)
        {
            throw new NotImplementedException();
        }

        public Task<List<NirvanaTask>> GetTasks()
        {
            return Task.FromResult(_tasks);
        }
    }
}
