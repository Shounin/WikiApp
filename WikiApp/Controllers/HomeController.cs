using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WikiApp.DAL;
using WikiApp.Models;
using WikiApp.Models.View_Models;

namespace WikiApp.Controllers
{
	public class HomeController : Controller
	{
         SubtitleRepository repo = new SubtitleRepository();
        //SubtitleContext repo2 = new SubtitleContext();
		public ActionResult Index() 
		{
            SubtitlesVM vm = new SubtitlesVM();
            vm.allMovies = (from item in repo.GetAllSubtitles()
                            where item.state == State.Edit && item.category != "Þættir"
                            orderby item.ID descending
                            select item).Take(10);

            vm.allTV = (from item in repo.GetAllSubtitles()
                        where item.state == State.Edit && item.category == "Þættir"
                        orderby item.ID descending
                        select item).Take(10);
            
            return View(vm);
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
            SubtitlesVM vm2 = new SubtitlesVM();
            vm2.allFiles = (from item in repo.GetAllSubtitles()
                            where item.state == State.Edit
                            orderby item.ID descending
                            select item);


            return View(vm2);
		}
        [HttpPost]
        public ActionResult AllSubtitles(char x)
        {
            ViewBag.Message = "Listi yfir alla skjátexta.";
            SubtitlesVM vm2 = new SubtitlesVM();
            vm2.specificFiles = (from item in repo.GetAllSubtitles()
                            where item.name[0] == x
                            orderby item.ID descending
                            select item);


            return View(vm2);
        }


/*
         [HttpPost]
		public ActionResult AllSubtitles(string id) 
		{ 
			ViewBag.Message = "Listi yfir alla skjátexta.";
            SubtitlesVM vm3 = new SubtitlesVM();
            vm3.allFiles = (from item in repo.GetAllSubtitles()
                               where item.name.StartsWith(id)
                               select item);
            vm3.allFiles = (from item in repo.GetAllSubtitles()
                            group item by item.name.Substring(0, 1)
                                into itemgroup
                                select new SubtitlesVM()
                                {
                                    FirstLetter = itemgroup.Key,
                                    allFiles = itemgroup.ToList()

                                }).OrderBy(mapping => mapping.FirstLetter);
                           
            return View(vm3);
		} */
      


        // Add a new SubtitleFile to the database //
		[Authorize]
        [HttpGet]
		public ActionResult AddSubtitle()
		{
            if (User.Identity.Name == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                List<SelectListItem> subtitleCategory = new List<SelectListItem>();
                subtitleCategory.Add(new SelectListItem { Text = "Velja tegund", Value = "" });
                subtitleCategory.Add(new SelectListItem { Text = "Barnaefni", Value = "Barnaefni" });
                subtitleCategory.Add(new SelectListItem { Text = "Drama", Value = "Drama" });
                subtitleCategory.Add(new SelectListItem { Text = "Gamanmyndir", Value = "Gamanmyndir" });
                subtitleCategory.Add(new SelectListItem { Text = "Hryllingsmyndir", Value = "Hryllingsmyndir" });
                subtitleCategory.Add(new SelectListItem { Text = "Rómantík", Value = "Rómantík" });
                subtitleCategory.Add(new SelectListItem { Text = "Spennumyndir", Value = "Spennuþættir" });
                subtitleCategory.Add(new SelectListItem { Text = "Þættir", Value = "Þættir" });
                subtitleCategory.Add(new SelectListItem { Text = "Ævintýramyndir", Value = "Ævintýramyndir" });

                ViewData["Categories"] = subtitleCategory;

                return View(new SubtitleFile());
            }
		}
        
        [HttpGet]
        public ActionResult Requests()
        {
            ViewBag.Message = "Here you can request subtitles.";
            SubtitlesVM vm = new SubtitlesVM();
            vm.allMovies = (from item in repo.GetAllSubtitles()
                            where item.state == State.Request && item.category != "Þættir"
                            orderby item.ID descending
                            select item).Take(10);

            vm.allTV = (from item in repo.GetAllSubtitles()
                        where item.state == State.Request && item.category != "Þættir"
                        orderby item.ID descending
                        select item).Take(10);

            return View(vm);
           // return View();
           // return View(new SubtitleFile());
        }
        public ActionResult View3()
        {
            ViewBag.Message = "Here you can request subtitles.";

            SubtitlesVM vm = new SubtitlesVM();
            vm.allMovies = (from item in repo.GetAllSubtitles()
                            orderby item.ID descending
                            select item).Take(10);

            return View(vm); 

        }

        public ActionResult About()
        {

            ViewBag.Message = "About the site";

            return View();
        }

		[Authorize]
        [HttpPost]
        public ActionResult AddSubtitle(HttpPostedFileBase file)
        {
            List<SelectListItem> subtitleCategory = new List<SelectListItem>();
            subtitleCategory.Add(new SelectListItem { Text = "Velja tegund", Value = "" });
            subtitleCategory.Add(new SelectListItem { Text = "Barnaefni", Value = "Barnaefni" });
            subtitleCategory.Add(new SelectListItem { Text = "Drama", Value = "Drama" });
            subtitleCategory.Add(new SelectListItem { Text = "Gamanmyndir", Value = "Gamanmyndir" });
            subtitleCategory.Add(new SelectListItem { Text = "Hryllingsmyndir", Value = "Hryllingsmyndir" });
            subtitleCategory.Add(new SelectListItem { Text = "Rómantík", Value = "Rómantík" });
            subtitleCategory.Add(new SelectListItem { Text = "Spennumyndir", Value = "Spennuþættir" });
            subtitleCategory.Add(new SelectListItem { Text = "Þættir", Value = "Þættir" });
            subtitleCategory.Add(new SelectListItem { Text = "Ævintýramyndir", Value = "Ævintýramyndir" });

            ViewData["Categories"] = subtitleCategory;

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
                        
                        //Uri baseUri = new Uri("http://www.github.com");
                        //Uri myUri = new Uri(baseUri, "/Shounin/WikiApp/tree/master/WikiApp/Assets/Upload");
                        //string myUri = ("http://www.github.com/Shounin/WikiApp/tree/master/WikiApp/Assets/Upload");

                        file.SaveAs(path);

                        SubtitleFile item = new SubtitleFile();
                        UpdateModel(item);
                        item.state = State.Edit;
                        repo.AddSubtitle(item);
                        repo.Save();

                        ModelState.Clear();
                        

                        ViewBag.Message = "File uploaded successfully";
                    }
                }
            }
            return View();
            }

		[HttpGet]
		public ActionResult Search()
		{
            return View();
        }

        public ActionResult AddRequest()
        {
            List<SelectListItem> subtitleCategory = new List<SelectListItem>();
            subtitleCategory.Add(new SelectListItem { Text = "Velja tegund", Value = "" });
            subtitleCategory.Add(new SelectListItem { Text = "Barnaefni", Value = "Barnaefni" });
            subtitleCategory.Add(new SelectListItem { Text = "Drama", Value = "Drama" });
            subtitleCategory.Add(new SelectListItem { Text = "Gamanmyndir", Value = "Gamanmyndir" });
            subtitleCategory.Add(new SelectListItem { Text = "Hryllingsmyndir", Value = "Hryllingsmyndir" });
            subtitleCategory.Add(new SelectListItem { Text = "Rómantík", Value = "Rómantík" });
            subtitleCategory.Add(new SelectListItem { Text = "Spennumyndir", Value = "Spennuþættir" });
            subtitleCategory.Add(new SelectListItem { Text = "Þættir", Value = "Þættir" });
            subtitleCategory.Add(new SelectListItem { Text = "Ævintýramyndir", Value = "Ævintýramyndir" });

            ViewData["Categories"] = subtitleCategory;
            return View(new SubtitleFile());
        }

        [HttpPost]
        public ActionResult AddRequest(FormCollection form)
        {
            List<SelectListItem> subtitleCategory = new List<SelectListItem>();
            subtitleCategory.Add(new SelectListItem { Text = "Velja tegund", Value = "" });
            subtitleCategory.Add(new SelectListItem { Text = "Barnaefni", Value = "Barnaefni" });
            subtitleCategory.Add(new SelectListItem { Text = "Drama", Value = "Drama" });
            subtitleCategory.Add(new SelectListItem { Text = "Gamanmyndir", Value = "Gamanmyndir" });
            subtitleCategory.Add(new SelectListItem { Text = "Hryllingsmyndir", Value = "Hryllingsmyndir" });
            subtitleCategory.Add(new SelectListItem { Text = "Rómantík", Value = "Rómantík" });
            subtitleCategory.Add(new SelectListItem { Text = "Spennumyndir", Value = "Spennuþættir" });
            subtitleCategory.Add(new SelectListItem { Text = "Þættir", Value = "Þættir" });
            subtitleCategory.Add(new SelectListItem { Text = "Ævintýramyndir", Value = "Ævintýramyndir" });

            ViewData["Categories"] = subtitleCategory;
            SubtitleFile item = new SubtitleFile();
            UpdateModel(item);
            item.state = State.Request;
            repo.AddSubtitle(item);


            repo.Save();
            return RedirectToAction("Index"); // View();


        }

		[HttpPost]
		public ActionResult Search(string searchString)
		{
			Console.WriteLine(searchString);
			SubtitlesVM sVM = new SubtitlesVM();
			sVM.SearchResultList = (from item in repo.GetAllSubtitles()
									where item.name.Contains(searchString)
									orderby item.name descending
									select item);
			return View(sVM);
		}
	}
}