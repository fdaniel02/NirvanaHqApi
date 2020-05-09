using System.Collections.Generic;
using System.Threading.Tasks;
using NirvanaHqApi.Api.DTOs;

namespace NirvanaHqApi
{
    internal interface IApiService
    {
        Task<List<TaskContainerDto>> GetDataFromServer(string type);

        Task<bool> CreateTask(List<TaskDto> tasks);
    }
}
