using FluentAssertions;
using NirvanaHqApi.Api.Helpers;
using Xunit;

namespace NirvanaHqApi.Test.Api.Helpers
{
    public class HttpResponseParserShould
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("{}", "")]
        [InlineData("{\"request\": {}, \"results\": [{\"task\": {}}]}", "[{\"task\": {}}]")]
        public void GetResultFromJson(string inputJson, string expected)
        {
            var sut = new ResultParser();

            var actual = sut.GetResult(inputJson);

            actual.Should().Be(expected);
        }
    }
}
