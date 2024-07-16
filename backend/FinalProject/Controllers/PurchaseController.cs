using AutoMapper;
using FinalProject.BLL;
using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerContext
    {
        public readonly IPurchaseService Purchase;
        public readonly IGiftService Gift;
        public readonly IMapper mapper;
        public PurchaseController(IPurchaseService Purchase, IMapper m)
        {
            this.Purchase = Purchase;
            this.mapper = m;
        }
        [HttpGet]
       // [Authorize(Roles = "Manager")]
        public async Task<List<PurchaseDTO>> getAllPurchases()
        {
            List<Purchase> p = await Purchase.getAllPurchases();
            return mapper.Map<List<PurchaseDTO>>(p);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<PurchaseDTO> getPurchaseById(int id)
        {
            Purchase p = await Purchase.getPurchaseById(id);
            return mapper.Map<PurchaseDTO>(p);
        }
        [HttpPost]
       // [Authorize(Roles = "Customer")]
        public async Task<PurchaseDTO> Add(PurchaseDTO PurchaseDTO)
        {
            Purchase p = mapper.Map<Purchase>(PurchaseDTO);
            Purchase p1 = await Purchase.Add(p);
            return mapper.Map<PurchaseDTO>(p1);
        }
        [HttpDelete]
        [AllowAnonymous]
        public async Task<PurchaseDTO> deletePurchase(int id)
        {
            Purchase p = await Purchase.deletePurchase(id);
            return mapper.Map<PurchaseDTO>(p);
        }
        [HttpPut]
       // [Authorize(Roles = "Customer")]
        public async Task<PurchaseDTO> Update(PurchaseDTO PurchaseDTO, int id)
        {
            Purchase p = mapper.Map<Purchase>(PurchaseDTO);
            Purchase p1 = await Purchase.updatePurchase(id, p);
            return mapper.Map<PurchaseDTO>(p1);
        }
        [HttpPut("payment")]
        //[Authorize(Roles = "Customer")]
        public async Task<PurchaseDTO> payment(int p)
        { 
            Purchase p1 = await Purchase.payment(p);
            return mapper.Map<PurchaseDTO>(p1);
        }
    }
}