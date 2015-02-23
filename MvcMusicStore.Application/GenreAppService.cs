using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MvcMusicStore.Application.Interfaces;
using MvcMusicStore.Data.Context;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Service;
using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Application
{
    public class GenreAppService : AppService<MusicStoreContext>, IGenreAppService
    {
        private readonly IGenreService _service;

        public GenreAppService(IGenreService genreService)
        {
            _service = genreService;
        }

        public ValidationResult Create(Genre genre)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(genre));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Genre genre)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(genre));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Genre genre)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(genre));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Genre Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public Genre GetWithAlbums(string genreName)
        {
            return _service.GetWithAlbums(genreName);
        }

        public IEnumerable<Genre> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Genre> Find(Expression<Func<Genre, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}