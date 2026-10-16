using AutoMapper;
using LastDemo.DTO;
using LastDemo.Model;
using LastDemo.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IMapper mapper, IUnitOfWork unitOfWork)
        {
             _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var c = await _unitOfWork.Categories.GetAll();
            var map=_mapper.Map<List<CategoryDto>>(c);
            return Ok(map);
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> Add(CategoryDto categorydto)
        {
            var map=_mapper.Map<Category>(categorydto);
            await _unitOfWork.Categories.add(map);
            await _unitOfWork.Save();
            return Created();
        }
    }
}
