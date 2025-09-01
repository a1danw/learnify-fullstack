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
    public class CategoriesController : BaseController
    {
        // private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _repository;
        // ICategoryRepository repository, IMapper mapper - replaced with generic
        public CategoriesController(IGenericRepository<Category> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoriesDto>>> GetCategories()
        {
            var categories = await _repository.ListAllAsync();
            // var categories = await _repository.GetCategoriesAsync();

            return Ok(_mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoriesDto>>(categories));
            // return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var spec = new CategoriesWithCoursesSpecification(id);
            var category = await _repository.GetEntityWithSpec(spec);

            return _mapper.Map<Category, CategoryDto>(category);
        }
    }
}