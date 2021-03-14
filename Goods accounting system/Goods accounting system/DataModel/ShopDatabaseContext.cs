﻿using System.Data.Entity;

namespace Goods_accounting_system.DataModel
{
    public class ShopDatabaseContext : DbContext
    {
        public ShopDatabaseContext()
            : base()
        {
        }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Provider> Providers { get; set; }

    }
}