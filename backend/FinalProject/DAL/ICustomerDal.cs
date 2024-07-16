using FinalProject.Models;
using FinalProject.Models.DTO;

namespace FinalProject.DAL
{
    public interface ICustomerDal
    {
        public Task<Customer> Add(Customer customer);
        public Task<List<Customer>> getAllCustomers();
        public Task<Customer> getCustomerById(int id);
        public Task<Customer> deleteCustomers(int id);
        public Task<Customer> updateCustomer(int id, Customer c);
        public Task<Customer> Login(LoginDTO loginDto);
        public Task<Purchase> addToBucket(int g, int id);
       // public  Task<List<Purchase>> getMyPurchase(int id);
        public  Task<List<Purchase>> getAllTickets(int id);
        }
}

