using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Goods_accounting_system
{
    /// <summary>
    /// Логика взаимодействия для CreateGood.xaml
    /// </summary>
    public partial class CreateGood : Window
    {
        private DataBase db = new DataBase();
        public CreateGood()
        {
            InitializeComponent();
        }

        private void CreateGoodButton_Click(object sender, RoutedEventArgs e)
        {
            db.CreateNewGood(GoodNameField.Text, 
                Convert.ToInt32(GoodPlaceField.Text), 
                Convert.ToInt32(GoodAmountField.Text), 
                Convert.ToInt32(GoodProviderField.Text));

        }
    }
}
