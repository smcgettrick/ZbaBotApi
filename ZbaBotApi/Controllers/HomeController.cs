﻿using System.Web.Http;
using System.Web.Mvc;

namespace ZbaBotApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var apiExplorer = GlobalConfiguration.Configuration.Services.GetApiExplorer();
            return View(apiExplorer);
        }
    }
}
