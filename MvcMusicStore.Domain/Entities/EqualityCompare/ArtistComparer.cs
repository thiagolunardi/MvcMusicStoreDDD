using System.Collections.Generic;

namespace MvcMusicStore.Domain.Entities.EqualityCompare
{
    public class ArtistComparer : IEqualityComparer<Artist>
    {
        // Objects are equal if their unique data are equal.
        public bool Equals(Artist x, Artist y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            //Check whether the objects' properties are equal.
            return x.Name == y.Name;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(Artist artist)
        {
            //Check whether the object is null
            if (ReferenceEquals(artist, null)) return 0;

            //Get hash code for the field.
            var hashArtistName = artist.Name.GetHashCode();

            //Calculate the hash code for the object.
            return hashArtistName;
        }
    }
}
