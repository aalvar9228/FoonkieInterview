using System.Net;

namespace FoonkieInterview.Repository.Models.Shared
{
    public class RestResponse<TData> where TData : class
    {
        public bool Success => StatusCode == HttpStatusCode.OK;
        public HttpStatusCode StatusCode { get; set; }
        public TData Data { get; set; }
    }
}
