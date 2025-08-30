using API.Dto;
using AutoMapper;
using Entity;

namespace API.Helpers
{
    // map dto with classes/original entity with the dto
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(c => c.Category,
                    o => o.MapFrom(s => s.Category.Name));

            CreateMap<Learning, LearningsDto>();

            CreateMap<Requirement, RequirementsDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<Category, CategoriesDto>();
        }
    }
}