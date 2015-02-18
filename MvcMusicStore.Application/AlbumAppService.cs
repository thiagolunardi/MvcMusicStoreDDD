using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MvcMusicStore.Application.Interfaces;
using MvcMusicStore.Data.Context;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Service;
using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Application
{
    public class AlbumAppService : AppService<MusicStoreContext>, IAlbumAppService
    {
        private readonly IAlbumService _service;

        public AlbumAppService(IAlbumService albumService)
        {
            _service = albumService;
        }

        public ValidationResult Create(Album orderDetail)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(orderDetail));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Album orderDetail)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(orderDetail));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Album orderDetail)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(orderDetail));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Album Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Album> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Album> Find(Expression<Func<Album, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<Album> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            return _service.All()
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}