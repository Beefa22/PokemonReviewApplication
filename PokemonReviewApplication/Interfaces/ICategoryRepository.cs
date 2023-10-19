using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Interfaces
{
	public interface ICategoryRepository
	{
		ICollection<Category> GetCategories();
		ICollection<Category> GetCategoriesWithIncludes();

		Category GetCategory(int id);
		bool IsCatigoryExist(int categoryId);
		ICollection<Pokemon> GetPokemonsByCategory(int catigoryId);

	}
}
