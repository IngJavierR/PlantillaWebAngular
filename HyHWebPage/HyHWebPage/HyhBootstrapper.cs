using System;
using HyHWebPage.Db.Hyhweb.Repository;
using HyHWebPage.Db.Imas.Repository;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Ninject;
using Nancy.Diagnostics;
using NHibernate;
using NLog;

namespace HyHWebPage
{
    public class HyhBootstrapper: NinjectNancyBootstrapper
    {
        public bool ApplicationContainerConfigured { get; set; }
        private readonly ISessionFactory _sessionFactoryHyhWeb;
        private readonly ISessionFactory _sessionFactoryImas;

        private static readonly Logger Log = LogManager.GetCurrentClassLogger ();

        public Ninject.IKernel Container => ApplicationContainer;

        public bool RequestContainerConfigured { get; set; }

        public HyhBootstrapper()
        {
            try
            {
                var config = new NHibernate.Cfg.Configuration();
                var hibernateConfiguration = config.Configure("HibernateHyhWeb.cfg.xml");
                _sessionFactoryHyhWeb = hibernateConfiguration.BuildSessionFactory();
            }
            catch (Exception e)
            {
                Log.Error(e, "Inicializando NHibernate HyhWeb: " + e.Message);
            }

            try
            {
                var config = new NHibernate.Cfg.Configuration();
                var hibernateConfiguration = config.Configure("HibernateImas.cfg.xml");
                _sessionFactoryImas = hibernateConfiguration.BuildSessionFactory();
            }
            catch (Exception e)
            {
                Log.Error(e, "Inicializando NHibernate Imas: " + e.Message);
            }
        }

        protected override void ConfigureApplicationContainer (Ninject.IKernel existingContainer)
        {
            ApplicationContainerConfigured = true;
            base.ConfigureApplicationContainer (existingContainer);

            Nancy.Json.JsonSettings.MaxJsonLength = Int32.MaxValue;  

            StaticConfiguration.DisableErrorTraces = false;
            StaticConfiguration.EnableRequestTracing = true;
        }

        protected override void ConfigureRequestContainer (Ninject.IKernel container, NancyContext context)
        {
            container.Bind<IHyhWebRepository>()
                .ToConstructor(ctx => new HyhWebRepository(_sessionFactoryHyhWeb.OpenSession()));
            container.Bind<IImasRepository>()
                .ToConstructor(ctx => new ImasRepository(_sessionFactoryImas.OpenSession()));
        }
            
        protected override DiagnosticsConfiguration DiagnosticsConfiguration => new DiagnosticsConfiguration { Password = @"12345" };

        protected override void ApplicationStartup(Ninject.IKernel container, IPipelines pipelines)
        {
            DiagnosticsHook.Disable(pipelines);

            //CORS Enable
            pipelines.AfterRequest.AddItemToEndOfPipeline(ctx =>
            {
                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                                .WithHeader("Access-Control-Allow-Methods", "POST,GET,DELETE")
                                .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");

            });

            pipelines.OnError += (ctx, ex) => 404;
        }
    }

}


