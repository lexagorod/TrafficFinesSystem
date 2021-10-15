using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Traffic_fine_system
{
    public class SpecialSymbolsValidationRule : ValidationRule
    {
        public string ErrorMessage { get; set; }
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(String.IsNullOrEmpty(value as String))
                return new ValidationResult(true,String.Empty);

            var text = value as string;
            var regexItem = new Regex(@"^[\sаАбБвВгГдДеЕёЁжЖзЗиИйЙкКлЛмМнНоОпПрРсСтТуУфФхХцЦчЧшШщЩъЪыЫьЬэЭюЮяЯaa-zA-Z0-9 ]*$");
            var isSucceeded = regexItem.IsMatch(text);

            if (isSucceeded)
            {
                return new ValidationResult(true,String.Empty);
            }

            return new ValidationResult(false,ErrorMessage);
            
        }
    }
}
