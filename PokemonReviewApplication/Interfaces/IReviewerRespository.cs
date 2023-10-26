using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Interfaces
{
	public interface IReviewerRespository
	{
		ICollection<Reviewer> GetReviewers();
		Reviewer GetReviewer(int id);
		bool IsReviewerExist(int id);
		ICollection<Review> GetReviewsByReviewer(int reviewerId);

	}
}
