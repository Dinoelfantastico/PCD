using AutoMapper;
using Product.Domain.Models;
using Product.Resource;

namespace Product.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveProduct_Resource, Product_>();
        }

    }
}
