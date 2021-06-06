using System;
using System.Collections.Generic;
using System.Text;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.Business.Concrete.Manager
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetProduct(int id)
        {
            return _productDal.Get(p => p.ProductId==id);
        }

        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }
    }
}
