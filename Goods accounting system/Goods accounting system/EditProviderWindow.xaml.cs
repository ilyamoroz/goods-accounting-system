using System.Configuration;
using System.Windows;
using Goods_accounting_system.DataModel;

namespace Goods_accounting_system
{
    /// <summary>
    /// Логика взаимодействия для EditProviderWindow.xaml
    /// </summary>
    public partial class EditProviderWindow : Window
    {
        private IDataBase _db;
        private Provider provider;
        private int ProviderId;
        public EditProviderWindow(int id, IDataBase db)
        {
            InitializeComponent();
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ShopDatabaseContext"];
            _db = db;
            ProviderId = id;
            FillFields();
        }

        private void FillFields()
        {
            provider = _db.GetProviderByID(ProviderId);
            ProviderNameField.Text = provider.Name;
            ProviderAddressField.Text = provider.Address;
            ProviderPhoneNumberField.Text = provider.PhoneNumber;
        }

        private void EditProviderButton_Click(object sender, RoutedEventArgs e)
        {
            _db.EditProvider(ProviderId, ProviderNameField.Text, ProviderAddressField.Text, ProviderPhoneNumberField.Text);
            this.Close();
        }
    }
}
