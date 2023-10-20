using PokemonReviewApplication.Data;
using PokemonReviewApplication.Interfaces;
using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Repositories
{
	public class CountryRepository : ICountryRepository
	{
		private readonly DataContext _context;

		public CountryRepository(DataContext context)
		{
			_context = context;
		}
		public ICollection<Country> GetCountries()
		=> _context.Countries.ToList();

		public Country GetCountry(int id)
		=> _context.Countries.Find(id);

		public Country GetCoutnriesByOwner(int ownerId)
		{
			return _context.Owners.Where(o => o.Id == ownerId)
								  .Select(c => c.Country).FirstOrDefault();
		}

		public bool IsCoutnryExists(int id)
		=> _context.Countries.Any(c => c.Id==id);
	}
}
