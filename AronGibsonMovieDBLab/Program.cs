using System;
using System.Collections.Generic;
using System.Linq;
namespace AronGibsonMovieDBLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Populate();
            int choice;
            do {
                Console.WriteLine("1. Display all movies");
                Console.WriteLine("2. Search for movies by Title");
                Console.WriteLine("3. Search for movies by genre");
                Console.WriteLine("4. Quit");
                Console.WriteLine("Enter a number:");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                    DisplayAllDB();
                else if (choice == 2)
                    SearchByTitle();
                else if (choice == 3)
                    SearchByGenre();
            } while (choice!=4);
        }


        public static void Populate() {
            List<Movie> movieList = new List<Movie>
            {
                new Movie("The ShawShank Redemption","Drama",2+(22/60)),
                new Movie("The GodFather","Drama",2+(55/60)),
                new Movie("The Matrix","Sci-Fi",2+(16/60)),
                new Movie("The Pianist","Drama",2.5),
                new Movie("Terminator","Sci-Fi ",1+(47/60)),
                new Movie("Back to the Future","Comedy",1+(56/60)),
                new Movie("Pyscho","horror",1+(49/60)),
                new Movie("Hamilton","History",2+(40/60)),
                new Movie("Joker","Drama",2+(55/60)),
                new Movie("Avengers: Endgame","Action",2+(55/60)),
                new Movie("The Dark Knight Rises","Action",2+(32/60)),
                new Movie("Raiders of the Lost Ark","Action",2+(55/60)),
            };


            using (MovieDBContext context = new MovieDBContext())
            {
                foreach (Movie m in movieList)
                    context.Movies.Add(m);
                context.SaveChanges();
            }
        }

        public static void SearchByGenre(){
            MovieDBContext context = new MovieDBContext();
            Console.WriteLine("Enter genre:");
            string input = Console.ReadLine().ToLower().Trim();
            foreach (Movie m in context.Movies)
                if (m.Genre.ToLower() == input) 
                    Console.WriteLine($"Title: {m.Title} Genre: {m.Genre} Runtime: {m.Runtime}");
        }

        public static void SearchByTitle() {
            MovieDBContext context = new MovieDBContext();
            Console.WriteLine("Enter Title:");
            string input = Console.ReadLine().ToLower().Trim();
            string[] inputWordList = input.Split();
      
            foreach (Movie m in context.Movies)
            {
                string[] wordList = m.Title.Split();
                foreach (string s in wordList)
                    s.ToLower();
                foreach (string s in wordList)
                    if (inputWordList.Contains(s)) 
                        Console.WriteLine($"Title: {m.Title} Genre: {m.Genre} Runtime: {m.Runtime}");   
            }
        }

        public static void DisplayAllDB()
        {
            MovieDBContext context = new MovieDBContext();
            foreach (Movie m in context.Movies)
                Console.WriteLine($"Title: {m.Title} Genre: {m.Genre} Runtime: {m.Runtime}");
        }


    }
}
