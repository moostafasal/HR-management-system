using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Spasificatin
{
    public class EmployeeSpasific: BaseSpasifcation<Employee> 
    {
        //apply the base spasification
        public EmployeeSpasific()
        {
            
            Includs.Add(p => p.Department);
            
        }
        public EmployeeSpasific(int id) : base(p => p.Id == id)//CRAITERA
        {
            Includs.Add(p => p.Department);
        }
 


    }
}
