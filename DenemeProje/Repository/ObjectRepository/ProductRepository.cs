using DenemeProje.Models;
using DenemeProje.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DenemeProje.Repository.Concrete
{
    public class ProductRepository
    {
        private IRepository<Product> _productRepository;
        private IUnitOfWork _productUnitOfWork;
        private DbContext _dbContext;
        public ProductRepository()
        {
            _dbContext = new NorthwindEntities();
            _productUnitOfWork = new EFUnitOfWork(_dbContext);
            _productRepository = new EFRepository<Product>(_dbContext);
        }
        public List<Product> SixProduct()
        {
            return _productRepository.GetAll().OrderBy(p => p.ProductID).Take(8).ToList();
        }

        public List<Product> ProductsByCategory(int? id)
        {
            return _productRepository.GetAll(p => p.CategoryID == id).ToList();
        }

        public List<Product> ProductsBySuppliers(int? id)
        {
            return _productRepository.GetAll(p => p.SupplierID == id).ToList();
        }
        public List<Product> Products()
        {
            return _productRepository.GetAll().ToList();
        }
        public void ProductInsert(Product entity)
        {
            _productRepository.Insert(entity);
            _dbContext.SaveChanges();
            _dbContext.Dispose();
        }
        public void ProductDelete(int id)
        {
            _productRepository.Delete(id);
            _dbContext.SaveChanges();
            _dbContext.Dispose();
        }
        public void ProductUpdate(Product entity)
        {
            _productRepository.Update(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            _dbContext.Dispose();
        }
    }
}