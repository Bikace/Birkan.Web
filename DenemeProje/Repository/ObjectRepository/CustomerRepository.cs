using DenemeProje.Models;
using DenemeProje.Repository.Abstract;
using DenemeProje.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _AccountingWebApp.Repository.Concrete
{
    public class CustomerRepository
    {
        private IRepository<Customer> _customerRepository;
        private IUnitOfWork _customerUnitOfWork;
        private DbContext _dbContext;
        public CustomerRepository()
        {
            _dbContext = new NorthwindEntities();
            _customerUnitOfWork = new EFUnitOfWork(_dbContext);
            _customerRepository = new EFRepository<Customer>(_dbContext);
        }

        public List<Customer> Customers()
        {
            return _customerRepository.GetAll().ToList();
        }
        public void CategoryInsert(Customer entity)
        {
            _customerRepository.Insert(entity);
            _dbContext.SaveChanges();
            _dbContext.Dispose();
        }
        public void CustomerDelete(int id)
        {
            _customerRepository.Delete(id);
            _dbContext.SaveChanges();
            _dbContext.Dispose();
        }
        public void CustomerUpdate(Customer entity)
        {
            _customerRepository.Update(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            _dbContext.Dispose();
        }
    }
}