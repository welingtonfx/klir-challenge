using Klir.TechChallenge.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KlirTechChallenge.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("getproducts")]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();

            return Ok(products);
        }
    }
}
