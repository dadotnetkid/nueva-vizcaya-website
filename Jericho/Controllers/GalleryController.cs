using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jericho.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }
        [Route("lower-magat")]
        public ActionResult LowerMagat()
        {
            return View();
        }
        [Route("capisaan-cave")]
        public ActionResult CapisaanCave()
        {
            return View();
        }
        [Route("capitol")]
        public ActionResult Capitol()
        {
            return View();
        }
    }
}