using AutoMapper;
using BLL.Interfaces;
using DAL.Entites;
using DAL.Spasificatin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Helper;
using PL.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Authorize]

    public class EmployeeController : Controller
    {
        private readonly IUintOfWork _uintOfWork;

        //private readonly IEmployee _employee;
        //private readonly IDepartment _department;
        private readonly IMapper _mapper;

        public EmployeeController(IUintOfWork uintOfWork,IMapper mapper)
        {
           _uintOfWork = uintOfWork;
            // ask IDepartmetn to get a data from Department=== in veiw data in Employee controller 
            //_employee = employee;
            //_department = department;
            _mapper = mapper;
        }



        public async Task<IActionResult> Index(string serchvalue)
        {
            if (string.IsNullOrEmpty(serchvalue))
            {
                var Employee = await _uintOfWork._EmployeeReposatry.GEtAll();
                var mappEmployee = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeVeiewModel>>(Employee);
                return View(mappEmployee);
            }
            else
            {
                var employees= _uintOfWork._EmployeeReposatry.GetEmployeesByName(serchvalue);
                var mappEmployee = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeVeiewModel>>(employees);
                return View(mappEmployee); 
            }

        }
        public async Task <IActionResult> Create()
        {
            //call Department Reposatry to get Department :)
            ViewBag.Department =await _uintOfWork._DepartmentReposatry.GEtAll();
              return  View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVeiewModel Employeevm)
        {
            ViewBag.Department = await _uintOfWork._DepartmentReposatry.GEtAll();

            if (ModelState.IsValid)//server side VALIDATION

            {
                //manoul maping
                    ///    Name=Employeevm.Name,
                    ///    Address= Employeevm.Address,
                    ///    age= Employeevm.age,
                    ///    salary= Employeevm.salary,
                    ///    Email= Employeevm.Email,
                    ///    DepartmentId= Employeevm.DepartmentId,
                    ///    IsActive= Employeevm.IsActive,
                
                   Employeevm.ImgName= DecoumentSeting.UploadFiles(Employeevm.Image, "Imges");
                    //thes is a just basic mapping salary ==salery and salary != EMSAlae :)
                var mappEmp = _mapper.Map<EmployeeVeiewModel,Employee>(Employeevm);
                await    _uintOfWork._EmployeeReposatry.add(mappEmp);
                return  RedirectToAction(nameof(Index));
                    
               

            } 
            return View(Employeevm);
        }
        //Employee/details/id
        public async Task < IActionResult >Details(int? id, string ViewName = "Details")
        {
            if (id == null)
            {
                return NotFound();
            }
            var spec = new EmployeeSpasific(id.Value);
            var Employee = await _uintOfWork._EmployeeReposatry.GetIdwithspecAsync(spec);


            //if (id == null)
            //    return NotFound();
         
            //if (Employee == null)
            
            //    return NotFound();
            

            var mappEmployees = _mapper.Map<Employee, EmployeeVeiewModel>(Employee);
            return View(ViewName, mappEmployees);

        }
        public  async Task < IActionResult> Edit(int? id)
        {
            ViewBag.Department = _uintOfWork._DepartmentReposatry.GEtAll();

            //if (id == null)
            //    return NotFound();
            //var Employee =  _employee.GEtById(id.Value);
            //if (Employee == null)
            //    return NotFound();
            //return View(Employee);
            return await Details(id, "Edit");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Edit([FromRoute] int id, EmployeeVeiewModel EmployeeVm)
        {

            //if (id != Employee.Id)
            //    return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var mappEp = _mapper.Map<EmployeeVeiewModel, Employee>(EmployeeVm);
                  await  _uintOfWork._EmployeeReposatry.update(mappEp);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception cw)
                {
                    ModelState.AddModelError("", cw.Message);
                    return View(EmployeeVm);
                }
            }
            return View(EmployeeVm);
        }
        public  async  Task<IActionResult> Delete(int id)
        {
            return await Details(id, "Delete");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int? id, EmployeeVeiewModel EmployeevM)
        {
            //if (id != Employee.Id)
            //{
            //    return BadRequest();
            //}
            if (ModelState.IsValid)
            {

                try
                {
                    var mappEp = _mapper.Map<EmployeeVeiewModel, Employee>(EmployeevM);

                  await  _uintOfWork._EmployeeReposatry.delete(mappEp);
                    DecoumentSeting.DeleFile(EmployeevM.ImgName, "Imges");
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception xe)
                {
                    ModelState.AddModelError("", xe.Message);
                    return View(EmployeevM);


                }

            }
            return View();



        }
    }
}
