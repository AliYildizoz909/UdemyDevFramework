using System.Data.Entity;
using System.IO;
using System.Reflection;
using System.Xml;
using Autofac;
using DevFramework.Core.DataAccess;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Concrete.Manager;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.Extensions.Configuration;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Log4Net;
using Module = Autofac.Module;

namespace DevFramework.Northwind.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        public BusinessModule()
        {
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            ILoggerRepository relay = Log4NetCollectingRepositorySelector.RedirectLoggingToPostSharp();

            // Configure the *relay* repository (instead of the default repository) with your final output appenders:
            XmlConfigurator.Configure(relay, new FileInfo("log4net.config"));

            // Use the relay repository to create a Log4NetLoggingBackend and set it as the default backend:
            LoggingServices.DefaultBackend = new Log4NetLoggingBackend(relay);

            //builder.RegisterType(typeof(EfQueryableRepository<>)).As(typeof(IQueryableRepository<>)).SingleInstance();

            builder.RegisterType<NorthwindContext>().As<DbContext>();

            builder.RegisterType<SqlServerHelper>().As<NHibernateHelper>().SingleInstance();
        }


    }
}
