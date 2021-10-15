using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for RegulatorWindow.xaml
    /// </summary>
    public partial class RegulatorWindow : Window, IView<RegulatorViewModel>
    {
        private RegulatorViewModel _viewModel;
        private readonly string _addingSuccess = "Штрафы изменены удачно";
        private readonly string _addingFail = "Или штраф содержит спец символы или его значение меньше равно 0";
        public RegulatorWindow()
        {
            InitializeComponent();
        }

        public void Initialize(RegulatorViewModel viewModel)
        {
            _viewModel = viewModel;
            SaveButton.Click += OnSaveClick;
            InitializeFinesView();
        }

        private void InitializeFinesView()
        {
            FinesInfo.ItemsSource = _viewModel.GetFinesCollection();
            FinesInfo.CanUserDeleteRows = true;
        }

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            if (_viewModel.TryToSetTrafficFinesInfo())
            {
                changeSuccess.Text = _addingSuccess;
                return;
            }

            changeSuccess.Text = _addingFail;
        }
    }
}
