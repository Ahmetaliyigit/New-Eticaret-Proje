using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.Index
{
    public class SelectOfferViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
