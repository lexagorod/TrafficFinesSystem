using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Traffic_fine_system
{
    public partial class MainWindow : Window, IView<MainWindowViewModel>
    {
        private MainWindowViewModel _viewModel;

        public void Initialize(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            InitializeButtons();
        }

        public void InitializeButtons()
        {
            var buttonsActions = new Dictionary<ActorType, RoutedEventHandler>() { { new ActorType("Водитель"), OnButtonClick }, { new ActorType("Полиция"), OnButtonClick }, { new ActorType("Регулятор"), OnButtonClick } };
            var buttonFactory = new ActorsButtonFactory();
            foreach (var action in buttonsActions)
            {
                var initializedButton = buttonFactory.CreateAButton(action.Key, action.Value);
                this.LayoutRoot.Items.Add(initializedButton);
            }    
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var clickedButton = (Button)sender;
            _viewModel.InitActorsViewModel((ActorType)clickedButton.Content);
        }
    }
}
