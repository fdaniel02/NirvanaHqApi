using System;
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

        [Fact]
        public async void CreateNewTask()
        {
            var task = new NirvanaTask { Type = TaskType.TodoItem, State = TaskState.Inbox };
            var expected = new List<NirvanaTask>(_testData); ;
            expected.Add(task);

            var sut = new TaskService(new FakeTaskApi(_testData));

            var actual = await sut.CreateTask(task);
            var tasks = await sut.GetTasks();

            actual.Should().BeTrue();
            tasks.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void NotAllowNullInCreateTask()
        {
            var sut = new TaskService(new FakeTaskApi(_testData));

            FluentActions.Invoking(() => sut.CreateTask(null)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async void CreateNewTasks()
        {
            var tasks = new List<NirvanaTask> {
                new NirvanaTask { Type = TaskType.TodoItem, State = TaskState.Inbox },
                new NirvanaTask { Type = TaskType.Project, State = TaskState.Deleted},
                new NirvanaTask { Type = TaskType.TodoItem, State = TaskState.Logged },
            };
            var expected = new List<NirvanaTask>(_testData);
            expected.AddRange(tasks);

            var sut = new TaskService(new FakeTaskApi(_testData));

            var actual = await sut.CreateTasks(tasks);
            var resultTasks = await sut.GetTasks();

            actual.Should().BeTrue();
            resultTasks.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void NotAllowNullInCreateTasks()
        {
            var sut = new TaskService(new FakeTaskApi(_testData));

            FluentActions.Invoking(() => sut.CreateTasks(null)).Should().Throw<ArgumentNullException>();
        }
    }
}
