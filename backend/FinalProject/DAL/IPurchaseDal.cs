using FinalProject.Models;

namespace FinalProject.DAL
{
    public interface IPurchaseDal
    {
        public Task<Purchase> Add(Purchase Owner);
        public Task<List<Purchase>> getAllPurchases();
        public Task<Purchase> getPurchaseById(int id);
        public Task<Purchase> deletePurchase(int id);
        public Task<Purchase> updatePurchase(int id, Purchase p);
        public Task<Purchase> payment(int p);
       // public double CalculateTotalPurchaseAmount(List<Purchase> purchases, List<Gift> gifts);
    }
}
