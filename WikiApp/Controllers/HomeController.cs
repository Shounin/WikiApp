using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WikiApp.DAL;
using WikiApp.Models;

namespace WikiApp.Controllers
{
	public class HomeController : Controller
	{

        SubtitleRepository repo = new SubtitleRepository();
		public ActionResult Index() 
		{
            /*
            //Bætt við aukalega!!!!
            IEnumerable<SubtitleFile> subtitle = (from item in repo.GetAllSubtitles()
                                                  orderby item.subtitleID descending
                                                  select item).Take(3);
			return View(subtitle);
             */ 
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
        public ActionResult Requests()
        {
            ViewBag.Message = "Here you can request subtitles.";

            return View();
        }
        public ActionResult About()
        {

            ViewBag.Message = "About the site";

            return View();
        }
	}
}