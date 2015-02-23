using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using DapperExtensions;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Repository.ReadOnly;

namespace MvcMusicStore.Data.Repository.Dapper
{
    public class OrderDapperRepository : Common.Repository , IOrderReadOnlyRepository
    {
        public Order Get(int id)
        {
            using (var cn = MusicStoreConnection)
            {
                var order = cn.Query<Order>
                    ("SELECT * " +
                     "  FROM Order O" +
                     " WHERE C.OrderId = @OrderId",
                        new {CartId = id})
                    .FirstOrDefault();
                return order;
            }
        }

        public IEnumerable<Order> All()
        {
            using (var cn = MusicStoreConnection)
            {
                var orders = cn.Query<Order>("SELECT * FROM Order C").ToList();
                return orders;
            }
        }

        public IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            using (var cn = MusicStoreConnection)
            {
                var orders = cn.GetList<Order>(predicate);
                return orders;
            }
        }
    }
}
