using DAL.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Authorize(Roles = "Admin")]

    public class UserController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public UserController(UserManager<ApplicationUser> userManager) 
		{
			_userManager = userManager;
		}


        public async Task<IActionResult> Index(string serchvalue="")
        {
            if (string.IsNullOrEmpty(serchvalue))
            {
                var user = _userManager.Users;
                return View(user);
            }
            else
            {
                var users =await _userManager.Users.Where(U => U.NormalizedEmail.Contains(serchvalue.ToUpper())).ToListAsync();
                return View(users);
            }


        }

        public async Task< IActionResult> Details(string id, string viewName = "Details")
        {
            if (id == null)
                return BadRequest();
            var user =await _userManager.FindByIdAsync(id);
            if (user is null)
                return NotFound();
            return View(viewName, user);
        }

        public async Task< IActionResult> Update(string id)
        {
            return await Details(id, "Update");

        }
        [HttpPost]
        public async Task<IActionResult> Update(string id, ApplicationUser user)
        {
            if (id != user.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var appUser = await _userManager.FindByIdAsync(id);

                    appUser.UserName = user.UserName;
                    appUser.NormalizedUserName = user.UserName.ToUpper();
                    appUser.PhoneNumber = user.PhoneNumber;

                    var result = await _userManager.UpdateAsync(appUser);
                    if (result.Succeeded)
                        return RedirectToAction(nameof(Index));

                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);

                }
                catch (System.Exception)
                {

                    throw;
                }
            }
            return View(user);

        }
        public async Task<IActionResult> Delete(string id, ApplicationUser user)
        {
            if (id != user.Id)
                return BadRequest();

            try
            {
                var appUser = await _userManager.FindByIdAsync(id);

                var result = await _userManager.DeleteAsync(appUser);

                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));

                ViewBag.Errors = result.Errors;
            }
            catch (Exception )
            {

            }

            return RedirectToAction(nameof(Index));
        }
    }
}
