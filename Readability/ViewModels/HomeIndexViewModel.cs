using Readability.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Omu.ValueInjecter;

namespace Readability.ViewModels
{
    public class HomeIndexViewModel
    {
        public string Ttl { get; set; }
        public string Auth { get; set; }
        public int Yr { get; set; }
        public int Qty { get; set; }
        public bool O { get; set; }
        public bool S { get; set; }

        public HomeIndexViewModel(Itm item)
        {
            this.InjectFrom(item);
        }
    }
}