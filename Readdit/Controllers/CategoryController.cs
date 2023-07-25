using Readdit.Core.Contracts;
using Readdit.Core.DTOs;
using Readdit.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Readdit.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categoryNames = await categoryService.GetAllCategories();
            var model = new CategoryViewModel(categoryNames.Select(x => x.Name).ToList());
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                var newCat = await categoryService.GetAllCategories();
                category.CategoryNames = newCat.Select(x => x.Name).ToList();
                return View(category);
            }
            CategoryDto dto = new CategoryDto
            {
                Name = category.Name
            };
            await categoryService.AddNewCategory(dto);


            return RedirectToAction(nameof(RequestController.Add), "Request");
        }
    }
}
