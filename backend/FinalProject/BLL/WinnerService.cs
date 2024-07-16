using FinalProject.DAL;
using FinalProject.Models;

namespace FinalProject.BLL
{
    public class WinnerService: IWinnerService
    {
        private readonly IWinnerDal WinnerDal;

        public WinnerService(IWinnerDal WinnerDal)
        {
            this.WinnerDal = WinnerDal;
        }
        public async Task<Winner> Add(Winner Winner)
        {
            return await WinnerDal.Add(Winner);
        }
        public async Task<List<Winner>> getAllWinners()
        {
            return await WinnerDal.getAllWinners();
        }
    }
}
