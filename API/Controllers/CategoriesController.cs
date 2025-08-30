using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dto;
using AutoMapper;
using Entity;
using Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriesController : BaseController
    {
        // private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _repository;
        // ICategoryRepository repository, IMapper mapper - replaced with generic
        public CategoriesController(IGenericRepository<Category> repository, IMapper mapper) // inject ICategoryRepository & IMapper
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoriesDto>>> GetCategories() // get all categories
        {
            var categories = await _repository.ListAllAsync();
            // var categories = await _repository.GetCategoriesAsync();

            return Ok(_mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoriesDto>>(categories));
            // return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            // var category = await _repository.GetCategoryByIdAsync(id);

            return _mapper.Map<Category, CategoryDto>(category);
            // return category;
        }
    }
}