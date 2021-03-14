using Goods_accounting_system.DataModel;

namespace Goods_accounting_system
{
    public class DataBase
    {
        public void CreateNewGood(string name, int place, int amount, int provider)
        {
            using (ShopDatabaseContext context = new ShopDatabaseContext())
            {
                Good good = new Good();
                good.Name = name;
                good.StoragePlace = place;
                good.Amount = amount;
                good.ProviderID = provider;
                context.Goods.Add(good);
                context.SaveChanges();
            }
        }

        public void CreateNewProvider(string name, string address, string phoneNumber)
        {
            using (ShopDatabaseContext context = new ShopDatabaseContext())
            {
                Provider provider = new Provider();
                provider.Name = name;
                provider.Address = address;
                provider.PhoneNumber = phoneNumber;
                context.Providers.Add(provider);
                context.SaveChanges();
            }
        }
    }
}