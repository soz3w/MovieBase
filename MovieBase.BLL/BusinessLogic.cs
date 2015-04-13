using Moviebase.Entities;
using MovieBase.BLL.Interfaces;
using MovieBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.BLL
{
    public class BusinessLogic : IBusinessLogic
    {
        private readonly IDataAccess _dataAccess;

        public BusinessLogic(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        #region Implementation of IBusinessLogic

        public List<Movie> GetMovies()
        {
            return _dataAccess.GetMovies();
        }

        public List<Movie> GetMoviesByCountry(string country)
        {
            if (String.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country is not valid", "country");

            return _dataAccess.GetMoviesByCountry(country);
        }

        public List<Movie> GetMoviesByYear(ushort year)
        {
            if (year <= 1900 || year >= DateTime.Now.Year)
                throw new ArgumentOutOfRangeException("year");

            return _dataAccess.GetMoviesByYear(year);
        }

        public List<Movie> GetMoviesByYearAndCountry(ushort year, string country)
        {
            if (year <= 1900 || year >= DateTime.Now.Year)
                throw new ArgumentOutOfRangeException("year");

            if (String.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country is not valid", "country");

            return _dataAccess.GetMoviesByYearAndCountry(year, country);
        }

        public Movie GetMovie(int movieId)
        {
            return _dataAccess.GetMovie(movieId);
        }

        public void InsertMovie(string title, string country, ushort year)
        {
            if (String.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is not valid", "title");

            if (String.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country is not valid", "country");

            if (year <= 1900 || year > DateTime.Now.Year)
                throw new ArgumentOutOfRangeException("year");

            var movie = new Movie
            {
                Title = title,
                Country = country,
                Year = year,
            };

            _dataAccess.InsertMovie(movie);
        }

        #endregion
    }
}
