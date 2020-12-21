using AutoMapper;

using CustomerLookup.Models.DataModels;
using CustomerLookup.Models.Dto;

namespace CustomerLookup.Models.Maps
{
    public class StatisticProfile : Profile
    {

        public StatisticProfile()
        {
            CreateMap<Statistics, StatisticDto>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.STATS_ID))
                .ForMember(dest => dest.CustomerId, act => act.MapFrom(src => src.CUSTOMER_ID.Trim()))
                .ForMember(dest => dest.Year, act => act.MapFrom(src => src.YEAR_))
                .ForMember(dest => dest.Month, act => act.MapFrom(src => src.MONTH_))
                .ForMember(dest => dest.MaxAmount, act => act.MapFrom(src => src.MAX_AMOUNT))
                .ForMember(dest => dest.DateMax, act => act.MapFrom(src => src.DATE_MAX))
                .ForMember(dest => dest.SecAmount, act => act.MapFrom(src => src.SEC_AMOUNT))
                .ForMember(dest => dest.DateSec, act => act.MapFrom(src => src.DATE_SEC))
                .ForMember(dest => dest.LastDate, act => act.MapFrom(src => src.LAST_DATE))
                .ForMember(dest => dest.FixedDate, act => act.MapFrom(src => src.FIXED_DATE))
                .ForMember(dest => dest.EventId, act => act.MapFrom(src => src.EVENT_ID));
        }
    }
}
