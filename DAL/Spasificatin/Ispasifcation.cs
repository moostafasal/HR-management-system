using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Spasificatin
{
    public interface Ispasifcation<T> where T :class
    {
        Expression<Func<T, bool>> Critera { get; }
        List<Expression<Func<T, Object>>> Includs { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> orderByDesinding { get; }
        int Skip { get; }
        int Take { get; }
        bool IsPageinationON { get; }
    }
}
