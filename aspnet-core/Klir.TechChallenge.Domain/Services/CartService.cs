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

            var applicator = PromotionFactory.GetPromotionApplicator((PromotionTypeEnum)productPromotion.PromotionId);
            applicator.Apply(item);
            return item;
        }

        private ProductPromotion GetProductPromotion(int productId)
        {
            return _productPromotionRepository.GetProductPromotion(productId);
        }
    }
}
