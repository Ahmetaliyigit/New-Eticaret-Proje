
    using E_Ticaret_Prjesi_AHMT.Models;
    using E_Ticaret_Prjesi_AHMT.Controllers;
    using Entity;
    using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace E_Ticaret_Prjesi_AHMT.Controllers
{
    public class AccountController : Controller
    {
            private readonly UserManager<ApplicationUser> userManager;
            private readonly RoleManager<IdentityRole> roleManager;
            private readonly SignInManager<ApplicationUser> signInManager;

            public AccountController(UserManager<ApplicationUser> UserManager, RoleManager<IdentityRole> RoleManager, SignInManager<ApplicationUser> Sign)
            {
                userManager = UserManager;
                roleManager = RoleManager;
                signInManager = Sign;
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
                    user.EmailConfirmed = true;


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
                         Program.OnlineUser = user ;
                         return RedirectToAction("Index", "Home");
                    }

                }

                return View(register);
            }


            public IActionResult Login()
            {
                return View("LoginRegister",new LoginViewModel());
            }

            [HttpPost]
            [ValidateAntiForgeryToken]

            public async Task<IActionResult> Login(LoginViewModel login)
            {

                if (!ModelState.IsValid)
                {
                    return View("~/Views/Home/LoginRegister.cshtml", login);
                }

                var user = userManager.Users.FirstOrDefault(u => u.Email.ToLower() == login.Email.ToLower());

                if (user != null)
                {
               
                    var result = await signInManager.PasswordSignInAsync(user, login.Password, false, false);
                    
                    if (result.Succeeded)
                    {
                        Program.OnlineUser = new ApplicationUser();
                        Program.OnlineUser = user;
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Geçersiz giriş denemesi.");
                return View("~/Views/Home/LoginRegister.cshtml", login);
            }

        }
    }
