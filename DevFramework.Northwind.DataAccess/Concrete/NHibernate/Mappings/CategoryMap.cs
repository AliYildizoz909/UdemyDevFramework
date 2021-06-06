using System;
using System.Collections.Generic;
using System.Text;
using DevFramework.Northwind.Entities.Concrete;
using FluentNHibernate.Mapping;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Categories");
            //LazyLoad();
            Id(p => p.CategoryId).Column("CategoryID");


            Map(x => x.CategoryName).Column("CategoryName");
        }
    }
}
