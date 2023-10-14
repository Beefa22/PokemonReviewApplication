using Microsoft.AspNetCore.SignalR.Protocol;

namespace PokemonReviewApplication.Models
{
	public class Pokemon
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DateOfBirth { get; set; }

	}
}
