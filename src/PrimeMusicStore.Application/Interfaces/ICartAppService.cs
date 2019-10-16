using System.Collections.Generic;
using FluentValidation.Results;
using PrimeMusicStore.Application.Interfaces.Common;
using PrimeMusicStore.Domain.Entities;

namespace PrimeMusicStore.Application.Interfaces
{
    public interface ICartAppService : IAppService<Cart>
    {
        ValidationResult Remove(IEnumerable<Cart> carts);
        ValidationResult Update(IEnumerable<Cart> carts);
    }
}
