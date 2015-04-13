using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieBase.Presentation.AspNetMvc.Utils
{
	public class UnityControllerActivator : IControllerActivator
	{
		public IController Create(RequestContext requestContext, Type controllerType)
		{
			return DependencyResolver.Current.GetService(controllerType) as IController;
		}
	}
}