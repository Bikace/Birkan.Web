using DenemeProje.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DenemeProje.Repository.Concrete
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private bool disposed = false;

        public EFUnitOfWork(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    _dbContext.Dispose();
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EFRepository<T>(_dbContext);
        }

        public int SaveChanges()
        {

            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException.Message);
            }
        }
    }
}