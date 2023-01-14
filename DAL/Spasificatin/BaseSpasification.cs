using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Spasificatin
{

    public class BaseSpasifcation<T> : Ispasifcation<T> where T : class
    {
        //prop
        public Expression<Func<T, bool>> Critera { get; set; }
        public List<Expression<Func<T, Object>>> Includs { get; set; }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> orderByDesinding { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPageinationON { get; set; }
        public BaseSpasifcation()
        {
            Includs = new List<Expression<Func<T, Object>>>();

        }
        public BaseSpasifcation(Expression<Func<T, bool>> Critera)
        {
            this.Critera = Critera;

            Includs = new List<Expression<Func<T, Object>>>();


        }
        public void AddOrderBy(Expression<Func<T, object>> ordrrBy)
        {
            OrderBy = ordrrBy;
        }
        public void AddOrderByDes(Expression<Func<T, object>> orderbyDes)
        {
            orderByDesinding = orderbyDes;
        }

        public void AddInclud(Expression<Func<T, Object>> includeEx)
        {
            Includs.Add(includeEx);
            //Includs.Add(P => P.ProductType);


        }
        public void ApplyPigination(int skip, int take)
        {
            IsPageinationON = true;
            Skip = skip;
            Take = take;

        }
    }

}
