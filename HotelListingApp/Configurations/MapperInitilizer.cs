using AutoMapper;
using HotelListingApp.Data;
using HotelListingApp.Models;

namespace HotelListingApp.Configurations;

public class MapperInitilizer : Profile
{
	public MapperInitilizer()
	{
		CreateMap<Country, CountryDTO>().ReverseMap();
        CreateMap<Country, CreateCountryDTO>().ReverseMap();
        CreateMap<Hotel, HotelDTO>().ReverseMap();
        CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
    }
}
