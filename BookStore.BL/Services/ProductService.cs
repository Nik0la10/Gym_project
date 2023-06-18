using Gym.BL.Interfaces;
using Gym.DL.Interfaces;
using Gym.Models.Data;
using Gym.Models.Request;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository,
            ILogger<ProductService> logger) 
        {
            _productRepository= productRepository;
            _logger= logger;
        }

        public async Task AddProduct(AddProductRequest productRequest)
        {
            var product = new Product()
            { 
                Id = Guid.NewGuid(),
                Description = productRequest.Description,
                ManufacturerId = productRequest.ManufacturerId,
                Name = productRequest.Name
            };

            _productRepository.AddProduct(product);
        }

        public async Task <IEnumerable<Product>> GetAll()
        {
            var result = 
                await _productRepository.GetAll();
            return result;
        }

        public async Task <Product?> GetById(Guid id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null) 
            {
                _logger.LogError(message: $"GetById:{id} returns null");
                return null;
            }
            return product;
        }

        public async Task DeleteProduct(Guid id)
        {
            await _productRepository.DeleteProduct(id);
        }
    }
}
