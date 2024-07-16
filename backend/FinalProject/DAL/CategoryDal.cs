using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.DAL
{
    public class CategoryDal : ICategoryDal
    {
        public Context Context { get; }
        public CategoryDal(Context Context)
        {
            this.Context = Context;
        }

        public async Task<List<Category>> getAllCategoryies()
        {
            try
            {
                return await Context.Categories.Select(x => x).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<Category> getCategoryById(int id)
        {///////////////////////////can effect
            try
            {
                List<Category> lc = await Context.Categories.Select(x => x).ToListAsync();
                return lc.Find(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Category> updateCategory(int id, Category c)
        {
            try
            {

                Category cc = await Context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                cc.Description = c.Description;
                cc.Name = c.Name;
                await Context.SaveChangesAsync();
                return cc;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Category> Add(Category Category)
        {
            try
            {
                await Context.Categories.AddAsync(Category);
                await Context.SaveChangesAsync();
                return Category;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Category> deleteCategory(int id)
        {
            try
            {
                Category c = await Context.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
                Context.Categories.Remove(c);
                await Context.SaveChangesAsync();
                return c;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
