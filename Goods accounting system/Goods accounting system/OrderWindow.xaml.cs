using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Goods_accounting_system.DataModel;
using System.Windows;


namespace Goods_accounting_system
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private DataBase db;
        
        public OrderWindow()
        {
            InitializeComponent();
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ShopDatabaseContext"];
            db = new DataBase(new ShopDatabaseContext(settings.ConnectionString));
            FillDataGrid();
        }


        private void FillDataGrid()
        {
            OrderDataGrid.ItemsSource = db.GetAllGoods();

        }

        private void AddGoodBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int amount = Convert.ToInt32(OrderTextBox.Text);

                if (amount > 0 && amount < 10000)
                {
                    List<Good> goods = db.GetGoods();
                    db.MakeOrder(goods[indexList.Last()].GoodID, amount);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Enter correct value!");
                OrderTextBox.Text = "";
            }
        }
        private List<int> indexList = new List<int>();
        private void OrderDataGrid_SelectedCellsChanged(object sender, System.Windows.Controls.SelectedCellsChangedEventArgs e)
        {
            indexList.Add(OrderDataGrid.SelectedIndex);
        }
    }
}
