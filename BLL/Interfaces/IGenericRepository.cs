using DAL.Spasificatin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
       Task <IEnumerable<T>> GEtAll();
        Task<  T >GEtByName(string name);
        Task<IEnumerable<T>> GetAllWithSpecAsync(Ispasifcation<T> spec);

        Task<T> GetIdwithspecAsync(Ispasifcation<T> spec);
        Task<T> GEtById(int id);
        Task<int> add(T item);
        Task<int> update(T item);
       Task< int> delete(T item);
    }
}