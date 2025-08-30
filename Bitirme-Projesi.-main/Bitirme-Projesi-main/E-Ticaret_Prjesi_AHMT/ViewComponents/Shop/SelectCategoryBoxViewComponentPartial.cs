using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.Shop
{
    public class SelectCategoryBoxViewComponentPartial : ViewComponent
    {
        ICategoryService service;

        public SelectCategoryBoxViewComponentPartial(ICategoryService categoryService)
        {
            service = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await service.GetAllAsync());
        }
    }
}
