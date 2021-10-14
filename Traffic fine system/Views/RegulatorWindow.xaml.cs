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

        private void OnSaveClick(object sender, RoutedEventArgs e) => _viewModel.SetTrafficFinesInfo();
    }
}
