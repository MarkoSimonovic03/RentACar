using RentACar.Models;
using System.Linq;

namespace RentACar.Services
{
	public class CarService : ICarCervice
	{
		private readonly RentACarContext _context;

		public CarService(RentACarContext context)
		{
			_context = context;
		}

		public IEnumerable<Car> GetAllCars()
		{
			return _context.Cars.ToList();
		}

		public IEnumerable<Car> GetAllFilteredCars(string make, string model, int? minPrice, int? maxPrice)
		{
			var cars = _context.Cars.AsQueryable();

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

			return cars;
		}

		public Car GetCarById(int id)
		{
			return _context.Cars.Find(id);
		}

		public void AddCar(Car car)
		{
			_context.Cars.Add(car);
			_context.SaveChanges();
		}

		public void UpdateCar(Car car)
		{
			_context.Cars.Update(car);
			_context.SaveChanges();
		}

		public void DeleteCar(int id)
		{
			var car = _context.Cars.Find(id);
			if (car != null)
			{
				_context.Cars.Remove(car);
				_context.SaveChanges();
			}
		}
	}
}
