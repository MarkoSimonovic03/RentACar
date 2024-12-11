using RentACar.Models;

namespace RentACar.Services
{
	public interface IBookingService
	{
		IEnumerable<Booking> GetAllBookings();
		Booking GetBookingById(int id);
		void AddBooking(Booking booking);
		void UpdateBooking(Booking booking);
		void DeleteBooking(int id);
		IEnumerable<Booking> GetBookingsByUserId(int userId);
	}
}
