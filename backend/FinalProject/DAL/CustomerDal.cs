
using AutoMapper;
using FinalProject.BLL;
using FinalProject.Models;
using FinalProject.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace FinalProject.DAL
{
    public class CustomerDal : ICustomerDal
    {
        public Context Context { get; }
        public CustomerDal(Context Context)
        {
            this.Context = Context;
        }
        public async Task<List<Customer>> getAllCustomers()
        {
            try
            {
                return await Context.Customers.Select(x => x).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Purchase>> getAllTickets(int id)
        {
            try
            {
                 List<Purchase> p = await Context.Purchases.Where(x => x.CustomerId==id&&x.Status==false).ToListAsync();
                if (p == null)
                {
                    throw new Exception("Custormer doesnt exit");
                }
                return p;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Customer> updateCustomer(int id, Customer c)
        {
            try
            {
                Validation(c);
                Customer cc = await Context.Customers.FirstOrDefaultAsync(x => x.Id==id);
                cc.FirstName = c.FirstName;
                cc.LastName = c.LastName;
                cc.Phone = c.Phone;
               // cc.Purchases = c.Purchases;
                cc.Email = c.Email;
                cc.Password = c.Password;
                cc.Role = "customer";
                await Context.SaveChangesAsync();
                return cc;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Customer> getCustomerById(int id)
        {
            try
            {
                List<Customer> lc= await Context.Customers.Select(x => x).Where(x => x.Id == id).ToListAsync();
                return lc[0];
            }
            catch (Exception ex)
            {
                throw;
            }
        }
      

        public async Task<Customer> Add(Customer customer)
        {
            try
            {
                Validation(customer);
                customer.Role = "Customer";
                await Context.Customers.AddAsync(customer);
                await Context.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw;
            }
           

        }
        public void Validation(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.FirstName)
                  || string.IsNullOrEmpty(customer.LastName)
                  || string.IsNullOrEmpty(customer.Phone)
                  || string.IsNullOrEmpty(customer.Email)
                   || string.IsNullOrEmpty(customer.Password))
            {
                throw new Exception("Please provide all the necessary fields");
            }
            if (!ValidateEmail(customer.Email))
            {
                throw new InvalidOperationException("Invalid email address format");
            }

            if (customer.FirstName.Length < 2 || customer.LastName.Length < 2)
            {
                throw new InvalidOperationException("First name and last name must contain at least 2 characters");
            }

            if (!HasOnlyDigits(customer.Phone) || customer.Phone.Length < 10)
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

        public async Task<Customer> deleteCustomers(int id)
        {
            try
            {
                Customer c =await Context.Customers.FirstOrDefaultAsync(x => x.Id == id);
                Context.Customers.Remove(c);
                await Context.SaveChangesAsync();
                return c;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Customer> Login(LoginDTO loginDto)
        {
            Customer customer;
            try
            {
                customer = await Context.Customers.FirstOrDefaultAsync(c => c.FirstName == loginDto.FirstName && c.LastName == loginDto.LastName && c.Password == loginDto.Password);
                return customer;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<Purchase> addToBucket(int g, int id)
        {
            try
            {
                Purchase p = new Purchase();
                p.Status = false;
                p.GiftId = g;
                p.CustomerId = id;
                await Context.Purchases.AddAsync(p);
                await Context.SaveChangesAsync();
                return p;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public async Task<List<Purchase>> getMyPurchase(int id) {
            
        //    List<Purchase> lp = await Context.Purchases.Select(x => x).Where(x => x.CustomerId == id&&x.Status==false).ToListAsync();
        //    return lp;
        //}
        //public async Task<Purchase> AddPurchase(int id)
        //{

        //    Purchase lc = await Context.Purchases.AddAsync();
        //    return lc;
        //}

    }
}