using ComputerShop.Core;
using ComputerShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Server.Access
{
    class ComputerPartsDBContext : DbContext
    {
        public ComputerPartsDBContext() : base("dbConnection2016")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComputerPartsDBContext, Configuration>());

            //FunctionCheck();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<StockComponent> StockComponents { get; set; }

        public void FunctionCheck()
        {
            foreach (var item in Users.ToList())
            {
                if (item.Username == "admin")
                {
                    return;
                }
            }
            Users.Add(new User { Name="admin",
                                 Password="admin",
                                 Role="admin",
                                 Username="admin",
                                 Surname="admin" });
            SaveChanges();
        }
    }
}
