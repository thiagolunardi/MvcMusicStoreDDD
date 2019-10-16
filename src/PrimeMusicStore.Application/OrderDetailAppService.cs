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
    public class OrderDetailAppService : AppService, IOrderDetailAppService
    {
        private readonly IOrderDetailService _service;

        public OrderDetailAppService(IOrderDetailService orderDetailService, IUnitOfWork uow)
            : base(uow)
        {
            _service = orderDetailService;
        }

        public ValidationResult Create(OrderDetail orderDetail)
        {
            BeginTransaction();
            ValidationResult = _service.Add(orderDetail);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(OrderDetail orderDetail)
        {
            BeginTransaction();
            ValidationResult = _service.Update(orderDetail);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(OrderDetail orderDetail)
        {
            BeginTransaction();
            ValidationResult = _service.Delete(orderDetail);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValueTask<OrderDetail> GetAsync(int id)
        {
            return _service.GetAsync(id);
        }

        public IAsyncEnumerable<OrderDetail> AllAsync()
        {
            return _service.AllAsync();
        }

        public IAsyncEnumerable<OrderDetail> FindAsync(Expression<Func<OrderDetail, bool>> predicate)
        {
            return _service.FindAsync(predicate);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}