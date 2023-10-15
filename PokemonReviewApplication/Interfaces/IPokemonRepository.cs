using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Interfaces
{
	public interface IPokemonRepository
	{
		ICollection<Pokemon> GetPokemons();
	}
}
