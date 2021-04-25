using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KlirTechChallenge.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("recalculateitemprice")]
        public IActionResult RecalculateItemPrice(CartItem item)
        {
            var recalculatedItem = _cartService.RecalculateItemPrice(item);

            return Ok(recalculatedItem);
        }
    }
}
