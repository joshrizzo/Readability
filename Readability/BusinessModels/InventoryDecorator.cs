using Readability.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Readability.BusinessModels
{
    public class InventoryDecorator
    {
        private Book book;

        public InventoryDecorator(Book book)
        {
            this.book = book;
        }

        public bool IsInStock()
        {
            return book.Quantity >= 0;
        }

        public bool IsNew()
        {
            return book.Year > 1990;
        }
    }
}