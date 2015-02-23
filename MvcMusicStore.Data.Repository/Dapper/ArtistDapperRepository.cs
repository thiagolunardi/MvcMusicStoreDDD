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
    public class ArtistDapperRepository : Common.Repository , IArtistReadOnlyRepository
    {
        public Artist Get(int id)
        {
            using (var cn = MusicStoreConnection)
            {
                var artist = cn.Query<Artist>("SELECT * FROM Artist WHERE ArtistId = @ArtistId",
                    new { ArtistiId = id }).FirstOrDefault();
                return artist;
            }
        }

        public IEnumerable<Artist> All()
        {
            using (var cn = MusicStoreConnection)
            {
                var artist = cn.Query<Artist>("SELECT * FROM Artist");
                return artist;
            }
        }

        public IEnumerable<Artist> Find(Expression<Func<Artist, bool>> predicate)
        {
            using (var cn = MusicStoreConnection)
            {
                var artist = cn.GetList<Artist>(predicate);
                return artist;
            }
        }
    }
}
