using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.DAL
{
    public class PurchaseDal : IPurchaseDal
    {
        public Context Context { get; }
        public PurchaseDal(Context Context)
        {
            this.Context = Context;
        }

        public async Task<List<Purchase>> getAllPurchases()
        {
            try
            {
                return Context.Purchases.Select(x => x).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Purchase> updatePurchase(int id, Purchase p)
        {
            try
            {
                var d = Context.Customers.FirstOrDefault(d => d.Id == p.CustomerId);
                if (d == null)
                {
                    throw new ArgumentException("Customer ID not found in the database");
                }
                var g = Context.Gifts.FirstOrDefault(c => c.Id == p.GiftId);
                if (g == null)
                {
                    throw new IOException("Category ID not found in the database");
                }
                if (p == null)
                {
                    throw new Exception("You dont");
                }
                else {
                    Purchase pp = await Context.Purchases.FirstOrDefaultAsync(x => x.Id == id);
                    pp.CustomerId = p.CustomerId;
                    pp.Status = p.Status;
                    await Context.SaveChangesAsync();
                    return pp;
                }
            }
            catch (IOException ex)
            {
                throw new IOException("Category ID not found in the database");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Donor ID not found in the database");
            }
            catch(Exception e)
            {
                throw new Exception("what to update?");
            }
        }
        public async Task<Purchase> getPurchaseById(int id)
        {
            try
            {
                List<Purchase> lp = await Context.Purchases.Select(x => x).ToListAsync();
                return lp.Find(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Purchase> Add(Purchase Purchase)
        {
            try
            {
                Context.Purchases.Add(Purchase);
                await Context.SaveChangesAsync();
                return Purchase;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Purchase> deletePurchase(int id)
        {
            try
            {
                List<Purchase> lp = Context.Purchases.Select(x => x).ToList();
                Purchase p = lp.Find(x => x.Id == id);
                Context.Purchases.Remove(p);
                await Context.SaveChangesAsync();
                return p;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Purchase> payment(int id)
        {
            try
            {
                Purchase pp = await Context.Purchases.FirstOrDefaultAsync(x => x.Id == id);
                pp.Status = true;
                await Context.SaveChangesAsync();
                return pp;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //סך ההכנסות מהמכירה
        //public double CalculateTotalPurchaseAmount(List<Purchase> purchases, List<Gift> gifts)
        //{
        //    double totalAmount = 0;

        //    foreach (var purchase in purchases)
        //    {
        //        Gift gift = gifts.FirstOrDefault(g => g.Id == purchase.GiftId);
        //        if (gift != null)
        //        {
        //            totalAmount += gift.Price;
        //        }
        //    }
        //    return totalAmount;
        //}
    }
}
