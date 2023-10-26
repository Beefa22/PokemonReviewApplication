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
	public class ReviewController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IReviewRepository _reviewRepository;

		public ReviewController(IMapper mapper, IReviewRepository reviewRepository)
		{
			_mapper = mapper;
			_reviewRepository = reviewRepository;
		}
		[HttpGet]
		public IActionResult GetReviews()
		{
			var reviews = _reviewRepository.GetReviews();
			if (!ModelState.IsValid) return BadRequest();
			return Ok(_mapper.Map<ICollection<Review>, ICollection<ReviewDto>>(reviews));
		}

		[HttpGet("{id}")]
		public IActionResult GetReview(int id)
		{
			if (!_reviewRepository.IsReviewExists(id)) return NotFound();
			var review = _reviewRepository.GetReview(id);
			if (!ModelState.IsValid) return BadRequest();
			return Ok(_mapper.Map<Review, ReviewDto>(review));

		}
		[HttpGet("pokemon/{pokeId}")]
		[ProducesResponseType(200, Type = typeof(Review))]
		[ProducesResponseType(400)]
		public IActionResult ReviewsByPokemonId(int pokeId)
		{
			
			var reviews =_mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewsForAPokemon(pokeId));
		
			if (!ModelState.IsValid) return BadRequest();
			return Ok(reviews);


		}
	}
}
