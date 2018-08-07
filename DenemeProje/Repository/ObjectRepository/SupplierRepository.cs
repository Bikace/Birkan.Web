using DenemeProje.Models;
using DenemeProje.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DenemeProje.Repository.Concrete
{
    public class SupplierRepository
    {
        private IRepository<Supplier> _supplierRepository;
        private IUnitOfWork _supplierUnitOfWork;
        private DbContext _dbContext;
        public SupplierRepository()
        {
            _dbContext = new NorthwindEntities();
            _supplierUnitOfWork = new EFUnitOfWork(_dbContext);
            _supplierRepository = new EFRepository<Supplier>(_dbContext);
        }

        public List<Supplier> Suppliers()
        {
            return _supplierRepository.GetAll().OrderBy(p => p.SupplierID).Take(8).ToList();
        }

        public void SupplierInsert(Supplier entity)
        {
            _supplierRepository.Insert(entity);
            _dbContext.SaveChanges();
            _dbContext.Dispose();
        }
        public void SupplierDelete(int id)
        {
            _supplierRepository.Delete(id);
            _dbContext.SaveChanges();
            _dbContext.Dispose();
        }

        public void SupplierUpdate(Supplier entity)
        {
            _supplierRepository.Update(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            _dbContext.Dispose();
        }
    }
}