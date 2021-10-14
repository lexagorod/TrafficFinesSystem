using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_fine_system.ViewModels
{
    public class PoliceViewModel : IViewModel
    {
        public PoliceViewModel(ServiceLocator serviceLocator)
        {
            serviceLocator.WindowsController.Show(new PoliceWindow(), this);
        }
    }
}
