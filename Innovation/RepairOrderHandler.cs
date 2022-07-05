using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation
{
    public class RepairOrderHandler
    {
        /// <summary>
        /// All of the default matchers for this, may be at instance level
        /// </summary>
        public static List<IRepairOrderHandlerMatcher> Matchers = new List<IRepairOrderHandlerMatcher>()
        {
            new RepairOrderMatcher(OrderStatus.Closed, order => order.IsLargeOrder && order.IsNewCustomer),
            new RepairOrderMatcher(OrderStatus.Closed, order => order.IsLargeOrder && order.IsRushOrder),
            new RepairOrderMatcher(OrderStatus.AuthorisationRequired, order => order is { IsLargeOrder: true, OrderType: OrderType.Repair}),
            new RepairOrderMatcher(OrderStatus.AuthorisationRequired, order => order is { IsRushOrder : true } ),
            new RepairOrderMatcher(OrderStatus.Confirmed, _ => true)
        };


        public OrderStatus HandleOrder(RepairOrder order)
        {
            return Matchers.First(f => f.IsMatch(order)).Status;
        }
    }
}
