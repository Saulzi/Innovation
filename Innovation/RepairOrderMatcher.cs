namespace Innovation
{
    public class RepairOrderMatcher : IRepairOrderHandlerMatcher
    {
        public OrderStatus Status { get; }

        private readonly Func<RepairOrder, bool> _isMatch;

        public RepairOrderMatcher(OrderStatus status, Func<RepairOrder, bool> isMatch)
        {
            Status = status;
            _isMatch = isMatch;
        }

        public bool IsMatch(RepairOrder order) => _isMatch(order);

    }
}
