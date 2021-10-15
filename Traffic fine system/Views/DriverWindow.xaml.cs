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
    /// Interaction logic for DriverWindow.xaml
    /// </summary>
    public partial class DriverWindow : Window, IView<DriverViewModel>
    {
        private DriverViewModel _viewModel;
        private readonly string _finesFounded = "Штрафы найдены";
        private readonly string _finesNotFounded = "Штрафы для номера не найдены";
        private readonly string _dateCanBeChosen = "Можете найти штраф по времени";
        public DriverWindow()
        {
            InitializeComponent();

            findViolator.DataContext = new PlateNumberSubject();
        }

        public void Initialize(DriverViewModel viewModel)
        {
            _viewModel = viewModel;
        }


        private void FindViolationsButton_click(object sender, RoutedEventArgs e)
        {
            dateCanBeChosen.Text = "";
            violationsListByTime.ItemsSource = null;
            fineInfo.Visibility = Visibility.Collapsed;

            var plateNumberSubject = new PlateNumberSubject() { PlateNumber = txtNumber.Text };
            var validationEngine = new ValidationEngine();

            var isValid = validationEngine.Validate(plateNumberSubject);

            var brokenRules = validationEngine.GetBrokenRules();

            if (!isValid)
                return;

            _viewModel.FindFinesForPlateNumber(plateNumberSubject.PlateNumber.ToUpperInvariant());
            violationsListByTime.ItemsSource = _viewModel.GetAllFinesDates();

            if (violationsListByTime.ItemsSource == null || violationsListByTime.Items.Count == 0)
            {
                findingResult.Text = _finesNotFounded;
                return;
            }
            findingResult.Text = _finesFounded;
            dateCanBeChosen.Text = _dateCanBeChosen;
        }

        private void OnDropDownValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(violationsListByTime.Text))
                return;

            fineInfo.Visibility = Visibility.Visible;

            var issuedFines = _viewModel.GetAllIssuedFinesForCurrentNumber();
            var selectedFineIndex = violationsListByTime.SelectedIndex;
            violatorName.Text = issuedFines[selectedFineIndex].ViolatorName;
            violationType.Text = issuedFines[selectedFineIndex].FineType;
            date.Text = issuedFines[selectedFineIndex].DateTimeIssued.ToString();
            fineAmount.Text = issuedFines[selectedFineIndex].FineAmount.ToString();
        }

        private void PayTheFineButton_click(object sender, RoutedEventArgs e)
        {
            _viewModel.PayTheFine(violationsListByTime.SelectedIndex);
            FindViolationsButton_click(null, null);
        }
    }
}
