using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Dtos
{
	public class ReviewerDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public virtual ICollection<Review> Reviews { get; set; }

	}
}
