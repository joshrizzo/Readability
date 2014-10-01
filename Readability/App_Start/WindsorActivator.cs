using System;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(Readability.App_Start.WindsorActivator), "PreStart")]
[assembly: ApplicationShutdownMethodAttribute(typeof(Readability.App_Start.WindsorActivator), "Shutdown")]

namespace Readability.App_Start
{
    public static class WindsorActivator
    {
        public static ContainerBootstrapper bootstrapper;

        public static void PreStart()
        {
            bootstrapper = ContainerBootstrapper.Bootstrap();
        }
        
        public static void Shutdown()
        {
            if (bootstrapper != null)
                bootstrapper.Dispose();
        }
    }
}