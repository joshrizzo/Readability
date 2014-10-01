using Readability.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Readability.Services
{
    public class Inventory
    {
        private IBookRepo repo;

        public Inventory(IBookRepo repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Book> Book
        {
            get
            {
                return repo.Books.Where(x => x.Quantity > 0 && x.Year > 1990);
            }
        }
    }
}