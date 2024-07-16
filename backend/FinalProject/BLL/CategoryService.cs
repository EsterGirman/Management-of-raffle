using FinalProject.DAL;
using FinalProject.Models;

namespace FinalProject.BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal CategoryDal;

        public CategoryService(ICategoryDal CategoryDal)
        {
            this.CategoryDal = CategoryDal;
        }
        public async Task<Category> Add(Category Category)
        {
            return await CategoryDal.Add(Category);
        }
        public async Task<List<Category>> getAllCategories()
        {
            return await CategoryDal.getAllCategoryies();
        }
        public async Task<Category> getCategoryById(int id)
        {
            return await CategoryDal.getCategoryById(id);
        }
        public async Task<Category> deleteCategories(int id)
        {
           return await CategoryDal.deleteCategory(id);

        }
        public async Task<Category> updateCategory(int id, Category c)
        {
            return await CategoryDal.updateCategory(id, c);
        }
    }
}
