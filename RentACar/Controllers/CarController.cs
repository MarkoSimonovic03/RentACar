using Microsoft.AspNetCore.Mvc;
using RentACar.Models;

namespace RentACar.Controllers
{
	public class CarController : Controller
	{
		public IActionResult Index(string make, string model, int? minPrice, int? maxPrice)
		{
			var cars = InitCars();

			if (make != null)
			{
				cars = cars.Where(c => c.Make.ToUpper().Contains(make.Trim().ToUpper()));
			}

			if (model != null)
			{
				cars = cars.Where(c => c.Model.ToUpper().Contains(model.Trim().ToUpper()));
			}

			if (minPrice > 0)
			{
				cars = cars.Where(c => c.PricePerDay >= minPrice);
			}

			if (maxPrice > 0)
			{
				cars = cars.Where(c => c.PricePerDay <= maxPrice);
			}

			return View(cars);
		}

		public IActionResult Details(int id)
		{
			var cars = InitCars();

			var car = cars.FirstOrDefault(c => c.CarId == id);

			if (car == null) return NotFound();

			return View(car);
		}

		public IActionResult Booking()
		{
			return View();
		}

		public IActionResult Review()
		{
			return View();
		}

		private IEnumerable<Car> InitCars()
		{
			List<Car> cars = new List<Car>()
{
	new Car
	{
		CarId = 1,
		Make = "Audi",
		Model = "A4",
		PricePerDay = 75.00m,
		IsAvailable = true,
		Year = 2022,
		Seats = 5,
		FuelType = "Petrol",
		ImageUrl = "audi-a4.png"
	},
	new Car
	{
		CarId = 2,
		Make = "BMW",
		Model = "2 Series",
		PricePerDay = 65.00m,
		IsAvailable = true,
		Year = 2021,
		Seats = 4,
		FuelType = "Diesel",
		ImageUrl = "bmw-2.png"
	},
	new Car
	{
		CarId = 3,
		Make = "BMW",
		Model = "3 Series",
		PricePerDay = 80.00m,
		IsAvailable = true,
		Year = 2023,
		Seats = 5,
		FuelType = "Petrol",
		ImageUrl = "bmw-3.png"
	},
	new Car
	{
		CarId = 4,
		Make = "BMW",
		Model = "5 Series",
		PricePerDay = 95.00m,
		IsAvailable = true,
		Year = 2023,
		Seats = 5,
		FuelType = "Diesel",
		ImageUrl = "bmw-5.png"
	},
	new Car
	{
		CarId = 5,
		Make = "BMW",
		Model = "7 Series",
		PricePerDay = 120.00m,
		IsAvailable = true,
		Year = 2023,
		Seats = 5,
		FuelType = "Petrol",
		ImageUrl = "bmw-7.png"
	},
	new Car
	{
		CarId = 6,
		Make = "Mercedes-Benz",
		Model = "E-Class",
		PricePerDay = 100.00m,
		IsAvailable = false,
		Year = 2022,
		Seats = 5,
		FuelType = "Diesel",
		ImageUrl = "mb-e.png"
	},
	new Car
	{
		CarId = 7,
		Make = "Mercedes-Benz",
		Model = "GLC",
		PricePerDay = 110.00m,
		IsAvailable = true,
		Year = 2023,
		Seats = 5,
		FuelType = "Petrol",
		ImageUrl = "mb-glc.png"
	},
	new Car
	{
		CarId = 8,
		Make = "Skoda",
		Model = "Octavia",
		PricePerDay = 55.00m,
		IsAvailable = true,
		Year = 2021,
		Seats = 5,
		FuelType = "Petrol",
		ImageUrl = "skoda-octavia.png"
	},
	new Car
	{
		CarId = 9,
		Make = "Volkswagen",
		Model = "Jetta",
		PricePerDay = 60.00m,
		IsAvailable = true,
		Year = 2022,
		Seats = 5,
		FuelType = "Diesel",
		ImageUrl = "vw-jetta.png"
	}
};



			return cars;
		}
	}
}
