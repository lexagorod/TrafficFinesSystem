using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_fine_system
{
    public class ServiceLocator
    {
        public WindowsController WindowsController;
        public TrafficFinesModel TrafficFinesModel;
        public FinesReaderWriter FinesReaderWriter;
        public ServiceLocator()
        {
            TrafficFinesModel = new TrafficFinesModel();
            WindowsController = new WindowsController();
            FinesReaderWriter = new FinesReaderWriter();
        }
    }
}
