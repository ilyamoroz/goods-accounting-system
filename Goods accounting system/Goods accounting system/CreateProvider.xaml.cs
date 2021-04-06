using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Goods_accounting_system.DataModel;

namespace Goods_accounting_system
{
    /// <summary>
    /// Логика взаимодействия для CreateProvider.xaml
    /// </summary>
    public partial class CreateProvider : Window
    {
        private IDataBase _db;
        public CreateProvider(IDataBase db)
        {
            InitializeComponent();
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ShopDatabaseContext"];
            _db = db;
        }

        private void CreateNewProviderButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProviderNameField.Text.Length >= 3 &&
                ProviderNameField.Text.Length <= 20 &&
                ProviderAddressField.Text.Length >= 4 &&
                ProviderAddressField.Text.Length <= 50 &&
                ProviderPhoneNumberField.Text.Length == 10)
            {
                _db.CreateNewProvider(ProviderNameField.Text,
                    ProviderAddressField.Text,
                    ProviderPhoneNumberField.Text);
            }
            else
            {
                MessageBox.Show("Enter correct values!");
            }
            this.Close();
            
        }
    }
}
