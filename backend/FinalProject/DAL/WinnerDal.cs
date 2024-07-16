using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;

namespace FinalProject.DAL
{
    public class WinnerDal: IWinnerDal
    {
        public Context Context { get; }
        public WinnerDal(Context Context)
        {
            this.Context = Context;
        }
        public async Task<List<Winner>> getAllWinners()
        {
            try
            {
                return await Context.Winners.Select(x => x).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Winner> Add(Winner winner)
        {
            try
            {
                if (winner.Customer == null || winner.Gift == null )
                { throw new Exception("Please provide all the necessary fields"); }
                var x = Context.Customers.FirstOrDefault(c => c.Id == winner.CustomerId);
                if (x == null)
                {
                    throw new ArgumentException("Customer ID not found in the database");
                }
                var g = Context.Gifts.FirstOrDefault(c => c.Id == winner.GiftId);
                if (g == null)
                {
                    throw new IOException("Gift ID not found in the database");
                }
                Context.Winners.Add(winner);
                await Context.SaveChangesAsync();
                return winner;
            }

            catch (IOException ex)
            {
                throw new IOException("Customer ID not found in the database");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Gift ID not found in the database");
            }
        }
    }
}
