using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using RentACar.Util;

namespace RentACar.Controllers
{
	public class BookingController : Controller
	{
		public IActionResult Create(int carId, int userId)
		{
			var cars = Garage.GenerateCars();

			var car = cars.Single(c => c.CarId == carId);

			if (car == null || !car.IsAvailable)
			{
				return NotFound("The car is not available for booking.");
			}

			return View(new Booking { BookingId = 1, CarId = carId, Car = car, PricePerDay = car.PricePerDay, UserId = userId, StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(2), TotalPrice = car.PricePerDay });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Booking booking)
		{
			var cars = Garage.GenerateCars();
			var car = cars.SingleOrDefault(c => c.CarId == booking.CarId);

			if (car == null || !car.IsAvailable)
			{
				return NotFound("The car is not available for booking.");
			}

			//var rentalDays = (booking.EndDate - booking.StartDate).Days;
			//booking.TotalPrice = rentalDays * car.PricePerDay;
			booking.Car = car;

			if (ModelState.IsValid)
			{
				return RedirectToAction("Confirmation", new { booking.BookingId });
			}

			return View(booking);
		}

		public IActionResult Confirmation(int bookingId)
		{
			var bookings = Garage.GenerateBookings();
			var booking = bookings.SingleOrDefault(b => b.BookingId == bookingId);

			if (booking == null)
			{
				return NotFound("Booking not found.");
			}

			return View(booking);
		}

		public IActionResult History(int userId)
		{
			var bookings = Garage.GenerateBookings().Where(x => x.UserId == userId);

			return View(bookings);
		}
	}
}
