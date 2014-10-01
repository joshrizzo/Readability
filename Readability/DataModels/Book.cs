using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace Readability.DataModels
{
    public class Book
    {
        public Book()
        {
            this.ID = Guid.NewGuid();
        }

        [Key]
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        [Year]
        public int Year { get; set; }

        [Min(0)]
        public int Quantity { get; set; }
    }
}