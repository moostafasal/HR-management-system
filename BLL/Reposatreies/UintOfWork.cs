using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Reposatreies
{
    public class UintOfWork:IUintOfWork 
    {
        //Aoutomutc prop
        public IDepartment _DepartmentReposatry { get; set; }
        public IEmployee _EmployeeReposatry { get; set; }

        public UintOfWork(IEmployee employeeReposatry ,IDepartment departmentReposatrey ) 
        {
            _EmployeeReposatry = employeeReposatry;
            _DepartmentReposatry = departmentReposatrey;
        }

        public IGenericRepository<TEntity> reposatery<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<int> complet()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
