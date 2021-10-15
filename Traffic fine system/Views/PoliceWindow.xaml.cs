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
        private readonly string _fineTypeError = "Тип штрафа должен быть выбран";
        private readonly string _fineTypePropertyName = "Тип штрафа";
        private readonly string _successText = "Успешно добавлено";
        private readonly string _failedText = "Ошибка";

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

            var brokenRules = validationEngine.GetBrokenRules().ToList();

            if (string.IsNullOrEmpty(violationsList.Text))
            {
                brokenRules.Add(new BrokenRule() { Message = _fineTypeError, PropertyName = _fineTypePropertyName });
                isValid = false;
            }

            errorList.ItemsSource = brokenRules;

            if (isValid)
            {
                _viewModel.AddFine(fineIssueSubject.Number, new FineType(violationsList.Text), fineIssueSubject.Name);
                addingResult.Text = _successText;

                return;
            }
            addingResult.Text = _failedText;
        }
    }
}
