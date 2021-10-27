using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TrafficFineSystem
{
    public class ValidationEngine
    {
        private List<BrokenRule> _brokenRules = new List<BrokenRule>();

        public IList<BrokenRule> GetBrokenRules() 
        {
           return new ReadOnlyCollection<BrokenRule>(_brokenRules); 
        }

        public bool Validate<T>(T item) where T : BusinessBase 
        {
            var properties = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var customAtt = property.GetCustomAttributes(typeof(ValidationAttribute), true);

                foreach (var att in customAtt)
                {
                    var valAtt = att as ValidationAttribute;
                    if (valAtt == null) continue;

                    if (valAtt.IsValid(property.GetValue(item, null))) continue;

                    var brokenRule = new BrokenRule
                                         {
                                             Message = valAtt.Message, 
                        PropertyName = property.Name
                    };

                    _brokenRules.Add(brokenRule);
                }

            }

            return (_brokenRules.Count == 0);
        }
    }
}
