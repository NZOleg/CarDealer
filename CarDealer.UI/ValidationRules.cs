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
            int n;
            if (!int.TryParse(value.ToString(), out n))
            {
                return new ValidationResult(false, "Illegal characters used in this field");
            }
            if (n<1950 || n> 2018){
                return new ValidationResult(false, "Year is out of the range");
            }
            return ValidationResult.ValidResult;
        }
    }
}
