using Moviebase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.DAL.Interfaces
{
    public interface IDataAccess
    {
        List<Movie> GetMovies();
        List<Movie> GetMoviesByCountry(String country);
        List<Movie> GetMoviesByYear(ushort year);
        List<Movie> GetMoviesByYearAndCountry(ushort year, String country);
        Movie GetMovie(int movieId);
        void InsertMovie(Movie movie);
    }
}