using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Project_iRely.Models;

namespace Vidly_Project_iRely.Controllers
{
    public class returnmovieController : Controller
    {

        MoviesRentalDbEntities db = new MoviesRentalDbEntities();

       

        // GET: returnmovie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(returnmovie returnmov)
        {

            if (ModelState.IsValid)
            {
                db.returnmovies.Add(returnmov);

                var movie = db.movieRegs.SingleOrDefault(e => e.movieno == returnmov.movieno);

                if (movie == null)
                
                    return HttpNotFound("Movie Number not Found");
                    movie.available = "Return";
                    db.Entry(movie).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
            }
            return View(returnmov);
        }

        [HttpPost]
        public ActionResult Getid(String movieno)
        {
            var movienum = (from s in db.rents
                            where s.movieid == movieno
                            select new
                            {
                                StartDate = s.startdate,
                                EndDate = s.enddate,
                                Customerid = s.customerid,
                                Movieno = s.movieid,
                                Fee = s.fee,
                                ElapsedDays = SqlFunctions.DateDiff("day", s.enddate, DateTime.Now)


                            }).ToArray();
            return Json(movienum,JsonRequestBehavior.AllowGet);
        }
    }
}