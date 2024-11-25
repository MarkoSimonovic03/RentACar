using System.ComponentModel.DataAnnotations;

namespace RentACar.Util
{
	public class DateGreaterThanAttribute : ValidationAttribute
	{
		private readonly string _comparisonProperty;

		public DateGreaterThanAttribute(string comparisonProperty)
		{
			_comparisonProperty = comparisonProperty;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var currentValue = (DateTime?)value;
			var comparisonPropery = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (comparisonPropery == null)
            {
				throw new ArgumentException("Comparison propery not found");
            }

			var comparisonValue = (DateTime?)comparisonPropery.GetValue(validationContext.ObjectInstance);

			if(comparisonValue != null && comparisonValue != null && currentValue <= comparisonValue)
			{
				return new ValidationResult(ErrorMessage);
			}

            return ValidationResult.Success;
		}
	}
}