using Klir.TechChallenge.Infra.Enums;

namespace Klir.TechChallenge.Infra.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public PromotionTypeEnum PromotionType { get; set; }
    }
}
