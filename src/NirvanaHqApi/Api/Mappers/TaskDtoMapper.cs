using System;
using System.Collections.Generic;
using System.Linq;
using NirvanaHqApi.Api.DTOs;
using NirvanaHqApi.Enums;
using NirvanaHqApi.Models;

namespace NirvanaHqApi.Api.Mappers
{
    internal class TaskDtoMapper
    {
        private static Lazy<TaskDtoMapper> _mapper = new Lazy<TaskDtoMapper>(() => new TaskDtoMapper());

        private TaskDtoMapper()
        {
            ExpressMapper.Mapper.Register<TaskDto, NirvanaTask>()
                .Member(dest => dest.Tags, src => MapTags(src.Tags))
                .Member(dest => dest.Type, src => (TaskType)src.Type)
                .Member(dest => dest.State, src => (TaskState)src.State);

            ExpressMapper.Mapper.Register<NirvanaTask, TaskDto>()
                .Member(dest => dest.Tags, src => MapTags(src.Tags))
                .Member(dest => dest.Type, src => src.Type)
                .Member(dest => dest.State, src => src.State);
        }

        public static TaskDtoMapper Mapper => _mapper.Value;

        private string MapTags(List<string> tags)
        {
            string mappedTags = ",";

            foreach (var tag in tags)
            {
                mappedTags = $"{mappedTags}{tag},";
            }

            return mappedTags;
        }

        private List<string> MapTags(string tags)
        {
            if (string.IsNullOrEmpty(tags))
            {
                return new List<string>();
            }

            var splittedTags = tags.Split(',');
            var mappedTags = splittedTags.Where(t => !string.IsNullOrEmpty(t)).ToList();
            return mappedTags;
        }

        public List<NirvanaTask> MapDtoToTask(IEnumerable<TaskDto> taskDtos)
        {
            var tasks = ExpressMapper.Mapper.Map<List<TaskDto>, List<NirvanaTask>>(taskDtos.ToList());

            return tasks;
        }

        public List<TaskDto> MapTaskToDto(IEnumerable<NirvanaTask> tasks)
        {
            var taskDtos = ExpressMapper.Mapper.Map<List<NirvanaTask>, List<TaskDto>>(tasks.ToList());

            return taskDtos;
        }
    }
}
