using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Readability.DataModels;
using System.Data.Entity;
using System.Xml.Linq;
using Readability.Services;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System.ComponentModel;
using Raven.Client;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(Readability.App_Start.DataPopulator), "Populate")]

namespace Readability.App_Start
{
    public class DataPopulator
    {
        public static void Populate()
        {
            var books = new SourceFileRepo().Books.ToList();
            new SQLRepo().Books = books;
            new RavenRepo(WindsorActivator.bootstrapper.Container.Resolve<IDocumentSession>()).Books = books;
        }
    }
}