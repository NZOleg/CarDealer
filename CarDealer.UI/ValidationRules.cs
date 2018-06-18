using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarDealer.UI
{
    class ValidationRules : ValidationRule
    {
        public string Type { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Field is required");
            }
            ValidationResult result;
            int n;

            switch (Type)
            {
                case "year":
                case "engineSize":
                case "currentMileage":
                case "numberOfSeats":
                case "askingPrice":
                    result = ValidateInt(value);
                    if (result != null)
                    {
                        return result;
                    }
                    break;
            }

            switch (Type)
            {
                case "year":


                    int.TryParse(value.ToString(), out n);
                    if (n < 1950 || n > 2018)
                    {
                        return new ValidationResult(false, "Year is out of the range");
                    }
                    break;
                case "engineSize":
                    int.TryParse(value.ToString(), out n);
                    if (n < 100 || n > 15000)
                    {
                        return new ValidationResult(false, "This engine Size does not exist");
                    }
                    break;
                case "numberOfSeats":
                    int.TryParse(value.ToString(), out n);
                    if (n < 1 || n>20)
                    {
                        return new ValidationResult(false, "Your car can't have that amount of seats");
                    }
                    break;
            }


            return ValidationResult.ValidResult;
        }



        public ValidationResult ValidateInt(object value)
        {
            if (!int.TryParse(value.ToString(), out int n))
            {
                return new ValidationResult(false, "Illegal characters used in this field");
            }
            else
            {
                return null;
            }
        }
    }
}
