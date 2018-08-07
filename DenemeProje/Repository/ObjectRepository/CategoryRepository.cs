using DenemeProje.Models;
using DenemeProje.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DenemeProje.Repository.Concrete;

namespace DenemeProje.Repository.Concrete
{
    public class CategoryRepository
    {
        private IRepository<Category> _categoryRepository;
        private IUnitOfWork _categoryUnitOfWork;
        private DbContext _dbContext;
        public CategoryRepository()
        {
            _dbContext = new NorthwindEntities();
            _categoryUnitOfWork = new EFUnitOfWork(_dbContext);
            _categoryRepository = new EFRepository<Category>(_dbContext);
        }

        public List<Category> Categories()
        {
            return _categoryRepository.GetAll().ToList();
        }
        public void CategoryInsert(Category entity)
        {
            _categoryRepository.Insert(entity);
            _dbContext.SaveChanges();
            _dbContext.Dispose();
        }
        
        public void CategoryDelete(int id)
        {
            _categoryRepository.Delete(id);
            _dbContext.SaveChanges();
            _dbContext.Dispose();
        }

        public void CategoryUpdate(Category entity)
        {
            _categoryRepository.Update(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;  
            _dbContext.SaveChanges();
            _dbContext.Dispose();
        }
    }
}