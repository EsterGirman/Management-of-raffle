using FinalProject.Models;
using System.Drawing;

namespace FinalProject.DAL
{
    public interface IDonorDal
    {
        public Task<Donor> Add(Donor Donor);
        public Task<List<Donor>> getAllDonors();
        public Task<Donor> getDonorById(int id);
        public Task<Donor> deleteDonor(int id);
        public Task<Donor> updateDonor(int id, Donor d);
        public Task<List<Gift>> GetAllDonates(int id);
        public Task<Donor> GetDonorByName(string Name);
        public Task<Donor> GetDonorByGift(int giftId);
        public Task<Donor> GetDonorByEmail(string Email);

    }
}
