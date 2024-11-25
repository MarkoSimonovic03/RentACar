using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using RentACar.Util;

namespace RentACar.Controllers
{
	public class CarController : Controller
	{
		public IActionResult Index(string make, string model, int? minPrice, int? maxPrice)
		{
			var cars = Garage.GenerateCars();

			if (!string.IsNullOrEmpty(make))
			{
				cars = cars.Where(c => c.Make.ToUpper().Contains(make.Trim().ToUpper()));
			}

			if (!string.IsNullOrEmpty(model))
			{
				cars = cars.Where(c => c.Model.ToUpper().Contains(model.Trim().ToUpper()));
			}

			if (minPrice.HasValue)
			{
				cars = cars.Where(c => c.PricePerDay >= minPrice);
			}

			if (maxPrice.HasValue)
			{
				cars = cars.Where(c => c.PricePerDay <= maxPrice);
			}

			return View(cars);
		}

		public IActionResult Details(int id)
		{
			var cars = Garage.GenerateCars();

			var car = cars.FirstOrDefault(c => c.CarId == id);

			if (car == null) return NotFound();

			return View(car);
		}
	}
}
