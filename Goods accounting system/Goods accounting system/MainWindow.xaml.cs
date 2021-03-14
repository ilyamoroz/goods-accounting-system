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

namespace Goods_accounting_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateNewGoodButton_Click(object sender, RoutedEventArgs e)
        {
            CreateGood createGood = new CreateGood();
            createGood.ShowDialog();
        }

        private void CreateNewProviderButton_Click(object sender, RoutedEventArgs e)
        {
            CreateProvider createProvider = new CreateProvider();
            createProvider.ShowDialog();
        }
    }
}