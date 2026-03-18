using Ecommerce.Domain.Interfaces;
using System.Linq.Expressions;

public class BaseSpecification<T>(
    Expression<Func<T, bool>>? criteria
) : ISpecification<T>
{
    protected BaseSpecification() : this(null) { }
    public Expression<Func<T, bool>>? Criteria => criteria;

    public Expression<Func<T, object>>? OrderBy { get; private set; }

    public Expression<Func<T, object>>? OrderByDescending { get; private set; }

    public bool IsDistinct  { get; private set; }

    public int skip { get; private set; }

    public int take { get; private set; }

    public bool isPaginated { get; private set; }

    public IQueryable<T> ApplyCriteria(IQueryable<T> query)
    {
       if(Criteria != null)
        {
            query=query.Where(criteria);
        }
       return query;
    }

    protected void AddOrderBy(Expression<Func<T, object>> OrderByExpression)
    {
        OrderBy = OrderByExpression;
    }

    protected void AddOrderByDescending(Expression<Func<T, object>> OrderByDescendingExpression)
    {
        OrderByDescending = OrderByDescendingExpression;
    }
    protected void ApplyDistinct()
    {
        IsDistinct = true;
    }

    protected void ApplyPagination(int skip,int take)
    {
        this.skip = skip;
        this.take = take;
        isPaginated = true;
    }

    
}

public class BaseSpecification<T, TResult>(Expression<Func<T, bool>> Criteria) : BaseSpecification<T>(Criteria), ISpecification<T, TResult>
{
    protected BaseSpecification() : this(null) { }
    public Expression<Func<T, TResult>>? Select { get; private set; }

    protected void AddSelect(Expression<Func<T, TResult>> SelectExpression) { Select = SelectExpression; }

   
}
