using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Interfaces
{
	public interface IReviewRepository
	{
		ICollection<Review> GetReviews();
		Review GetReview(int id);
		bool IsReviewExists(int id);
		ICollection<Review> GetReviewsForAPokemon(int pokeId);
	}
}
