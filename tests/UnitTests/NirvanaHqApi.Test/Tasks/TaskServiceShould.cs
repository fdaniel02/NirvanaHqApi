using System.Collections.Generic;
using FluentAssertions;
using NirvanaHqApi.Enums;
using NirvanaHqApi.Models;
using Xunit;

namespace NirvanaHqApi.Test.Tasks
{
    public class TaskServiceShould
    {
        private List<NirvanaTask> _testData;

        public TaskServiceShould()
        {
            _testData = new List<NirvanaTask> {
                new NirvanaTask { Type = TaskType.Project, State = TaskState.Active},
                new NirvanaTask { Type = TaskType.TodoItem, State = TaskState.Active },
                new NirvanaTask { Type = TaskType.Project, State = TaskState.Next },
            };
        }

        [Fact]
        public async void ReturnAllTask()
        {
            var expected = _testData;
            var sut = new TaskService(new FakeTaskApi(_testData));

            var actual = await sut.GetTasks();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
