using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.Checkout
{
    public class SelectCheckoutPageViewComponentResult : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
