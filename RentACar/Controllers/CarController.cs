using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using RentACar.Models.ViewModels;
using RentACar.Services;
using RentACar.Util;

namespace RentACar.Controllers
{
	public class CarController : Controller
	{
		private readonly ICarCervice _carService;

		public CarController(ICarCervice carService)
		{
			_carService = carService;
		}

		public async Task<IActionResult> Index(string make, string model, int? minPrice, int? maxPrice, int pageCount = 1, int pageSize = 3)
		{
			var cars = _carService.GetAllFilteredCars(make, model, minPrice, maxPrice);

			var totalPages = (int)Math.Ceiling((double)cars.Count() / pageSize);
			pageCount = (pageCount < 1) ? 1 : (pageCount > totalPages ? totalPages : pageCount);

			var modelView = new CarIndexViewModel()
			{
				Pagination = new PaginationViewModel()
				{
					TotalPages = totalPages,
					PageCount = pageCount,
					PageSize = pageSize
				}
			};

			cars = cars.Skip(pageSize * (pageCount - 1)).Take(pageSize);

			modelView.Cars = cars;

			return View(modelView);
		}

		public async Task<IActionResult> Details(int id)
		{
			var car = _carService.GetCarById(id);

			//var cars = Garage.GenerateCars();
			//var car = cars.FirstOrDefault(c => c.CarId == id);

			if (car == null) return NotFound();

			return View(car);
		}
	}
}
