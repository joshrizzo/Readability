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
        private IBookRepo repo;

        public HomeController(IBookRepo repo)
        {
            this.repo = repo;
        }

        public virtual ActionResult Index()
        {
            var books = repo.Books;
            if (books == null) { throw new ApplicationException("No books found."); }
            var viewModel = new HomeIndexViewModelBuilder(books.ToList()).Build();
            return View(viewModel);
        }
    }
}