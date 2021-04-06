using System.Configuration;
using System.Data;
using Autofac;
using Goods_accounting_system.DataModel;


namespace Goods_accounting_system
{
    public class DataBaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ShopDatabaseContext"];
            builder.RegisterType<DataBase>().As<IDataBase>();
        }
    }
}