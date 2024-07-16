using FinalProject.Models;
using FinalProject.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace FinalProject.DAL
{
    public class GiftDal : IGiftDal
    {
        public Context Context { get; }
       public IWinnerDal win { get; }
        public GiftDal(Context Context, IWinnerDal win)
        {
            this.Context = Context;
            this.win = win;
        }

        public async Task<List<Gift>> getAllGifts()
        {
            try
            {
                return await Context.Gifts.Select(x => x).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Gift> updateGift(int id, Gift gift)
        {
           try
            {
                if (string.IsNullOrEmpty(gift.Name) || gift.DonorId == null
                || gift.CategoryId == null)
                { throw new Exception("Please provide all the necessary fields"); }
                var d = Context.Donors.FirstOrDefault(d => d.Id == gift.DonorId);
                if (d == null)
                {
                    throw new ArgumentException("Donor ID not found in the database");
                }
                var g = Context.Categories.FirstOrDefault(c => c.Id == gift.CategoryId);
                if (g == null)
                {
                    throw new IOException("Category ID not found in the database");
                }
                Gift gg = await Context.Gifts.FirstOrDefaultAsync(g => g.Id == id);
                if (g != null)
                {
                    gg.Name = g.Name;
                    gg.CategoryId = gift.CategoryId;
                    gg.DonorId = gift.DonorId;
                    gg.Price = gift.Price;
                    gg.Image = gift.Image;
                }
                await Context.SaveChangesAsync();
                return gift;
            }
            catch (IOException ex)
            {
                throw new IOException("Category ID not found in the database");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Donor ID not found in the database");
            }
        }

        public async Task<Gift> getGiftById(int id)
        {
            try
            {
                return Context.Gifts.Where(x => x.Id == id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Donor> GetAllDonors(int id)
        {
            try
            {
                Donor donor = Context.Donors.Where(d => d.Id == Context.Gifts.Where(x => x.Id == id).FirstOrDefault().DonorId).FirstOrDefault();
                return donor;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Gift>> SearchByName(string n)
        {
            try
            {
                List<Gift> lg = await Context.Gifts.Where(x => x.Name == n).ToListAsync();
                return lg;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Gift>> SearchGiftsByDonor(string name)
        {
            try
            {
                List<Gift> gifts = await Context.Gifts
                    .Include(g => g.Donor)
                    .Where(g => g.Donor.LastName == name)
                    .ToListAsync();

                return gifts;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Purchase>> HowManybuying(int id)
        {
            List<Purchase> lp = await Context.Purchases.Where(x => x.GiftId == id && x.Status == true).ToListAsync();
            return lp;
        }
        public async Task<List<Purchase>> GetCustomerBuyGift(int Gift)
        {
            List <Purchase> Purchase = await Context.Purchases.Where(x => x.GiftId == Gift).ToListAsync();
            return Purchase;
        }
      
        public async Task<Gift> Add(Gift gift)
        {
            try
            {
                if (string.IsNullOrEmpty(gift.Name) || gift.DonorId == null
                || gift.CategoryId == null)
                { throw new Exception("Please provide all the necessary fields"); }
                var d =Context.Donors.FirstOrDefault(d => d.Id == gift.DonorId);
                if (d==null)
                {
                    throw new ArgumentException("Donor ID not found in the database");
                }
                var g = Context.Categories.FirstOrDefault(c => c.Id == gift.CategoryId);
                if (g == null)
                {
                    throw new IOException("Category ID not found in the database");
                }
                if (gift.IsDrawn == true)
                {
                    throw new IOException("The gift is drawn");
                }
                gift.IsDrawn = false;
                Context.Gifts.Add(gift);
                await Context.SaveChangesAsync();
                return gift;
            }
           
            catch (IOException ex)
            {
                throw new IOException("Category ID not found in the database");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Donor ID not found in the database");
            }
        }
        public async Task<Gift> deleteGift(int giftId) 
        { try 
            {
                var giftToDelete = await Context.Purchases.FirstOrDefaultAsync(g => g.GiftId == giftId);          
                if (giftToDelete!=null) 
                { throw new Exception("Cannot delete the gift as there are buyers associated with it"); }
                Gift g = await Context.Gifts.FirstOrDefaultAsync(x => x.Id == giftId);
                Context.Gifts.Remove(g);
                await Context.SaveChangesAsync();
                return g;
            }
            catch (Exception ex)
            { throw; } 
        }
        public async Task<Winner> DoRaffle(int giftId)
        {
            //List<Purchase> lp=await HowManybuying(giftId);
            //Random random = new Random();
            //int randomIndex = random.Next(0, lp.Capacity- 1);
            //Purchase p= lp.ElementAt(randomIndex);
            //Winner w = new Winner();
            //w.Customer = p.Customer;
            //w.CustomerId = p.CustomerId;
            //w.Gift = p.Gift;
            //w.GiftId = p.GiftId;
            //Context.Winners.Add(w);
            //await Context.SaveChangesAsync();
            //return w;

            List<Purchase> lp = await HowManybuying(giftId);
            Random random = new Random();
            try
            {
                while (true)
                {
                    int randomIndex = random.Next(0, lp.Capacity - 1);
                    Purchase p = lp.ElementAt(randomIndex);
                    Gift g=await Context.Gifts.FirstOrDefaultAsync(g => g.Id == giftId);
                    if (Context.Purchases.Any(purchase => purchase.GiftId == giftId)&&g.IsDrawn==false)
                    {
                        Winner w = new Winner();
                        w.Customer = p.Customer;
                        w.CustomerId = p.CustomerId;
                        w.Gift = p.Gift;
                        w.GiftId = p.GiftId;
                        g.IsDrawn = true;
                        Context.Winners.Add(w);
                        await Context.SaveChangesAsync();
                        return w;
                    }
                    else
                    {
                        throw new Exception("There are no customers who have purchased tickets");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There are no customers who have purchased tickets");
            }

        }
        public async Task<List<Gift>> GetGiftsByCustomer(int CustId)
        {
            try
            {
                List<Purchase> lp =await Context.Purchases.Where(x => x.CustomerId == CustId).ToListAsync();
                List<Gift> lg=new List<Gift>();
                for (int i = 0; i < lp.Count(); i++)
                {
                    lg.Add(await Context.Gifts.FirstOrDefaultAsync(x => x.Id == lp.ElementAt(i).GiftId));
                }
                return lg;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
