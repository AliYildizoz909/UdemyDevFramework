using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DevFramework.Northwind.Entities.ComplexTypes;

namespace DevFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
    }
}
