using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using DAL.Entites;
using Microsoft.AspNetCore.Http;

namespace PL.ViewModels
{
    public class EmployeeVeiewModel
    {
        //her w
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is reqoird")]

        public string Name { get; set; }

        [Range(22, 35, ErrorMessage = "Age must be between 22 and 35")]
        public int? age { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal salary { get; set; }
        public bool IsActive { get; set; }

        public string Email { get; set; }
        public string phone { get; set; }
        public DateTime HireDate { get; set; }
        public Department Department { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public IFormFile Image { get; set; }
        public string ImgName { get; set; }

    }
}
