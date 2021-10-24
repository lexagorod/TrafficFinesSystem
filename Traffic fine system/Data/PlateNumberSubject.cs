using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace Traffic_fine_system
{
    public class PlateNumberSubject : BusinessBase,INotifyPropertyChanged
    {
        private string _plateNumber;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        [SpecialSymbolsValidation("В знаке не должно быть спец символов")]
        [PlateNumberValidation("Знак должен состоять из 6 символов")]
        [NotNullOrEmpty("Номер не может быть null или пустым!")]
        public string PlateNumber
        {
            get
            {
                return _plateNumber;
            }
            set
            {
                _plateNumber = value; 
                OnPropertyChanged("Number");
            }
        }
    }
}
