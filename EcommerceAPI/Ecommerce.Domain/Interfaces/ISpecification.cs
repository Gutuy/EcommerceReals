using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>>? Criteria { get; }

        public Expression<Func<T, object>>? OrderBy { get; }

        public Expression<Func<T, object>>? OrderByDescending { get; }

        bool IsDistinct { get; }

        int skip { get; }
        int take { get; }

        bool isPaginated {  get; }

        IQueryable<T> ApplyCriteria(IQueryable<T> query);
    }


    public interface ISpecification<T, TResult> : ISpecification<T> {
    
    Expression<Func<T,TResult>>?Select { get; }
    }

}
