using Klir.TechChallenge.Infra.Models;
using System.Collections.Generic;

namespace Klir.TechChallenge.Data.Interfaces
{
    public interface IProductPromotionRepository
    {
        IEnumerable<ProductPromotion> GetProductPromotions();
        ProductPromotion GetProductPromotion(int productId);
    }
}
