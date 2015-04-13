using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MovieBase.Presentation.AspNetMvc.Controllers;
using MovieBase.Presentation.AspNetMvc.Utils;

namespace MovieBase.Presentation.AspNetMvc
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Filter",
				"Movies/Filter",
				new { controller = "Movies", action = "Filter", filterByCountry = UrlParameter.Optional, filterByYear = UrlParameter.Optional }
				);

			routes.MapRoute(
				"FilterByCountry",
				"ByCountry/{country}",
				new { controller = "Movies", action = "ByCountry", country = "USA" }
			);

			routes.MapRoute(
				"FilterByYear",
				"ByYear/{year}",
				new { controller = "Movies", action = "ByYear" }
			);

			routes.MapRoute(
				"FilterByYearAndCountry",
				"ByYearAndCountry/{year}/{country}",
				new { controller = "Movies", action = "ByYearAndCountry" }
			);

			routes.MapRoute(
				"Default", // Route name
				"{action}", // URL with parameters
				new { controller = "Movies", action = "Index" } // Parameter defaults
			);

		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);

			var container = new UnityContainer().LoadConfiguration();
			ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

			container.RegisterType<IControllerActivator, UnityControllerActivator>();

			DependencyResolver.SetResolver(type =>
			                               		{
													if (container.IsRegistered(type))
														return container.Resolve(type);
													else
														return null;
			                               		},
											type =>
												{
													if (container.IsRegistered(type))
														return container.ResolveAll(type);
													else
														return new HashSet<object>();
												});
		}
	}
}