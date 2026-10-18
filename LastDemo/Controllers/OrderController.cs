using System.Collections.Immutable;
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

       // [Authorize(Roles = "Customer")]
        [HttpPost("AddOrder")]
        public async Task<IActionResult> Add(OrderDto orderdto)
        {


            var map = _mapper.Map<Order>(orderdto);
            map.TotalAmount = map.OrderIteams.Sum(x => x.Quantity * x.UnitPrice);
            await _unitOfWork.Orders.add(map);
            await _unitOfWork.Save();
            return Created();
        }



        [HttpGet("OrderById{id}")]
        public async Task<IActionResult> GetByIdOrder(int id)
        {
            var o = await _unitOfWork.Orders.GetByIdList(id);
            var op = new OrderDto
            {
                OrderDate = DateTime.Now,
                Status = o.Status,
                TotalAmmount = o.OrderIteams.Sum(x => x.Quantity * x.UnitPrice),
                OrderIteams = o.OrderIteams.Select(x => new OrderItemProductDto
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                }).ToList(),  

            };
            return Ok(op);


           
        }












        [HttpGet("ById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var o=await _unitOfWork.Orders.GetByIdList(id);
         //   o.TotalAmount=o.OrderIteams.
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
