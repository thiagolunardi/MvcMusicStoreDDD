using AutoMapper;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.ViewModels;

namespace MvcMusicStore.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<GenreMenuViewModel, Genre>();
        }
    }
}