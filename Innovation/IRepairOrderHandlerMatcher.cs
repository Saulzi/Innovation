namespace Innovation
{
    public interface IRepairOrderHandlerMatcher
    {
        bool IsMatch(RepairOrder order);
        OrderStatus Status { get; }
    }
}
