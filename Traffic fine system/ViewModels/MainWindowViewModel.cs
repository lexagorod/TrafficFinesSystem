using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrafficFineSystem.ViewModels;

namespace TrafficFineSystem
{
    public class MainWindowViewModel : IViewModel
    {
        private ServiceLocator _serviceLocator;
        public MainWindowViewModel(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _serviceLocator.WindowsController.Show(new MainWindow(), this);
        }

        public void InitActorsViewModel(ActorType actorType)
        {
            switch (actorType)
            {
                case "Водитель":
                    new DriverViewModel(_serviceLocator);
                    break;
                case "Полиция":
                    new PoliceViewModel(_serviceLocator);
                    break;
                case "Регулятор":
                    new RegulatorViewModel(_serviceLocator);
                    break;
                default:
                    break;
            }
        }
    }
}
