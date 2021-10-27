using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficFineSystem
{
    public abstract class ValidationAttribute : System.Attribute
    {
        public string Message { get; set; }

        public abstract bool IsValid(object o);  
    }
}
