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

		public Pokemon GetPokemonById(int id)
		
		=>	_context.Pokemons.Where(p => p.Id == id).FirstOrDefault();


		public Pokemon GetPokemonByName(string name)
		=> _context.Pokemons.Find(name);

		public decimal GetPokemonRating(int pokeId)
		{
			var reviews = _context.Reviews.Where(p => p.Pokemon.Id==pokeId) ;
			if (reviews.Count() <= 0) return 0;
			return ((decimal)reviews.Sum(R => R.Rating) / reviews.Count());
		}

		public ICollection<Pokemon> GetPokemons()
			=>_context.Pokemons.OrderBy(P => P.Id).ToList();

		public bool IsPokemonExists(int pokeId)
		=> _context.Pokemons.Any(p => p.Id == pokeId);
			
		
	}
}
