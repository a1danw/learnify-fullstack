using System;

namespace Entity.Specifications
{
    public class CoursesWithCategoriesSpecification : BaseSpecification<Course>
    {
        // string sort, int? categoryId
        public CoursesWithCategoriesSpecification(CourseParams courseParams) : base(x =>
            (string.IsNullOrEmpty(courseParams.Search) || x.Title.ToLower().Contains(courseParams.Search)) && // api/courses?search=abc
            (!courseParams.CategoryId.HasValue || x.CategoryId == courseParams.CategoryId)) // api/courses?categoryId=1
        {
            IncludeMethod(x => x.Category);
            IncludeMethod(c => c.Requirements);
            IncludeMethod(c => c.Learnings);
            // courseParams.PageSize * (courseParams.PageIndex - 1)
            ApplyPagination(courseParams.PageSize, courseParams.PageSize * ((courseParams.PageIndex ?? 1) - 1)); // api/courses?pageIndex=2 / pageSize=10&pageIndex=2

            // api/courses?sort=priceAscending
            if (!string.IsNullOrEmpty(courseParams.Sort))
            {
                switch (courseParams.Sort)
                {
                    case "priceAscending":
                        SortMethod(c => c.Price);
                        break;
                    case "priceDescending":
                        SortByDescendingMethod(c => c.Price);
                        break;
                    default:
                        SortMethod(c => c.Title);
                        break;
                }
            }
        }

        public CoursesWithCategoriesSpecification(Guid id) : base(x => x.Id == id)
        {
            IncludeMethod(c => c.Requirements);
            IncludeMethod(c => c.Learnings);
            IncludeMethod(c => c.Category);
            SortMethod(x => x.Id);
        }
    }
}