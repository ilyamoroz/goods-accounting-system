using Goods_accounting_system.DataModel;
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
    /// Логика взаимодействия для EditGoodWindow.xaml
    /// </summary>
    public partial class EditGoodWindow : Window
    {
        private DataBase db = new DataBase();
        Good good;
        private int GoodId;
        public EditGoodWindow()
        {
            InitializeComponent();
        }
        public EditGoodWindow(int id)
        {
            InitializeComponent();
            GoodId = id;
            FillFields();
        }

        private void FillFields()
        {
            good = db.GetGoodByID(GoodId);
            GoodNameField.Text = good.Name;
            GoodPlaceField.Text = good.StoragePlace.ToString();
            GoodAmountField.Text = good.Amount.ToString();
        } 

        private void SaveGoodButton_Click(object sender, RoutedEventArgs e)
        {
            db.EditGoodByID(GoodId, GoodNameField.Text, Convert.ToInt32(GoodPlaceField.Text), Convert.ToInt32(GoodAmountField.Text));
            MessageBox.Show("Data Changed");
            GoodNameField.Text = "";
            GoodPlaceField.Text = "";
            GoodAmountField.Text = "";
        }
    }
}
