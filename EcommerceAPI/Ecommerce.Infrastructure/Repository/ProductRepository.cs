using Ecommerce.Domain.entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repository
{
    public class ProductRepository : IProductInterfaces
    {
        private readonly StoreContext storeContext;

        public ProductRepository( StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }
        public async Task AddProduct(Product product)
        {
            storeContext.Products.Add(product);
        }

        public async Task DeleteProduct(Product product)
        {
            storeContext.Products.Remove(product);
        }

        public async Task<IReadOnlyList<string>> GetBrands()
        {
          return await  storeContext.Products.Select(x => x.Brand).Distinct().ToListAsync();
        }

        public async Task<Product> GetProduct(int productId)
        {
          return await  storeContext.Products.FindAsync(productId);
        }

        public async Task<IReadOnlyList<Product>> GetProducts(string? brand, string? type, string? sort)
        {
            var query = storeContext.Products.AsQueryable();
            if (!string.IsNullOrEmpty(brand))

              query=  query.Where(x => x.Brand == brand);
            if(!string.IsNullOrEmpty(type))
            query=query.Where(x=>x.Type==type);

            query = sort switch
            {
                "priceAsc" => query.OrderBy(x => x.Price),
                "priceDesc" => query.OrderByDescending(x => x.Price),
                _ => query.OrderBy(x => x.Name)
            };

            return await query.ToListAsync();
            
        }

        public async Task<IReadOnlyList<string>> GetTypes()
        {
            return await storeContext.Products.Select(x => x.Type).Distinct().ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
          return  await storeContext.SaveChangesAsync()>0;
        }

        public async Task UpdateProduct(Product product)
        {
             storeContext.Products.Update(product);
        }
    }
}
