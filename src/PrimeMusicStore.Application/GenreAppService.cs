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
    public class GenreAppService : AppService, IGenreAppService
    {
        private readonly IGenreService _service;

        public GenreAppService(IGenreService genreService, IUnitOfWork uow)
            : base(uow)
        {
            _service = genreService;
        }

        public ValidationResult Create(Genre genre)
        {
            BeginTransaction();
            ValidationResult = _service.Add(genre);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Genre genre)
        {
            BeginTransaction();
            ValidationResult = _service.Update(genre);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Genre genre)
        {
            BeginTransaction();
            ValidationResult = _service.Delete(genre);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValueTask<Genre> GetAsync(int id)
        {
            return _service.GetAsync(id);
        }

        public IAsyncEnumerable<Genre> GetWithAlbumsAsync(string genreName)
        {
            return _service.GetWithAlbumsAsync(genreName);
        }

        public IAsyncEnumerable<Genre> AllAsync()
        {
            return _service.AllAsync();
        }

        public IAsyncEnumerable<Genre> FindAsync(Expression<Func<Genre, bool>> predicate)
        {
            return _service.FindAsync(predicate);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}