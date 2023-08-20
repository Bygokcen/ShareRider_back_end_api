using AutoMapper;
using ShareRider2.Dtos;
using ShareRider2.Models;

namespace ShareRider2.Helpers;

public class AutoMapperProfiles:Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Journey, JourneyForListDto>()
            .ForMember(dest => dest.CreatorUserName, opt => opt.MapFrom(src => $"{src.CreatorUser.FirstName} {src.CreatorUser.LastName}"))
            .ForMember(dest => dest.DepartureCityName, opt => opt.MapFrom(src => src.DepartureCity.CityName))
            .ForMember(dest => dest.ArrivalCityName, opt => opt.MapFrom(src => src.ArrivalCity.CityName));

        CreateMap<ShareRiderForAddDto, ShareRider>();
        CreateMap<AddJourneyDto, Journey>();
        CreateMap<Journey, JourneyForDetailDto>();
        CreateMap<ShareRiderDto, ShareRider>().ForMember(dest => dest.JourneyId, opt => opt.MapFrom(src => src.JourneyId))
            .ForMember(dest=> dest.UserId,opt=> opt.MapFrom(src => src.UserId));
        CreateMap<User, UserDto>();
        CreateMap<City, CityDto>();
    }
}