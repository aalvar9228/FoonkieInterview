using FoonkieInterview.Repository.Models.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoonkieInterview.Repository.Contracts.Repositories
{
    public interface ICaseStudyRepository
    {
        Task<List<CaseStudy>> GetCaseStudiesAsync();
    }
}
