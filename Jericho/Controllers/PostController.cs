using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Repository;

namespace Jericho.Controllers
{
    public class PostController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Post
        [Route("post/{post?}")]
        public ActionResult Index(string post)
        {
            ViewBag.Title = post;
            var model = unitOfWork.PostsRepo.Find(x => x.Title.Replace(".", "-").Replace(",", "-").Replace(" ", "-") == post);
            return View(model);
        }

        [Route("page/{page?}")]
        public ActionResult Pages(string page)
        {
            ViewBag.Title = page;
            var model = unitOfWork.PostsRepo.Get(x => x.Type == page);
            return View(model);
        }

    }
}