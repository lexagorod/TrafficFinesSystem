using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFineSystem
{
    [Serializable]
    public class IssuedFine
    {
        public string FineType { get; set; }
        public decimal FineAmount { get; set; }
        public DateTime DateTimeIssued { get; set; }
        public string ViolatorName { get; set; }
    }
}
