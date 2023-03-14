using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Project_iRely.Models;

namespace Vidly_Project_iRely.Controllers
{
    public class RentController : Controller
    {
        MoviesRentalDbEntities db = new MoviesRentalDbEntities();

        // GET: Rent
        public ActionResult Index()
        {
            var result = (from r in db.rents
                          join c in db.movieRegs on r.movieid equals c.movieno
                          select new  RentaiViewModel
                          {
                              id = r.id,
                              movieid = r.movieid,
                              customerid = r.customerid,
                              fee = r.fee,
                              startdate = r.startdate,
                              enddate = r.enddate,
                              available = c.available
                          }).ToList();

            return View(result);
        }


        [HttpGet]
        public ActionResult Getmovie()
        {
            var movie = db.movieRegs.ToList();

            return Json(movie, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Getid(int id)
        {
            var customer = (from s in db.customers where s.id == id select s.customername).ToList();

            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Getavail (String movieno)
        {
            var movieavail = (from s in db.movieRegs where s.movieno == movieno select s.available).FirstOrDefault();
            return Json(movieavail, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(rent rentfee)
        {
            if (ModelState.IsValid)
            {
                db.rents.Add(rentfee);
                var movie = db.movieRegs.SingleOrDefault(e => e.movieno == rentfee.movieid);

                if (movie == null)
                {
                    // Move these lines of code outside of the if block
                    return HttpNotFound("Movie Numbers is not Valid");
                }

                movie.available = "Renting"; /*Can be change*/
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the view with the model
            return View(rentfee);
        }

    }
}
