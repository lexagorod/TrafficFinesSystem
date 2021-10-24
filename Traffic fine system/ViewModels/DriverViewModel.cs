using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_fine_system.ViewModels
{
    public class DriverViewModel : IViewModel
    {
        private ServiceLocator _serviceLocator;
        private IssuedFine[] _currentPlateNumberFines;
        private string _currentPlateNumber;
        public DriverViewModel(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _serviceLocator.WindowsController.Show(new DriverWindow(), this);
        }

        public void FindFinesForPlateNumber(string plateNumber)
        {
            var allFines =_serviceLocator.FinesReaderWriter.AllFines;
            _currentPlateNumber = plateNumber;
            if (allFines.TryGetValue(plateNumber, out var issuedFines))
            {
                _currentPlateNumberFines = issuedFines;
                return;
            }

            _currentPlateNumberFines = null;
        }

        public DateTime[] GetAllFinesDates()
        {
            return _currentPlateNumberFines?.Select(f => f.DateTimeIssued).ToArray();
        }

        public IssuedFine[] GetAllIssuedFinesForCurrentNumber() => _currentPlateNumberFines;

        public void PayTheFine(int fineIndex)
        {
            var allFines = _serviceLocator.FinesReaderWriter.AllFines;
            var issuedFinesList = allFines[_currentPlateNumber].ToList();
            issuedFinesList.RemoveAt(fineIndex);
            allFines[_currentPlateNumber] = issuedFinesList.ToArray();

            if (issuedFinesList.Count == 0)
                allFines.Remove(_currentPlateNumber);

            _serviceLocator.FinesReaderWriter.AllFines = allFines;
        }
    }
}
