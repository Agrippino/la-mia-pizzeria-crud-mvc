using System.ComponentModel.DataAnnotations;

namespace PizzeriaAgrippino.Utilies.Validation
{
    public class ValidationParticolari
    {
        public class MoreThanOneWordValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(
               object value, ValidationContext validationContext)
            {
                string fieldValue = (string)value;

                if (fieldValue == null || fieldValue.Trim().IndexOf("     ") == -1)
                {
                    return new ValidationResult("Il campo deve contenere almeno cinque parole");
                }

                return ValidationResult.Success;
            }
           

        }
    }
}
