using AutoMapper;
using FinalProject.BLL;
using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace FinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerService customers;
        public readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public CustomerController(ICustomerService customer, IMapper mapper, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.customers = customer;
            this.configuration = configuration;

        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<CustomerDTO>> getAllCustomers()
        {
            List<Customer> custom = await customers.getAllCustomers();
            return mapper.Map<List<CustomerDTO>>(custom);
        }
        [HttpGet("{id}")]
        public async Task<IEnumerable<PurchaseDTO>> getAllTickets(int id)
        {
            IEnumerable<Purchase> Purchase = await customers.getAllTickets(id);
            return mapper.Map<IEnumerable<PurchaseDTO>>(Purchase);
        }

        [HttpPost("register")]
        public async Task<CustomerDTO> Add(CustomerDTO customerDTO)
        {
            Customer customer = mapper.Map<Customer>(customerDTO);
            Customer customer1 = await customers.Add(customer);
            return mapper.Map<CustomerDTO>(customer1);

        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<Customer>> Login(LoginDTO a)
        {
            try
            {
                var user = await customers.Login(a);
                if (user != null)
                {
                    var token = Generate(user);
                    return Ok(token);
                }
                return NotFound("user not found!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
        [HttpGet("GetuserByToken")]
        [AllowAnonymous]
        private string Generate(Customer user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.LastName),
                new Claim(ClaimTypes.OtherPhone, user.Phone),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpDelete]
        //[Authorize(Roles = "Manager")]
        public async Task<CustomerDTO> DeleteCustomers(int id)
        {
            Customer customer = await customers.deleteCustomers(id);
            return mapper.Map<CustomerDTO>(customer);
        }
        [HttpPut]
        //[Authorize(Roles = "Manager")]
        public async Task<CustomerDTO> Update(CustomerDTO customerDTO, int id)
        {
            Customer customer = mapper.Map<Customer>(customerDTO);
            customer = await customers.updateCustomer(id, customer);
            return mapper.Map<CustomerDTO>(customer);
        }

        [HttpPost("bucket")]
        [AllowAnonymous]
        public async Task<PurchaseDTO> AddToBucket(int giftId, int CustumrId)
        {
            Purchase p1 = await customers.addToBucket(giftId, CustumrId);
            return mapper.Map<PurchaseDTO>(p1);
        }


    }
}

