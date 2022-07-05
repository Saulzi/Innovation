using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation
{

    public record RepairOrder
    {
        public bool IsRushOrder { get; init; }
        public OrderType OrderType { get; init; }
        
        public bool IsNewCustomer { get; init; }
        public bool IsLargeOrder { get; init; }
    }
}
