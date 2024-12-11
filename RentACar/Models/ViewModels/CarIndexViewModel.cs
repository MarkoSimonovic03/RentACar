namespace RentACar.Models.ViewModels
{
	public class CarIndexViewModel
	{
		public IEnumerable<Car> Cars { get; set; }
		public PaginationViewModel Pagination { get; set; }

	}
}
