using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptinsure.ViewModels;

namespace Cryptinsure.Controllers
{
    public class ClaimsController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(ClaimViewModel model)
        {
            if (ModelState.IsValid)
            {

            }

            return View(model);
        }
    }
}