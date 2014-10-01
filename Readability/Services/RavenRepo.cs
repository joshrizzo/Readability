using Raven.Client;
using Raven.Client.Document;
using Readability.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Readability.Services
{
    public class RavenRepo : IBookRepo
    {
        private IDocumentSession session;

        public RavenRepo(IDocumentSession session)
        {
            this.session = session;
        }

        public IEnumerable<Book> Books
        {
            get 
            {
                return session.Query<Book>().ToList();
            }

            set
            {
                session.Query<Book>().ToList().ForEach(book => session.Delete(book));
                value.ToList().ForEach(book => session.Store(book));
                session.SaveChanges();
            }
        }
    }
}