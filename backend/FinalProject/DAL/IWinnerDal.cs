using FinalProject.Models;

namespace FinalProject.DAL
{
    public interface IWinnerDal
    {
        public Task<List<Winner>> getAllWinners();
        public Task<Winner> Add(Winner winner);
    }
}
