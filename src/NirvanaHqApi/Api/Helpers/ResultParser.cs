using System;
using System.Text.Json;

namespace NirvanaHqApi.Api.Helpers
{
    internal class ResultParser : IHttpResponseParser
    {
        public string GetResult(string response)
        {
            try
            {
                using var jsonDoc = JsonDocument.Parse(response);

                var root = jsonDoc.RootElement.GetProperty("results");
                var resultText = root.GetRawText();

                return resultText;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
