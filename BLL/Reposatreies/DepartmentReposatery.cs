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
    public class DepartmentReposatery : GenaricRepo<Department> ,IDepartment
    {
        private readonly MVCDB _dbContext;
        public DepartmentReposatery(MVCDB dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        //public int add(Department department)
        //{
        //    _dbContext.Add(department);
        //    return _dbContext.SaveChanges();
        //}

        //public int delete(Department department)
        //{
        //    _dbContext.Departments.Remove(department);
        //    return _dbContext.SaveChanges();


        //}

        //public IEnumerable<Department> GEtAll()
        //{
        //    return _dbContext.Departments.ToList();
        //}

        //public Department GEtById(int id)
        //{
        //    return _dbContext.Departments.Where(D => D.id == id).FirstOrDefault();

        //}

        //public Department GEtByName(string name)
        //{
        //    return _dbContext.Departments.Where(D => D.Name == name).FirstOrDefault();

        //}

        //public int update(Department department)
        //{
        //    _dbContext.Departments.Update(department);
        //    return _dbContext.SaveChanges();
        //}
    }
    }
