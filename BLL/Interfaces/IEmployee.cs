using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEmployee:IGenericRepository<Employee>
    {
        IQueryable<Employee> GetEmployeesByDepartmentName(string name);
        IQueryable<Employee> GetEmployeesByName(string name);

    }
}
