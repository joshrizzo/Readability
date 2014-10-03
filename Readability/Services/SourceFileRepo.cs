using Readability.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Readability.Services
{
    public class SourceFileRepo : IBookRepo
    {
        private string source = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + @"\BookData.xml";

        public IEnumerable<Itm> Books 
        { 
            get 
            {
                var data = XDocument.Load(source);
                var books = data.Element("books").Elements("book").ToList();
                foreach (var book in books)
                {
                    yield return new Itm()
                    {
                        Auth = book.Element("author").Value,
                        Ttl = book.Element("title").Value,
                        Yr = int.Parse(book.Element("year").Value),
                        Qty = int.Parse(book.Element("quantity").Value)
                    };
                }
            } 
        }
    }
}