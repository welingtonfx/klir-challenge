using Klir.TechChallenge.Data.FakeData;
using Klir.TechChallenge.Data.Interfaces;
using Klir.TechChallenge.Infra.Models;
using System.Collections.Generic;

namespace Klir.TechChallenge.Data.Services
{
    public class PromotionRepository : IPromotionRepository
    {
        public PromotionRepository()
        {

        }

        public IEnumerable<Promotion> GetPromotions()
        {
            return Context.Promotions;
        }
    }
}
