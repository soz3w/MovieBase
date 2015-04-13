using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MovieBase.BLL.Interfaces;
using Moviebase.Entities;

namespace MovieBase.Presentation.AspNetMvc.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IBusinessLogic _businessLogicLayer;

        public MoviesController(IBusinessLogic businessLogicLayer)
        {
            _businessLogicLayer = businessLogicLayer;
        }

        //
        // GET: /Movies/

        public ActionResult Index()
        {
            return View(_businessLogicLayer.GetMovies());
        }

        [HttpPost]
        public ActionResult Filter(string filterByYear, string filterByCountry)
        {
            if (!String.IsNullOrWhiteSpace(filterByCountry))
            {
                if (!String.IsNullOrWhiteSpace(filterByYear))
                {
                    return RedirectToAction("ByYearAndCountry", new { year = ushort.Parse(filterByYear), country = filterByCountry });
                }
                else
                {
                    return RedirectToAction("ByCountry", new { country = filterByCountry });
                }
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(filterByYear))
                {
                    return RedirectToAction("ByYear", new { year = ushort.Parse(filterByYear) });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult ByYear(ushort year)
        {
            return View(_businessLogicLayer.GetMoviesByYear(year));
        }

        public ActionResult ByCountry(string country)
        {
            return View(_businessLogicLayer.GetMoviesByCountry(country));
        }

        public ActionResult ByYearAndCountry(ushort year, string country)
        {
            return View(_businessLogicLayer.GetMoviesByYearAndCountry(year, country));
        }

    }
}
