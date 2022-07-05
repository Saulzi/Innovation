using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation
{
    public class RepairOrderHandler
    {
        public OrderStatus HandleOrder(RepairOrder order)
        {
            return OrderStatus.Confirmed;
        }
    }
}
