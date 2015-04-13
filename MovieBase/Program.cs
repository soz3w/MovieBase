using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Moviebase.Entities;
using MovieBase.BLL;
using MovieBase.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase
{
    class Program
    {
        private static IUnityContainer _container;
       
        static void Main(string[] args)
        {
            //Unity configuration
            _container = new UnityContainer().LoadConfiguration();
         
            while (true)
            {
                DisplayMenu();
                var choice = Console.ReadLine();
                if (choice == "q")
                    break;
                int nChoice;
                if (!int.TryParse(choice, out nChoice))
                    System.Console.WriteLine("Choix inconnu!");
                else
                    TreatChoice(nChoice);
                Console.ReadLine();
            }
        }

        private static void TreatChoice(int i)
        {
            var businessLayer = _container.Resolve<IBusinessLogic>();
            String country;
            ushort year;
            List<Movie> movies;
            switch (i)
            {
                case 1:
                    movies = businessLayer.GetMovies();
                    foreach (var movie in movies)
                        System.Console.WriteLine("{0}: {1} - {2} - {3}", movie.Id, movie.Title, movie.Year,
                        movie.Country);
                    break;
                case 2:
                    System.Console.WriteLine("Enter year:");
                    year = ushort.Parse(System.Console.ReadLine());
                    movies = businessLayer.GetMoviesByYear(year);
                    foreach (var movie in movies)
                        System.Console.WriteLine("{0}: {1} - {2} - {3}", movie.Id, movie.Title, movie.Year,
                        movie.Country);
                    break;
                case 3:
                    System.Console.WriteLine("Enter country:");
                    country = System.Console.ReadLine();
                    movies = businessLayer.GetMoviesByCountry(country);
                    foreach (var movie in movies)
                        System.Console.WriteLine("{0}: {1} - {2} - {3}", movie.Id, movie.Title, movie.Year,
                        movie.Country);
                    break;
                case 4:
                    System.Console.WriteLine("Enter year:");
                    year = ushort.Parse(System.Console.ReadLine());
                    System.Console.WriteLine("Enter country:");
                    country = System.Console.ReadLine();
                    movies = businessLayer.GetMoviesByYearAndCountry(year, country);
                    foreach (var movie in movies)
                        System.Console.WriteLine("{0}: {1} - {2} - {3}", movie.Id, movie.Title, movie.Year,
                        movie.Country);
                    break;
            }
        }
        private static void DisplayMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("1 to display all");
            System.Console.WriteLine("2 to filter by year");
            System.Console.WriteLine("3 to filter by country");
            System.Console.WriteLine("4 to filter by year & country");
            System.Console.WriteLine("q to quit");
        }
    }

}

