using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NirvanaHqApi.Api.Constants;
using NirvanaHqApi.Api.DTOs;
using NirvanaHqApi.Api.Helpers;

namespace NirvanaHqApi
{
    internal class ApiService : IApiService
    {
        private readonly IConnection _connection;
        private readonly IHttpResponseParser _httpResponseParser;
        private readonly IApiClient _apiClient;

        internal ApiService(IConnection connection) : this(connection, new ResultParser(), new ApiHttpClient())
        {
        }

        internal ApiService(IConnection connection, IHttpResponseParser httpResponseParser, IApiClient apiClient)
        {
            _connection = connection;
            _httpResponseParser = httpResponseParser;
            _apiClient = apiClient;
        }

        public async Task<List<TaskContainerDto>> GetDataFromServer(string type)
        {
            var uri = GetUri(ApiParameters.Rest, type);
            var response = await _apiClient.Get(uri).ConfigureAwait(false);
            response = _httpResponseParser.GetResult(response);

            var tasks = Deserialize(response);
            return tasks;
        }

        public async Task<bool> CreateTask(List<TaskDto> tasks)
        {
            var uri = GetUri(ApiParameters.Create);
            var postMessage = GetPostMessage(tasks);
            var response = await _apiClient.Post(uri, postMessage).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        private Uri GetUri(string apiParam, string type = "")
        {
            var uriBuilder = new UriBuilder(ApiParameters.BaseUrl);

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[ApiParameters.AppIdParam] = ApiParameters.AppId;
            query[ApiParameters.AppVersionParam] = ApiParameters.AppVersion;

            query[ApiParameters.ApiParam] = apiParam;
            query[ApiParameters.TokenParam] = _connection.Token;

            if (!string.IsNullOrEmpty(type))
            {
                query[ApiParameters.MethodParam] = type;
            }

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }

        private List<TaskContainerDto> Deserialize(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return new List<TaskContainerDto>();
            }

            var deserialized = JsonConvert.DeserializeObject<List<TaskContainerDto>>(json);

            return deserialized;
        }

        private StringContent GetPostMessage(List<TaskDto> tasks)
        {
            string json =
                JsonConvert.SerializeObject(
                    tasks,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var postMessage = new StringContent(json);

            return postMessage;
        }
    }
}
