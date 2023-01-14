using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Employee
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Name is reqoird")]
        [MaxLength(50,ErrorMessage ="Max lenth is 50")]
        public string Name { get; set; }
        [Range(22,35,ErrorMessage ="Age must be between 22 and 35")]
        public int? age { get; set; }
        //[RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",ErrorMessage ="Adders must be like 123-street-City-Country")]
        public string Address { get; set; }
        [Range(4000,8000)]
        [DataType(DataType.Currency)]
        public decimal salary { get; set; }
        public bool IsActive { get;  set; }
        [EmailAddress]

        public string Email { get; set; }
        [Phone]
        public string phone { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public Department Department { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public string ImgName { get; set; }

    }
}
