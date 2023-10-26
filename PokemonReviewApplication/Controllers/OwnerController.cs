using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PokemonReviewApplication.Dtos;
using PokemonReviewApplication.Interfaces;
using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OwnerController : ControllerBase
	{
		private readonly IOwnerRepository _ownerRepository;
		private readonly ICountryRepository _countryRepository;
		private readonly IMapper _mapper;

		public OwnerController(IOwnerRepository ownerRepository,ICountryRepository countryRepository,
			IMapper mapper)
		{
			_ownerRepository = ownerRepository;
			_countryRepository = countryRepository;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetOwners()
		{
			var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());
			if (!ModelState.IsValid) return NotFound();
			return Ok(owners);
		}
		[HttpGet("{id}")]
		public ActionResult<OwnerDto> GetOwnerById(int id)
		{
			if (!_ownerRepository.IsOwnerExisted(id)) return NotFound();
			var owner = _ownerRepository.GetOwner(id);
			if (!ModelState.IsValid) return BadRequest();
			return Ok(_mapper.Map<Owner, OwnerDto>(owner));
		}
		[HttpGet("{ownerId}/pokemons")]
		public IActionResult GetPokemonsByOwnerId(int ownerId)
		{
			var pokemons = _mapper.Map<List<PokemonDto>>(_ownerRepository.GetPokemonsByOwner(ownerId));
			if (!ModelState.IsValid) return BadRequest();
			return Ok(pokemons);
		}

		[HttpPost]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		public IActionResult CreateOwner([FromQuery]int countryId,[FromBody] OwnerDto ownerDto)
		{
			if (ownerDto is null) return BadRequest();

			var owner = _ownerRepository.GetOwners().Where(o => o.Id == ownerDto.Id).FirstOrDefault();
			if (owner is not null)
			{
				ModelState.AddModelError("", "This Owner is already Exists");
				return StatusCode(422, ModelState);
			}
			if (!ModelState.IsValid) return BadRequest();

			var mappedOwner = _mapper.Map<Owner>(ownerDto);
			mappedOwner.Country = _countryRepository.GetCountry(countryId);

			if (!_ownerRepository.CreateOwner(mappedOwner))
			{
				ModelState.AddModelError("", "Something went wrong while saving");
				return StatusCode(500, ModelState);
			}
			return Ok("Succefully Created");
		}
	
	}
}
