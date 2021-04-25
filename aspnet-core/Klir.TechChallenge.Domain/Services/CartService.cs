using Klir.TechChallenge.Data.Interfaces;
using Klir.TechChallenge.Domain.Factories.Promotion;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Infra.Enums;
using Klir.TechChallenge.Infra.Models;
using Klir.TechChallenge.Infra.ViewModels;

namespace Klir.TechChallenge.Domain.Services
{
    public class CartService : ICartService
    {
        private readonly IProductPromotionRepository _productPromotionRepository;
        private readonly IProductRepository _productRepository;

        public CartService(IProductPromotionRepository productPromotionRepository,
            IProductRepository productRepository)
        {
            _productPromotionRepository = productPromotionRepository;
            _productRepository = productRepository;
        }

        public CartItem RecalculateItemPrice(CartItem item)
        {
            CalculateProductGrossPrice(item);
            var productPromotion = GetProductPromotion(item.ProductId);
            item.SetNoPromotion();

            if (productPromotion == null)
                return item;

            ApplyPromotion(item, productPromotion.PromotionId);

            return item;
        }

        private CartItem CalculateProductGrossPrice(CartItem item)
        {
            var product = _productRepository.GetProductById(item.ProductId);
            item.OriginalPrice = product.Price;
            item.FinalPrice = item.OriginalPrice * item.Amount;
            return item;
        }

        private ProductPromotion GetProductPromotion(int productId)
        {
            return _productPromotionRepository.GetProductPromotion(productId);
        }

        private CartItem ApplyPromotion(CartItem item, int promotionId)
        {
            var applicator = PromotionFactory.GetPromotionApplicator((PromotionTypeEnum)promotionId);
            applicator.Apply(item);
            return item;
        }
    }
}
