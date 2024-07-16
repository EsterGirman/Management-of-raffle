using FinalProject.Models;

namespace FinalProject.BLL
{
    public interface IPurchaseService
    {
        public Task<Purchase> Add(Purchase Purchase);
        public Task<List<Purchase>> getAllPurchases();
        public Task<Purchase> getPurchaseById(int id);
        public Task<Purchase> deletePurchase(int id);
        public Task<Purchase> updatePurchase(int id, Purchase p);
        public Task<Purchase> payment(int p);
        
    }
}
