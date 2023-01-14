using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using DAL.Entites;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Authorize]

    public class DepartmentController : Controller
    {
        private readonly IDepartment _Department;
        public DepartmentController(IDepartment  Department)
        {
            _Department = Department;
        }



        public async Task< IActionResult> Index()
        {
            var department =await _Department.GEtAll();
            return View(department);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async  Task< IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)//server side VALIDATION
            {
                await _Department.add(department);
                TempData["massage"] = "Departmet is Created sucsesfly";
               return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        //department/details/id
        public async Task< IActionResult>  Details(int? id,string ViewName= "Details")
        {
            if (id == null)
                return NotFound();
            var department= await _Department.GEtById(id.Value);
            if (department == null)
                return NotFound();
            return View(ViewName,department);

        }
        public async Task < IActionResult> Edit(int?id)
        {
            //if (id == null)
            //    return NotFound();
            //var department = _repos.GEtById(id.Value);
            //if (department == null)
            //    return NotFound();
            //return View(department);
            return await Details(id,"Edit");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Department department)
        {
            if (id != department.id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _Department.update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch(System.Exception cw)
                {
                    ModelState.AddModelError("", cw.Message);
                    return View(department);
                }
            }
            return View(department);
        }
        public async Task< IActionResult> Delete(int id)
        {
            return await Details(id, "Delete");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int? id ,Department department)
        {
            if (id != department.id)
            {
                return BadRequest();
            }
            try
            {
                _Department.delete(department);
                TempData["DeletMasseg"] = "Departmet is Deleted XX";


                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception xe)
            {
                ModelState.AddModelError("", xe.Message);
                return View(department);

                
            }
                  
                 
        }
    }
}
