using System.Net;

namespace FoonkieInterview.Repository.Models.Shared
{
    public class RestResponse<TData> where TData : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public TData Data { get; set; }
    }
}
