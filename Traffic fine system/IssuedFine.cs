using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_fine_system
{
    [Serializable]
    public class IssuedFine
    {
        public string FineType { get; set; }
        public decimal FineAmount { get; set; }
        public DateTime DateTimeIssued { get; set; }
        public string VehicleOwner { get; set; }
    }
}
