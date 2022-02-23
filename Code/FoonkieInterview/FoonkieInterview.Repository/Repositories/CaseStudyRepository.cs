using FoonkieInterview.Repository.Contracts.Repositories;
using FoonkieInterview.Repository.Models.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoonkieInterview.Repository.Repositories
{
    public class CaseStudyRepository : ICaseStudyRepository
    {
        public Task<List<CaseStudy>> GetCaseStudiesAsync()
        {
            return Task.FromResult(DummyCaseStudies());
        }

        private List<CaseStudy> DummyCaseStudies()
        {
            return new List<CaseStudy>
            {
                #region Pfizer

                new CaseStudy
                {
                    Id = 1,
                    Title = "Digital Platform for Pfizer",
                    Description = "Give the Hability to the content administrator to create, edit, and delete the desired commercial content in a technological solution, and allow the users to download and work online or offline with the content, were the two main challenges we had.",
                    LaboratoryId = 1
                },
                new CaseStudy
                {
                    Id = 2,
                    Title = "Digital Platform for Pfizer #2",
                    Description = "Give the Hability to the content administrator to create, edit, and delete the desired commercial content in a technological solution, and allow the users to download and work online or offline with the content, were the two main challenges we had.",
                    LaboratoryId = 1
                },
                new CaseStudy
                {
                    Id = 3,
                    Title = "Digital Platform for Pfizer #3",
                    Description = "Give the Hability to the content administrator to create, edit, and delete the desired commercial content in a technological solution, and allow the users to download and work online or offline with the content, were the two main challenges we had.",
                    LaboratoryId = 1
                },

                #endregion

                #region Takeda

                new CaseStudy
                {
                    Id = 4,
                    Title = "Digital Platform for Takeda",
                    Description = "Give the Hability to the content administrator to create, edit, and delete the desired commercial content in a technological solution, and allow the users to download and work online or offline with the content, were the two main challenges we had.",
                    LaboratoryId = 2
                },
                new CaseStudy
                {
                    Id = 5,
                    Title = "Digital Platform for Takeda #2",
                    Description = "Give the Hability to the content administrator to create, edit, and delete the desired commercial content in a technological solution, and allow the users to download and work online or offline with the content, were the two main challenges we had.",
                    LaboratoryId = 2
                },
                new CaseStudy
                {
                    Id = 6,
                    Title = "Digital Platform for Takeda #3",
                    Description = "Give the Hability to the content administrator to create, edit, and delete the desired commercial content in a technological solution, and allow the users to download and work online or offline with the content, were the two main challenges we had.",
                    LaboratoryId = 2
                },

                #endregion

                #region Boston Scientific Group

                new CaseStudy
                {
                    Id = 7,
                    Title = "Digital Platform for Boston Scientific Group",
                    Description = "Give the Hability to the content administrator to create, edit, and delete the desired commercial content in a technological solution, and allow the users to download and work online or offline with the content, were the two main challenges we had.",
                    LaboratoryId = 3
                },

                #endregion

                #region BSJI

                new CaseStudy
                {
                    Id = 8,
                    Title = "Digital Platform for BSJI",
                    Description = "Give the Hability to the content administrator to create, edit, and delete the desired commercial content in a technological solution, and allow the users to download and work online or offline with the content, were the two main challenges we had.",
                    LaboratoryId = 4
                },
                new CaseStudy
                {
                    Id = 9,
                    Title = "Digital Platform for BSJI # 2",
                    Description = "Give the Hability to the content administrator to create, edit, and delete the desired commercial content in a technological solution, and allow the users to download and work online or offline with the content, were the two main challenges we had.",
                    LaboratoryId = 4
                }

                #endregion
            };
        }
    }
}
