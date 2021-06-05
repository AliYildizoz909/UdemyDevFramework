using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
            //Veri tabanı zaten hazır olduğu için veritabanında herhangi bir işlem yapılması engellendi.
            Database.SetInitializer<NorthwindContext>(null);
        }
        public DbSet<Product> Products { get; set; }
    }
}
