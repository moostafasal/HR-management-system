using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Spasificatin
{
    public class SpaceficationEvaluat<T> where T : class
    {
        public static IQueryable<T> GetQurey(IQueryable<T> inputQuery, Ispasifcation<T> spec)
        {
            var query = inputQuery;//_dbcontecext<prouduct>()
            if (spec.Critera != null)
                query = query.Where(spec.Critera);
            if (spec.IsPageinationON)
                query = query.Skip(spec.Skip).Take(spec.Take);
            if (spec.OrderBy != null)
                query = query.OrderBy(spec.OrderBy);
            if (spec.orderByDesinding != null)
                query = query.OrderByDescending(spec.orderByDesinding);
            query = spec.Includs.Aggregate(query, (currentQuery, include) => currentQuery.Include(include));

            return query;

        }


    }
}
