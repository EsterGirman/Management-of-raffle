using AutoMapper;
using FinalProject.BLL;
using FinalProject.Models.DTO;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FinalProject.DAL;
using FinalProject.Migrations;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiftController
    {
        public readonly IGiftService Gift;
        public readonly IMapper mapper;
        public GiftController(IGiftService Gift, IMapper m)
        {
            this.Gift = Gift;
            this.mapper = m;
        }
        [HttpGet]
        //[Authorize(Roles = "Customer")]
        public async Task<List<GiftDTO>> GetAllGifts()
        {
            List<Gift> g = await Gift.getAllGifts();
            return mapper.Map<List<GiftDTO>>(g);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<GiftDTO> getGiftById(int id)
        {
            Gift g =await Gift.getGiftById(id);
            return mapper.Map<GiftDTO>(g);
             
        }
        [HttpGet("Donor/{DonorId}")]
        //[Authorize(Roles = "Manager")]
        public async Task<DonorDTO> GetAllDonors(int DonorId)
        {
            Donor gg = await Gift.GetAllDonors(DonorId);
            return mapper.Map<DonorDTO>(gg);
        }
        [HttpPost]
        //[Authorize(Roles = "Manager")]
        public async Task<GiftDTO> Add(GiftDTOWithoutId GiftDTO)
        {
            Gift p = mapper.Map<Gift>(GiftDTO);
            Gift g = await Gift.Add(p);
            return mapper.Map<GiftDTO>(g);            
        }
        [HttpDelete]
        //[Authorize(Roles = "Manager")]
        public async Task<GiftDTO> deleteGift(int id)
        {
            Gift g=await Gift.deleteGifts(id);
            return mapper.Map<GiftDTO>(g);
        }
        [HttpPut]
        //[Authorize(Roles = "Manager")]
        public async Task<GiftDTO> Update(GiftDTO GiftDTO, int id)
        {
            Gift G = mapper.Map<Gift>(GiftDTO);
            Gift g =await Gift.updateGift(id, G);
            return mapper.Map<GiftDTO>(g);
        }
        [HttpGet("Search")]
        [AllowAnonymous]
        //[Authorize(Roles = "Manager,Customer,Donor")]
        public async Task<GiftDTO> SearchGiftsByDonor(string name) 
        { 
            var gifts = await Gift.SearchGiftsByDonor(name);
            return mapper.Map<GiftDTO>(gifts);
        }
        [HttpGet("GetCustomerBuyGift/{Gift1}")]
        [AllowAnonymous]
        public async Task<List<PurchaseDTO>> GetCustomerBuyGift(int Gift1)
        {                            
            List<Purchase> p1 = await Gift.GetCustomerBuyGift(Gift1);
            return mapper.Map<List<PurchaseDTO>>(p1);

        }
        [HttpPost("DoRaffle/{giftId}")]
        //[Authorize(Roles = "Manager")]
        public async Task<WinnerDTO> DoRaffle(int giftId)
        {
            Winner win = await Gift.DoRaffle(giftId);
            return mapper.Map<WinnerDTO>(win);
        }
        [HttpGet("GetGiftsByCustomer/{custID}")]
        public async Task<List<GiftDTO>> GetGiftsByCustomer(int custID)
        {
            List<Gift> lg = await Gift.GetGiftsByCustomer(custID);
            return mapper.Map<List<GiftDTO>>(lg);
        }
    }

}
