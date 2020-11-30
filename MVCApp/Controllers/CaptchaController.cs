using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class CaptchaController : Controller
    {
        // GET: Captcha
        public ActionResult Index()
        {
            return View();
        }
        public string Getbrowserversion()
        {
            var browser = Request.Browser;
            string version = browser.Version;
            string platform = Request.Browser.Platform;
            if (Request.UserAgent.Contains("Edg") && Request.Browser.Browser != "Edge")
            {
                string Browsername = "Edge";
            }
            return browser.Browser;
        }
    }
}