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
using Goods_accounting_system.DataModel;

namespace Goods_accounting_system
{
    /// <summary>
    /// Логика взаимодействия для EditProviderWindow.xaml
    /// </summary>
    public partial class EditProviderWindow : Window
    {
        private DataBase db = new DataBase();
        private Provider provider;
        private int ProviderId;
        public EditProviderWindow()
        {
            InitializeComponent();
        }
        public EditProviderWindow(int id)
        {
            InitializeComponent();
            ProviderId = id;
            FillFields();
        }

        private void FillFields()
        {
            provider = db.GetProviderByID(ProviderId);
            ProviderNameField.Text = provider.Name;
            ProviderAddressField.Text = provider.Address;
            ProviderPhoneNumberField.Text = provider.PhoneNumber;
        }

        private void EditProviderButton_Click(object sender, RoutedEventArgs e)
        {
            db.EditProvider(ProviderId, ProviderNameField.Text, ProviderAddressField.Text, ProviderPhoneNumberField.Text);
            this.Close();
        }
    }
}
