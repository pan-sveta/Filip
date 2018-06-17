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

namespace Filip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller;

        public MainWindow()
        {
            InitializeComponent();

            controller = new Controller(CanvasSimulation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            controller.filipus.Step();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            controller.filipus.Turn();
        }
    }
}
