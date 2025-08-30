using BLL;
using E_Ticaret_Prjesi_AHMT.Models;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.LoginRegister
{
    public class RegisterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(new RegisterViewModel());
        }
    }
}
