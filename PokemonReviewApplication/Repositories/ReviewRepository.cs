using PokemonReviewApplication.Data;
using PokemonReviewApplication.Interfaces;
using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Repositories
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly DataContext _context;

		public ReviewRepository(DataContext context)
		{
			_context = context;
		}
		public Review GetReview(int id)
		=> _context.Reviews.Find(id);

		public ICollection<Review> GetReviews()
		=> _context.Reviews.ToList();

		public ICollection<Review> GetReviewsForAPokemon(int pokeId)
		=>_context.Reviews.Where(r => r.Pokemon.Id == pokeId).ToList();
		

		public bool IsReviewExists(int id)
		=> _context.Reviews.Any(r => r.Id == id);
	}
}
