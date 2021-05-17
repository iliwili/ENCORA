using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les6
{
    class MusicVideo : Video
    {
        public string Artist;
        public int Rating;

        public MusicVideo(string title, int length, string artist, int rating) : base(title, length)
        {
            Title = title;
            Length = length;
            Artist = artist;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"Title: {Title} by {Artist} - {Length}s";
        }
    }
}
