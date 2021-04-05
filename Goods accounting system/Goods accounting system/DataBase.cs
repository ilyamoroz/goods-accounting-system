using System;
using Goods_accounting_system.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace Goods_accounting_system
{
    public class DataBase : IDataBase
    {
        private ShopDatabaseContext _context;

        public DataBase(ShopDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); 
        }
        public void CreateNewGood(string name, int place, int amount, string provider)
        {
            Good good = new Good();
            good.Name = name;
            good.StoragePlace = place;
            good.Amount = amount;
            if (provider.Length > 0)
            {
                good.ProviderID = _context.Providers.Single(x => x.Name == provider).ProviderID;
            }

            _context.Goods.Add(good);
            _context.SaveChanges();
        }
        public void CreateNewProvider(string name, string address, string phoneNumber)
        {
            Provider provider = new Provider();
            provider.Name = name;
            provider.Address = address;
            provider.PhoneNumber = phoneNumber;
            _context.Providers.Add(provider);
            _context.SaveChanges();
        }
        public IEnumerable<object> GetAllGoods()
        {
            var s = from e in _context.Goods
                    join d in _context.Providers
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
        public IEnumerable<object> GetAllProviders()
        {
            var s = from e in _context.Providers
                    select new
                    {
                        ProviderName = e.Name,
                        ProviderAddress = e.Address,
                        ProviderPhone = e.PhoneNumber
                    };
            return s.ToList();
        }
        public void DeleteGood(int id)
        {

            var s = _context.Goods.Single(x => x.GoodID == id);
            _context.Goods.Remove(s);
            _context.SaveChanges();
        }
        public Good GetGoodByID(int id)
        {
            var good = _context.Goods.Single(x => x.GoodID == id);
            return good;
        }
        public void EditGood(int id, string name, int place, int amount)
        {
            
            var good = _context.Goods.Single(x => x.GoodID == id);
            good.Name = name;
            good.StoragePlace = place;
            good.Amount = amount;
            _context.SaveChanges();
        
        }
        public void DeleteProvider(int id)
        {
            var z = _context.Providers.Single(x => x.ProviderID == id);
            _context.Providers.Remove(z);
            _context.SaveChanges();
        }
        public Provider GetProviderByID(int id)
        {
            var provider = _context.Providers.Single(x => x.ProviderID == id);
            return provider;

        }
        public void EditProvider(int id, string name, string address, string phone)
        {
            var provider = _context.Providers.Single(x => x.ProviderID == id);
            provider.Name = name;
            provider.Address = address;
            provider.PhoneNumber = phone;
            _context.SaveChanges();
        }
        public IEnumerable<object> GetAvailableGoods()
        {
            var s = from e in _context.Goods
                where e.Amount >= 1 
                join d in _context.Providers
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
        public IEnumerable<object> GetNeedGoods()
        {
            var s = from e in _context.Goods
                where e.Amount <= 10
                join d in _context.Providers
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
        public IEnumerable<object> GetGoodsByProvider(string provider)
        {
            var s = from e in _context.Goods
                join d in _context.Providers
                    on e.ProviderID equals d.ProviderID
                where d.Name.StartsWith(provider)
                select new
                {
                    GoodName = e.Name,
                    GoodAmount = e.Amount,
                    StoragePlace = e.StoragePlace,
                    ProviderName = d.Name
                };
            return s.ToList();
        }
        public void Create_Cart()
        {
            Cart cart = new Cart();
            cart.Date = DateTime.Now.ToShortDateString();
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }
        public void MakeOrder(int goodID, int amount)
        {
            var _cartID = _context.Carts.ToList<Cart>().Last().CartID;

            Order order = new Order();
            order.GoodID = goodID;
            order.Amount = amount;
            order.CartId = _cartID;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public IEnumerable<object> FillComboBox()
        { 
            return (from e in _context.Providers select e.Name).ToList();
        }
        public List<Good> GetGoods()
        {
            return _context.Goods.ToList();
        }
        public List<Provider> GetProviders()
        {
            return _context.Providers.ToList();
        }
    }
}