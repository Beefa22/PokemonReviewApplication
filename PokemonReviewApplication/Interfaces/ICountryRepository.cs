using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Interfaces
{
	public interface ICountryRepository
	{
		ICollection<Country> GetCountries();
		Country GetCountry(int id);
		bool IsCoutnryExists(int id);
		Country GetCoutnriesByOwner(int ownerId);

		bool CreateCountry(Country country);
		bool Save();
	}
}
