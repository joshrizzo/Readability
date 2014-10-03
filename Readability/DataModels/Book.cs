using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace Readability.DataModels
{
    public class Itm
    {
        public Itm()
        {
            this.ID = Guid.NewGuid();
        }

        [Key]
        public Guid ID { get; set; }

        public string Ttl { get; set; }

        public string Auth { get; set; }

        [Year]
        public int Yr { get; set; }

        [Min(0)]
        public int Qty { get; set; }
    }
}