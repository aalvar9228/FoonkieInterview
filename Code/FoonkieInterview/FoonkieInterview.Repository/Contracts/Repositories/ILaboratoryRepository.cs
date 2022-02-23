using FoonkieInterview.Repository.Models.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoonkieInterview.Repository.Contracts.Repositories
{
    public interface ILaboratoryRepository
    {
        Task<IEnumerable<Laboratory>> GetLaboratoriesAsync();
    }
}
