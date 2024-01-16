using Domain.CreativeWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CreativeWebApp.Abstraction.IRepository
{
    public  interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> SearchProducts(string userName, string categoryName);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
