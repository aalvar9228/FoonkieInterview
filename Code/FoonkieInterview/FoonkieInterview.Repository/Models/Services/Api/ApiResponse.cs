using FoonkieInterview.Repository.Models.Services.Api.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FoonkieInterview.Repository.Models.Services.Api
{
    public class ApiResponse<TData> where TData : class
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("data")]
        public List<TData> Data { get; set; }

        [JsonPropertyName("support")]
        public Support Support { get; set; }
    }
}
