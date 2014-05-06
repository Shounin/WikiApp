using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WikiApp.Controllers
{
	public class HomeController : Controller
	{
       
		public ActionResult Index() 
		{
			return View();
		} 
		
		public ActionResult AllSubtitles() 
		{ 
			ViewBag.Message = "List of all subtitles.";

			return View();
		}

		public ActionResult AddSubtitle()
		{
          
			ViewBag.Message = "Your website to add subtitles.";

			return View();
		}
		public ActionResult About()
		{

			ViewBag.Message = "About the site";

			return View();
		}
	}
}