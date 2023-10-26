using Microsoft.EntityFrameworkCore;
using PokemonReviewApplication.Data;
using PokemonReviewApplication.Interfaces;
using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly DataContext _context;

		public CategoryRepository(DataContext context)
		{
			_context = context;
		}

		public bool CreateCategory(Category category)
		{
			_context.Add(category);
			return Save();
		}

		public ICollection<Category> GetCategories()
		=> _context.Categories.ToList();

		public ICollection<Category> GetCategoriesWithIncludes()
		=> _context.Categories.Include(c => c.PokemonCategories).ToList();

		public Category GetCategory(int id)
		=> _context.Categories.Find(id);

		public ICollection<Pokemon> GetPokemonsByCategory(int catigoryId)
		=> _context.PokemonCategories.Where(p => p.CategoryId == catigoryId)
									 .Select(p=>p.Pokemon).ToList();

		public bool IsCatigoryExist(int categoryId)
		=> _context.Categories.Any(c => c.Id == categoryId);

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
	}
}
