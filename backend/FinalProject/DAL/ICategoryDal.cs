using FinalProject.Models;
using FinalProject.Models.DTO;

namespace FinalProject.DAL
{
    public interface ICategoryDal
    {
        Context Context { get; }
        Task<Category> Add(Category Category);
        Task<Category> deleteCategory(int id);
        Task<List<Category>> getAllCategoryies();
        Task<Category> getCategoryById(int id);
        Task<Category> updateCategory(int id, Category c);
    }
}
