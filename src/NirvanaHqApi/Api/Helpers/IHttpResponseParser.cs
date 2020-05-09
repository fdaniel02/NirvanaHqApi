namespace NirvanaHqApi.Api.Helpers
{
    internal interface IHttpResponseParser
    {
        public string GetResult(string response);
    }
}
