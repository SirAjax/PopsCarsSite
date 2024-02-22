using AutoMapper;
using EFTest.Models;


namespace PopsCars.Services;


public class CarFromRepoToDTO : Profile
{
	public CarFromRepoToDTO() 
	
	{
		CreateMap<Car, CarDTO>()		
			.ForMember(des => des.Company, opt => opt.MapFrom(src => src.Make))
			.ReverseMap();
	}
}
