using Goods_accounting_system.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                    EditProviderWindow edit = new EditProviderWindow(providers[ProvidersDataGrid.SelectedIndex].ProviderID);
                    edit.ShowDialog();
                    FillProvidersGrid();
                }
            }
        }
    }
}
