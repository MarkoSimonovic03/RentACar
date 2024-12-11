using RentACar.Models;

namespace RentACar.Services
{
	public class BookingService : IBookingService
	{
		private readonly RentACarContext _context;

		public BookingService(RentACarContext context)
		{
			_context = context;
		}

		public IEnumerable<Booking> GetAllBookings()
		{
			return _context.Bookings.ToList();
		}

		public Booking GetBookingById(int id)
		{
			return _context.Bookings.Find(id);
		}

		public void AddBooking(Booking booking)
		{
			_context.Bookings.Add(booking);
			_context.SaveChanges();
		}

		public void UpdateBooking(Booking booking)
		{
			_context.Bookings.Add(booking);
			_context.SaveChanges();
		}

		public void DeleteBooking(int id)
		{
			var booking = _context.Bookings.Find(id);
			if (booking != null)
			{
				_context.Bookings.Remove(booking);
				_context.SaveChanges();
			}
		}

		public IEnumerable<Booking> GetBookingsByUserId(int userId)
		{
			return _context.Bookings.Where(b => b.UserId == userId).ToList();
		}

	}
}
