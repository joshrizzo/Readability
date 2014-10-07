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

namespace Readability.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            var booksFromXML = GetBooksFromXML();
            var viewModel = ConstructViewModel(booksFromXML);
            return View(viewModel);
        }

        private static List<HomeIndexViewModel> ConstructViewModel(List<Book> booksFromXML)
        {
            var viewModel = new List<HomeIndexViewModel>();
            foreach (var book in booksFromXML)
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
            var booksFromXML = new List<Book>();
            XDocument.Load(AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + @"\BookData.xml")
                .Element("books")
                .Elements("book")
                .ToList()
                .ForEach(book => 
                    booksFromXML.Add(new Book()
                    {
                        Author = book.Element("author").Value,
                        Title = book.Element("title").Value,
                        Year = int.Parse(book.Element("year").Value),
                        Quantity = int.Parse(book.Element("quantity").Value)
                    })
                );
            return booksFromXML;
        }
    }
}