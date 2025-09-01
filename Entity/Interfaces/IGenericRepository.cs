using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Specifications;

namespace Entity.Interfaces
{
    // both ICourseRepository & ICategoryRepository are doing the exact same job - getting the list and single list from the db
    // placeholder used in place of type and generic placeholder replaced by Category and Course entity when compiled
    public interface IGenericRepository<T>
    {
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetByIdAsync(dynamic id);
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListWithSpec(ISpecification<T> spec);
    }
}