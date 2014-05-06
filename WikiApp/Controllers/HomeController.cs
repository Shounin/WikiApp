using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WikiApp.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index() //Marteinn ég nenni þessu ekki
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
            // prufa.
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}