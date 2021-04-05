using System.Collections.Generic;
using Goods_accounting_system.DataModel;

namespace Goods_accounting_system
{
    public interface IDataBase
    {
        public void CreateNewGood(string name, int place, int amount, string provider);
        public void CreateNewProvider(string name, string address, string phoneNumber);
        public IEnumerable<object> GetAllGoods();
        public IEnumerable<object> GetAllProviders();
        public void DeleteGood(int id);
        public Good GetGoodByID(int id);
        public void EditGood(int id, string name, int place, int amount);
        public void DeleteProvider(int id);
        public Provider GetProviderByID(int id);
        public void EditProvider(int id, string name, string address, string phone);
        public IEnumerable<object> GetAvailableGoods();
        public IEnumerable<object> GetNeedGoods();
        public IEnumerable<object> GetGoodsByProvider(string provider);
        public void Create_Cart();
        public void MakeOrder(int goodID, int amount);
        public IEnumerable<object> FillComboBox();
        public List<Good> GetGoods();
        public List<Provider> GetProviders();
    }
}
