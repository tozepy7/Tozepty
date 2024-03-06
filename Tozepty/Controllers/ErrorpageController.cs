using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tozepty.Controllers
{
    public class ErrorpageController : Controller
    {
        // GET: Errorpage
        public ActionResult UnauthorisedAccess()
        {
            return View();
        }
        public ActionResult PageNotFound()
        {
            return View();
        }
    }
}