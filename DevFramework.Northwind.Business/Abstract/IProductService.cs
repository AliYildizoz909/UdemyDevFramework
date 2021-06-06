using System;
using System.Collections.Generic;
using System.Text;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetProduct(int id);

        Product Add(Product product);
        Product Update(Product product);

        void TransactionalOperation(Product product1, Product product2);
    }
}
