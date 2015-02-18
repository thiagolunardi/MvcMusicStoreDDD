using AutoMapper;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.ViewModels
{
    public class GenreMenuViewModel
    {
        public string Name { get; set; }

        public static GenreMenuViewModel ToViewModel(Genre genre)
        {
            return Mapper.Map<GenreMenuViewModel>(genre);
        }
    }
}