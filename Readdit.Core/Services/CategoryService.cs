using Readdit.Core.Contracts;
using Readdit.Core.DTOs;
using Readdit.Data;
using Readdit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Readdit.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BookshelfDbContext dbContext;
        public CategoryService(BookshelfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddNewCategory(CategoryDto model)
        {
            Category category = new Category()
            {
                CategoryName = model.Name,
            };
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> FindCategoryByName(string name)
        {
            return await dbContext.Categories.AnyAsync(x => x.CategoryName == name);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            return await dbContext.Categories.Select(c => new CategoryDto
            {
                Id = c.CategoryId,
                Name = c.CategoryName,
            }).ToListAsync();
        }
    }
}
