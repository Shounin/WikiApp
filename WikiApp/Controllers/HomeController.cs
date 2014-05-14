using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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

           // for (int i = 'A'; i < vm2.alphaBetical.Length; i++)
            //{   
              //  vm2.alphaBetical[i] = new List<SubtitleFile>();
               // var xjd = vm2.allFiles.Where(x => x.name.StartsWith(i.ToString()));
                //vm2.alphaBetical[i];

                //vm2.alphaBetical[i];

            //}



            vm2.A= (from item in repo.GetAllSubtitles()
                    where item.name[0] == 'A'
                    orderby item.ID descending
                    select item);

            vm2.B = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'B'
                     orderby item.ID descending
                     select item);

            vm2.C = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'C'
                     orderby item.ID descending
                     select item);
            vm2.D = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'D'
                     orderby item.ID descending
                     select item);
            vm2.E = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'E'
                     orderby item.ID descending
                     select item);
            vm2.F = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'F'
                     orderby item.ID descending
                     select item);
            vm2.G = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'G'
                     orderby item.ID descending
                     select item);
            vm2.H = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'H'
                     orderby item.ID descending
                     select item);
            vm2.I = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'I'
                     orderby item.ID descending
                     select item);
            vm2.J = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'J'
                     orderby item.ID descending
                     select item);
            vm2.K = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'K'
                     orderby item.ID descending
                     select item);
            vm2.L = (from item in repo.GetAllSubtitles()
                    where item.name[0] == 'L'
                     orderby item.ID descending
                     select item);
            vm2.M = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'M'
                     orderby item.ID descending
                     select item);
            vm2.N = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'N'
                     orderby item.ID descending
                     select item);
            vm2.O = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'O'
                     orderby item.ID descending
                     select item);
            vm2.P = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'P'
                     orderby item.ID descending
                     select item);
            vm2.Q = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'Q'
                     orderby item.ID descending
                     select item);
            vm2.R = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'R'
                     orderby item.ID descending
                     select item);
            vm2.S = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'S'
                     orderby item.ID descending
                     select item);
            vm2.T = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'T'
                     orderby item.ID descending
                     select item);
            vm2.U = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'U'
                     orderby item.ID descending
                     select item);
            vm2.V = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'V'
                     orderby item.ID descending
                     select item);
            vm2.W = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'W'
                     orderby item.ID descending
                     select item);
            vm2.X = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'X'
                     orderby item.ID descending
                     select item);
            vm2.Y = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'Y'
                     orderby item.ID descending
                     select item);
            vm2.Z = (from item in repo.GetAllSubtitles()
                     where item.name[0] == 'Z'
                     orderby item.ID descending
                     select item);

           /* darf ad fa vm2 til ad taka a moti for lykkjunni
             for (char i = 'A'; i <= 'Z'; i++)
            {
                vm2.i = (from item in repo.GetAllSubtitles()
                         where item.name[0] == i
                         orderby item.ID descending
                         select item);
            }*/

            
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
        public ActionResult View3(int? subtitleid)
        {
            ViewBag.Message = "Here you can request subtitles.";

            CommentVM cvm = new CommentVM();
            cvm.allComments = CommentRepository.Instance.GetComments();

            cvm.allSubtitleFiles = (from item in repo.GetAllSubtitles()
                                    where subtitleid == item.ID
                                    select item);

            return View(cvm); 
        }

        [HttpPost]
        public ActionResult View3(FormCollection formData)
        {
            String strComment = formData["CommentText"];
            if (!String.IsNullOrEmpty(strComment))
            {
                SubtitleComment c = new SubtitleComment();

                c.commentText = strComment;
                String strUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                if (!String.IsNullOrEmpty(strUser))
                {
                    int slashPos = strUser.IndexOf("\\");
                    if (slashPos != -1)
                    {
                        strUser = strUser.Substring(slashPos + 1);
                    }
                    c.username = strUser;

                    CommentRepository.Instance.AddComment(c);
                }
                else
                {
                    c.username = "Unknown user";
                }
                return RedirectToAction("CommentView");
            }
            else
            {
                ModelState.AddModelError("CommentText", "Comment text cannot be empty!");
                return Index();
            }
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
                        
                        string srtContent = null;
                        using (StreamReader sr = new StreamReader(file.InputStream, Encoding.Default, true))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                srtContent += line + '\0';
                            }
                        }

                        SubtitleFile item = new SubtitleFile();
                        UpdateModel(item);
                        item.state = State.Edit;
                        item.SubtitleText = srtContent;
                       // item.name = item.name.First().
                        repo.AddSubtitle(item);
                        repo.Save();



                        ModelState.Clear();
                        

                        ViewBag.Message = "File uploaded successfully";
                    }
                }
            }
            return View();
            }


        [Authorize]
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

        [Authorize]
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
/*
		[HttpPost]
		public ActionResult Search()
		{
			return View();
		}
 */ 
		public ActionResult Search(string searchString, string category)
		{
			var categoryList = new List<string>();

			var categoryQry = from d in repo.GetAllSubtitles()
						   orderby d.category
						   select d.category;

			categoryList.AddRange(categoryQry.Distinct());
			ViewBag.movieGenre = new SelectList(categoryList);
			var allSubtitles = from m in repo.GetAllSubtitles()
							select m;

			if (!String.IsNullOrEmpty(searchString))
			{
				allSubtitles = allSubtitles.Where(s => s.name.Contains(searchString));
			}
			   
			if (!string.IsNullOrEmpty(category))
			{
				allSubtitles = allSubtitles.Where(x => x.category == category);
			}


			return View(allSubtitles); 
		}
	}
}