using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFineSystem
{
    public class ServiceLocator
    {
        public WindowsController WindowsController;
        public FinesCostReaderWriter TrafficFinesModel;
        public FinesReaderWriter FinesReaderWriter;
        public ServiceLocator()
        {
            TrafficFinesModel = new FinesCostReaderWriter();
            WindowsController = new WindowsController();
            FinesReaderWriter = new FinesReaderWriter();
        }
    }
}
