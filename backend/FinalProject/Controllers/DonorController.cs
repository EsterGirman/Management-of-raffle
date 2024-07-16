using AutoMapper;
using FinalProject.BLL;
using FinalProject.Models.DTO;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorController:ControllerBase
    {

        public readonly IDonorService Donor;
        public readonly IMapper mapper;
        public DonorController(IDonorService Donor, IMapper m)
        {
            this.Donor = Donor;
            this.mapper = m;
        }
        [HttpGet]
       // [Authorize(Roles = "Manager")]
        public async Task<List<DonorDTO>> getAllDonors()
        {
             List <Donor> f=await Donor.getAllDonors();
            return  mapper.Map<List<DonorDTO>>(f);
                
        }
        [HttpGet("{id}")]
       // [Authorize(Roles = "Manager")]
        public async Task<DonorDTO> getDonorById(int id)
        {
            Donor f= await Donor.getDonorById(id);
            return mapper.Map<DonorDTO>(f);
        }
        [HttpPost]
       // [Authorize(Roles = "Manager")]
        public async Task<DonorDTO> Add(DonorDTO DonorDTO)
        {
            Donor d = mapper.Map<Donor>(DonorDTO);
            Donor dd= await Donor.Add(d);
            return mapper.Map<DonorDTO>(dd);
        }
        [HttpDelete]
       // [Authorize(Roles = "Manager")]
        public async Task<DonorDTO> deleteDonor(int id)
        {
            Donor f = await Donor.deleteDonors(id);
            return mapper.Map<DonorDTO>(f);
        }
        [HttpPut]
        public async Task<Donor> Update(DonorDTO DonorDTO, int id)
        {
            Donor Donors = mapper.Map<Donor>(DonorDTO);
            return await Donor.updateDonor(id, Donors);
        }
        [HttpGet("GetAllDonates")]
      //  [Authorize(Roles = "Manager")]
        public async Task<List<GiftDTO>> GetAllDonates(int id)
        {
            List<Gift> f = await Donor.GetAllDonates(id);
            return mapper.Map<List<GiftDTO>>(f);
        }
        [HttpGet("DonorByName")]
        public async Task<DonorDTO> GetDonorByName(string Name)
        {
            Donor d = await Donor.GetDonorByName(Name);
            return mapper.Map<DonorDTO>(d);
        }
        [HttpGet("DonorByGift")]
        public async Task<DonorDTO> GetDonorByGift(int giftId)
        {
            Donor d = await Donor.GetDonorByGift(giftId);
            return mapper.Map<DonorDTO>(d);
        }
        [HttpGet("DonorByEmail")]
        public async Task<DonorDTO> GetDonorByEmail(string Email)
        {
            Donor d = await Donor.GetDonorByEmail(Email);
            return mapper.Map<DonorDTO>(d);
        }
    }
}
