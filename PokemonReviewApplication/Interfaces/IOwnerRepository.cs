using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Interfaces
{
	public interface IOwnerRepository
	{
		ICollection<Owner> GetOwners();
		Owner GetOwner(int id);
		bool IsOwnerExisted(int id);
		ICollection<Pokemon> GetPokemonsByOwner(int ownerId);

	}
}
