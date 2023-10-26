using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PokemonReviewApplication.Dtos;
using PokemonReviewApplication.Interfaces;
using PokemonReviewApplication.Models;
using System.Security.Principal;

namespace PokemonReviewApplication.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewerController : ControllerBase
	{
		private readonly IReviewerRespository _reviewerRespository;
		private readonly IMapper _mapper;

		public ReviewerController(IReviewerRespository reviewerRespository, IMapper mapper)
		{
			_reviewerRespository = reviewerRespository;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetReviwers()
		{
			var reviwers = _reviewerRespository.GetReviewers();
			if (!ModelState.IsValid) return BadRequest();
			
			return Ok(_mapper.Map<ICollection<Reviewer>,ICollection<ReviewerDto>> (reviwers));
		}

		[HttpGet("{id}")]
		public IActionResult GetReviwer(int id)
		{
			if (!_reviewerRespository.IsReviewerExist(id)) return NotFound();
			var reviwer = _reviewerRespository.GetReviewer(id);
			if (!ModelState.IsValid) return BadRequest();
			return Ok(_mapper.Map<Reviewer, ReviewerDto>(reviwer));
		}
		[HttpGet("{reviwerId}/reviews")]
		public IActionResult GetReviewsByReviwer(int reviwerId)
		{
			if (!_reviewerRespository.IsReviewerExist(reviwerId)) return NotFound();
		var reviews =_mapper.Map<List<ReviewDto>> (_reviewerRespository.GetReviewsByReviewer(reviwerId));
			if (!ModelState.IsValid) return BadRequest();
			return Ok(reviews);
		}
	}
}
