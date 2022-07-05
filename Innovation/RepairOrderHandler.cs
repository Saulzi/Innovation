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

            var result = order switch
            {
                { IsLargeOrder: true, IsNewCustomer: true } => OrderStatus.Closed,
                { IsLargeOrder: true, IsRushOrder: true} => OrderStatus.Closed,
                { IsLargeOrder: true, OrderType: OrderType.Repair} => OrderStatus.AuthorisationRequired,
                { IsRushOrder: true } => OrderStatus.AuthorisationRequired,
                _ => OrderStatus.Confirmed
            };

            return result;



        }
    }
}
