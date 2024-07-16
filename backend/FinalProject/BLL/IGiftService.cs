using FinalProject.Models;
using FinalProject.Models.DTO;

namespace FinalProject.BLL
{
    public interface IGiftService
    {
        public Task<Gift> Add(Gift Gift);
        public Task<List<Gift>> getAllGifts();
        public Task<Gift> getGiftById(int id);
        public Task<Gift> deleteGifts(int id);
        public Task<Gift> updateGift(int id, Gift g);
        public Task<Donor> GetAllDonors(int id);
        public Task<List<Gift>> SearchByName(string n);
        public Task<List<Gift>> SearchGiftsByDonor(string name);
        public Task<List<Purchase>> GetCustomerBuyGift(int Gift);
        public Task<Winner> DoRaffle(int giftId);
        public Task<List<Gift>> GetGiftsByCustomer(int CustId);

    }
}
