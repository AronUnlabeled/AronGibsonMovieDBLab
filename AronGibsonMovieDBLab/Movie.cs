using System;
using System.Collections.Generic;

#nullable disable

namespace AronGibsonMovieDBLab
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Runtime { get; set; }

        public Movie(string Title, string Genre, double Runtime) {
            this.Title = Title;
            this.Genre =  Genre;
            this.Runtime = Runtime;
        }


    }
}
