using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NirvanaHqApi.Enums;
using NirvanaHqApi.Models;
using NirvanaHqApi.Projects;
using Xunit;

namespace NirvanaHqApi.Test
{
    public class ProjectServiceShould
    {
        private readonly Mock<ITaskService> _taskServiceMock = new Mock<ITaskService>();

        public ProjectServiceShould()
        {
            var testData = new List<NirvanaTask> {
                new NirvanaTask { Type = TaskType.Project, State = TaskState.Active},
                new NirvanaTask { Type = TaskType.TodoItem, State = TaskState.Active },
                new NirvanaTask { Type = TaskType.Project, State = TaskState.Next },
            };

            SetupMock(testData);
        }

        private void SetupMock(List<NirvanaTask> testData)
        {
            _taskServiceMock.Setup(m => m.GetTasks()).Returns(Task.FromResult(testData));
        }

        [Fact]
        public async void ReturnProjects()
        {
            List<NirvanaTask> expected = new List<NirvanaTask> {
                new NirvanaTask { Type = TaskType.Project, State = TaskState.Active},
                new NirvanaTask { Type = TaskType.Project, State = TaskState.Next },
            };

            var sut = new ProjectService(_taskServiceMock.Object);

            var actual = await sut.GetProjects();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void ReturnActiveProjects()
        {
            List<NirvanaTask> expected = new List<NirvanaTask> {
                new NirvanaTask { Type = TaskType.Project, State = TaskState.Active},
            };

            var sut = new ProjectService(_taskServiceMock.Object);

            var actual = await sut.GetActiveProjects();

            actual.Should().BeEquivalentTo(expected);
        }

        //[Fact]
        //public async void CreateNewProject()
        //{
        //    var sut = new ProjectService(_taskServiceMock.Object);

        //    var actual = await sut.GetActiveProjects();

        //    actual.Should().BeEquivalentTo(expected);
        //}
    }
}
