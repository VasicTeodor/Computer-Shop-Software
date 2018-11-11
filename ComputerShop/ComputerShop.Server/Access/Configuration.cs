using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Server.Access
{
    class Configuration : DbMigrationsConfiguration<ComputerPartsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ComputerPartsDBContext";
        }
    }
}
