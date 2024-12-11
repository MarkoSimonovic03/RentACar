namespace RentACar.Models.ViewModels
{
	public class BookingHistoryViewModel
	{
		public IEnumerable<Booking> Bookings { get; set; }
		public PaginationViewModel Pagination { get; set; }
	}
}
