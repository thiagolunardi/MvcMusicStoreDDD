using AutoMapper;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.ViewModels;

namespace MvcMusicStore.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Genre, GenreMenuViewModel>();
        }
    }
}