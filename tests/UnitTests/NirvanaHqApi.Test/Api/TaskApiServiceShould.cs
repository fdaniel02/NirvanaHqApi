using System;
using System.Collections.Generic;
using FluentAssertions;
using NirvanaHqApi.Api;
using NirvanaHqApi.Enums;
using NirvanaHqApi.Models;
using Xunit;

namespace NirvanaHqApi.Test.Api
{
    public class TaskApiServiceShould
    {
        [Fact]
        public async void ReturnOnlyTasks()
        {
            var expected = new List<NirvanaTask> {
                new NirvanaTask { Type = TaskType.Project, State = TaskState.Active, Tags = new List<string>() },
                new NirvanaTask { Type = TaskType.TodoItem, State = TaskState.Active , Tags = new List<string>() },
                new NirvanaTask { Type = TaskType.Project, State = TaskState.Next, Tags = new List<string>() },
            };

            var sut = new TaskApiService(new FakeApiService());

            var actual = await sut.GetTasksFromServer();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void CreateTasks()
        {
            var sut = new TaskApiService(new FakeApiService());

            var actual = await sut.CreateTasks(new List<NirvanaTask>());

            actual.Should().BeTrue();
        }

        [Fact]
        public void NotAllowNullInCreateTasks()
        {
            var sut = new TaskApiService(new FakeApiService());

            FluentActions.Invoking(() => sut.CreateTasks(null)).Should().Throw<ArgumentNullException>();
        }
    }
}
