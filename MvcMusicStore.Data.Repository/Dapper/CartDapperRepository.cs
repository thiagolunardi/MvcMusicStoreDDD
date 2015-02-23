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
    public class CartDapperRepository : Common.Repository , ICartReadOnlyRepository
    {
        public Cart Get(int id)
        {
            using (var cn = MusicStoreConnection)
            {
                var cart = cn.Query<Cart, Album, Cart>
                    ("SELECT * " +
                     "  FROM Cart C" +
                     "  JOIN Album A ON A.AlbumId = C.AlbumId" +
                     " WHERE C.CartId = @CartId",
                        (c, a) =>
                        {
                            c.Album = a;
                            return c;
                        },
                        new { CartId = id }, splitOn: "CartId,AlbumId")
                    .FirstOrDefault();
                return cart;
            }
        }

        public IEnumerable<Cart> All()
        {
            using (var cn = MusicStoreConnection)
            {
                var carts = cn.Query<Cart, Album, Cart>
                    ("SELECT * " +
                     "  FROM Cart C" +
                     "  JOIN Album A ON A.AlbumId = C.AlbumId",
                        (c, a) =>
                        {
                            c.Album = a;
                            return c;
                        },
                        null, splitOn: "CartId,AlbumId")
                    .ToList();
                return carts;
            }
        }

        public IEnumerable<Cart> Find(Expression<Func<Cart, bool>> predicate)
        {
            using (var cn = MusicStoreConnection)
            {
                var carts = cn.GetList<Cart>(predicate);
                return carts;
            }
        }
    }
}
