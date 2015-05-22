[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SiBRute.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SiBRute.WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace SiBRute.WebAPI.App_Start
{
    using System;
    using System.Web;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.WebApi;
    using SiBRute.Repository.Common;
    using Moq;
    using SiBRute.Model.Common;
    using System.Collections.Generic;
    using SiBRute.WebAPI.Models;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var settings = new NinjectSettings();
            settings.LoadExtensions = true;
            settings.ExtensionSearchPatterns = settings.ExtensionSearchPatterns.Union(new string[] { "SiBRute.*.dll" }).ToArray();

            var kernel = new StandardKernel(settings);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Mocked repository for testing before the Database is created
            Mock<IRoutesRepository> mock = new Mock<IRoutesRepository>();

            mock.Setup(m => m.GetAllRoutes()).Returns(new List<IBikeRoute> {
                new MockBikeRoute {Name = "Ruta po Baranji", Description = "Kratka ruta po Baranji, podloga je cesta, makadam i šumski put.", Author = "krunoslav", Distance = 75, Places = "Osijek, Bilje, Kopaèevo, Kopaèki rit, Tikveš", DateCreated = DateTime.Now},
                new MockBikeRoute {Name = "Ruta do Valpova", Description = "Vožnja do valpova preko nasipa, podloga je makadam i cesta. Treba paziti na promet u Valpovu i blizini Osijeka.", Author = "krunoslav", Distance = 70, Places = "Osijek, Belišæe, Valpovo, Ladimirevci, Satnica, Petrijevci.", DateCreated = DateTime.Now},
                new MockBikeRoute {Name = "Slavonska ruta", Description = "Dulja kružna vožnja po Slavoniji, jedan jaèi uspon kod Aljmaša, vozi se uglavnom po cesti tako da treba paziti na promet.", Author = "krunosalv", Distance = 125, Places = "Osijek, Bijelo Brdo, Aljmaš, Erdut, Dalj, Borovo, Vukovar, Trpinja, Klisa.", DateCreated = DateTime.Now}
            });

            kernel.Bind<IRoutesRepository>().ToConstant(mock.Object);
        }        
    }
}
