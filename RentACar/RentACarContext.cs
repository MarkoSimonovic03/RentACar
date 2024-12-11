using Microsoft.EntityFrameworkCore;
using RentACar.Models;

namespace RentACar
{
	public class RentACarContext : DbContext
	{
		public RentACarContext(DbContextOptions<RentACarContext> options) : base(options) { }
		public DbSet<Car> Cars { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		//public DbSet<Review> Reviews { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
