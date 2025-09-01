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
    }
}