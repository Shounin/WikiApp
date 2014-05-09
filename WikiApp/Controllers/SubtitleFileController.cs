using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WikiApp.Controllers
{
    public class SubtitleFileController : Controller
    {
        //
        // GET: /SubtitleFile/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /SubtitleFile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SubtitleFile/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SubtitleFile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SubtitleFile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /SubtitleFile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SubtitleFile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SubtitleFile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
