using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.Index
{
    public class SelectMenuCategoriesViewComponentPartial : ViewComponent
    {
        IProductService service;
        ICategoryService CategoryService;

        public SelectMenuCategoriesViewComponentPartial(IProductService pro, ICategoryService categoryService)
        {
            service = pro;
            CategoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await CategoryService.GetCategoryWithProduct());
        }
    }
}
