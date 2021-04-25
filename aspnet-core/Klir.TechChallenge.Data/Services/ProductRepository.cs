using Klir.TechChallenge.Data.FakeData;
using Klir.TechChallenge.Data.Interfaces;
using Klir.TechChallenge.Infra.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Klir.TechChallenge.Data.Services
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {

        }

        public IEnumerable<Product> GetProducts()
        {
            return Context.Products;
        }

        public Product GetProductById(int id)
        {
            return Context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
