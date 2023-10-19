	using Microsoft.EntityFrameworkCore;
using PokemonReviewApplication.Models;

namespace PokemonReviewApplication.Data
{
	public class DataContext:DbContext
	{
		public DataContext(DbContextOptions<DataContext> options):base(options)
		{

		}
		public DbSet<Pokemon> Pokemons { get; set; }
		public DbSet<PokemonCategory> PokemonCategories { get; set; }
		public DbSet<PokemonOwner> PokemonOwners { get; set; }
		public DbSet<Owner> Owners { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Reviewer> Reviewers { get; set; }
		public DbSet<Country> Countries { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PokemonCategory>()
				.HasKey(PC => new { PC.PokemonId,PC.CategoryId });
			modelBuilder.Entity<PokemonOwner>()
			.HasKey(PO => new { PO.PokemonId, PO.OwnerId });

			modelBuilder.Entity<PokemonCategory>()
				.HasOne(P => P.Pokemon)
				.WithMany(PC => PC.PokemonCategories)
				.HasForeignKey(P => P.PokemonId);
			modelBuilder.Entity<PokemonCategory>()
				.HasOne(C => C.Category)
				.WithMany(PC => PC.PokemonCategories)
				.HasForeignKey(C => C.CategoryId);

			modelBuilder.Entity<PokemonOwner>()
				.HasOne(P => P.Pokemon)
				.WithMany(PO => PO.PokemonOwners)
				.HasForeignKey(P => P.PokemonId);
			modelBuilder.Entity<PokemonOwner>()
				.HasOne(O => O.Owner)
				.WithMany(PO => PO.PokemonOwners)
				.HasForeignKey(O => O.OwnerId);

		}


	}
}
