using System;
using System.Collections.Generic;
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
        public OrderWindow()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private DataBase db = new DataBase();

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
                    using (ShopDatabaseContext context = new ShopDatabaseContext())
                    {
                        List<Good> goods = context.Goods.ToList<Good>();
                        db.MakeOrder(goods[indexList.Last()].GoodID, amount);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Enter correct value!");
                OrderTextBox.Text = "";
            }
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private List<int> indexList = new List<int>(); 

        private void OrderDataGrid_SelectedCellsChanged(object sender, System.Windows.Controls.SelectedCellsChangedEventArgs e)
        {
            indexList.Add(OrderDataGrid.SelectedIndex);
        }
    }
}
