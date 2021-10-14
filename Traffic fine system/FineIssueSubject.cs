using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace Traffic_fine_system
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
