using FoonkieInterview.Repository.Models.Services.Api.Responses;
using FoonkieInterview.Repository.Models.Shared;
using System.Threading.Tasks;

namespace FoonkieInterview.Repository.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<RestResponse<UserListResponse>> GetUserListAsync(int page);
    }
}
