using DenemeProje.Models;
using DenemeProje.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DenemeProje.Repository.Concrete
{
    public class EmployeeRepository
    {
        private IRepository<Employee> _employeeRepository;
        private IUnitOfWork _employeeUnitOfWork;
        private DbContext _dbContext;
        public EmployeeRepository()
        {
            _dbContext = new NorthwindEntities();
            _employeeUnitOfWork = new EFUnitOfWork(_dbContext);
            _employeeRepository = new EFRepository<Employee>(_dbContext);
        }

        public List<Employee> Employees()
        {
            return _employeeRepository.GetAll().ToList();
        }
        //public void EmployeeInsert(EmployeeModel model)
        //{
        //    MembershipCreateStatus status;
        //    Membership.CreateUser(model.UserName, model.Password, model.Email, "soru", "cevap", true, out status);
        //    if (status == MembershipCreateStatus.Success)
        //    {
        //        Guid id = (Guid)Membership.GetUser(model.UserName).ProviderUserKey;
        //        _employeeRepository.Insert(new Models.Employee
        //        {

        //            BirthDate = model.BirthDate,
        //            EmployeeId = id,
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            Notes = model.Notes,
        //            Phone = model.Phone,
        //            Title = model.Title
        //        });
        //        _dbContext.SaveChanges();
        //        _dbContext.Dispose();
        //    }
        //}
    }
}