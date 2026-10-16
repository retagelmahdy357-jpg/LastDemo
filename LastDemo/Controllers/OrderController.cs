using AutoMapper;
using LastDemo.DTO;
using LastDemo.Model;
using LastDemo.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "Customer")]
        [HttpPost("AddOrder")]
        public async Task<IActionResult> Add(OrderDto orderdto)
        {
            //var cus = await _unitOfWork.Users.GetById(orderdto.UserId);
            //if (cus.Role != "Customer")
            //{
            //    return BadRequest("You are not Customer");
            //}

            var map = _mapper.Map<Order>(orderdto);
            await _unitOfWork.Orders.add(map);
            await _unitOfWork.Save();
            return Created();
        }

        [HttpGet("ById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var o=await _unitOfWork.Orders.GetByIdList(id);
            var map=_mapper.Map<OrderDto>(o);
            return Ok(map);
        }

        [HttpPatch("PatchStatus{id}")]
        public async Task<IActionResult>PatchStatus(int id,PatchOrderDto orderDto)
        {
            var o=await _unitOfWork.Orders.GetById(id);
            var map=_mapper.Map(orderDto,o);
            _unitOfWork.Orders.Update(o);
            await _unitOfWork.Save();
            return Ok(map);
        }

        [HttpGet("Reveneu")]
        public async Task<IActionResult> Revenue()
        {
            var o = await _unitOfWork.Orders.TotalRevenue();
            return Ok($"Toltal Amount:{o}");
        }
    }
}
