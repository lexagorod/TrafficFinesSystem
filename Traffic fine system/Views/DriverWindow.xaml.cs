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
        public DriverWindow()
        {
            InitializeComponent();
        }

        public void Initialize(DriverViewModel viewModel)
        {
            _viewModel = viewModel;
        }
    }
}
