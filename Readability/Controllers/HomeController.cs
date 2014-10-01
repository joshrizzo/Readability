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
            // List for books from DB.
            var lst = new List<Book>();
            // Get books from the XML file and turn them into Book objects. 
            try { foreach (var y in XDocument.Load(AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + @"\BookData.xml").Element("books").Elements("book").ToList()) { lst.Add(new Book() { Author = y.Element("author").Value, Title = y.Element("title").Value, Year = int.Parse(y.Element("year").Value), Quantity = int.Parse(y.Element("quantity").Value) }); } }
            // Reading from files is dangerous, so lets catch any exeptions.
            catch (Exception ex) { LogManager.GetLogger(typeof(HomeController)).Error("Stuff happened when loading the data from XML.", ex); throw ex; }
            // Loop through the original list and filter certain results from the new list.  This is necessary because C# does not like us modifying the list that we are looping through.
            var lst2 = new List<HomeIndexViewModel>();
            foreach (var x in lst) lst2.Add(new HomeIndexViewModel(x) { IsInStock = x.Quantity <= 0, IsOld = x.Year < 1990 });
            // Return the view and populate the model with the filtered list.
            return View(lst2);
        }
    }
}