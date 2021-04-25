using Klir.TechChallenge.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface IPromotionApplicator
    {
        ICartItem Apply(ICartItem item);
    }
}
