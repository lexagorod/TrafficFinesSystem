﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static TrafficFineSystem.RegulatorWindow;

namespace TrafficFineSystem.Views
{
    /// <summary>
    /// Interaction logic for TextBox.xaml
    /// </summary>
    public partial class FineBox : UserControl, IFineCost
    {
        public FineBox()
        {
            InitializeComponent();
        }

        public string FineType { get ; set; }
        public decimal FineAmount { get ; set; }

    }
}
