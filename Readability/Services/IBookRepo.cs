using Readability.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Readability.Services
{
    public interface IBookRepo
    {
        IEnumerable<Book> Books { get; }
    }
}