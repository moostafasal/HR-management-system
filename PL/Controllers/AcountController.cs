using DAL.Entites;
using DAL.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PL.Helper;
using PL.ViewModels;
using System.Threading.Tasks;

namespace PL.Controllers
{
    //[Authorize]
    public class AcountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AcountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region suing up 
        public IActionResult Regester()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Regester(RegersterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //manul maper=>
                var user = new ApplicationUser()
                {
                    UserName = model.Email.Split("@")[0],
                    Email = model.Email,
                    IsAgree = model.IsAgree

                };
                var result = await _userManager.CreateAsync(user, model.password);

                if (result.Succeeded)
                    return RedirectToAction(nameof(Login));

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        #endregion

        #region SignIn
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user is null)
                    ModelState.AddModelError("", "Invalid Email");

                var password = await _userManager.CheckPasswordAsync(user, model.Password);

                if (password)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
        #endregion

        #region Singout
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        #endregion

        #region ForgetPassword
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPassVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPass = Url.Action("ResetPasswordDone", "Acount", new { email = model.Email ,token=token},Request.Scheme);
                    var email = new Email()
                    { 
                        Title = "Rest your password",
                        To = model.Email,
                        Body = resetPass

                    };
                    EmailSetting.Send(email);
                    return RedirectToAction(nameof(inbox));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email not found back and regester:)");
                };


            }

            return View(model);


        }

        #endregion

        public IActionResult inbox()
        {
            return View();
        }
        #region Reset Pass
        public IActionResult ResetPasswordDone(string Email,string token)
        {
            TempData["Email"]=Email;
            TempData["Token"] = token;
            return View();

        }
        [HttpPost]
        public async Task< IActionResult> ResetPasswordDone(ResetPassVM model)
        {


            if (ModelState.IsValid)
            {
            string Email = TempData["Email"] as string;
            string token = TempData["Token"] as string;
                var user= await _userManager.FindByEmailAsync(Email);

                var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Login));
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        #endregion








    }
}








    
