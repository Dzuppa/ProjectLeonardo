﻿using MahApps.Metro.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatDesMahAppsDemoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShipsBtn_Click(object sender, RoutedEventArgs e)
        {
            Ships.Visibility = Visibility.Visible;
        }

        private void APBtn_Click(object sender, RoutedEventArgs e)
        {
            AP.Visibility = Visibility.Visible;
        }

        private void BCBtn_Click(object sender, RoutedEventArgs e)
        {
            BC.Visibility = Visibility.Visible;
        }

        private void PointsBtn_Click(object sender, RoutedEventArgs e)
        {
            Points.Visibility = Visibility.Visible;
        }
    }
}
