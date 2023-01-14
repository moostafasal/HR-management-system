using BLL.Interfaces;
using DAL.Context;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Reposatreies
{
    public class EmployeeRepo : GenaricRepo<Employee>, IEmployee
    {
        private readonly MVCDB _dbContext;

        public EmployeeRepo(MVCDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Employee> GetEmployeesByDepartmentName(string name)
        {
            return _dbContext.Employees.Where(E => E.Department.Name == name);
        }

        public IQueryable<Employee> GetEmployeesByName(string name)
        {
            return _dbContext.Employees.Where(E => E.Name.Contains(name));
        }
    }
}
