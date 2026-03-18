using Ecommerce.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Data
{
    public class StoreContextSeed
    {
          
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.Products.Any())
            {
                var productData = await File.ReadAllTextAsync("../Ecommerce.Infrastructure/SeedData/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                if (products == null) return;
                context.Products.AddRange(products);
              await  context.SaveChangesAsync();


            }
        }
    }
}
