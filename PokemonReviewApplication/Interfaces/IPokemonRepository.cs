using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Interfaces
{
	public interface IPokemonRepository
	{
		ICollection<Pokemon> GetPokemons();
		Pokemon GetPokemonById(int id);
		Pokemon GetPokemonByName(string name);
		decimal GetPokemonRating(int pokeId);
		bool IsPokemonExists(int pokeId);

	}
}
