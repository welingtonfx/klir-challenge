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

        public IActionResult ApplyProductPromotion(CartItem item)
        {
            _cartService.
        }
    }
}
