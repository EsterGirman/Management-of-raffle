using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.Models.DTO;

namespace FinalProject.BLL
{
    public class GiftService:IGiftService
    {
        private readonly IGiftDal GiftDal;

        public GiftService(IGiftDal GiftDal)
        {
            this.GiftDal = GiftDal;
        }
        public async Task<Gift> Add(Gift Gift)
        {
            return await GiftDal.Add(Gift);
        }
        public async Task<List<Gift>> getAllGifts()
        {
            return await GiftDal.getAllGifts();
        }
        public async Task<Gift> getGiftById(int id)
        {
            return await GiftDal.getGiftById(id);
        }
        public async Task<Gift> deleteGifts(int id)
        {
          return await GiftDal.deleteGift(id);
        }
        public async Task<Gift> updateGift(int id, Gift g)
        {
            return await GiftDal.updateGift(id, g);
        }
        public async Task<Donor> GetAllDonors(int id)
        {
            return await GiftDal.GetAllDonors(id);
        }
        public async Task<List<Gift>> SearchByName(string n)
        {
            return await GiftDal.SearchByName(n);
        }
        public async Task<List<Gift>> SearchGiftsByDonor(string name)
        {
            return await GiftDal.SearchGiftsByDonor(name);
        }
        public async Task<List<Purchase>> GetCustomerBuyGift(int Gift)
        {
            return await GiftDal.GetCustomerBuyGift(Gift);
        }
        public async Task<Winner> DoRaffle(int giftId)
        {
            return await GiftDal.DoRaffle(giftId);    
        }
        public async Task<List<Gift>> GetGiftsByCustomer(int CustId)
        {
            return await GiftDal.GetGiftsByCustomer(CustId);
        }

    }
}
