using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentValidation.Results;
using PrimeMusicStore.Application.Interfaces;
using PrimeMusicStore.Data.Context.Interfaces;
using PrimeMusicStore.Domain.Entities;
using PrimeMusicStore.Domain.Interfaces.Service;

namespace PrimeMusicStore.Application
{
    public class AlbumAppService : AppService, IAlbumAppService
    {
        private readonly IAlbumService _service;

        public AlbumAppService(IUnitOfWork uow, IAlbumService service) 
            : base(uow)
        {
            _service = service;
        }

        public ValidationResult Create(Album orderDetail)
        {
            BeginTransaction();
            ValidationResult = _service.Add(orderDetail);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Album orderDetail)
        {
            BeginTransaction();
            ValidationResult = _service.Update(orderDetail);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Album orderDetail)
        {
            BeginTransaction();
            ValidationResult = _service.Delete(orderDetail);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValueTask<Album> GetAsync(int id)
        {
            return _service.GetAsync(id);
        }

        public IAsyncEnumerable<Album> AllAsync()
        {
            return _service.AllAsync();
        }

        public IAsyncEnumerable<Album> FindAsync(Expression<Func<Album, bool>> predicate)
        {
            return _service.FindAsync(predicate);
        }

        public async IAsyncEnumerable<Album> GetTopSellingAlbumsAsync(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            var allAlbums = new List<Album>();

            await foreach (var album in _service.AllAsync())
                allAlbums.Add(album);

            var albums = allAlbums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();

            foreach (var album in albums)
                yield return album;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}