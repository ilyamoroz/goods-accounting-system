namespace Goods_accounting_system.DataModel
{
    public class Order
    {
        public int OrderID { get; set; }
        public int GoodID { get; set; }
        public int Amount { get; set; }
        public int CartId { get; set; }
        public virtual Good good { get; set; }
        public virtual Cart cart { get; set; }
    }
}