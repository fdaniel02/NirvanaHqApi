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

    internal class FakeApiService : IApiService
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
