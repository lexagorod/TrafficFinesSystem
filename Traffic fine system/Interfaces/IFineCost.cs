using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_fine_system
{
    interface IFineCost
    {
        string FineType { get; set; }
        decimal FineAmount { get; set; }
    }
}
