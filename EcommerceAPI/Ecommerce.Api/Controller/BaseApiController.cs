using Ecommerce.Api.RequestHelper;
using Ecommerce.Domain.entities;
using Ecommerce.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected async Task<ActionResult> CreatedPageResult<T>(IGenericRepository<T> repo, ISpecification<T> Spec, int pageSize, int pageIndex) where T : BaseEntity
        {
            var items = await repo.ListAllAsync(Spec);
            var count=await repo.CountAsync(Spec);
            var pagination = new Pagination<T>(pageSize, pageIndex, count, items);
            return Ok(pagination);
        }
    }
}
