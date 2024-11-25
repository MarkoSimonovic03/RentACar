using RentACar.Models;

namespace RentACar.Util
{
    public class Garage
    {
        public static IEnumerable<Car> GenerateCars()
        {
            var cars = new List<Car>
            {
                new Car { CarId = 1, Make = "Audi", Model = "A4", PricePerDay = 75.00m, IsAvailable = true, Year = 2022, Seats = 5, FuelType = "Petrol", ImageUrl = "audi-a4.png" },
                new Car { CarId = 2, Make = "BMW", Model = "2 Series", PricePerDay = 65.00m, IsAvailable = true, Year = 2021, Seats = 4, FuelType = "Diesel", ImageUrl = "bmw-2.png" },
                new Car { CarId = 3, Make = "BMW", Model = "3 Series", PricePerDay = 80.00m, IsAvailable = true, Year = 2023, Seats = 5, FuelType = "Petrol", ImageUrl = "bmw-3.png" },
                new Car { CarId = 4, Make = "BMW", Model = "5 Series", PricePerDay = 95.00m, IsAvailable = true, Year = 2023, Seats = 5, FuelType = "Diesel", ImageUrl = "bmw-5.png" },
                new Car { CarId = 5, Make = "BMW", Model = "7 Series", PricePerDay = 120.00m, IsAvailable = true, Year = 2023, Seats = 5, FuelType = "Petrol", ImageUrl = "bmw-7.png" },
                new Car { CarId = 6, Make = "Mercedes-Benz", Model = "E-Class", PricePerDay = 100.00m, IsAvailable = false, Year = 2022, Seats = 5, FuelType = "Diesel", ImageUrl = "mb-e.png" },
                new Car { CarId = 7, Make = "Mercedes-Benz", Model = "GLC", PricePerDay = 110.00m, IsAvailable = true, Year = 2023, Seats = 5, FuelType = "Petrol", ImageUrl = "mb-glc.png" },
                new Car { CarId = 8, Make = "Skoda", Model = "Octavia", PricePerDay = 55.00m, IsAvailable = true, Year = 2021, Seats = 5, FuelType = "Petrol", ImageUrl = "skoda-octavia.png" },
                new Car { CarId = 9, Make = "Volkswagen", Model = "Jetta", PricePerDay = 60.00m, IsAvailable = true, Year = 2022, Seats = 5, FuelType = "Diesel", ImageUrl = "vw-jetta.png" },
                new Car { CarId = 10, Make = "Volkswagen", Model = "Golf 8", PricePerDay = 50.00m, IsAvailable = true, Year = 2020, Seats = 5, FuelType = "Diesel" }
            };

            return cars;
        }

        public static IEnumerable<Booking> GenerateBookings()
        {
            var bookings = new List<Booking>
            {
                new Booking { BookingId = 1, CarId = 2, UserId = 3, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now, TotalPrice = 2560, PricePerDay = 2560, Car = new Car(){ CarId = 2, Make = "BMW", Model = "2 Series", PricePerDay = 65.00m, IsAvailable = true, Year = 2021, Seats = 4, FuelType = "Diesel", ImageUrl = "bmw-2.png" }},
                new Booking { BookingId = 2, CarId = 2, UserId = 3, StartDate = DateTime.Now.AddDays(3), EndDate = DateTime.Now.AddDays(5), TotalPrice = 5120, PricePerDay = 2560, Car = new Car(){ CarId = 2, Make = "BMW", Model = "2 Series", PricePerDay = 65.00m, IsAvailable = true, Year = 2021, Seats = 4, FuelType = "Diesel", ImageUrl = "bmw-2.png" }}
            };

            return bookings;
        }
    }
}
