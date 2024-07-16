using FinalProject.Models;

namespace FinalProject.BLL
{
    public interface IWinnerService
    {
        public Task<Winner> Add(Winner Winner);
        public Task<List<Winner>> getAllWinners();
    }
}
