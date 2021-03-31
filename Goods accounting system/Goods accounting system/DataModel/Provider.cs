using System.Collections.Generic;

namespace Goods_accounting_system.DataModel
{
    public class Provider
    {
        public int ProviderID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Good> Goods { get; set; }
    }
}