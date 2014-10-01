namespace Readability.Installers
{
    using System.Diagnostics.CodeAnalysis;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Raven.Client;
    using Raven.Client.Document;
    using Raven.Client.Embedded;
    using Raven.Database.Server;

    [ExcludeFromCodeCoverage]
    public class RavenInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var documentStore = InitializeStore();

            container.Register(
                Component.For<IDocumentStore>().Instance(documentStore).LifeStyle.Transient,
                Component.For<IDocumentSession>().UsingFactoryMethod(k => k.Resolve<IDocumentStore>().OpenSession()).LifestyleTransient(),
                Classes.FromThisAssembly().Where(m => m.Name.EndsWith("Repo")).WithServiceAllInterfaces().LifestyleTransient());
        }

        public static EmbeddableDocumentStore InitializeStore()
        {
            var documentStore = new EmbeddableDocumentStore
            {
                DataDirectory = "App_Data",
                Conventions =
                {
                    DefaultQueryingConsistency = ConsistencyOptions.AlwaysWaitForNonStaleResultsAsOfLastWrite
                }
            };
            NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8080);
            documentStore.UseEmbeddedHttpServer = true;
            documentStore.Configuration.Port = 8080;

            documentStore.Initialize();
            return documentStore;
        }
    }
}