using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product.Domain.Models;
using Product.Domain.Services;
using Product.Extension;
using Product.Resource;
using Swashbuckle.AspNetCore.Annotations;

namespace Product.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/v1/[controller]")]
    public class Product_sController : ControllerBase
    {
        private readonly IProduct_Service _product_Service;
        private readonly IMapper _mapper;

        public Product_sController(IProduct_Service product_Service, IMapper mapper)
        {
            _product_Service = product_Service;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all product_s",
            Description = "List of product_s",
            OperationId = "ListAllRoles",
            Tags = new[] { "Product_s" })]
        [SwaggerResponse(200, "List of Product_s", typeof(IEnumerable<Product_Resource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product_Resource>), 200)]
        public async Task<IEnumerable<Product_Resource>> GetAllAsync()
        {
            var product_s = await _product_Service.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product_>, IEnumerable<Product_Resource>>(product_s);

            return resources;
        }



        [SwaggerOperation(
           Summary = "Add product_s",
           Description = "Add new product_s",
           OperationId = "AddProduct_s",
           Tags = new[] { "Product_s" })]
        [SwaggerResponse(200, "Add Product_s", typeof(IEnumerable<Product_Resource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<Product_Resource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveProduct_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var product_ = _mapper.Map<SaveProduct_Resource, Product_>(resource);
            var result = await _product_Service.SaveAsync(product_);

            if (!result.Success)
                return BadRequest(result.Message);

            var product_Resource = _mapper.Map<Product_, Product_Resource>(result.Resource);
            return Ok(product_Resource);
        }


        [SwaggerOperation(
           Summary = "Update product_s",
           Description = "Update a product_s",
           OperationId = "Updateproduct_s",
           Tags = new[] { "Product_s" })]
        [SwaggerResponse(200, "Update Product_s", typeof(IEnumerable<Product_Resource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Product_Resource>), 200)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProduct_Resource resource)
        {
            var product_ = _mapper.Map<SaveProduct_Resource, Product_>(resource);
            var result = await _product_Service.UpdateAsync(id, product_);

            if (!result.Success)
                return BadRequest(result.Message);
            var product_Resource = _mapper.Map<Product_, Product_Resource>(result.Resource);
            return Ok(product_Resource);
        }


        [SwaggerOperation(
       Summary = "Delete product_",
       Description = "Delete a product_",
       OperationId = "DeleteProduct_",
       Tags = new[] { "Product_s" })]
        [SwaggerResponse(200, "Delete Product_s", typeof(IEnumerable<Product_Resource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Product_Resource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _product_Service.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var product_Resource = _mapper.Map<Product_, Product_Resource>(result.Resource);
            return Ok(product_Resource);

        }

    }
}
