﻿[assembly: WebActivator.PreApplicationStartMethod(typeof(ProjectManagement.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(ProjectManagement.Web.App_Start.NinjectWebCommon), "Stop")]

namespace ProjectManagement.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;
    using Ninject.WebApi.DependencyResolver;
    using ProjectManagement.Data;
    using ProjectManagement.Common.Settings;
    using ProjectManagement.Common.Settings.Impl;
    using ProjectManagement.Data.Repositories;
    using ProjectManagement.Data.Repositories.Impl;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static IKernel Kernel
        {
            get
            {
                return bootstrapper.Kernel;
            }
        }

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
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                GlobalConfiguration.Configuration.DependencyResolver =
                    new NinjectDependencyResolver(kernel);

                RegisterServices(kernel);
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
            kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
            kernel.Bind<ICommonSettings>().To<CommonSettings>();
            kernel.Bind<IProjectsRepository>().To<ProjectsRepository>();
        }
    }
}