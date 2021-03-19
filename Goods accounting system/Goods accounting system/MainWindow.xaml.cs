﻿using Goods_accounting_system.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Drawing;
using System.Drawing.Printing;
using System.Printing;
using System.Windows.Controls;


namespace Goods_accounting_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataBase db = new DataBase();

        public MainWindow()
        {
            InitializeComponent();

            FillGoodsDataGrid();
            FillProvidersGrid();
        }

        private void FillGoodsDataGrid()
        {
            GoodsDataGrid.ItemsSource = db.GetAllGoods();
        }

        private void FillProvidersGrid()
        {
            ProvidersDataGrid.ItemsSource = db.GetAllProviders();
        }

        private void CreateNewGoodButton_Click(object sender, RoutedEventArgs e)
        {
            CreateGood createGood = new CreateGood();
            createGood.ShowDialog();
            FillGoodsDataGrid();
        }

        private void CreateNewProviderButton_Click(object sender, RoutedEventArgs e)
        {
            CreateProvider createProvider = new CreateProvider();
            createProvider.ShowDialog();
            FillProvidersGrid();
        }

        private void GoodEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (GoodsDataGrid.SelectedIndex >= 0)
            {
                using (ShopDatabaseContext context = new ShopDatabaseContext())
                {
                    List<Good> goods = context.Goods.ToList();
                    EditGoodWindow edit = new EditGoodWindow(goods[GoodsDataGrid.SelectedIndex].GoodID);
                    edit.ShowDialog();
                    FillGoodsDataGrid();
                }
            }
        }

        private void ProviderDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProvidersDataGrid.SelectedIndex > 0)
            {
                using (ShopDatabaseContext context = new ShopDatabaseContext())
                {
                    List<Provider> providers = context.Providers.ToList();
                    db.DeleteProvider(providers[ProvidersDataGrid.SelectedIndex].ProviderID);
                    FillProvidersGrid();
                }
            }
        }

        private void DeleteGoodButton_Click(object sender, RoutedEventArgs e)
        {
            if (GoodsDataGrid.SelectedIndex > 0)
            {
                using (ShopDatabaseContext context = new ShopDatabaseContext())
                {
                    List<Good> goods = context.Goods.ToList<Good>();
                    db.DeleteGood(goods[GoodsDataGrid.SelectedIndex].GoodID);
                    FillGoodsDataGrid();
                }
            }
        }

        private void ProviderEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProvidersDataGrid.SelectedIndex >= 0)
            {
                using (ShopDatabaseContext context = new ShopDatabaseContext())
                {
                    List<Provider> providers = context.Providers.ToList();
                    EditProviderWindow edit =
                        new EditProviderWindow(providers[ProvidersDataGrid.SelectedIndex].ProviderID);
                    edit.ShowDialog();
                    FillProvidersGrid();
                }
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
                    GoodsDataGrid.ItemsSource = db.GetAvailableGoods();
                    break;
                case "Necessary goods":
                    GoodsDataGrid.ItemsSource = db.GetNeedGoods();
                    break;
                case "Goods by provider":
                    ProviderNameField.IsEnabled = true;
                    ProviderNameField.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void ProviderNameField_TextChanged(object sender, TextChangedEventArgs e)
        {
            GoodsDataGrid.ItemsSource = db.GetGoodsByProvider(ProviderNameField.Text);
        }

        private void btnMouseDown(object sender, RoutedEventArgs e)
        {
            db.Create_Cart();
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.ShowDialog();
        }
    }
}
