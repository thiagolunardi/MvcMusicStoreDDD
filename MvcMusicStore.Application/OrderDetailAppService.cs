using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MvcMusicStore.Application.Interfaces;
using MvcMusicStore.Data.Context;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Service;
using MvcMusicStore.Domain.Services.Helpers;
using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Application
{
    public class OrderDetailAppService : AppService<MusicStoreContext>, IOrderDetailAppService
    {
        private readonly IOrderDetailService _service;

        public OrderDetailAppService(IOrderDetailService orderDetailService)
        {
            _service = orderDetailService;
        }

        public ValidationResult Create(OrderDetail orderDetail)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(orderDetail));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(OrderDetail orderDetail)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(orderDetail));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(OrderDetail orderDetail)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(orderDetail));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public OrderDetail Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<OrderDetail> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<OrderDetail> Find(Expression<Func<OrderDetail, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}