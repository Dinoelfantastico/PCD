using AutoMapper;
using Product.Domain.Models;
using Product.Resource;

namespace Product.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Product_, Product_Resource>();
        }
    }
}
