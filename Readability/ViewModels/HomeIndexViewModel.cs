using Readability.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Omu.ValueInjecter;

namespace Readability.ViewModels
{
    public class HomeIndexViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Quantity { get; set; }
        public bool IsOld { get; set; }
        public bool IsInStock { get; set; }

        public HomeIndexViewModel(Book book)
        {
            this.InjectFrom(book);
        }
    }
}