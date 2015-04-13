using Moviebase.Entities;
using MovieBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieBase.DAL
{
    public class DataAccess : IDataAccess
    {
        public string StoreFile { private get; set; }

        public DataAccess()
        {
        }

        public void Initialize()
        {
            System.Diagnostics.Trace.Write("Hello from Initialize");
        }

        #region Implementation of IDataAccess

        public List<Movie> GetMovies()
        {
            var xdoc = XDocument.Load(StoreFile);
            var movies = xdoc.Root.Elements("movie");
            return movies.Select(m => new Movie
            {
                Id = Int32.Parse(m.Attribute("id").Value),
                Title = m.Attribute("title").Value,
                Country = m.Attribute("country").Value,
                Year = UInt16.Parse(m.Attribute("year").Value)
            }).ToList();
        }

        public List<Movie> GetMoviesByCountry(string country)
        {
            return GetMovies().Where(m => m.Country == country).ToList();
        }

        public List<Movie> GetMoviesByYear(ushort year)
        {
            return GetMovies().Where(m => m.Year == year).ToList();
        }

        public List<Movie> GetMoviesByYearAndCountry(ushort year, string country)
        {
            return GetMovies().Where(m => m.Country == country && m.Year == year).ToList();
        }

        public Movie GetMovie(int movieId)
        {
            return GetMovies().Single(m => m.Id == movieId);
        }

        public void InsertMovie(Movie movie)
        {
            var xdoc = XDocument.Load(StoreFile);
            var i = Int32.Parse(xdoc.Root.Attribute("autoincrement").Value);
            i++;

            movie.Id = i;

            xdoc.Root.Add(new XElement("movie", new XAttribute("id", movie.Id), new XAttribute("title", movie.Title), new XAttribute("country", movie.Country), new XAttribute("year", movie.Year)));
            xdoc.Root.Attribute("autoincrement").Value = i.ToString();

            xdoc.Save(StoreFile);
        }

        #endregion
    }
}
