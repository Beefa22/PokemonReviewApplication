using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
		private readonly IMapper _mapper;

		public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
		{
			_ownerRepository = ownerRepository;
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
	
	}
}
