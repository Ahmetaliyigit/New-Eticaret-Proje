using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.Contact
{
    public class SelectContactPageViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
