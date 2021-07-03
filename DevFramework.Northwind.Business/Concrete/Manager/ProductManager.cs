using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevFramework.Core.Aspects.Postsharp;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
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

        
        [LogAspect(typeof(DatabaseLogger),2)]
        [LogAspect(typeof(FileLogger),3)]
        [CacheAspect(typeof(MemoryCacheManager),1)]
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetProduct(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        
        [CacheRemoveAspect("",typeof(MemoryCacheManager),2)]
        [FluentValidationAspect(typeof(ProductValidator), 1)]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator),1)]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect(1)]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);

            _productDal.Add(product2);
        }
    }
}
