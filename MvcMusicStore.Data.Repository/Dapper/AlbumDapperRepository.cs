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
    public class AlbumDapperRepository : Common.Repository , IAlbumReadOnlyRepository
    {
        public Album Get(int id)
        {
            using (var cn = MusicStoreConnection)
            {
                var album = cn.Query<Album, Artist, Genre, Album>
                    ("SELECT * " +
                     "  FROM Album Al" +
                     "  JOIN Artist Ar ON Ar.ArtistId = Al.ArtistId" +
                     "  JOIN Genre Ge ON Ge.GenreId = Al.GenreId" +
                     " WHERE Al.AlbumId = @AlbumId",
                        (al, ar, ge) =>
                        {
                            al.Artist = ar;
                            al.Genre = ge;
                            return al;
                        },
                        new {AlbumId = id}, splitOn: "AlbumId, ArtistId, GenreId").FirstOrDefault();
                return album;
            }
        }

        public IEnumerable<Album> All()
        {
            using (var cn = MusicStoreConnection)
            {
                var albuns = cn.Query<Album, Artist, Genre, Album>
                    ("SELECT * " +
                     "  FROM Album Al" +
                     "  JOIN Artist Ar ON Ar.ArtistId = Al.ArtistId" + 
                     "  JOIN Genre Ge ON Ge.GenreId = Al.GenreId",
                        (al, ar, ge) =>
                        {
                            al.Artist = ar;
                            al.Genre = ge;
                            return al;
                        },
                        splitOn: "AlbumId, ArtistId, GenreId");
                return albuns;
            }
        }

        public IEnumerable<Album> Find(Expression<Func<Album, bool>> predicate)
        {
            using (var cn = MusicStoreConnection)
            {
                var albuns = cn.GetList<Album>(predicate);
                return albuns;
            }
        }
    }
}
