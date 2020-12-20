using AutoMapper;

using CustomerLookup.Models.DataModels;
using CustomerLookup.Models.Dto;

namespace CustomerLookup.Models.Maps
{
    public class TxnProfile : Profile
    {

        public TxnProfile()
        {
            CreateMap<Txn, TxnDto>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.TXN_ID.Trim()))
                .ForMember(dest => dest.AgreementId, act => act.MapFrom(src => src.AGREEMENT_ID.Trim()))
                .ForMember(dest => dest.CustomerId, act => act.MapFrom(src => src.CUSTOMER_ID.Trim()))
                .ForMember(dest => dest.BankId, act => act.MapFrom(src => src.BANK_ID.Trim()))
                .ForMember(dest => dest.TxnCode, act => act.MapFrom(src => src.TXN_CODE.Trim()))
                .ForMember(dest => dest.TxnDate, act => act.MapFrom(src => src.TXN_DATE))
                .ForMember(dest => dest.TxnAmount, act => act.MapFrom(src => src.TXN_AMOUNT))
                .ForMember(dest => dest.TxnText, act => act.MapFrom(src => src.TXN_TEXT.Trim()))
                .ForMember(dest => dest.CurrencyCode, act => act.MapFrom(src => src.CURRENCY_CODE.Trim()))
                .ForMember(dest => dest.TxnCurAmount, act => act.MapFrom(src => src.TXN_CUR_AMOUNT))
                .ForMember(dest => dest.CorrAccount, act => act.MapFrom(src => src.TXN_CORR_ACCOUNT))
                .ForMember(dest => dest.CorrName, act => act.MapFrom(src => src.TXN_CORR_NAME.Trim()))
                .ForMember(dest => dest.CorrBank, act => act.MapFrom(src => src.TXN_CORR_BANK.Trim()))
                .ForMember(dest => dest.CorrCountry, act => act.MapFrom(src => src.TXN_CORR_COUNTRY.Trim()))
                .ForMember(dest => dest.CustomerSegment, act => act.MapFrom(src => src.CUSTOMER_SEGMENT.Trim()))
                .ForMember(dest => dest.CustomerType, act => act.MapFrom(src => src.CUSTOMER_TYPE.Trim()))
                .ForMember(dest => dest.SalaryFlag, act => act.MapFrom(src => src.SALARY_FLAG.Trim()))
                .ForMember(dest => dest.ProductId, act => act.MapFrom(src => src.PRODUCT_ID.Trim()));
            
        }
    }
}
