using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using NirvanaHqApi.Api.Constants;
using NirvanaHqApi.Api.DTOs;
using NirvanaHqApi.Api.Mappers;
using NirvanaHqApi.Models;

namespace NirvanaHqApi.Api
{
    internal class TaskApiService : ITaskApiService
    {
        private readonly IApiService _apiService;

        public TaskApiService(IConnection connection) : this(new ApiService(connection))
        {
        }

        public TaskApiService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<NirvanaTask>> GetTasksFromServer()
        {
            var data = await _apiService.GetDataFromServer(ApiParameters.TaskMethod).ConfigureAwait(false);

            var taskDtos = data.Select(e => e.Task);

            var tasks = TaskDtoMapper.Mapper.MapDtoToTask(taskDtos);
            return tasks;
        }

        public async Task<bool> CreateTask(NirvanaTask task)
        {
            Guard.Against.Null(task, nameof(task));

            var tasks = new List<NirvanaTask> { task };

            var result = await CreateTasks(tasks).ConfigureAwait(false);
            return result;
        }

        public async Task<bool> CreateTasks(List<NirvanaTask> tasks)
        {
            Guard.Against.Null(tasks, nameof(tasks));

            var data = CreateTaskDtos(tasks);
            var result = await _apiService.CreateTask(data).ConfigureAwait(false);

            return result;
        }

        private List<TaskDto> CreateTaskDtos(List<NirvanaTask> tasks)
        {
            var dtos = TaskDtoMapper.Mapper.MapTaskToDto(tasks);
            foreach (var dto in dtos)
            {
                dto.Method = "task.save";
                if (string.IsNullOrEmpty(dto.Id))
                {
                    dto.Id = Guid.NewGuid().ToString().ToUpper(CultureInfo.InvariantCulture);
                }
            }

            return dtos;
        }
    }
}
