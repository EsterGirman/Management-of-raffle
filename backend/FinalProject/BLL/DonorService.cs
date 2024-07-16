using FinalProject.DAL;
using FinalProject.Models;

namespace FinalProject.BLL
{
    public class DonorService:IDonorService
    {
        private readonly IDonorDal DonorDal;

        public DonorService(IDonorDal DonorDal)
        {
            this.DonorDal = DonorDal;
        }
        public async Task<Donor> Add(Donor Donor)
        {
           return  await DonorDal.Add(Donor);
        }
        public async Task<List<Donor>> getAllDonors()
        {
            return await DonorDal.getAllDonors();
        }
        public async Task<Donor> getDonorById(int id)
        {
            return await DonorDal.getDonorById(id);
        }
        public async Task<Donor> deleteDonors(int id)
        {
           return await DonorDal.deleteDonor(id);
        }
        public async Task<Donor> updateDonor(int id, Donor c)
        {
            return await DonorDal.updateDonor(id, c);
        }
        public async Task<List<Gift>> GetAllDonates(int id)
        {
            return await DonorDal.GetAllDonates(id);
        }
        public async Task<Donor> GetDonorByName(string Name)
        {
            return await DonorDal.GetDonorByName(Name);
        }
        public async Task<Donor> GetDonorByGift(int giftId)
        {
            return await DonorDal.GetDonorByGift(giftId);
        }
        public async Task<Donor> GetDonorByEmail(string Email)
        {
            return await DonorDal.GetDonorByEmail(Email);
        }
    }
}
