using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test_Generico.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// Only show a generic error, is more for security
        /// </summary>
        /// <returns>Error message</returns>
        public ActionResult ErrorMessage()
        {
            return View();
        }

    }
}