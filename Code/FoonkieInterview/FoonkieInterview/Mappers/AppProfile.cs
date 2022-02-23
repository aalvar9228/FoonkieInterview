using AutoMapper;
using Entities = FoonkieInterview.Database.Entities;
using Dtos = FoonkieInterview.Models;
using RepositoryModels = FoonkieInterview.Repository.Models;

namespace FoonkieInterview.Mappers
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Entities.UserEntity, Dtos.User>()
                .ReverseMap();

            CreateMap<RepositoryModels.Services.Api.Shared.User, Dtos.User>()
                .ReverseMap();

            CreateMap<RepositoryModels.Services.Api.Shared.User, Entities.UserEntity>()
                .ReverseMap();
        }
    }
}
