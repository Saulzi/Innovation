namespace Innovation.Tests
{
    public class RepairOrderHandlerTests
    {
        RepairOrderHandler itemUnderTest = new RepairOrderHandler();

        [Fact]
        public void Large_repair_orders_for_new_customers_should_be_closed()
        {
            var largeNewCustomerOrder = new RepairOrder()
            {
                IsLargeOrder = true,
                IsNewCustomer = true
            };

            var result = itemUnderTest.HandleOrder(largeNewCustomerOrder);

            result.Should().Be(OrderStatus.Closed);
        }

        [Fact]
        public void Large_rush_hire_orders_should_always_be_closed()
        {
            var largeRushOrder = new RepairOrder()
            {
                IsLargeOrder = true,
                IsRushOrder = true
            };

            var result = itemUnderTest.HandleOrder(largeRushOrder);

            result.Should().Be(OrderStatus.Closed);
        }

        [Fact]
        public void Large_repair_orders_always_require_authorisation()
        {
            var largeRepairOrder = new RepairOrder()
            {
                IsLargeOrder = true,
                OrderType = OrderType.Repair
            };

            var result = itemUnderTest.HandleOrder(largeRepairOrder);

            result.Should().Be(OrderStatus.AuthorisationRequired);
        }

        [Fact]
        public void All_rush_orders_for_new_customers_always_require_authorisation()
        {
            var rushOrder = new RepairOrder()
            {
                IsRushOrder = true
            };

            var result = itemUnderTest.HandleOrder(rushOrder);

            result.Should().Be(OrderStatus.AuthorisationRequired);
        }

        [Fact]
        public void All_other_orders_should_be_confirmed()
        {
            var otherOrder = new RepairOrder();

            var result = itemUnderTest.HandleOrder(otherOrder);

            result.Should().Be(OrderStatus.Confirmed);
        }
    }
}