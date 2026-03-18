using Ecommerce.Api.RequestHelper;
using Ecommerce.Domain.entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Specification;
using Ecommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.Api.Controller
{

    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> repo;

        // private readonly IProductInterfaces repo;

        //private readonly StoreContext storeContext;

        public ProductController(IGenericRepository<Product> repo)
        {
            this.repo = repo;

            //this.storeContext = storeContext;
        }



        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<Product>>> GetProduct( [FromQuery] ProductParamsSpec paramsSpec)
        {
          var spec=new ProductSpecification(paramsSpec);
          
           
            return await CreatedPageResult(repo,spec,paramsSpec.PageSize,paramsSpec.pageIndex);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProductbyId(int id)
        {


            var product = await repo.GetByIdAsync(id);
   
            if (product == null) return NotFound();

            return Ok(product);

        }


        [HttpGet("brands")]

        public async Task<ActionResult<IReadOnlyList<string>>>GetBrands()
        {

            //TODO:Implement method

            var spec = new BrandListSpecification();

            return Ok(await repo.ListAllAsync(spec));
        }



        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
        {
            //TODO:Implement method

            var spec = new TypeListSpecification();
            return Ok(await repo.ListAllAsync(spec));
        }


        [HttpPost]

        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            repo.Add(product);
            if (await repo.SaveAllAsync()) {
                return CreatedAtAction("GetProduct", new{id = product.Id},product);
            
            }

            return BadRequest("Problem with creating Product");
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {

            if (id != product.Id) return NotFound();

           repo.Update(product);
            if (await repo.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest("Problem with Updating product");

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult>DeleteProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);
            if (product == null) return NotFound();

            repo.DeleteAsync(product);
            if (await repo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem with deleting product");
        }

    }
}
