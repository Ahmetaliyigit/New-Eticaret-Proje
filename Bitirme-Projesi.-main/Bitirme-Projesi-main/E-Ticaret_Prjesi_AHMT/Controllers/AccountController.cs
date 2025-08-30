
using E_Ticaret_Prjesi_AHMT.Models;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<ApplicationUser> UserManager, RoleManager<IdentityRole> RoleManager)
        {
            userManager = UserManager;
            roleManager = RoleManager;
        }

        public  IActionResult Register()    
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterViewModel register)
        {
           

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.NameSurname = register.NameSurname;
                user.Email = register.Email;
                user.UserName = register.Email; // UserName zorunlu olduğundan böyle yaptım
                
                var result = await userManager.CreateAsync(user , register.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

            }

            return View(register);
        }

    }
}
