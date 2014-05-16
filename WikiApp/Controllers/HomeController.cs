using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
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

		public ActionResult Index() 
		{
			// Data for the category drop-down menu.
			var categoryList = new List<string>();

			var categoryQry = from d in repo.GetAllSubtitles()
							  orderby d.category
							  select d.category;

			categoryList.AddRange(categoryQry.Distinct());
			ViewBag.movieGenre = new SelectList(categoryList);
			// Drop-down data completed
            
			SubtitlesVM vm = new SubtitlesVM();
            vm.NewestMovies = (from item in repo.GetAllSubtitles()
                            where item.state == State.Edit && item.category != "Þættir"
                            orderby item.ID descending
                            select item).Take(10);

            vm.NewestTV = (from item in repo.GetAllSubtitles()
                        where item.state == State.Edit && item.category == "Þættir"
                        orderby item.ID descending
                        select item).Take(10);
            
            vm.PopularMovies = (from item in repo.GetAllSubtitles()
                           where item.state == State.Edit && item.category != "Þættir"
                           orderby item.upvote descending
                           select item).Take(10);

            vm.PopularTV = (from item in repo.GetAllSubtitles()
                                where item.state == State.Edit && item.category == "Þættir"
                                orderby item.upvote descending
                                select item).Take(10);

            return View(vm);
        }

        /// Response when searchstring is entered in front page ///
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
        /// Show all the Subtitles as well as orginized ///
		public ActionResult AllSubtitles() 
		{
			ViewBag.Message = "Listi yfir alla skjátexta.";
            SubtitlesVM vm2 = new SubtitlesVM();
            vm2.allFiles = (from item in repo.GetAllSubtitles()
                            where item.state == State.Edit
                            orderby item.name ascending
                            select item);

            vm2.stuff = (from item in repo.GetAllSubtitles()
                         where item.state == State.Edit
                         orderby item.ID ascending
                         group item by item.name[0]);

            return View(vm2);
		}




                           
        /// Add a new SubtitleFile to the database ///
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
        
        /// Returns all requests to the requests page ///
        [HttpGet]
        public ActionResult Requests()
        {
            ViewBag.Message = "Here you can request subtitles.";
            
            SubtitlesVM vm = new SubtitlesVM();
            vm.NewestMovies = (from item in repo.GetAllSubtitles()
                               where item.state == State.Request
                               orderby item.ID descending
                               select item);
            return View(vm);

        }


        public ActionResult View3(int? id)
        {
            
            CommentVM comment1 = new CommentVM();
            /*comment1.allComments = SubtitleRepository.GetAllComments();*/
            
            comment1.allSubtitleFiles = (from item in repo.GetAllSubtitles()
                                         where id == item.ID
                                         select item);

            comment1.allComments = (from item in repo.GetAllComments()
                                         where id == item.SubtitleFileID
                                         select item);

            return View(comment1);

            //return View(cvm); 
        }

        [HttpPost]
        public ActionResult View3(FormCollection formData, SubtitleFile file)
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
                    c.SubtitleFileID = file.ID;
                    c.username = strUser;
                    SubtitleRepository.Instance.AddComment(c);
                }
                else
                {
                    c.username = "Unknown user";
                }
                return RedirectToAction("View3");
            }
            else
            {
                ModelState.AddModelError("CommentText", "Comment text cannot be empty!");
                return Index();
            }
        }

        [HttpPost]
        public ActionResult About(String Name, String Email, String Message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("fromadd");
                mail.To.Add("toadd");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return RedirectToAction("Home");
            }
            catch (Exception ex)
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("fromadd");
                mail.To.Add("toadd");
                mail.Subject = "Test Mail";
                mail.Body = ex.ToString();

                return RedirectToAction("Home");
            }
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
                        
                        string srtContent = null;
                        using (StreamReader sr = new StreamReader(file.InputStream, Encoding.Default, true))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                srtContent += line + '\n';
                            }
                        }

                        SubtitleFile item = new SubtitleFile();
                        UpdateModel(item);
                        item.state = State.Edit;
                        item.SubtitleText = srtContent;
                        item.name = char.ToUpper(item.name[0]) + item.name.Substring(1);
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
        [HttpGet]
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

        /// New reqest added to database ///
        [Authorize]
        [HttpPost]
        public ActionResult AddRequest(FormCollection form)
        {
            // Values for dropdown list declared.
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
            
            // The SubtitleFile data from view added to database.
            SubtitleFile item = new SubtitleFile();
            UpdateModel(item);
            item.state = State.Request;
            repo.AddSubtitle(item);
            repo.Save();

            // The user is redirected to the Index page when done.
            return RedirectToAction("Index");
        }


		public ActionResult Search(string searchString, string category)
		{
			var categoryList = new List<string>();

			var categoryQry = from d in repo.GetAllSubtitles()
						   orderby d.category
						   select d.category;

			categoryList.AddRange(categoryQry.Distinct());
			ViewBag.movieGenre = new SelectList(categoryList);
			var allSubtitles = from m in repo.GetAllSubtitles()
							   where m.state == State.Edit || m.state == State.Ready
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

		public ActionResult RequestSearch(string searchString, string category)
		{
			var categoryList = new List<string>();

			var categoryQry = from d in repo.GetAllSubtitles()
							  orderby d.category
							  select d.category;

			categoryList.AddRange(categoryQry.Distinct());
			ViewBag.movieGenre = new SelectList(categoryList);
			var allSubtitles = from m in repo.GetAllSubtitles()
							   where m.state == State.Request
							   select m;

			if (!String.IsNullOrEmpty(searchString))
			{
				allSubtitles = allSubtitles.Where(s => s.name.Contains(searchString));
			}

			if (!string.IsNullOrEmpty(category))
			{
				allSubtitles = allSubtitles.Where(x => x.category == category);
			}


			return View("Search", allSubtitles);
		}

		public ActionResult UpvoteSubtitle(/*SubtitleFile subtitle*/ int subtitleFileID)
		{
			Debug.WriteLine(subtitleFileID);
			/*IEnumerable<Upvote> upvotes = SubtitleRepository.Instance.GetAllUpvotes();
			Upvote up = new Upvote();
			up.SubtitleFileID = subtitle.ID;
			up.applicationUserID = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

			if(upvotes.Contains(up))
			{
				SubtitleRepository.Instance.RemoveUpvote(up);
				subtitle.upvote--;
			}
			else
			{
				SubtitleRepository.Instance.AddUpvote(up);
				subtitle.upvote++;
			}*/

			Upvote u = SubtitleRepository.Instance.GetUpvoteByID(subtitleFileID);
			if (u != null)
			{
				SubtitleRepository.Instance.RemoveUpvote(u);
			}
			else
			{
				SubtitleRepository.Instance.AddUpvote(new Upvote
				{
					SubtitleFileID = subtitleFileID,
					applicationUserID = System.Security.Principal.WindowsIdentity.GetCurrent().Name
				});
			}

			return RedirectToAction("View3");
		}

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        [HttpGet]
        public ActionResult Downloader(int? id)
        {
            var subFile = (from item in repo.GetAllSubtitles()
                        where item.ID == id
                        select item).SingleOrDefault().SubtitleText;

            var subName = (from item in repo.GetAllSubtitles()
                           where item.ID == id
                           select item).SingleOrDefault().name;

            return File(GetBytes(subFile), System.Net.Mime.MediaTypeNames.Application.Octet, subName + ".srt");			
		}
}
}
