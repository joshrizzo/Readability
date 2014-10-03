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

        public IEnumerable<Itm> Book
        {
            get
            {
                return repo.Books.Where(x => x.Qty > 0 && x.Yr > 1990);
            }
        }
    }
}