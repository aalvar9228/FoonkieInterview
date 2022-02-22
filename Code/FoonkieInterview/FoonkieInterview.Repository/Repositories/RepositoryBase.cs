using FoonkieInterview.Repository.Contracts.Services;
using Refit;

namespace FoonkieInterview.Repository.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly IApiService ApiService;

        protected RepositoryBase()
        {
            ApiService = RestService.For<IApiService>(ReqresApiUrl);
        }

        private const string ReqresApiUrl = "https://reqres.in/api";
    }
}
