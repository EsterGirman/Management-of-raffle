using FinalProject.Models;

namespace FinalProject.BLL
{
    public interface ICategoryService
    {
        public  Task<Category> Add(Category Category);
        public  Task<List<Category>> getAllCategories();
        public  Task<Category> getCategoryById(int id);
        public Task<Category> deleteCategories(int id);
        public Task<Category> updateCategory(int id, Category c);

    }
}
