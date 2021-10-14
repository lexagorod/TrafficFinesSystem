using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Traffic_fine_system
{
    public class NumericValidationRule : ValidationRule
    {
        public string ErrorMessage { get; set; }
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(String.IsNullOrEmpty(value as String))
                return new ValidationResult(true,String.Empty);

            var valueAsNumber = 0;
            var isSucceeded = Int32.TryParse(value as string, out valueAsNumber);

            if(isSucceeded)
            {
                return new ValidationResult(true,String.Empty);
            }

            return new ValidationResult(false,ErrorMessage);
            
        }
    }
}
