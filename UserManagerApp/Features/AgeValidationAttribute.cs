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

        public override bool IsValid(object value)
        {
            if (value is not DateTime birthDate)
                return false;

            var age = DateTime.Today.Year - birthDate.Year;
            if (birthDate > DateTime.Today.AddYears(-age)) age--;

            return age >= _minAge && age <= _maxAge;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"La fecha de nacimiento no es válida (Parameter '{name}')";
        }
    }
}
