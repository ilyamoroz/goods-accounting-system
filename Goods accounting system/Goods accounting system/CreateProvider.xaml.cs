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
    /// Логика взаимодействия для CreateProvider.xaml
    /// </summary>
    public partial class CreateProvider : Window
    {
        private DataBase db = new DataBase();
        public CreateProvider()
        {
            InitializeComponent();
        }

        private void CreateNewProviderButton_Click(object sender, RoutedEventArgs e)
        {
            db.CreateNewProvider(ProviderNameField.Text, 
                ProviderAddressField.Text, 
                ProviderPhoneNumberField.Text);
        }
    }
}
