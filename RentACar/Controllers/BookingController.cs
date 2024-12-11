using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using RentACar.Models.ViewModels;
using RentACar.Services;
using RentACar.Util;

namespace RentACar.Controllers
{
	public class BookingController : Controller
	{
		private readonly IBookingService _bookingService;
		private readonly ICarCervice _carService;

		public BookingController(IBookingService bookingService, ICarCervice carService)
		{
			_bookingService = bookingService;
			_carService = carService;
		}

		public IActionResult Create(int carId, int userId)
		{
			var car = _carService.GetCarById(carId);

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
			var car = _carService.GetCarById(booking.CarId);

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
			var booking = _bookingService.GetBookingById(bookingId);

			if (booking == null)
			{
				return NotFound("Booking not found.");
			}

			booking.Car = _carService.GetCarById(booking.CarId);

			return View(booking);
		}

		public IActionResult History(int userId = 1, int pageCount = 1, int pageSize = 3)
		{
			var bookings = _bookingService.GetBookingsByUserId(userId);
			foreach (var booking in bookings)
			{
				booking.Car = _carService.GetCarById(booking.CarId);
			}

			var totalPages = (int)Math.Ceiling((double)bookings.Count() / pageSize);
			pageCount = (pageCount < 1) ? 1 : (pageCount > totalPages ? totalPages : pageCount);

			var modelView = new BookingHistoryViewModel()
			{
				Pagination = new PaginationViewModel()
				{
					TotalPages = totalPages,
					PageCount = pageCount,
					PageSize = pageSize
				}
			};

			bookings = bookings.Skip(pageSize * (pageCount - 1)).Take(pageSize);

			modelView.Bookings = bookings;

			return View(modelView);
		}
	}
}
