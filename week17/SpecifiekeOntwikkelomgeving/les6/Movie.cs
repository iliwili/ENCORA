using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les6
{
    class Movie : Video
    {
        public string Director;
        public int ReleaseYear;
        public string Genre;
        public int Rating;

        public Movie(string title, int length, string director, int releaseYear, string genre, int rating) : base(title, length)
        {
            Director = director;
            ReleaseYear = releaseYear;
            Genre = genre;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"\"{Title}\" by {Director} - {Length}min - {ReleaseYear}";
        }
    }
}
