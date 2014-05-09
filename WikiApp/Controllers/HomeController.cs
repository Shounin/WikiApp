using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            
            //Bætt við aukalega!!!!
            ViewBag.Message = "Tyding.is";
            //ArrayList<SubtitleFile> subtitle = new ArrayList<SubtitleFile>();

            //Array<IEnumerable<SubtitleFile>> subtitle = new Array<IEnumerable<SubtitleFile>>();
                
            IEnumerable<SubtitleFile> subtitle = (from item in repo.GetAllSubtitles()
                                                                   orderby item.ID descending
                                                                   select item).Take(10);
           /* subtitle.AddLast((from item in repo.GetAllSubtitles()
                              orderby item.upvote descending
                              select item).Take(10));

            */
			return View(subtitle);
        }
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var movies = from m in repo.GetAllSubtitles()
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.name.Contains(searchString));
            }

            return View(movies);
        }

		public ActionResult AllSubtitles() 
		{ 
			ViewBag.Message = "Listi yfir alla skjátexta.";

			return View();
		}

        // Add a new SubtitleFile to the database //
		public ActionResult AddSubtitle()
		{
			//ViewBag.Message = "Your website to add subtitles.";

			return View(new SubtitleFile());
		}
        
        // Add new SubtitleFile to 
//        [HttpPost]
 //       public ActionResult AddSubtitle(FormCollection form)
  //      {

            
            //repo.Save();
			//ViewBag.Message = "Your website to add subtitles.";

	//		return RedirectToAction("Index");
	//	}
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

        [HttpPost]
        public ActionResult AddSubtitle(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 3; //3 MB
                    string[] AllowedFileExtensions = new string[] { ".srt" };

                    if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }

                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        //TO:DO
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Assets/Upload"), fileName);
                        file.SaveAs(path);
                        ModelState.Clear();
                        SubtitleFile item = new SubtitleFile();
                        UpdateModel(item);
                        repo.AddSubtitle(item);
                        ViewBag.Message = "File uploaded successfully";
                    }
                }
            }
            return View();
        }
	}
}