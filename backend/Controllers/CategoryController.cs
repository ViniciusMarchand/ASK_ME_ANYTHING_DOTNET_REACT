using backend.DTO;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers

{
    [Route("api/category")]
    [ApiController]
    public class CategoryController(CategoryRepository repository) : ControllerBase
    {
        private readonly CategoryRepository _repository = repository;

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _repository.GetCategories();
        }

        [HttpPost]
        [Authorize]
        public async Task<Category> Save(CategoryDTO category)
        {
            return await _repository.Save(category);
        }

    }
}