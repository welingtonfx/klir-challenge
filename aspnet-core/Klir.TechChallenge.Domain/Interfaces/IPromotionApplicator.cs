using Klir.TechChallenge.Infra.Interfaces;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface IPromotionApplicator
    {
        ICartItem Apply(ICartItem item);
    }
}
