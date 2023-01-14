using BLL.Interfaces;
using DAL.Context;
using DAL.Entites;
using DAL.Spasificatin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Reposatreies
{
    public class GenaricRepo<T>: IGenericRepository<T> where T :class 
    {

        private readonly MVCDB _dbContext;
            public GenaricRepo(MVCDB dbContext)
            {
                _dbContext = dbContext;
            }

        //public int add(T obj)
        //{
        //    _dbContext.Add(T);
        //    return _dbContext.SaveChanges();
        //}
        public async Task< int> add(T item)
        {
            await _dbContext.Set<T>().AddAsync(item);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> delete(T T)
            {
                _dbContext.Set<T>().Remove(T);
                return await _dbContext.SaveChangesAsync();


            }

            public async Task<IEnumerable<T>> GEtAll()
            {
            if (typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>) await _dbContext.Set<Employee>().Include(E => E.Department).ToListAsync();
            }
            else
            {



                return await _dbContext.Set<T>().ToListAsync();
            }

             }
        
        public async Task<IEnumerable<T>> GEtById()
        {
            if (typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>)await _dbContext.Set<Employee>().Include(E => E.Department).Where(E => E.Id == E.Id).ToListAsync();
            }
            else
            {



                return await _dbContext.Set<T>().ToListAsync();
            }

        }




        public async Task<T> GEtById(int id)
        {
            //get department of employee by id
            if (typeof(T) == typeof(Employee))
            {
                return (T)(object)await _dbContext.Set<Employee>().Include(E => E.Department).Where(E => E.Id == id).FirstOrDefaultAsync();
            }
            else
            {
                return await _dbContext.Set<T>().FindAsync(id);
            }



        }

        public async Task< T> GEtByName(string name)
        {
            return await _dbContext.Set<T>().FindAsync(name);

        }

        public async Task< int> update(T item)
            {

                _dbContext.Set<T>().Update(item);
                return await _dbContext.SaveChangesAsync();
            }

        //public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(Ispasifcation<T> spec)
        //{

        //    return await ApplySpasifcation(spec).ToListAsync();

        //}
        public async Task<T> GetIdwithspecAsync(Ispasifcation<T> spec)
        {

            return await ApplySpasifcation(spec).FirstOrDefaultAsync();

        }

        private IQueryable<T> ApplySpasifcation(Ispasifcation<T> spec)
        {
            return SpaceficationEvaluat<T>.GetQurey(_dbContext.Set<T>(), spec);
        }

      async  Task<IEnumerable<T>> IGenericRepository<T>.GetAllWithSpecAsync(Ispasifcation<T> spec)
        {
            return await ApplySpasifcation(spec).ToListAsync();
        }
    }
}
