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
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("Pagiation")]

        public async Task<IActionResult> GetPagenation(int catid, int pagenum, int pageSize)
        {
            var p=await _unitOfWork.Products.Pagination(catid, pagenum, pageSize);
            var map=_mapper.Map<List<ProductDto>>(p);
            return Ok(map);

        }

        [HttpGet("ById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var p=await _unitOfWork.Products.GetById(id);
            var map = _mapper.Map<ProductDto>(p);
            return Ok(map);
        }

        [HttpGet("MostExpensive{catid}")]
        public async Task<IActionResult> GetMostExpensive(int catid)
        {
            var p=await _unitOfWork.Products.SecoundMostExpensive(catid);
            var map = _mapper.Map<ProductDto>(p);
            return Ok(map);
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> Add(ProductDto productDto)
        {
            var cat = _unitOfWork.Categories.GetAll();
            if ( productDto.CategoryId!=cat.Id)
            {
                return BadRequest("This Category Dosenot Exsit");
            } 
            var map = _mapper.Map<Product>(productDto);
            await _unitOfWork.Products.add(map);
            await _unitOfWork.Save();
            return Created();
        }

        [HttpPut("Update{id}")]
        public async Task<IActionResult> Update(int id, ProductDto productDto)
        {
            var p = await _unitOfWork.Products.GetById(id);
            var map=_mapper.Map(productDto, p);
             _unitOfWork.Products.Update(p);
            await _unitOfWork.Save();
            return Ok(map);
        }

        [HttpGet("Search{name}")]
        public async Task<IActionResult>Search(string name)
        {
            var p=await _unitOfWork.Products.Search(name);
            var map=_mapper.Map<List<ProductDto>>(p);
            return Ok(map);
        }

        [HttpPatch("Patch{id}")]
        public async Task<IActionResult>PatchQuntity(int id,PatchProductDto patchProduct)
        {
            var p = await _unitOfWork.Products.GetById(id);
            var map=_mapper.Map(patchProduct, p);
            _unitOfWork.Products.Update(p);
            await _unitOfWork.Save();
            return Ok(map);
        }

    }
}
