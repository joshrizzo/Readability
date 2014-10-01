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
            var booksFromXML = GetBooksFromXML();
            var viewModel = ConstructViewModel(booksFromXML);
            return View(viewModel);
        }

        private static List<HomeIndexViewModel> ConstructViewModel(List<Book> books)
        {
            var viewModel = new List<HomeIndexViewModel>();
            foreach (var book in books)
            {
                viewModel.Add(new HomeIndexViewModel(book)
                {
                    IsInStock = book.Quantity <= 0,
                    IsOld = book.Year < 1990
                });
            }
            return viewModel;
        }

        private List<Book> GetBooksFromXML()
        {
            return repo.Books.ToList();
        }
    }
}