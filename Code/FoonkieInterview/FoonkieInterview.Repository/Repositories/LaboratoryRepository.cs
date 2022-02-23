using FoonkieInterview.Repository.Contracts.Repositories;
using FoonkieInterview.Repository.Models.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoonkieInterview.Repository.Repositories
{
    public class LaboratoryRepository : ILaboratoryRepository
    {
        public Task<IEnumerable<Laboratory>> GetLaboratoriesAsync()
        {
            return Task.FromResult(DummyLaboratories());
        }

        private IEnumerable<Laboratory> DummyLaboratories()
        {
            return new List<Laboratory>
            {
                new Laboratory { Id = 1, Name = "Pfizer"},
                new Laboratory { Id = 2, Name = "Takeda"},
                new Laboratory { Id = 3, Name = "Boston Scientific Group"},
                new Laboratory { Id = 4, Name = "BSJI"}
            };
        }
    }
}
