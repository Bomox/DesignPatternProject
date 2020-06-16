using DataAccess;
using Project.Helpers;
using Project.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Home()
        {
            return View();
        }

        [LoginAttribure]
        public ActionResult Planets()
        {
            return View();
        }

    }
}

    

