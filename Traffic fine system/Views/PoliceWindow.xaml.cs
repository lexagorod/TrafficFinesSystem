using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Traffic_fine_system.ViewModels;

namespace Traffic_fine_system
{
    /// <summary>
    /// Interaction logic for PoliceWindow.xaml
    /// </summary>
    public partial class PoliceWindow : Window, IView<PoliceViewModel>
    {
        private PoliceViewModel _viewModel;
        public PoliceWindow()
        {
            InitializeComponent();

            gvAddViolator.DataContext = new FineIssueSubject();
        }

        public void Initialize(PoliceViewModel viewModel)
        {
            _viewModel = viewModel;

            violationsList.ItemsSource = _viewModel.GetFineTypes();
        }


        private void AddViolatorButton_click(object sender, RoutedEventArgs e)
        {
            var fineIssueSubject = new FineIssueSubject() { Number = txtNumber.Text, Name = txtName.Text };
            var validationEngine = new ValidationEngine();

            var isValid = validationEngine.Validate(fineIssueSubject);

            errorList.ItemsSource = validationEngine.GetBrokenRules();

            if (isValid)
            {
                _viewModel.AddFine(fineIssueSubject.Number, new IssuedFine { FineType = violationsList.Text, FineAmount = 15, VehicleOwner = fineIssueSubject.Name, DateTimeIssued = DateTime.Now });
            }
        }
    }
}
