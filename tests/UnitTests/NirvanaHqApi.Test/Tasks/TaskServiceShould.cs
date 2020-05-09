using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NirvanaHqApi.Api;
using NirvanaHqApi.Enums;
using NirvanaHqApi.Models;
using Xunit;

namespace NirvanaHqApi.Test.Tasks
{
    public class TaskServiceShould
    {
        private readonly Mock<ITaskApiService> _taskApiServiceMock = new Mock<ITaskApiService>();
        private List<NirvanaTask> _testData;

        public TaskServiceShould()
        {
            _testData = new List<NirvanaTask> {
                new NirvanaTask { Type = TaskType.Project, State = TaskState.Active},
                new NirvanaTask { Type = TaskType.TodoItem, State = TaskState.Active },
                new NirvanaTask { Type = TaskType.Project, State = TaskState.Next },
            };

            SetupMock(_testData);
        }

        private void SetupMock(List<NirvanaTask> testData)
        {
            _taskApiServiceMock.Setup(m => m.GetTasksFromServer()).Returns(Task.FromResult(testData));
        }

        [Fact]
        public async void ReturnAllTask()
        {
            var expected = _testData;
            var sut = new TaskService(_taskApiServiceMock.Object);

            var actual = await sut.GetTasks();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
