using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Entity.Specifications
{
    public interface ISpecification<T>
    {
        // for db queries
        Expression<Func<T, bool>> Criteria { get; } // (e.g., c => c.Price < 10)
        List<Expression<Func<T, object>>> Include { get; } // entities for eager loading
        // ascending/descending order sorting
        Expression<Func<T, object>> Sort { get; }
        Expression<Func<T, object>> SortByDescending { get; }
        // pagination
        int Take { get; }
        int Skip { get; }
        bool IsPaging { get; }
    }
}