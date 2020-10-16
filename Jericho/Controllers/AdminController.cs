using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Repository;
using Models;

namespace Jericho.Controllers
{
    public class AdminController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult CardViewPartial()
        {
            var model = unitOfWork.PostsRepo.Get();
            return PartialView("_CardViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CardViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Posts item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_CardViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CardViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Posts item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_CardViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CardViewPartialDelete(System.Int32 Id)
        {
            var model = new object[0];
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_CardViewPartial", model);
        }

        public ActionResult AddEditCardPartial([ModelBinder(typeof(DevExpressEditorsBinder))]
            int? postId)
        {
            var model = unitOfWork.PostsRepo.Find(x => x.Id == postId);
            return PartialView(model);
        }



        public ActionResult PostHtmlEditorPartial()
        {
            return PartialView("_PostHtmlEditorPartial");
        }
        public ActionResult PostHtmlEditorPartialImageSelectorUpload()
        {
            HtmlEditorExtension.SaveUploadedImage("PostContent", AdminControllerPostHtmlEditorSettings.ImageSelectorSettings);
            return null;
        }
        public ActionResult PostHtmlEditorPartialImageUpload()
        {
            HtmlEditorExtension.SaveUploadedFile("PostContent", AdminControllerPostHtmlEditorSettings.ImageUploadValidationSettings, AdminControllerPostHtmlEditorSettings.ImageUploadDirectory);
            return null;
        }
    }
    public class AdminControllerPostHtmlEditorSettings
    {
        public const string ImageUploadDirectory = "~/Content/UploadImages/";
        public const string ImageSelectorThumbnailDirectory = "~/Content/Thumb/";

        public static DevExpress.Web.UploadControlValidationSettings ImageUploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif", ".png" },
            MaxFileSize = 4000000
        };

        static DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings imageSelectorSettings;
        public static DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings ImageSelectorSettings
        {
            get
            {
                if (imageSelectorSettings == null)
                {
                    imageSelectorSettings = new DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings(null);
                    imageSelectorSettings.Enabled = true;
                    imageSelectorSettings.UploadCallbackRouteValues = new { Controller = "Admin", Action = "PostHtmlEditorPartialImageSelectorUpload" };
                    imageSelectorSettings.CommonSettings.RootFolder = ImageUploadDirectory;
                    imageSelectorSettings.CommonSettings.ThumbnailFolder = ImageSelectorThumbnailDirectory;
                    imageSelectorSettings.CommonSettings.AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif" };
                    imageSelectorSettings.UploadSettings.Enabled = true;
                }
                return imageSelectorSettings;
            }
        }
    }



}