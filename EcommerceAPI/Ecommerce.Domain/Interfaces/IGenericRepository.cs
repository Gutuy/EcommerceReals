using Ecommerce.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetEntitywithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T?>> ListAllAsync(ISpecification<T> spec);


        Task<TResult?> GetEntitywithSpec<TResult>(ISpecification<T,TResult> spec);
        Task<IReadOnlyList<TResult?>> ListAllAsync<TResult>(ISpecification<T,TResult> spec);

        Task<T?> GetByIdAsync(int id);
        Task Add(T entity);

        Task Update(T entity);
        Task DeleteAsync(T entity);

        Task<bool> SaveAllAsync();

        Task<int> CountAsync(ISpecification<T> spec);

    }
}
