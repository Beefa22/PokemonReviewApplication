using PokemonReviewApplication.Data;
using PokemonReviewApplication.Interfaces;
using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Repositories
{
	public class PokemonRepository : IPokemonRepository
	{
		private readonly DataContext _context;

		public PokemonRepository(DataContext context)
		{
			_context = context;
		}
		public ICollection<Pokemon> GetPokemons()
			=>_context.Pokemons.OrderBy(P => P.Id).ToList();
		
	}
}
