using Bakeshop_Common;
using BakeshopManagement.Business;
using Microsoft.AspNetCore.Mvc;

namespace Bakeshop_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Customer Actions ⸜(｡˃ ᵕ ˂ )⸝♡")]
    public class CustomerActionsController : ControllerBase
    {
        private readonly BakeshopProcess _process;

        public CustomerActionsController(BakeshopProcess process)
        {
            _process = process;
        }

        // ========== CART ==========

       
        [HttpPost("cart/add")]
        public IActionResult AddToCart([FromBody] Cart cart)
        {
            if (_process.AddToCartProduct(cart))
                return Ok("🛒 Added to cart.");
            return BadRequest("❌ Failed to add to cart.");
        }

       
        [HttpGet("cart/{userId}")]
        public IActionResult GetCart(int userId)
        {
            return Ok(_process.GetCartItems(userId));
        }

        
        [HttpPut("cart/update")]
        public IActionResult UpdateCart([FromBody] Cart cart)
        {
            if (_process.UpdateCartItem(cart))
                return Ok("📝 Cart item updated.");
            return BadRequest("❌ Update failed.");
        }

        
        [HttpDelete("cart/delete/{cartId}")]
        public IActionResult DeleteCartItem(int cartId)
        {
            if (_process.DeleteCartItem(cartId))
                return Ok("🗑️ Item deleted from cart.");
            return NotFound("❌ Cart item not found.");
        }

        // ========== ORDER ==========

       
        [HttpPost("order/save")]
        public IActionResult SaveOrder([FromQuery] int userId, [FromBody] List<Cart> cartItems)
        {
            if (_process.SaveOrder(userId, cartItems, out int newOrderId))
                return Ok(new { message = "✅ Order saved.", orderId = newOrderId });

            return BadRequest("❌ Order save failed.");
        }

        
        [HttpGet("order/details/{orderId}")]
        public IActionResult GetOrderDetails(int orderId)
        {
            return Ok(_process.GetOrderDetails(orderId));
        }

       
        [HttpPut("order/complete/{orderId}")]
        public IActionResult CompleteOrder(int orderId)
        {
            if (_process.MarkOrderAsComplete(orderId))
                return Ok("✅ Order marked as complete.");
            return BadRequest("❌ Failed to mark order as complete.");
        }

        
        [HttpPut("order/cancel/{orderId}")]
        public IActionResult CancelOrder(int orderId)
        {
            if (_process.MarkOrderAsCancelled(orderId))
                return Ok("🚫 Order cancelled.");
            return BadRequest("❌ Cancel failed.");
        }

        // ========== FAVORITES ==========

       
        [HttpPost("favorite/add")]
        public IActionResult AddFavorite([FromQuery] int userId, [FromQuery] int productId)
        {
            if (_process.AddToFavorites(userId, productId))
                return Ok("💖 Added to favorites.");
            return BadRequest("❌ Failed to add favorite.");
        }

       
        [HttpDelete("favorite/remove")]
        public IActionResult RemoveFavorite([FromQuery] int userId, [FromQuery] int productId)
        {
            if (_process.RemoveFromFavorites(userId, productId))
                return Ok("💔 Removed from favorites.");
            return BadRequest("❌ Failed to remove favorite.");
        }

        
        [HttpGet("favorite/check")]
        public IActionResult IsFavorite([FromQuery] int userId, [FromQuery] int productId)
        {
            bool isFav = _process.IsFavorite(userId, productId);
            return Ok(new { isFavorite = isFav });
        }
    }
}
