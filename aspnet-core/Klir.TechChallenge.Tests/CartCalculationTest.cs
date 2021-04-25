using Klir.TechChallenge.Data.Services;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Services;
using Klir.TechChallenge.Infra.ViewModels;
using Xunit;

namespace KlirTechChallenge.Tests
{
    public class CartCalculationTest
    {
        private readonly ICartService _cartService;

        public CartCalculationTest()
        {
            var productPromotionRepository = new ProductPromotionRepository();
            var productRepository = new ProductRepository();
            _cartService = new CartService(productPromotionRepository, productRepository);
        }

        [Fact]
        public void ProductWithBuy1Get1Free_1UnitShouldReturnOriginalPrice()
        {
            var item = new CartItem() { Id = 1, ProductId = 1, Amount = 1m };
            _cartService.RecalculateItemPrice(item);

            Assert.Equal(20m, item.FinalPrice);
            Assert.False(item.IsPromotion);
        }

        [Fact]
        public void ProductWithBuy1Get1Free_2UnitsShouldReturnPromotionPrice()
        {
            var item = new CartItem() { Id = 1, ProductId = 1, Amount = 2m };
            _cartService.RecalculateItemPrice(item);

            Assert.Equal(20m, item.FinalPrice);
            Assert.True(item.IsPromotion);
        }

        [Fact]
        public void ProductWithBuy1Get1Free_3UnitsShouldReturnPromotionPricePlusOriginalPrice()
        {
            var item = new CartItem() { Id = 1, ProductId = 1, Amount = 3m };
            _cartService.RecalculateItemPrice(item);

            Assert.Equal(40m, item.FinalPrice);
            Assert.True(item.IsPromotion);
        }

        [Fact]
        public void ProductWithThreeFor10Euro_1UnitShouldReturnOriginalPrice()
        {
            var item = new CartItem() { Id = 1, ProductId = 2, Amount = 1m };
            _cartService.RecalculateItemPrice(item);

            Assert.Equal(4m, item.FinalPrice);
            Assert.False(item.IsPromotion);
        }

        [Fact]
        public void ProductWithThreeFor10Euro_2UnitsShouldReturnOriginalPrice()
        {
            var item = new CartItem() { Id = 1, ProductId = 4, Amount = 2m };
            _cartService.RecalculateItemPrice(item);

            Assert.Equal(8m, item.FinalPrice);
            Assert.False(item.IsPromotion);
        }

        [Fact]
        public void ProductWithThreeFor10Euro_3UnitsShouldReturnPromotionPrice()
        {
            var item = new CartItem() { Id = 1, ProductId = 4, Amount = 3m };
            _cartService.RecalculateItemPrice(item);

            Assert.Equal(10m, item.FinalPrice);
            Assert.True(item.IsPromotion);
        }

        [Fact]
        public void ProductWithThreeFor10Euro_4UnitsShouldReturnPromotionPricePlusOriginalPrice()
        {
            var item = new CartItem() { Id = 1, ProductId = 4, Amount = 4m };
            _cartService.RecalculateItemPrice(item);

            Assert.Equal(14m, item.FinalPrice);
            Assert.True(item.IsPromotion);
        }
    }
}
