using PokemonReviewApplication.Data;
using PokemonReviewApplication.Interfaces;
using PokemonReviewApplication.Models;
using System.Data;

namespace PokemonReviewApplication.Repositories
{
	public class OwnerRepository : IOwnerRepository
	{
		private readonly DataContext _context;

		public OwnerRepository(DataContext context)
		{
			_context = context;
		}
		public Owner GetOwner(int id)
		=> _context.Owners.Find(id);

		public ICollection<Owner> GetOwners()
		=> _context.Owners.ToList();

		public ICollection<Pokemon> GetPokemonsByOwner(int ownerId)
		{
			return _context.PokemonOwners.Where(o => o.OwnerId == ownerId)
													.Select(p => p.Pokemon).ToList();
			
		}

		public bool IsOwnerExisted(int id)
		=> _context.Owners.Any(o => o.Id == id);
	}
}
