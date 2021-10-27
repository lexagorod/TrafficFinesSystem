using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFineSystem
{
    interface IFineCost
    {
        string FineType { get; set; }
        decimal FineAmount { get; set; }
    }
}
