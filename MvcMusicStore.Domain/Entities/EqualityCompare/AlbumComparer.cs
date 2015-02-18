using System.Collections.Generic;

namespace MvcMusicStore.Domain.Entities.EqualityCompare
{
    public class AlbumComparer : IEqualityComparer<Album>
    {
        // Objects are equal if their unique data are equal.
        public bool Equals(Album x, Album y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            //Check whether the objects' properties are equal.
            return x.Title == y.Title && x.Artist == y.Artist;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(Album album)
        {
            //Check whether the object is null
            if (ReferenceEquals(album, null)) return 0;

            //Get hash code for the field if it is not null.
            var hashAlbumArtist = album.Artist == null ? 0 : album.Artist.Name.GetHashCode();

            //Get hash code for the field.
            var hashAlbumTitle = album.Title.GetHashCode();

            //Calculate the hash code for the object.
            return hashAlbumTitle ^ hashAlbumArtist;
        }
    }
}
