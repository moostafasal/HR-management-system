using AutoMapper;
using DAL.Entites;
using PL.ViewModels;

namespace PL.Mapper
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeVeiewModel, Employee>().ReverseMap();
        }
    }
}
