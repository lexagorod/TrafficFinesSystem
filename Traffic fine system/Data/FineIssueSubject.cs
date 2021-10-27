using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace TrafficFineSystem
{
    public class FineIssueSubject : BusinessBase,INotifyPropertyChanged
    {
        private string _number;
        private string _name; 

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        [SpecialSymbolsValidation("В знаке не должно быть спец символов")]
        [PlateNumberValidation("Номер должен состоять из 6 цифр")]
        [NotNullOrEmpty("Номер не может быть null или пустым!")]
        public string Number
        {
            get
            {
                return _number;
            }
            set
            {_number = value; 
                OnPropertyChanged("Number");
            }
        }

        [SpecialSymbolsValidation("В имени не должно быть спец символов")]
        [NotNullOrEmpty("Имя не может быть null или пустым!")]
        public string Name
        {
            get { return _name;}
            set
            {
                _name = value; 
                OnPropertyChanged("Name");
            }
        }



    }
}
