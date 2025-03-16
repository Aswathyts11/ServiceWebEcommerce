using DLServiceWebApp.DataService;
using ServiceCommon.Request;


namespace BLServiceOrder
{
    public class BLServiceOrderDetails
    {
        private readonly ServiceOrderRepository _orderRepository;

        public BLServiceOrderDetails(ServiceOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// fetch order details and validate user
        /// </summary>
        /// <param name="dtrequest"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<object> SelectOrderDetailsAsync(CustomerRequest request)
        {
            Dictionary<string, object> returnvalue = new Dictionary<string, object>();
            if (string.IsNullOrEmpty(request.CustomerId))
            {
                throw new ArgumentException("Customer ID cannot be null or empty.", nameof(request.CustomerId));
            }

            if (string.IsNullOrEmpty(request.User))
            {
                throw new ArgumentException("User cannot be null or empty.", nameof(request.User));
            }

            var customer = await Task.Run(() => _orderRepository.selectCustomerDetails(request.User, request.CustomerId));

            if (customer == null)
            {
                throw new ArgumentException("Invalid email or customer ID.");
            }

            var orderDetails = await _orderRepository.GetLatestOrderAsync(request.CustomerId);
            returnvalue.Add("Customer", customer);
            returnvalue.Add("order", orderDetails);

            return returnvalue; 
        }
    }
}
