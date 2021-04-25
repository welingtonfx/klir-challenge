using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Infra.Interfaces;
using System;

namespace Klir.TechChallenge.Domain.Promotions
{
    public class ThreeFor10Euro : IPromotionApplicator
    {
        public ICartItem Apply(ICartItem item)
        {
            if (item.Amount < 3m)
                return item;

            var timesToApplyPromotion = Math.Truncate(item.Amount / 3);
            var timesToChargeFullPrice = item.Amount % 3;

            item.FinalPrice = (timesToApplyPromotion * 10m) + (timesToChargeFullPrice * item.OriginalPrice);

            item.SetPromotion();
            return item;
        }
    }
}
