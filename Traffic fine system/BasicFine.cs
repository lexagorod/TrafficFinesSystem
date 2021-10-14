using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_fine_system
{
    public class Fine : IFine
    {
        public string FineType { get; set; }
        public decimal FineAmount { get; set; }
    }
}
