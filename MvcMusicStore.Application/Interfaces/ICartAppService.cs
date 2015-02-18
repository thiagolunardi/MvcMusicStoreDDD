using System.Collections.Generic;
using MvcMusicStore.Application.Interfaces.Common;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Application.Interfaces
{
    public interface ICartAppService : IAppService<Cart>
    {
        ValidationResult Remove(IEnumerable<Cart> carts);
        ValidationResult Update(IEnumerable<Cart> carts);
    }
}
