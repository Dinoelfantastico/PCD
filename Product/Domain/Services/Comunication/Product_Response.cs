using Product.Domain.Models;

namespace Product.Domain.Services.Comunication
{
    public class Product_Response : BaseResponse<Product_>
    {
        public Product_Response(Product_ resource) : base(resource)
        {
        }

        public Product_Response(string message) : base(message)
        {
        }
    }
}
