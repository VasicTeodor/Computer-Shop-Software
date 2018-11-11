using ComputerShop.Core;
using ComputerShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop
{
    public static class RuntimeContext
    {
        public static String msgLabel = "";
        public static User curentUser = null;
        public static StockComponent selectedComponent = null;
        public static StockComponent addedStockComponent = null;
        public static StockComponent deletedStockComponent = null;
        public static List<string> commands = new List<string>();
    }
}
