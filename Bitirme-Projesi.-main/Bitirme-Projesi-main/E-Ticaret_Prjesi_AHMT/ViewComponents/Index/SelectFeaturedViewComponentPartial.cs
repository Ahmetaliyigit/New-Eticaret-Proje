using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.Index
{
    public class SelectFeaturedViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
