using Klir.TechChallenge.Infra.ViewModels;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface ICartService
    {
        CartItem ApplyCartItemPromotion(CartItem item);
    }
}
