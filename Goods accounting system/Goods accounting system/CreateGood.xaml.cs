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
        private DataBase db;
        public CreateGood()
        {
            InitializeComponent();
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ShopDatabaseContext"];
            db = new DataBase(new ShopDatabaseContext(settings.ConnectionString));
            GoodProviderField.ItemsSource = db.FillComboBox();
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
                    db.CreateNewGood(GoodNameField.Text,
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
