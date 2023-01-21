using BLL.Interfaces;
using DAL.Context;
using DAL.Entites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Reposatreies
{
    public class UintOfWork : IUintOfWork
    {

        //Aoutomutc prop
        public UintOfWork(MVCDB context)
        {
            _context = context;
        }
        private Hashtable _Reposatry;
        private readonly MVCDB _context;


        public IGenericRepository<TEntity> reposatery<TEntity>() where TEntity : class
        {
            if(_Reposatry == null)
                _Reposatry = new Hashtable();

              var type = typeof(TEntity).Name;
            if (!_Reposatry.Contains(type))
            {
                var Repo = new GenaricRepo<TEntity>(_context);
                _Reposatry.Add(type, Repo);
            }
            return (IGenericRepository<TEntity>) _Reposatry[type];
        }
 



        public async Task<int> complet()
              => await _context.SaveChangesAsync();
        public void Dispose()
        {
            _context.Dispose();
        }

        public IEmployee EmployeeRepo()
        {
          return (IEmployee)reposatery<Employee>(); 
        }
    }
}
