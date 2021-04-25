namespace Klir.TechChallenge.Infra.Interfaces
{
    public interface ICartItem
    {
        bool IsPromotion { get; set; }
        decimal OriginalPrice { get; set; }
        decimal FinalPrice { get; set; }
        decimal Amount { get; set; }

        void SetPromotion();
    }
}
