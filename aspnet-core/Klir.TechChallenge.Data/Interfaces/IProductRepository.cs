using Klir.TechChallenge.Infra.Models;
using System.Collections.Generic;

namespace Klir.TechChallenge.Data.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
    }
}
