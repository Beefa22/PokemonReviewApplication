using AutoMapper;
using PokemonReviewApplication.Dtos;
using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Helpers
{
	public class MappingProfiles:Profile
	{
		public MappingProfiles()
		{
			CreateMap<Pokemon, PokemonDto>().ReverseMap();
			CreateMap<Category, CategoryDto>().ReverseMap();	
		}
	}
}
