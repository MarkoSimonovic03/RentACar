using System.ComponentModel.DataAnnotations;

namespace RentACar.Models
{
	public class Car
	{
		public int CarId { get; set; }
		[Required]
		public string Make { get; set; }
		[Required]
		public string Model { get; set; }
		[Required]
		public decimal PricePerDay { get; set; }
		[Required]
		public bool IsAvailable { get; set; }
		[Required]
		public int Year { get; set; }
		[Required]
		public int Seats { get; set; }
		[Required]
		public string FuelType { get; set; }
		[Required]
		public string ImageUrl { get; set; }
	}
}
