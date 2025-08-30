using BLL;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.ShopDetails
{
    public class SelectHeaderViewComponentResult : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
