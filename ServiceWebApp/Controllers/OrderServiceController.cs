using BLServiceOrder;
using Microsoft.AspNetCore.Mvc;
using ServiceCommon.Request;

namespace ServiceWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderServiceController : ControllerBase
    {
        private readonly BLServiceOrderDetails _blServiceOrder;

        public OrderServiceController(BLServiceOrderDetails blServiceOrder)
        {
            _blServiceOrder = blServiceOrder ?? throw new ArgumentNullException(nameof(blServiceOrder));
        }

        [HttpPost]
        [Route("GetLastOrder")]
        public async Task<IActionResult> GetLastOrder([FromBody] CustomerRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request payload.");
            }

            try
            {
               
                return Ok(await _blServiceOrder.SelectOrderDetailsAsync(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing the request.", error = ex.Message });
            }
        }
    }
}
