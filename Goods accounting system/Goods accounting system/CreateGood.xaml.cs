using System;
using System.Configuration;
using System.Windows;
using Goods_accounting_system.DataModel;

namespace Goods_accounting_system
{
    /// <summary>
    /// Логика взаимодействия для CreateGood.xaml
    /// </summary>
    public partial class CreateGood : Window
    {
        private IDataBase _db;
        public CreateGood(IDataBase db)
        {
            InitializeComponent();
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ShopDatabaseContext"];
            _db = db;
            GoodProviderField.ItemsSource = _db.FillComboBox();
        }

        private void CreateGoodButton_Click(object sender, RoutedEventArgs e)
        {
            if (GoodNameField.Text.Length >= 3 &&
                GoodNameField.Text.Length <= 20 &&
                GoodPlaceField.Text.Length >= 1 &&
                GoodPlaceField.Text.Length <= 20 &&
                GoodAmountField.Text.Length >= 1 &&
                GoodAmountField.Text.Length <= 10)
            {
                if (GoodProviderField.Text.Length > 0)
                {
                    _db.CreateNewGood(GoodNameField.Text,
                        Convert.ToInt32(GoodPlaceField.Text),
                        Convert.ToInt32(GoodAmountField.Text),
                        GoodProviderField.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Enter correct values!");
                }
            }
        }
    }
}
