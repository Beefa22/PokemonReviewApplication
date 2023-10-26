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
			CreateMap<Country, CountryDto>().ReverseMap();
			CreateMap<Owner, OwnerDto>().ReverseMap();
			CreateMap<Reviewer, ReviewerDto>().ReverseMap();
			CreateMap<Review, ReviewDto>().ReverseMap();

		}
	}
}
