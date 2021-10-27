using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFineSystem
{
    public class FineCost : IFineCost
    {
        public string FineType { get; set; }
        public decimal FineAmount { get; set; }
    }
}
