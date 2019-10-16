using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentValidation.Results;
using PrimeMusicStore.Application.Interfaces;
using PrimeMusicStore.Data.Context.Interfaces;
using PrimeMusicStore.Domain.Entities;
using PrimeMusicStore.Domain.Interfaces.Service;
using PrimeMusicStore.Domain.Services.Helpers;

namespace PrimeMusicStore.Application
{
    public class CartAppService : AppService, ICartAppService
    {
        private readonly ICartService _service;

        public CartAppService(ICartService cartService, IUnitOfWork uow)
            : base(uow)
        {
            _service = cartService;
        }

        public ValidationResult Create(Cart cart)
        {
            BeginTransaction();
            ValidationResult = _service.Add(cart);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Cart cart)
        {
            BeginTransaction();
            ValidationResult = _service.Update(cart);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(IEnumerable<Cart> carts)
        {
            BeginTransaction();
            carts.ForEach(cart =>
            {
                if (!ValidationResult.IsValid) return;
                ValidationResult = _service.Update(cart);
            });
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Cart cart)
        {
            BeginTransaction();
            ValidationResult = _service.Delete(cart);
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(IEnumerable<Cart> carts)
        {
            BeginTransaction();
            carts.ForEach(cart =>
            {
                if (!ValidationResult.IsValid) return;
                ValidationResult = _service.Delete(cart);
            });
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValueTask<Cart> GetAsync(int id)
        {
            return _service.GetAsync(id);
        }

        public IAsyncEnumerable<Cart> AllAsync()
        {
            return _service.AllAsync();
        }

        public IAsyncEnumerable<Cart> FindAsync(Expression<Func<Cart, bool>> predicate)
        {
            return _service.FindAsync(predicate);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}