using FoonkieInterview.Repository.Contracts.Repositories;
using FoonkieInterview.Repository.Models.Services.Api.Responses;
using FoonkieInterview.Repository.Models.Shared;
using Refit;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace FoonkieInterview.Repository.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public async Task<RestResponse<UserListResponse>> GetUserListAsync(int page)
        {
            var result = new RestResponse<UserListResponse>();

            try
            {
                var response = await ApiService.GetUserListAsync(page);
                result.Data = response;
                result.StatusCode = HttpStatusCode.OK;
            }
            catch (ApiException apiException)
            {
                Debug.WriteLine($"Exception thrown from {nameof(UserRepository)}: {apiException.Message}");
                result.StatusCode = apiException.StatusCode;
            }

            return result;
        }
    }
}
