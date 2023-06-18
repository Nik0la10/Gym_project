using Gym.BL.Interfaces;
using Gym.DL.Interfaces;
using Gym.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BL.Services
{
    public class ListService : IListService
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IProductRepository _productRepository;
        public ListService(
            IManufacturerRepository manufacturerRepository, 
            IProductRepository productRepository )
        {
            _manufacturerRepository = manufacturerRepository;
            _productRepository = productRepository;
        }
        public async Task <GetAllProductsByManufacturerResponse>
            GetAllProductsByManufacturer(Guid manufacturerId)
        {
            var response = new GetAllProductsByManufacturerResponse();

            response.Manufacturer = await _manufacturerRepository.GetById(manufacturerId);
            response.Product = await _productRepository.GetAllByManufacturerId(manufacturerId);

            return response;
        }
    }
}
