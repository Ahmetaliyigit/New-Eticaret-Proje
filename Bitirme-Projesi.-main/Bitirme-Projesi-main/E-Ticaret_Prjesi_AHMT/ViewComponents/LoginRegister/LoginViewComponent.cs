using E_Ticaret_Prjesi_AHMT.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.LoginRegister
{
    public class LoginViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {       
            return View(new LoginViewModel());
        }
    }
}
