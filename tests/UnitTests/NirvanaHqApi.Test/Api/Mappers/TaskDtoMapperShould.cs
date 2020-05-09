using System.Collections.Generic;
using FluentAssertions;
using NirvanaHqApi.Api.DTOs;
using NirvanaHqApi.Api.Mappers;
using NirvanaHqApi.Enums;
using NirvanaHqApi.Models;
using Xunit;

namespace NirvanaHqApi.Test.Api.Mappers
{
    public class TaskDtoMapperShould
    {
        private List<TaskDto> GetTestDtoData()
        {
            return new List<TaskDto>
                {
                    new TaskDto
                    {
                        Id = "id1",
                        Name = "name1",
                        Type = 1,
                        State = 11,
                        Tags = ",work,",
                    },
                    new TaskDto
                    {
                        Id = "id2",
                        Name = "name2",
                        Type = 0,
                        State = 0,
                        Tags = ",",
                    },
                    new TaskDto
                    {
                        Id = "id3",
                        Name = "name3",
                        Type = 1,
                        State = 1,
                        Tags = ",work,etc,",
                    },
                };
        }

        private List<NirvanaTask> GetTestTaskData()
        {
            return new List<NirvanaTask>
            {
                new NirvanaTask
                {
                    Id = "id1",
                    Name = "name1",
                    Type = TaskType.Project,
                    State = TaskState.Active,
                    Tags = new List<string> { "work" },
                },
                new NirvanaTask
                {
                    Id = "id2",
                    Name = "name2",
                    Type = TaskType.TodoItem,
                    State = TaskState.Inbox,
                    Tags = new List<string>(),
                },
                new NirvanaTask
                {
                    Id = "id3",
                    Name = "name3",
                    Type = TaskType.Project,
                    State = TaskState.Next,
                    Tags = new List<string> { "work", "etc" },
                },
            };
        }

        [Fact]
        public void MapEmptyDtoToTask()
        {
            var testData = new List<TaskDto>();
            var expected = new List<NirvanaTask>();

            var sut = TaskDtoMapper.Mapper;

            var actual = sut.MapDtoToTask(testData);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void MapDtoToTask()
        {
            var testData = GetTestDtoData();
            var expected = GetTestTaskData();

            var sut = TaskDtoMapper.Mapper;

            var actual = sut.MapDtoToTask(testData);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void MapEmptyTaskToDto()
        {
            var testData = new List<NirvanaTask>();
            var expected = new List<TaskDto>();

            var sut = TaskDtoMapper.Mapper;

            var actual = sut.MapTaskToDto(testData);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void MapTaskToDto()
        {
            var testData = GetTestTaskData();
            var expected = GetTestDtoData();

            var sut = TaskDtoMapper.Mapper;

            var actual = sut.MapTaskToDto(testData);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
