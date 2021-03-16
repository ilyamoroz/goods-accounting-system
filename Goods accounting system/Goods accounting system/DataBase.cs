using Goods_accounting_system.DataModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
        public IEnumerable<object> GetAllGoods()
        {
            using (ShopDatabaseContext context = new ShopDatabaseContext())
            {
                var s = from e in context.Goods
                        join d in context.Providers
                            on e.ProviderID equals d.ProviderID
                        select new
                        {
                            GoodName = e.Name,
                            GoodAmount = e.Amount,
                            StoragePlace = e.StoragePlace,
                            ProviderName = d.Name
                        };
                return s.ToList();

            }
        }
        public IEnumerable<object> GetAllProviders()
        {
            using (ShopDatabaseContext context = new ShopDatabaseContext())
            {
                var s = from e in context.Providers
                        select new
                        {
                            ProviderName = e.Name,
                            ProviderAddress = e.Address,
                            ProviderPhone = e.PhoneNumber
                        };
                return s.ToList();

            }
        }
        public void DeleteGood(int id)
        {
            using (ShopDatabaseContext context = new ShopDatabaseContext())
            {
                var s = context.Goods.Single(x => x.GoodID == id);
                context.Goods.Remove(s);
                context.SaveChanges();
            }
        }
        public Good GetGoodByID(int id)
        {
            using (ShopDatabaseContext context =  new ShopDatabaseContext())
            {
                var good = context.Goods.Single(x => x.GoodID == id);
                return good;
            }
        }
        public void EditGood(int id, string name, int place, int amount)
        {
            using (ShopDatabaseContext context = new ShopDatabaseContext())
            {
                var good = context.Goods.Single(x => x.GoodID == id);
                good.Name = name;
                good.StoragePlace = place;
                good.Amount = amount;
                context.SaveChanges();
            }
        }
        public void DeleteProvider(int id)
        {
            using (ShopDatabaseContext context = new ShopDatabaseContext())
            {
                var z = context.Providers.Single(x => x.ProviderID == id);
                context.Providers.Remove(z);
                context.SaveChanges();
            }

        }
        public Provider GetProviderByID(int id)
        {
            using (ShopDatabaseContext context = new ShopDatabaseContext())
            {
                var provider = context.Providers.Single(x => x.ProviderID == id);
                return provider;
            }
        }
        public void EditProvider(int id, string name, string address, string phone)
        {
            using (ShopDatabaseContext context = new ShopDatabaseContext())
            {
                var provider = context.Providers.Single(x => x.ProviderID == id);
                provider.Name = name;
                provider.Address = address;
                provider.PhoneNumber = phone;
                context.SaveChanges();
            }
        }
        public IEnumerable<object> GetAvailableGoods()
        {
            using (ShopDatabaseContext context = new ShopDatabaseContext())
            {
                var s = from e in context.Goods
                    where e.Amount >= 1 
                    join d in context.Providers
                        on e.ProviderID equals d.ProviderID
                    select new
                    {
                        GoodName = e.Name,
                        GoodAmount = e.Amount,
                        StoragePlace = e.StoragePlace,
                        ProviderName = d.Name
                    };
                return s.ToList();

            }
        }
    }
}