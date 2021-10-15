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

        public void AddFine(string plateNumber, FineType fineType, string trafficViolatorName)
        {
            plateNumber = plateNumber.ToUpperInvariant();
            var allFines = _serviceLocator.FinesReaderWriter.AllFines;
            var issuedFine = new IssuedFine() { FineType = (string)fineType, ViolatorName = trafficViolatorName, DateTimeIssued = DateTime.Now, FineAmount = _serviceLocator.TrafficFinesModel.TrafficFinesInfo[fineType] };

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
