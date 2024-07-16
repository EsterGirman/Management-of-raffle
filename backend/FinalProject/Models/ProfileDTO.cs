using AutoMapper;
using FinalProject.Models.DTO;

namespace FinalProject.Models
{
    public class ProfileDTO:Profile
    {
        public ProfileDTO()
        {
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<DonorDTO, Donor>().ReverseMap();
            CreateMap<DonorDTO, Donor>().ReverseMap();
            CreateMap<GiftDTO, Gift>();
            CreateMap<Gift, GiftDTO>();
            CreateMap<PurchaseDTO, Purchase>().ReverseMap();
            CreateMap< GiftDTOWithoutId, Gift>().ReverseMap();
            CreateMap<Winner, WinnerDTO>().ReverseMap();

        }
    }
}
