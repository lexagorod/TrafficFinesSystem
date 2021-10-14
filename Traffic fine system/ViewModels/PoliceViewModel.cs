using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_fine_system.ViewModels
{
    public class PoliceViewModel : IViewModel
    {
        private ServiceLocator _serviceLocator;
        public PoliceViewModel(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _serviceLocator.WindowsController.Show(new PoliceWindow(), this);
        }

        public FineType[] GetFineTypes() => _serviceLocator.TrafficFinesModel.TrafficFinesInfo.Keys.ToArray();

        public void AddFine(string plateNumber, IssuedFine issuedFine)
        {
            var allFines = _serviceLocator.FinesReaderWriter.AllFines;

            if (allFines.TryGetValue(plateNumber, out var foundIssuedFine))
            {
                var issuedFinesList = foundIssuedFine.ToList();
                issuedFinesList.Add(issuedFine);
                allFines[plateNumber] = issuedFinesList.ToArray();
            }
            else
                allFines.Add(plateNumber, new IssuedFine[] { issuedFine });

            _serviceLocator.FinesReaderWriter.AllFines = allFines;
        }
    }
}
