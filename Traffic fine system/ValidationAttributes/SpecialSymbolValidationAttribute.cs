using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Traffic_fine_system
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SpecialSymbolsValidationAttribute : ValidationAttribute 
    {
        public SpecialSymbolsValidationAttribute(string message)
        {
            Message = message; 
        }
        
        public override bool IsValid(object item)
        {
            var text = item as string;
            var regexItem = new Regex(@"^[\sаАбБвВгГдДеЕёЁжЖзЗиИйЙкКлЛмМнНоОпПрРсСтТуУфФхХцЦчЧшШщЩъЪыЫьЬэЭюЮяЯaa-zA-Z0-9 ]*$");
            var isSucceeded = regexItem.IsMatch(text);
            return isSucceeded;            
        }
    }
}
