using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.Models.DTO;

namespace FinalProject.BLL
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerDal CustomerDal;

        public CustomerService(ICustomerDal customerDal)
        {
            this.CustomerDal = customerDal;
        }
        public async Task<Customer> Add(Customer customer)
        {
            return await CustomerDal.Add(customer);
        }
        public async Task<List<Customer>> getAllCustomers()
        {
            return await CustomerDal.getAllCustomers();
        }
        public async Task<Customer> getCustomerById(int id) 
        {
            return await CustomerDal.getCustomerById(id);
        }
        public async Task<Customer> deleteCustomers(int id) 
        {
          return   await CustomerDal.deleteCustomers(id);
        }
        public async Task<Customer> updateCustomer(int id,Customer c)
        {
            return await CustomerDal.updateCustomer( id, c);
        }
        public async Task<Customer> Login(LoginDTO loginDto)
        {
            return await CustomerDal.Login(loginDto);
        }
        public async Task<Purchase> addToBucket(int g,int id)
        {
            return await CustomerDal.addToBucket(g, id);
        }
        public async Task<IEnumerable<Purchase>> getAllTickets(int id)
        {
            return await CustomerDal.getAllTickets(id);
        }
       
    }
}