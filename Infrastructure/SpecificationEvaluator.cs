using System.Linq;
using Entity.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    // used for generic repositories - take all queries/expressions and creates IQueryable after aggregating everything together to provide to db
    public class SpecificationEvaluator<T> where T : class
    {
        // IQueryable: Entity, ISpecification: What is passes as a query
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;

            if(spec.Criteria != null) // example: c => c.Price < 10
            {
                query = query.Where(spec.Criteria); // returns true/false
            }
            query = spec.Include.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}