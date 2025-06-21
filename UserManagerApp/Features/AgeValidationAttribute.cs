using System.ComponentModel.DataAnnotations;

namespace UserManagerApp.Features
{
    public class AgeValidationAttribute : ValidationAttribute
    {
        private readonly int _minAge;
        private readonly int _maxAge;

        public AgeValidationAttribute(int minAge, int maxAge)
        {
            _minAge = minAge;
            _maxAge = maxAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value is DateTime birthDate)
            {
                var age = DateTime.Today.Year - birthDate.Year;
                if (birthDate > DateTime.Today.AddYears(-age)) age--;

                if (age < _minAge || age > _maxAge)
                {
                    return new ValidationResult($"Age must be between {_minAge} and {_maxAge} years.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
