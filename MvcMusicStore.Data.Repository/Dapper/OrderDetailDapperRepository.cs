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
    public class OrderDetailDapperRepository : Common.Repository , IOrderDetailReadOnlyRepository
    {
        public OrderDetail Get(int id)
        {
            using (var cn = MusicStoreConnection)
            {
                var orderDetail = cn.Query<OrderDetail, Order, Album, OrderDetail>
                    ("SELECT * " +
                     "  FROM OrderDetail OD" +
                     "  JOIN Order O ON O.OrderId = OD.OrderId" +
                     "  JOIN Album A ON A.AlbumId = OD.AlbumId" +
                     " WHERE C.OrderDetailId = @OrderDetailId",
                        (od, o, a) =>
                        {
                            od.Order = o;
                            od.Album = a;
                            return od;
                        },
                        new { OrderDetailId = id }, splitOn: "OrderDetailId,OrderId,AlbumId")
                    .FirstOrDefault();
                return orderDetail;
            }
        }

        public IEnumerable<OrderDetail> All()
        {
            using (var cn = MusicStoreConnection)
            {
                var orderDetails = cn.Query<OrderDetail, Order, Album, OrderDetail>
                    ("SELECT * " +
                     "  FROM OrderDetail OD" +
                     "  JOIN Order O ON O.OrderId = OD.OrderId" +
                     "  JOIN Album A ON A.AlbumId = OD.AlbumId",
                        (od, o, a) =>
                        {
                            od.Order = o;
                            od.Album = a;
                            return od;
                        },
                        splitOn: "OrderDetailId,OrderId,AlbumId")
                    .ToList();
                return orderDetails;
            }
        }

        public IEnumerable<OrderDetail> Find(Expression<Func<OrderDetail, bool>> predicate)
        {
            using (var cn = MusicStoreConnection)
            {
                var orderDetails = cn.GetList<OrderDetail>(predicate);
                return orderDetails;
            }
        }
    }
}
