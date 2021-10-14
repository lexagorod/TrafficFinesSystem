using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_fine_system.ViewModels
{
    public class DriverViewModel : IViewModel
    {
        public DriverViewModel(ServiceLocator serviceLocator)
        {
            serviceLocator.WindowsController.Show<DriverViewModel>(new DriverWindow(), this);
        }
    }
}
