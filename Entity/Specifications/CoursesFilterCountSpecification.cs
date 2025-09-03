namespace Entity.Specifications
{
    public class CoursesFilterCountSpecification : BaseSpecification<Course>
    {
        public CoursesFilterCountSpecification(CourseParams courseParams) : base(x =>
            !courseParams.CategoryId.HasValue || x.CategoryId == courseParams.CategoryId) // api/courses?categoryId=1
        {
        }
    }
}