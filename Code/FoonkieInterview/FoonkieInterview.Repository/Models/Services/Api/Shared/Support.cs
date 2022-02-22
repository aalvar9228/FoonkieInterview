using System.Text.Json.Serialization;

namespace FoonkieInterview.Repository.Models.Services.Api.Shared
{
    public class Support
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
