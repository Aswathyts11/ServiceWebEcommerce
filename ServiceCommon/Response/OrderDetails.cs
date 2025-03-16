namespace ServiceCommon.Response
{
    public class OrderDetails
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime DeliveryExpected { get; set; }
        public List<OrderItemDetails> OrderItems { get; set; }
    }
}
