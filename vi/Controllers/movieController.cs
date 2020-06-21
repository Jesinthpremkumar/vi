using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vi.Models;

namespace vi.Controllers
{
    public class movieController : Controller
    {
        // GET: movie
        public ActionResult random()
        {
            var movie = new movie() { name="shrek"};
            return View(movie);
        }
       public ActionResult byreleased(int year,int month)
        {
            return Content(year + "/" + month);
        }
    }
}