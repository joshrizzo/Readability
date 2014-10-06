using Readability.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Readability.BusinessModels
{
    public class InventoryDecorator
    {
        private Itm book;

        public InventoryDecorator(Itm book)
        {
            this.book = book;
        }

        public bool IsInStock()
        {
            return book.Qty >= 0;
        }

        public bool IsNew()
        {
            return book.Yr > 1990;
        }
    }
}