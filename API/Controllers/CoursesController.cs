using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dto;
using AutoMapper;
using Entity;
using Entity.Interfaces;
using Entity.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CoursesController : BaseController
    {
        // private readonly StoreContext _context; // StoreContext is a database context for Entity Framework
        // private readonly ICourseRepository _repository;
        private readonly IGenericRepository<Course> _repository;
        private readonly IMapper _mapper;
        // Dependency injection of StoreContext & AutoMapper into the controller (abstracted with repository)
        // ICourseRepository repository - replaced with generic repository
        public CoursesController(IGenericRepository<Course> repository, IMapper mapper) // (StoreContext context)
        {
            _mapper = mapper;
            // abstract db via repository pattern instead
            _repository = repository;
            // _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> GetCourses()
        {
            var spec = new CoursesWithCategoriesSpecification();
            var courses = await _repository.ListWithSpec(spec);
            // var courses = await _repository.GetCoursesAsync(); - replaced with generic
            return Ok(_mapper.Map<IReadOnlyList<Course>, IReadOnlyList<CourseDto>>(courses));
            // return Ok(courses); // 200 response along with all courses
            // return await _context.Courses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourse(Guid id)
        {
            var spec = new CoursesWithCategoriesSpecification(id);
            var course = await _repository.GetEntityWithSpec(spec);
            // var course = await _repository.GetCourseByIdAsync(id);
            return _mapper.Map<Course, CourseDto>(course);
            // return await _repository.GetCourseByIdAsync(id);
            // return await _context.Courses.FindAsync(id);
        }
    }
}