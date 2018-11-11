using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Models
{
    [DataContract]
    public abstract class StockComponentPrototype
    {
        public abstract StockComponentPrototype Clone();
    }
}
