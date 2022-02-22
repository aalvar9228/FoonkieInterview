using FoonkieInterview.Repository.Models.Services.Api.Responses;
using Refit;
using System.Threading.Tasks;

namespace FoonkieInterview.Repository.Contracts.Services
{
    public interface IApiService
    {
        [Get("/users?page={page}")]
        Task<UserListResponse> GetUserListAsync(int page);
    }
}
