using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les5
{
    class Movie
    {
        public string Naam;
        public int Release;
        public string Genre;
        public string Regisseur;
        public int Speelduur;

        public Movie(string naam, int release, string genre, string regisseur, int speelduur)
        {
            Naam = naam;
            Release = release;
            Genre = genre;
            Regisseur = regisseur;
            Speelduur = speelduur;
        }

        public override string ToString()
        {
            return $"Title: {Naam} - Released: {Release} - Genre: {Genre} - Director: {Regisseur} - Duration: {Speelduur}";
        }
    }
}
