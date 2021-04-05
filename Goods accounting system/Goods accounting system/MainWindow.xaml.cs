using Goods_accounting_system.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Drawing;
using System.Drawing.Printing;
using System.Printing;
using System.Windows.Controls;
using Serilog;


namespace Goods_accounting_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataBase _db;

        public MainWindow()
        {
            
            InitializeComponent();
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File(@"../../../information.log").CreateLogger();
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ShopDatabaseContext"];
            _db = new DataBase(new ShopDatabaseContext(settings.ConnectionString));
            FillGoodsDataGrid();
            FillProvidersGrid();
        }

        private void FillGoodsDataGrid()
        {
            GoodsDataGrid.ItemsSource = _db.GetAllGoods();
        }

        private void FillProvidersGrid()
        {
            ProvidersDataGrid.ItemsSource = _db.GetAllProviders();
        }

        private void CreateNewGoodButton_Click(object sender, RoutedEventArgs e)
        {
            CreateGood createGood = new CreateGood();
            createGood.ShowDialog();
            Log.Information("Created new good");
            
            FillGoodsDataGrid();
        }

        private void CreateNewProviderButton_Click(object sender, RoutedEventArgs e)
        {
            CreateProvider createProvider = new CreateProvider();
            createProvider.ShowDialog();
            Log.Information("Created new provider");
            FillProvidersGrid();
        }

        private void GoodEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (GoodsDataGrid.SelectedIndex >= 0)
            {
                List<Good> goods = _db.GetGoods();
                EditGoodWindow edit = new EditGoodWindow(goods[GoodsDataGrid.SelectedIndex].GoodID);
                edit.ShowDialog();
                Log.Information("Edit good: {Name}", goods[GoodsDataGrid.SelectedIndex].Name);
                FillGoodsDataGrid();
            }
        }

        private void ProviderDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProvidersDataGrid.SelectedIndex > 0)
            {
                List<Provider> providers = _db.GetProviders();
                _db.DeleteProvider(providers[ProvidersDataGrid.SelectedIndex].ProviderID);
                Log.Information("Deleted provider: {Name}", providers[ProvidersDataGrid.SelectedIndex].Name);
                FillProvidersGrid();
            }
        }

        private void DeleteGoodButton_Click(object sender, RoutedEventArgs e)
        {
            if (GoodsDataGrid.SelectedIndex > 0)
            {
                List<Good> goods = _db.GetGoods();
                _db.DeleteGood(goods[GoodsDataGrid.SelectedIndex].GoodID);
                Log.Information("Deleted good: {Name}", goods[GoodsDataGrid.SelectedIndex].Name);
                FillGoodsDataGrid();
            }
        }

        private void ProviderEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProvidersDataGrid.SelectedIndex >= 0)
            {
                List<Provider> providers = _db.GetProviders();
                EditProviderWindow edit = new EditProviderWindow(providers[ProvidersDataGrid.SelectedIndex].ProviderID);
                edit.ShowDialog();
                Log.Information("Edit provider: {Name}", providers[ProvidersDataGrid.SelectedIndex].Name);
                FillProvidersGrid();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(GoodsDataGrid, "");
                }
                Log.Information("Print document");
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void FilterBox_DropDownClosed(object sender, EventArgs e)
        {
            ProviderNameField.IsEnabled = false;
            ProviderNameField.Visibility = Visibility.Hidden;
            switch (FilterBox.Text)
            {
                case "All Goods":
                    FillGoodsDataGrid();
                    break;
                case "Avalible Goods":
                    GoodsDataGrid.ItemsSource = _db.GetAvailableGoods();
                    break;
                case "Necessary goods":
                    GoodsDataGrid.ItemsSource = _db.GetNeedGoods();
                    break;
                case "Goods by provider":
                    ProviderNameField.IsEnabled = true;
                    ProviderNameField.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void ProviderNameField_TextChanged(object sender, TextChangedEventArgs e)
        {
            GoodsDataGrid.ItemsSource = _db.GetGoodsByProvider(ProviderNameField.Text);
        }

        private void btnMouseDown(object sender, RoutedEventArgs e)
        {
            _db.Create_Cart();
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.ShowDialog();
            Log.Information("Open cart");
        }
    }
}
