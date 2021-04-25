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

        public CartService(IProductPromotionRepository productPromotionRepository)
        {
            _productPromotionRepository = productPromotionRepository;
        }

        public CartItem ApplyCartItemPromotion(CartItem item)
        {
            var productPromotion = GetProductPromotion(item.ProductId);

            if (productPromotion != null)
                return item;

            ApplyPromotion(item, productPromotion.ProductId);

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
