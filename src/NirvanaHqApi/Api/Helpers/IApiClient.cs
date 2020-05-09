using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NirvanaHqApi.Api.Helpers
{
    internal interface IApiClient
    {
        Task<string> Get(Uri uri);

        Task<HttpResponseMessage> Post(Uri url, StringContent postMessage);
    }
}
