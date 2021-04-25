using Klir.TechChallenge.Data.FakeData;
using Klir.TechChallenge.Data.Interfaces;
using Klir.TechChallenge.Infra.Models;
using System.Collections.Generic;
using System.Linq;

namespace Klir.TechChallenge.Data.Services
{
    public class ProductPromotionRepository : IProductPromotionRepository
    {
        public ProductPromotionRepository()
        {

        }

        public IEnumerable<ProductPromotion> GetProductPromotions()
        {
            return Context.ProductPromotions;
        }

        public ProductPromotion GetProductPromotion(int productId)
        {
            return Context.ProductPromotions.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
