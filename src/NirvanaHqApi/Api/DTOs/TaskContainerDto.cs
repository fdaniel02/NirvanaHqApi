using System.Text.Json.Serialization;

namespace NirvanaHqApi.Api.DTOs
{
    internal class TaskContainerDto
    {
        [JsonPropertyName("task")]
        public TaskDto Task { get; set; }
    }
}
