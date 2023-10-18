using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApplication.Dtos;
using PokemonReviewApplication.Interfaces;
using PokemonReviewApplication.Models;
using PokemonReviewApplication.Repositories;

namespace PokemonReviewApplication.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PokemonController : ControllerBase
	{
		private readonly IPokemonRepository _pokemonRepository;
		private readonly IMapper _mapper;

		public PokemonController(IPokemonRepository pokemonRepository,
								IMapper mapper)
		{
			_pokemonRepository = pokemonRepository;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
		public IActionResult GetPokemons()
		{
			var pokemons = _pokemonRepository.GetPokemons();
			if (!ModelState.IsValid) return BadRequest(ModelState);
			return Ok(pokemons);
		}

		[HttpGet("{id}")]
		public ActionResult<PokemonDto> GetPokemonById(int id)
		{
			if (!_pokemonRepository.IsPokemonExists(id)) return NotFound();

			var pokemon = _pokemonRepository.GetPokemonById(id);
			var mappedPokemon = _mapper.Map<Pokemon, PokemonDto>(pokemon);
			if (!ModelState.IsValid) return BadRequest();
			return Ok(mappedPokemon);
		}

		[HttpGet("{name}")]
		public IActionResult GetPokemonByName(string name)
		{
			if (string.IsNullOrEmpty(name) || name.Length > 50) return BadRequest();
			var pokemon = _pokemonRepository.GetPokemonByName(name);
			if (pokemon is null) return NotFound();
			var mappedPokemon = _mapper.Map<Pokemon, PokemonDto>(pokemon);
			if (!ModelState.IsValid) return BadRequest();
			return Ok(mappedPokemon);
		}

		[ProducesResponseType(200, Type = typeof(decimal))]
		[ProducesResponseType(400)]
		[HttpGet("{pokeId}/rating")]
		public IActionResult GetPokemonRating(int pokeId)
		{
			if (!_pokemonRepository.IsPokemonExists(pokeId)) return NotFound();
			var rating = _pokemonRepository.GetPokemonRating(pokeId);
			if (!ModelState.IsValid) return BadRequest();
			return Ok(rating);

		}
	}
}
