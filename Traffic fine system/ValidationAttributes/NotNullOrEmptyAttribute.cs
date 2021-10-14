using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traffic_fine_system
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotNullOrEmptyAttribute : ValidationAttribute 
    {
        public NotNullOrEmptyAttribute(string message)
        {
            Message = message; 
        }
        
        public override bool IsValid(object item)
        {
            if (String.IsNullOrEmpty((string)item))
                return false;

            return true;             
        }
    }
}
