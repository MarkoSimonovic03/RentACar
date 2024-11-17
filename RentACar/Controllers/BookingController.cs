using Microsoft.AspNetCore.Mvc;
using RentACar.Models;

namespace RentACar.Controllers
{
	public class BookingController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Booking(Car carId)
		{
			return View();
		}

		[HttpPost]
		public IActionResult Booking(Booking booking)
		{
			return View();
		}
	}
}
