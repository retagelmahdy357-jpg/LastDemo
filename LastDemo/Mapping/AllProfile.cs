using AutoMapper;
using LastDemo.DTO;
using LastDemo.Model;

namespace LastDemo.Mapping
{
    public class AllProfile:Profile
    {
        public AllProfile()
        {
             CreateMap<Category,CategoryDto>().ReverseMap();
             CreateMap<Product,ProductDto>().ReverseMap();
             CreateMap<Product,PatchProductDto>().ReverseMap();
             CreateMap<Order,OrderDto>().ReverseMap();
             CreateMap<OrderIteam, OrderItemProductDto>().ReverseMap();
             CreateMap<Order, PatchOrderDto>().ReverseMap();
        }
    }
}
