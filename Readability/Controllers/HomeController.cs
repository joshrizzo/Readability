using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Readability.DataModels;
using Readability.ViewModels;
using System.Xml.Linq;
using log4net;
using Readability.Services;

namespace Readability.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            var data = new BookStoreContext().Books;
            var model = new List<HomeIndexViewModel>();
            return View();
        }
    }
}