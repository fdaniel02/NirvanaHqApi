using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NirvanaHqApi.Api;
using NirvanaHqApi.Api.DTOs;
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

            var sut = new TaskApiService(new ApiServiceFake());

            var actual = await sut.GetTasksFromServer();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void CreateTasks()
        {
            var sut = new TaskApiService(new ApiServiceFake());

            var actual = await sut.CreateTasks(new List<NirvanaTask>());

            actual.Should().BeTrue();
        }

        [Fact]
        public void NotAllowNullInCreateTasks()
        {
            var sut = new TaskApiService(new ApiServiceFake());

            FluentActions.Invoking(() => sut.CreateTasks(null)).Should().Throw<ArgumentNullException>();
        }
    }

    internal class ApiServiceFake : IApiService
    {
        public Task<bool> CreateTask(List<TaskDto> tasks)
        {
            return Task.FromResult(true);
        }

        public Task<List<TaskContainerDto>> GetDataFromServer(string type)
        {
            var testData = new List<TaskContainerDto> {
                new TaskContainerDto
                {
                    Task = new TaskDto
                    {
                        Type = 1,
                        State = 11
                    }
                },
                new TaskContainerDto
                {
                    Task = new TaskDto
                    {
                        Type = 0,
                        State = 11
                    }
                },
                new TaskContainerDto
                {
                    Task = new TaskDto
                    {
                        Type = 1,
                        State = 1
                    }
                },
            };
            return Task.FromResult(testData);
        }
    }
}
