using Application.CreativeWebApp.Abstraction.IRepository;
using Domain.CreativeWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.CreativeWebApp
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product)
        {
            
        }

        public void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> SearchProducts(string userName, string categoryName)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
