using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentValidation.Results;
using PrimeMusicStore.Application.Interfaces;
using PrimeMusicStore.Data.Context.Interfaces;
using PrimeMusicStore.Domain.Entities;
using PrimeMusicStore.Domain.Interfaces.Service;

namespace PrimeMusicStore.Application
{
    public class ArtistAppService : AppService, IArtistAppService
    {
        private readonly IArtistService _service;

        public ArtistAppService(IArtistService artistService, IUnitOfWork uow)
            : base(uow)
        {
            _service = artistService;
        }

        public ValidationResult Create(Artist artist)
        {
            BeginTransaction();
            ValidationResult = _service.Add(artist);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Artist artist)
        {
            BeginTransaction();
            ValidationResult = _service.Update(artist);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Artist artist)
        {
            BeginTransaction();
            ValidationResult = _service.Delete(artist);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValueTask<Artist> GetAsync(int id)
        {
            return _service.GetAsync(id);
        }

        public IAsyncEnumerable<Artist> AllAsync()
        {
            return _service.AllAsync();
        }

        public IAsyncEnumerable<Artist> FindAsync(Expression<Func<Artist, bool>> predicate)
        {
            return _service.FindAsync(predicate);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}