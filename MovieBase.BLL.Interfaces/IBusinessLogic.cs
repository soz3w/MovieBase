using Moviebase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.BLL.Interfaces
{
 
    public interface IBusinessLogic
    {
        List<Movie> GetMovies();
        List<Movie> GetMoviesByCountry(String country);
        List<Movie> GetMoviesByYear(ushort year);
        List<Movie> GetMoviesByYearAndCountry(ushort year, String country);
        Movie GetMovie(int movieId);
        void InsertMovie(String title, String country, ushort year);
    }
}
