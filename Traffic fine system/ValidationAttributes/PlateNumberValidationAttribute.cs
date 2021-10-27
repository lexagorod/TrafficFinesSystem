using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficFineSystem
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PlateNumberValidationAttribute : ValidationAttribute 
    {
        public PlateNumberValidationAttribute(string message)
        {
            Message = message; 
        }
        
        public override bool IsValid(object item)
        {
            var plateNumberString = item as string;

            var isSucceeded = plateNumberString.Length == 6;

            return isSucceeded;            
        }
    }
}
