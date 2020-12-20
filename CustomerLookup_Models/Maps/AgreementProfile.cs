using AutoMapper;

using CustomerLookup.Models.DataModels;
using CustomerLookup.Models.Dto;

namespace CustomerLookup.Models.Maps
{
    public class AgreementProfile : Profile
    {

        public AgreementProfile()
        {
            CreateMap<Agreement, AgreementDto>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.AGREEMENT_ID.Trim()))
                .ForMember(dest => dest.CustomerId, act => act.MapFrom(src => src.CUSTOMER_ID.Trim()))
                .ForMember(dest => dest.BankId, act => act.MapFrom(src => src.BANK_ID.Trim()))
                .ForMember(dest => dest.ProductId, act => act.MapFrom(src => src.PRODUCT_ID.Trim()))
                .ForMember(dest => dest.Balance, act => act.MapFrom(src => src.AGRMT_BALANCE))
                .ForMember(dest => dest.OpenDate, act => act.MapFrom(src => src.AGRMT_OPEN_DATE))
                .ForMember(dest => dest.CloseDate, act => act.MapFrom(src => src.AGRMT_CLOSE_DATE))
                .ForMember(dest => dest.Amount, act => act.MapFrom(src => src.AGRMT_AMOUNT))
                .ForMember(dest => dest.LastPaymentDate, act => act.MapFrom(src => src.LAST_PMNT_DATE))
                .ForMember(dest => dest.NextPaymentDate, act => act.MapFrom(src => src.NEXT_PMNT_DATE))
                .ForMember(dest => dest.PaymentType, act => act.MapFrom(src => src.AGRMT_PMNT_TYPE.Trim()))
                .ForMember(dest => dest.Limit, act => act.MapFrom(src => src.AGRMT_LIMIT))
                .ForMember(dest => dest.AbwObjTypSchl, act => act.MapFrom(src => src.AGRMT_ABW_OBJ_TYP_SCHL.Trim()))
                .ForMember(dest => dest.AbwObjId, act => act.MapFrom(src => src.AGRMT_ABW_OBJ_ID.Trim()))
                .ForMember(dest => dest.AbwObjWhgSchl, act => act.MapFrom(src => src.AGRMT_ABW_OBJ_WHG_SCHL.Trim()))
                .ForMember(dest => dest.Status, act => act.MapFrom(src => src.AGRMT_STATUS.Trim()));
        }
    }
}
