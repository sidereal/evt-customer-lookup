using AutoMapper;

using CustomerLookup.Models.DataModels;
using CustomerLookup.Models.Dto;

namespace CustomerLookup.Models.Maps
{
    public class CustomerProfile : Profile
    {

        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.CUSTOMER_ID.Trim()))
                .ForMember(dest => dest.Type, act => act.MapFrom(src => src.CUSTOMER_TYPE.Trim()))
                .ForMember(dest => dest.Branch, act => act.MapFrom(src => src.CUSTOMER_BRANCH.Trim()))
                .ForMember(dest => dest.Banker, act => act.MapFrom(src => src.CUSTOMER_BANKER.Trim()))
                .ForMember(dest => dest.Status, act => act.MapFrom(src => src.CUSTOMER_STATUS.Trim()))
                .ForMember(dest => dest.Segment, act => act.MapFrom(src => src.CUSTOMER_SEGMENT.Trim()))
                .ForMember(dest => dest.BankId, act => act.MapFrom(src => src.BANK_ID.Trim()))
                .ForMember(dest => dest.BirthDate, act => act.MapFrom(src => src.CUST_BIRTH_DATE))
                .ForMember(dest => dest.LastContact, act => act.MapFrom(src => src.CUSTOMER_LAST_CONTACT))
                .ForMember(dest => dest.SGFN, act => act.MapFrom(src => src.CUSTOMER_SGFN.Trim()))
                .ForMember(dest => dest.Kundenattrakt, act => act.MapFrom(src => src.CUSTOMER_KUNDENATTRAKT.Trim()))
                .ForMember(dest => dest.Betreuintens, act => act.MapFrom(src => src.CUSTOMER_BETREUINTENS.Trim()))
                .ForMember(dest => dest.NextContact, act => act.MapFrom(src => src.CUSTOMER_NEXT_CONTACT))
                .ForMember(dest => dest.KST, act => act.MapFrom(src => src.CUSTOMER_KST.Trim()));
        }
    }
}
