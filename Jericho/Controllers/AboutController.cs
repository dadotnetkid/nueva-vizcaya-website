using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jericho.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }

        [Route("historical-background")]
        public ActionResult HistoricalBackground()
        {
            return View();
        }
        [Route("political-officials")]
        public ActionResult PoliticalOfficials()
        {
            return View();
        }
        public ActionResult History()
        {
            return PartialView();
        }
    }
}