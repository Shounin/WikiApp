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
        //SubtitleContext repo = new SubtitleContext();
		public ActionResult Index() 
		{
            
            //Bætt við aukalega!!!!
            
            IEnumerable<SubtitleFile> subtitle = (from item in repo.GetAllSubtitles()
                                                  orderby item.ID descending
                                                  select item).Take(3);
			return View(subtitle);
            

            /*
            var subtitles = new List<SubtitleFile>
            {
                new SubtitleFile{
                    name = "Armageddon",
                    category = "Action",
                    dateInserted = "03.03.2014"
                },    
                new SubtitleFile{
                    name = "Gravity",
                    category = "Drama",
                    dateInserted = "04.03.2014"
                },         
                new SubtitleFile{
                    name = "Hungergames",
                    category = "Drama",
                    dateInserted = "21.03.2014"
                }
                
            };
            subtitles.ForEach(s => repo.SubtitleFiles.Add(s));
            repo.SaveChanges();
            return View();
             */ 
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