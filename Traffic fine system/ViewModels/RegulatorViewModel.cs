using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Traffic_fine_system.ViewModels
{
    public class RegulatorViewModel : IViewModel
    {
        private ServiceLocator _serviceLocator;
        private ObservableCollection<FineCost> FinesCollection = new ObservableCollection<FineCost>();
        public RegulatorViewModel(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _serviceLocator.WindowsController.Show(new RegulatorWindow(), this);
            FillFinesCollection();
        }

        private void FillFinesCollection()
        {
            foreach (var fine in _serviceLocator.TrafficFinesModel.TrafficFinesInfo)
            {
                FinesCollection.Add(new FineCost() { FineType = fine.Key, FineAmount = fine.Value });
            }
        }

        public ObservableCollection<FineCost> GetFinesCollection() => FinesCollection;

        public bool TryToSetTrafficFinesInfo()
        {
            var regexItem = new Regex(@"^[\sаАбБвВгГдДеЕёЁжЖзЗиИйЙкКлЛмМнНоОпПрРсСтТуУфФхХцЦчЧшШщЩъЪыЫьЬэЭюЮяЯa-zA-Z0-9]*$");
            foreach (var fineCost in FinesCollection)
            {
                if (fineCost.FineAmount <= 0 || !regexItem.IsMatch(fineCost.FineType))
                    return false;
            }

            _serviceLocator.TrafficFinesModel.TrafficFinesInfo = FinesCollection.ToDictionary(f => new FineType(f.FineType), f => f.FineAmount);
            return true;
        }
    }
}
