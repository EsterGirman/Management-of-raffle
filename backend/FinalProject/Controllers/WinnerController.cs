using AutoMapper;
using FinalProject.BLL;
using FinalProject.Models.DTO;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WinnerController : ControllerBase
    {
        public readonly IMapper mapper;
        public readonly IWinnerService Winner;
        public WinnerController(IWinnerService Winner, IMapper mapper)
        {
            this.Winner = Winner;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<WinnerDTO>> getAllWinners()
        {
            List<Winner> gg = await Winner.getAllWinners();
            return mapper.Map<List<WinnerDTO>>(gg);
        }
        [HttpPost]
        //[Authorize(Roles = "Manager")]
        public async Task<WinnerDTO> Add(WinnerDTO WinnerDTO)
        {
            Winner w = mapper.Map<Winner>(WinnerDTO);
            Winner ww = await Winner.Add(w);
            return mapper.Map<WinnerDTO>(ww);
        }
    }
}