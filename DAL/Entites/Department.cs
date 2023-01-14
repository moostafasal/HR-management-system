using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Department
    {
        public int id { get; set; }
        [Required(ErrorMessage ="CODE is REQuerd")]
        public string Code { get; set; }
        [Required(ErrorMessage = "name is REQuerd")]
        [MaxLength(50,ErrorMessage ="max lenth is 50")]
        public string Name { get; set; }

        public DateTime DateOfCaraTion { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

    }
}
