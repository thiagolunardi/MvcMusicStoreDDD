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
    public class ArtistAppService : AppService<MusicStoreContext>, IArtistAppService
    {
        private readonly IArtistService _service;

        public ArtistAppService(IArtistService artistService)
        {
            _service = artistService;
        }

        public ValidationResult Create(Artist artist)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(artist));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Artist artist)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(artist));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Artist artist)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(artist));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Artist Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Artist> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Artist> Find(Expression<Func<Artist, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}