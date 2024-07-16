using FinalProject.DAL;
using FinalProject.Models;

namespace FinalProject.BLL
{
    public class PurchaseService:IPurchaseService
    {
        private readonly IPurchaseDal PurchaseDal;

        public PurchaseService(IPurchaseDal PurchaseDal)
        {
            this.PurchaseDal = PurchaseDal;
        }
        public async Task<Purchase> Add(Purchase Purchase)
        {
            return await PurchaseDal.Add(Purchase);
        }
        public async Task<List<Purchase>> getAllPurchases()
        {
            return await PurchaseDal.getAllPurchases();
        }
        public async Task<Purchase> getPurchaseById(int id)
        {
            return await PurchaseDal.getPurchaseById(id);
        }
        public async Task<Purchase> deletePurchase(int id)
        {
            return await PurchaseDal.deletePurchase(id);
        }
        public async Task<Purchase> updatePurchase(int id, Purchase p)
        {
            return await PurchaseDal.updatePurchase(id, p);
        }
        public async Task<Purchase> payment(int p)
        {
            return await PurchaseDal.payment(p);
        }


    }
}
