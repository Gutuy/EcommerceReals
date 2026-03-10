using Ecommerce.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Specification
{
    public class ProductSpecification :BaseSpecification<Product>
    {
        public ProductSpecification(ProductParamsSpec paramsSpec) : base(x =>
        (string.IsNullOrEmpty(paramsSpec.Search) || x.Name.ToLower().Contains(paramsSpec.Search.ToLower())) &&
        
        (
       !paramsSpec.Brands.Any() || paramsSpec.Brands.Contains(x.Brand)

        ) && (!paramsSpec.Types.Any() || paramsSpec.Types.Contains(x.Type)))
        {
           ApplyPagination(paramsSpec.PageSize *(paramsSpec.pageIndex-1), paramsSpec.PageSize);
            switch (paramsSpec.Sort)
            {
                case "priceAsc": AddOrderBy(x => x.Price); break;

                case "priceDesc":AddOrderByDescending(x => x.Price); break;

                    default: AddOrderBy(x=>x.Name); break;
            }
        }
    }
}
