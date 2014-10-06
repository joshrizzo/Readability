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
            var data = new BookStoreContext().Books.ToList();
            var model = data.Select(book => new HomeIndexViewModel(book) { IsInStock = book.Quantity > 0, IsOld = book.Year < 1990 });
            return View(model);
        }
    }
}