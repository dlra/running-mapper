using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RunningMapper.Data.Services;

namespace RunningMapper.Web.Controllers
{
    public class HomeController : Controller
    {
        IRunData db;

        public HomeController()
        {
            db = new InMemoryRunData();
        }

        public ActionResult Index()
        {
            var model = db.GetAll();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}