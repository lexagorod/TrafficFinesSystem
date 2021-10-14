using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_fine_system
{
    interface IFine
    {
        string FineType { get; set; }
        decimal FineAmount { get; set; }
    }
}
