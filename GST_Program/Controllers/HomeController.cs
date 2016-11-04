using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GST_Program.Domain;
using GST_Program.Domain.ViewModels;
using Dapper;
using GST_Program.Models;


namespace GST_Program.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index() {
			
			return View();
        }
    }
}