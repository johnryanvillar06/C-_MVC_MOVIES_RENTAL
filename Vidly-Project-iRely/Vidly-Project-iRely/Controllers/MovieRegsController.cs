using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly_Project_iRely.Models;

namespace Vidly_Project_iRely.Controllers
{
    public class MovieRegsController : Controller
    {
        private MoviesRentalDbEntities db = new MoviesRentalDbEntities();

        // GET: MovieRegs
        public ActionResult Index()
        {
            return View(db.movieRegs.ToList());
        }

        // GET: MovieRegs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movieReg movieReg = db.movieRegs.Find(id);
            if (movieReg == null)
            {
                return HttpNotFound();
            }
            return View(movieReg);
        }

        // GET: MovieRegs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieRegs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,movieno,movietitle,genre,available")] movieReg movieReg)
        {
            if (ModelState.IsValid)
            {
                db.movieRegs.Add(movieReg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movieReg);
        }

        // GET: MovieRegs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movieReg movieReg = db.movieRegs.Find(id);
            if (movieReg == null)
            {
                return HttpNotFound();
            }
            return View(movieReg);
        }

        // POST: MovieRegs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,movieno,movietitle,genre,available")] movieReg movieReg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieReg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movieReg);
        }

        // GET: MovieRegs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movieReg movieReg = db.movieRegs.Find(id);
            if (movieReg == null)
            {
                return HttpNotFound();
            }
            return View(movieReg);
        }

        // POST: MovieRegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            movieReg movieReg = db.movieRegs.Find(id);
            db.movieRegs.Remove(movieReg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
