namespace Entity.Specifications
{
    public class CategoriesWithCoursesSpecification : BaseSpecification<Category>
    {
        public CategoriesWithCoursesSpecification(int id) : base(x => x.Id == id)
        {
            IncludeMethod(x => x.Courses);
            SortMethod(x => x.Id);
        }
    }
}