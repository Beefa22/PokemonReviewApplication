using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApplication.Dtos;
using PokemonReviewApplication.Interfaces;
using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryRepository _categoryRepo;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryRepository categoryRepo,
			IMapper mapper)
		{
			_categoryRepo = categoryRepo;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetCategories()
		{
			var categories = _categoryRepo.GetCategories();
			if (categories is null) return NotFound();
			if (!ModelState.IsValid) return BadRequest();

			var mappedCategories = _mapper.Map<IEnumerable<Category>,IEnumerable<CategoryDto>>(categories);
			return Ok(mappedCategories);
		}

		[HttpGet("{id}")]
		public IActionResult GetCategoryById(int id)
		{
			if (!_categoryRepo.IsCatigoryExist(id)) return NotFound();
			var category = _mapper.Map<CategoryDto>( _categoryRepo.GetCategory(id));
			if (!ModelState.IsValid) return BadRequest();
			return Ok(category);
		}
		[HttpGet("pokemon/{categoryId}")]
		[ProducesResponseType(400)]
		[ProducesResponseType(200,Type = typeof(IEnumerable<Pokemon>))]
		public IActionResult GetPokemonsByCategoryId(int categoryId)
		{
			if (_categoryRepo.IsCatigoryExist(categoryId)) return NotFound();

			var pokemons = _mapper.Map<List<PokemonDto>>( _categoryRepo.GetPokemonsByCategory(categoryId));
			if (!ModelState.IsValid) return BadRequest();
			return Ok(pokemons);
		}
	}
}
