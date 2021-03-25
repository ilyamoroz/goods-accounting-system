using System.Diagnostics.CodeAnalysis;

namespace Goods_accounting_system.DataModel
{
    public class Good
    {
        public int GoodID { get; set; }
        public string Name { get; set; }
        public int StoragePlace { get; set; }
        public int Amount { get; set; }
        [AllowNull]
        public int ProviderID { get; set; }
        public virtual Provider provider { get; set; }
    }
}