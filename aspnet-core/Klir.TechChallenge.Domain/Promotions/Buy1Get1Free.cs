using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Infra.Interfaces;
using System;

namespace Klir.TechChallenge.Domain.Promotions
{
    public class Buy1Get1Free : IPromotionApplicator
    {
        public ICartItem Apply(ICartItem item)
        {
            if (item.Amount == 1m)
                return item;

            var timesToChargeByPromotion = Math.Truncate(item.Amount / 2);
            var timesToChargeFullPrice = item.Amount % 2;

            if (timesToChargeByPromotion > 0)
                item.FinalPrice = item.OriginalPrice * timesToChargeByPromotion;

            if (timesToChargeFullPrice > 0)
                item.FinalPrice += item.OriginalPrice * timesToChargeFullPrice;

            return item;
        }
    }
}
