namespace ServiceCommon.Request
{
    public class CustomerRequest
    {
        public string User { get; set; }
        public string CustomerId { get; set; }
    }

    public class OrderResponse
    {
        public CustomerInfo Customer { get; set; }
        public OrderInfo Order { get; set; }
    }
    public class CustomerInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class OrderInfo
    {
        public int OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public string DeliveryExpected { get; set; }
    }

    public class OrderItem
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal PriceEach { get; set; }
    }

}
