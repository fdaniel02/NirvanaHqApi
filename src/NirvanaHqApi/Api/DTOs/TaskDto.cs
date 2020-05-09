using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace NirvanaHqApi.Api.DTOs
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:Element should begin with upper-case letter", Justification = "DTO")]
    internal class TaskDto
    {
        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("state")]
        public int State { get; set; }

        [JsonPropertyName("completed")]
        public int Completed { get; set; }

        [JsonPropertyName("cancelled")]
        public int Cancelled { get; set; }

        [JsonPropertyName("tags")]
        public string Tags { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }

        [JsonPropertyName("ps")]
        public string Ps { get; set; }

        [JsonPropertyName("energy")]
        public string Energy { get; set; }

        [JsonPropertyName("startdate")]
        public string Startdate { get; set; }

        [JsonPropertyName("duedate")]
        public string Duedate { get; set; }

        [JsonPropertyName("recurring")]
        public string Recurring { get; set; }

        [JsonPropertyName("updated")]
        public string Updated { get; set; }

        [JsonPropertyName("_type")]
        public string _type { get; set; }
            = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);

        [JsonPropertyName("_state")]
        public string _state { get; set; }
            = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);

        [JsonPropertyName("_completed")]
        public string _completed { get; set; }
            = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);

        [JsonPropertyName("_cancelled")]
        public string _cancelled { get; set; }
            = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);

        [JsonPropertyName("_name")]
        public string _name { get; set; }
            = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);

        [JsonPropertyName("_tags")]
        public string _tags { get; set; }
            = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);

        [JsonPropertyName("_note")]
        public string _note { get; set; }
            = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);

        [JsonPropertyName("_ps")]
        public string _ps { get; set; }
            = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);

        [JsonPropertyName("_energy")]
        public string _energy { get; set; }
            = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);

        [JsonPropertyName("_startdate")]
        public string _startdate { get; set; }
            = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);

        [JsonPropertyName("_duedate")]
        public string _duedate { get; set; }
            = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);

        [JsonPropertyName("_recurring")]
        public string _recurring { get; set; }
            = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);
    }
}
