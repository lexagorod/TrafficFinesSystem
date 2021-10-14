using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Traffic_fine_system
{
    public class NotNullOrEmptyValidationRule : ValidationRule
    {
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(String.IsNullOrEmpty(value as String))
            {
                return new ValidationResult(false, ErrorMessage); 
            }

            return new ValidationResult(true,String.Empty);
        }
    }
}
