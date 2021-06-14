using System.Data.Entity;
using Autofac;
using DevFramework.Core.DataAccess;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Concrete.Manager;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;

namespace DevFramework.Northwind.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            //builder.RegisterType(typeof(EfQueryableRepository<>)).As(typeof(IQueryableRepository<>)).SingleInstance();
            builder.RegisterType<NorthwindContext>().As<DbContext>().SingleInstance();
            builder.RegisterType<SqlServerHelper>().As<NHibernateHelper>().SingleInstance();
        }

        
    }
}
