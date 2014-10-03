using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Readability.DataModels
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Itm> Books { get; set; }
    }
}