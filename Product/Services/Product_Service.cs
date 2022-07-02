using Product.Domain.Models;
using Product.Domain.Repositories;
using Product.Domain.Services;
using Product.Domain.Services.Comunication;

namespace Product.Services
{
    public class Product_Service : IProduct_Service
    {
        private readonly IProduct_Repository _product_Repository;
        private readonly IUnitOfwork _unitOfwork;

        public Product_Service(IProduct_Repository product_Repository, IUnitOfwork unitOfwork)
        {
            _product_Repository = product_Repository;
            _unitOfwork = unitOfwork;
        }

        public async Task<IEnumerable<Product_>> ListAsync()
        {
            return await _product_Repository.ListAsync();
        }


        public async Task<Product_Response> SaveAsync(Product_ product_)
        {
            try
            {
                await _product_Repository.AddAsync(product_);
                await _unitOfwork.CompleteAsync();

                return new Product_Response(product_);
            }
            catch (Exception e)
            {
                return new Product_Response($"An error ocurred while saving role: {e.Message}");
            }
        }

        public async Task<Product_Response> UpdateAsync(int id, Product_ product_)
        {
            var existingProduct_ = await _product_Repository.FindByIdAsync(id);

            if (existingProduct_ == null)
                return new Product_Response("Product_ not found.");
            existingProduct_.Name = product_.Name;
            existingProduct_.Ferlizante = product_.Ferlizante;

            try
            {
                _product_Repository.Update(existingProduct_);
                await _unitOfwork.CompleteAsync();

                return new Product_Response(existingProduct_);
            }

            catch (Exception e)
            {
                return new Product_Response($"An error ocurred while updating the Product_ {e.Message}");
            }
        }

        public async Task<Product_Response> DeleteAsync(int id)
        {

            var existingProduct_ = await _product_Repository.FindByIdAsync(id);

            if (existingProduct_ == null)
                return new Product_Response("Product_ not found");

            try
            {
                _product_Repository.Remove(existingProduct_);
                await _unitOfwork.CompleteAsync();

                return new Product_Response(existingProduct_);
            }
            catch (Exception ex)
            {
                return new Product_Response($"An error ocurred while deleting Product_: {ex.Message}");
            }
        }
    
    }
}
