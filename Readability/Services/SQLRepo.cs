using Readability.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Readability.Services
{
    public class SQLRepo : IBookRepo
    {
        private BookStoreContext db;

        public SQLRepo()
        {
            this.db = new BookStoreContext();
        }

        public IEnumerable<Book> Books
        {
            get 
            {
                return db.Books.ToList();
            }
            set
            {
                db.Database.Delete();
                db.Books.AddRange(value);
                db.SaveChanges();
            }
        }
    }
}