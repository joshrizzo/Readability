using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Readability.Installers
{
    using System.Diagnostics.CodeAnalysis;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Readability.Services;

    [ExcludeFromCodeCoverage]
    public class IOCRegistration : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IBookRepo>().ImplementedBy<RavenRepo>().LifestyleTransient());
        }
    }
}