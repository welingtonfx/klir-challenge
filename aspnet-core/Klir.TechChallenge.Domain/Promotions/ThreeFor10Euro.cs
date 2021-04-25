using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Infra.Interfaces;
using System;

namespace Klir.TechChallenge.Domain.Promotions
{
    public class ThreeFor10Euro : IPromotionApplicator
    {
        public ICartItem Apply(ICartItem item)
        {
            throw new NotImplementedException();
        }
    }
}
