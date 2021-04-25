using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Infra.Interfaces;
using System;

namespace Klir.TechChallenge.Domain.Promotions
{
    public class Buy1Get1Free : IPromotionApplicator
    {
        public ICartItem Apply(ICartItem item)
        {
            throw new NotImplementedException();
        }
    }
}
