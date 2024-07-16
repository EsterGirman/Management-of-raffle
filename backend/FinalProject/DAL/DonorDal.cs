using FinalProject.Models;
using FinalProject.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Drawing;
using System.Text.RegularExpressions;

namespace FinalProject.DAL
{
    public class DonorDal:IDonorDal
    {
        public Context Context { get; }
        public DonorDal(Context Context)
        {
            this.Context = Context;
        }

        public async Task<List<Donor>> getAllDonors()
        {
            try
            {
                return Context.Donors.Select(x => x).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Donor> updateDonor(int id, Donor d)
        {
            try
            {
                validations(d);
                Donor dd = await Context.Donors.FirstOrDefaultAsync(x => x.Id==id);
                dd.FirstName = d.FirstName;
                dd.LastName = d.LastName;
                dd.Phone = d.Phone;
                await Context.SaveChangesAsync();
                return dd;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Donor> getDonorById(int id)
        {
            try
            {
                 List<Donor> ld =await Context.Donors.Select(x => x).Where(x => x.Id == id).ToListAsync();
                return ld[0];
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Donor> Add(Donor Donor)
        {
            try
            {
                validations(Donor);
                Context.Donors.Add(Donor);
                Context.SaveChanges();
                return Donor;
            }
            catch(InvalidOperationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
            
        }
        public void validations(Donor Donor)
        {
            if (string.IsNullOrEmpty(Donor.FirstName)
             || string.IsNullOrEmpty(Donor.LastName)
             || string.IsNullOrEmpty(Donor.Phone)
             || string.IsNullOrEmpty(Donor.Password)
             || string.IsNullOrEmpty(Donor.Password))
            {
                throw new Exception("Please provide all the necessary fields");
            }
            if (!ValidateEmail(Donor.Email))
            {
                throw new InvalidOperationException("Invalid email address format");
            }

            if (Donor.FirstName.Length < 2 || Donor.LastName.Length < 2)
            {
                throw new InvalidOperationException("First name and last name must contain at least 2 characters");
            }

            if (!HasOnlyDigits(Donor.Phone) || Donor.Phone.Length < 10)
            {
                throw new InvalidOperationException("Phone number must contain only digits and be at least 10 characters long");
            }
        }
        public bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }

        public bool HasOnlyDigits(string input)
        {
            return input.All(char.IsDigit);
        }

        public async Task<Donor> deleteDonor(int id)
        {
            try
            {
                var donorToDelete = await Context.Gifts.FirstOrDefaultAsync(g => g.DonorId == id);
                if (donorToDelete != null)
                { throw new Exception("Cannot delete the donor as there are gifts associated with it"); }
                List<Donor> ld =await Context.Donors.Select(x => x).ToListAsync();
                Donor d = ld.Find(x => x.Id == id);
                Context.Donors.Remove(d);
                await Context.SaveChangesAsync();
                return d;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Gift>> GetAllDonates(int id)
        {
            try
            {
                List<Gift> lg = await Context.Gifts.Where(x=>x.DonorId==id).ToListAsync();
                return lg;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Donor> GetDonorByEmail(string Email)
        {
            try
            {
                Donor donor = await Context.Donors.FirstOrDefaultAsync(c => c.Email == Email);
                return donor;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Donor> GetDonorByGift(int giftId)
        {
            try
            {
                Donor donor = await Context.Gifts.Where(g => g.Id == giftId).Include(g => g.Donor)
                    .Select(g => g.Donor).FirstOrDefaultAsync();
                return donor;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Donor> GetDonorByName(string Name)
        {
            try
            {
                Donor donor = await Context.Donors
                    .FirstOrDefaultAsync(c => c.FirstName == Name);
                return donor;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
