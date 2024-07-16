using FinalProject.Models;
using FinalProject.Models.DTO;

namespace FinalProject.BLL
{
    public interface ICustomerService
    {
        public Task<Customer> Add(Customer customer);
        public Task<List<Customer>> getAllCustomers();
        public Task<Customer> getCustomerById(int id);
        public Task<Customer> deleteCustomers(int id);
        public Task<Customer> updateCustomer(int id, Customer c);
        public Task<Purchase> addToBucket(int g, int id);
        public Task<IEnumerable<Purchase>> getAllTickets(int id);
        public Task<Customer> Login(LoginDTO l);
    }
}
