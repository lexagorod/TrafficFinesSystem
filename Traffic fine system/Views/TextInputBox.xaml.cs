﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrafficFineSystem.Views
{
    /// <summary>
    /// Interaction logic for TextInputBox.xaml
    /// </summary>
    public partial class TextInputBox : UserControl
    {
        private TextBox _textBox = null;

        private ObservableCollection<ValidationRule> _validationRules = null;

        public TextInputBox()
        {
            InitializeComponent();

            CreateControls();

            ValidationRules = new ObservableCollection<ValidationRule>();

            this.DataContextChanged += new DependencyPropertyChangedEventHandler(RequiredTextBox_DataContextChanged);
        }

        public ObservableCollection<ValidationRule> ValidationRules
        {
            get { return _validationRules; }
            set { _validationRules = value; }
        }

        private void CreateControls()
        {
            _textBox = new TextBox() { Width = 100, Height = 20 };
            _textBox.LostFocus += _textBox_LostFocus;
            _textBox.Style = TextBoxErrorStyle;
        }

        void _textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var bindingExpression = _textBox.GetBindingExpression(TextBox.TextProperty);
            if (bindingExpression != null)
                bindingExpression.UpdateSource();
        }

        void RequiredTextBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (_textBox != null)
            {
                var binding = new Binding();
                binding.Source = this.DataContext;
                binding.ValidatesOnDataErrors = true;
                binding.ValidatesOnExceptions = true;

                foreach (var rule in ValidationRules)
                {
                    binding.ValidationRules.Add(rule);
                }


                binding.Path = new PropertyPath(BoundPropertyName);
                _textBox.SetBinding(TextBox.TextProperty, binding);

                dpMain.Children.Add(_textBox);
            }

        }

        private Style TextBoxErrorStyle
        {
            get
            {
                var style = TryFindResource("TextBoxStyle") as Style;
                if (style == null)
                    throw new Exception("NO STYLE FOUND");
                return style;
            }
        }

        public string TextBoxErrorStyleName { get; set; }
        public string ValidationExpression { get; set; }
        public string BoundPropertyName { get; set; }
        public string Text
        {

            get
            {
                return _textBox.Text;
            }

        }
        public string ErrorText { get; set; }

    }
}
