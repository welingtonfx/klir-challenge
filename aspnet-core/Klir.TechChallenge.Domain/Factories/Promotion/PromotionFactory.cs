using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Promotions;
using Klir.TechChallenge.Infra.Enums;
using System;
using System.Collections.Generic;

namespace Klir.TechChallenge.Domain.Factories.Promotion
{
    public static class PromotionFactory
    {
        private static Dictionary<PromotionTypeEnum, IPromotionApplicator> Applicators { 
            get 
            {
                var dict = new Dictionary<PromotionTypeEnum, IPromotionApplicator>();
                dict.Add(PromotionTypeEnum.Buy1Get1Free, new Buy1Get1Free());
                dict.Add(PromotionTypeEnum.ThreeFor10Euro, new ThreeFor10Euro());
                return dict;
            } 
        }

        public static IPromotionApplicator GetPromotionApplicator(PromotionTypeEnum promotionType)
        {
            IPromotionApplicator applicator;

            Applicators.TryGetValue(promotionType, out applicator);

            if (applicator == null)
                throw new Exception("Promotion configuration not found");

            return applicator;
        }
    }
}
