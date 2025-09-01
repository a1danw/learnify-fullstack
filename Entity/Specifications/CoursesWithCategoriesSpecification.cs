using System;

namespace Entity.Specifications
{
    public class CoursesWithCategoriesSpecification : BaseSpecification<Course>
    {
        public CoursesWithCategoriesSpecification()
        {
            IncludeMethod(x => x.Category);
        }

        public CoursesWithCategoriesSpecification(Guid id) : base(x => x.Id == id)
        {
        }
    }
}