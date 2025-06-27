using Bakeshop_Common;
using BakeshopManagement.Business;
using Microsoft.AspNetCore.Mvc;

namespace Bakeshop_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Admin Actions ദ്ദി(˵ •̀ ᴗ - ˵ ) ✧")]
    public class AdminController : ControllerBase
    {
        private readonly BakeshopProcess _process;

        public AdminController(BakeshopProcess process)
        {
            _process = process;
        }

        // ========== PRODUCT MANAGEMENT ==========

       
        [HttpPost("products/add")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (_process.AddProduct(product, out string error))
                return Ok("✅ Product added successfully.");
            return BadRequest($"❌ {error}");
        }

       
        [HttpPut("products/update")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            if (_process.UpdateProduct(product))
                return Ok("✅ Product updated.");
            return BadRequest("❌ Failed to update product.");
        }

       
        [HttpDelete("products/delete/{productName}")]
        public IActionResult DeleteProduct(string productName)
        {
            if (_process.DeleteProduct(productName))
                return Ok($"🗑️ Product '{productName}' deleted.");
            return NotFound($"❌ Product '{productName}' not found.");
        }

        
        [HttpGet("products/all")]
        public IActionResult GetAllProducts()
        {
            return Ok(_process.GetAllProducts());
        }

        // ========== ORDER MANAGEMENT ==========

       
        [HttpGet("orders/pending")]
        public IActionResult GetPendingOrders()
        {
            return Ok(_process.GetAllPendingOrders());
        }

       
        [HttpGet("orders/completed")]
        public IActionResult GetCompletedOrders()
        {
            return Ok(_process.GetAllCompletedOrders());
        }

       
        [HttpPut("orders/complete/{orderId}")]
        public IActionResult MarkOrderComplete(int orderId)
        {
            if (_process.MarkOrderAsComplete(orderId))
                return Ok($"✅ Order {orderId} marked as complete.");
            return BadRequest("❌ Failed to mark order complete.");
        }

        
        [HttpPut("orders/cancel/{orderId}")]
        public IActionResult CancelOrder(int orderId)
        {
            if (_process.MarkOrderAsCancelled(orderId))
                return Ok($"🚫 Order {orderId} cancelled.");
            return BadRequest("❌ Failed to cancel order.");
        }
    }
}
