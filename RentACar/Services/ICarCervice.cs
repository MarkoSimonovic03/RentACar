using RentACar.Models;

namespace RentACar.Services
{
	public interface ICarCervice
	{
		IEnumerable<Car> GetAllCars();
		IEnumerable<Car> GetAllFilteredCars(string make, string model, int? minPrice, int? maxPrice);
		Car GetCarById(int id);
		void AddCar(Car car);
		void UpdateCar(Car car);
		void DeleteCar(int id);
	}
}
