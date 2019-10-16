using PrimeMusicStore.Data.Context;
using PrimeMusicStore.Data.Repository.EntityFramework.Common;
using PrimeMusicStore.Domain.Entities;
using PrimeMusicStore.Domain.Interfaces.Repository;

namespace PrimeMusicStore.Data.Repository.EntityFramework
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(PrimeMusicStoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
