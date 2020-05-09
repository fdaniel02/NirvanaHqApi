using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NirvanaHqApi.Api.Helpers
{
    internal class ApiHttpClient : IApiClient
    {
        public async Task<string> Get(Uri uri)
        {
            using HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(uri).ConfigureAwait(false);

            return response;
        }

        public async Task<HttpResponseMessage> Post(Uri url, StringContent postMessage)
        {
            using HttpClient client = new HttpClient();
            var response = await client.PostAsync(url, postMessage).ConfigureAwait(false);

            return response;
        }
    }
}
