using Ecommerce.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface IProductInterfaces
    {
        Task<IReadOnlyList<Product>> GetProducts(string? brand,string? type, string? sort);

        Task<Product> GetProduct(int productId);
        Task<IReadOnlyList<string>> GetBrands();
        Task<IReadOnlyList<string>> GetTypes();

        Task AddProduct(Product product);

        Task UpdateProduct(Product product);
        Task DeleteProduct(Product product);

        Task<bool> SaveChangesAsync();
    }
}
