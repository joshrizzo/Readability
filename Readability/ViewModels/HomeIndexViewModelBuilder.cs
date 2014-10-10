using Readability.BusinessModels;
using Readability.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Readability.ViewModels
{
    public class HomeIndexViewModelBuilder
    {
        private IEnumerable<Book> books;

        public HomeIndexViewModelBuilder(IEnumerable<Book> books)
        {
            this.books = books;
        }

        public List<HomeIndexViewModel> Build()
        {
            var viewModel = new List<HomeIndexViewModel>();
            foreach (var book in books)
            {
                var inventory = new InventoryDecorator(book);
                viewModel.Add(new HomeIndexViewModel(book)
                {
                    IsInStock = inventory.IsInStock(),
                    IsOld = !inventory.IsNew()
                });
            }
            return viewModel;
        }
    }
}