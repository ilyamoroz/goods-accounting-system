using System.Collections.Generic;

namespace Goods_accounting_system.DataModel
{
    public class Cart
    {
        public int CartID { get; set; }
        public string Date { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}