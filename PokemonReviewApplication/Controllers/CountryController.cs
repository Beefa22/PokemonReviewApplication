using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PokemonReviewApplication.Dtos;
using PokemonReviewApplication.Interfaces;
using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CountryController : ControllerBase
	{
		private readonly ICountryRepository _countryRepository;
		private readonly IMapper _mapper;

		public CountryController(ICountryRepository countryRepository, IMapper mapper)
		{
			_countryRepository = countryRepository;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetCountries()
		{
			var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
			if (!ModelState.IsValid) return BadRequest();

			return Ok(countries);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(400)]
		[ProducesResponseType(200, Type = typeof(CountryDto))]
		public IActionResult GetCountry(int id)
		{
			if (!_countryRepository.IsCoutnryExists(id)) return NotFound();
			var country = _countryRepository.GetCountry(id);
			if (!ModelState.IsValid) return BadRequest();
			var mappedCountry = _mapper.Map<Country, CountryDto>(country);
			return Ok(mappedCountry);

		}
		[ProducesResponseType(400)]
		[ProducesResponseType(200, Type = typeof(CountryDto))]
		[HttpGet("owners/{ownerId}")]
		public IActionResult GetCountryByOwner(int ownerId)
		{
			//if (!_countryRepository.IsCoutnryExists(ownerId)) return NotFound();
			var country = _countryRepository.GetCoutnriesByOwner(ownerId);
			if (!ModelState.IsValid) return BadRequest();
			return Ok(_mapper.Map<Country, CountryDto>(country));	
		}
	}
}
