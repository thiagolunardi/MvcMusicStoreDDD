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
    public class OrderAppService : AppService, IOrderAppService
    {
        private readonly IOrderService _service;

        public OrderAppService(IOrderService orderService, IUnitOfWork uow)
            : base(uow)
        {
            _service = orderService;
        }

        public ValidationResult Create(Order order)
        {
            BeginTransaction();
            ValidationResult = _service.Add(order);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Order order)
        {
            BeginTransaction();
            ValidationResult = _service.Update(order);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Order order)
        {
            BeginTransaction();
            ValidationResult = _service.Delete(order);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValueTask<Order> GetAsync(int id)
        {
            return _service.GetAsync(id);
        }

        public IAsyncEnumerable<Order> AllAsync()
        {
            return _service.AllAsync();
        }

        public IAsyncEnumerable<Order> FindAsync(Expression<Func<Order, bool>> predicate)
        {
            return _service.FindAsync(predicate);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}