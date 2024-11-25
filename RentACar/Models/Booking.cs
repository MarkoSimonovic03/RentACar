using System.ComponentModel.DataAnnotations;
using RentACar.Util;

namespace RentACar.Models
{
	//public class Booking
	//{
	//    public int BookingId { get; set; }
	//    [Required]
	//    public int CarId { get; set; }
	//    public Car? Car { get; set; }
	//    public int UserId { get; set; }
	//    [Required]
	//    [DataType(DataType.Date)]
	//    [Display(Name = "Start Date")]
	//    public DateTime StartDate { get; set; }
	//    [Required]
	//    [DataType(DataType.Date)]
	//    [DateGreaterThan(nameof(StartDate), ErrorMessage = "End date must be after the start date.")]
	//    public DateTime EndDate { get; set; }
	//    [Range(1, double.MaxValue, ErrorMessage = "Total price must be greater than 0.")]
	//    public decimal TotalPrice { get; set; }
	//}

	public class Booking : IValidatableObject
	{
		public int BookingId { get; set; }
		[Required]
		public int CarId { get; set; }
		public Car? Car { get; set; }
		public decimal PricePerDay { get; set; }
		[Required]
		public int UserId { get; set; }
		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "End Date")]
		public DateTime EndDate { get; set; }
		[Required]
		[Range(1, double.MaxValue, ErrorMessage = "Total price must be greater than 0.")]
		public decimal TotalPrice { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (StartDate <= DateTime.Now)
			{
				yield return new ValidationResult("Start date must be in the future.", new[] { nameof(StartDate) });
			}

			if (EndDate <= StartDate)
			{
				yield return new ValidationResult("End date must be after the start date.", new[] { nameof(EndDate) });
			}

			if (TotalPrice != PricePerDay * ((EndDate - StartDate).Days))
			{
				yield return new ValidationResult("Total price is incorrect.", new[] { nameof(TotalPrice) });
			}

			bool overlappingBookings = Garage.GenerateBookings()
				.Any(b => b.CarId == CarId &&
					((StartDate >= b.StartDate && StartDate < b.EndDate) ||
					(EndDate >= b.StartDate && EndDate <= b.EndDate) ||
					(StartDate <= b.StartDate && EndDate >= b.EndDate)));

			if (overlappingBookings)
			{
				yield return new ValidationResult("The car is already booked for the selected dates.", new[] { nameof(StartDate), nameof(EndDate) });
			}
		}
	}
}
