using AutoMapper;
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
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ManufacturerService> _logger;


        public ManufacturerService(
            IManufacturerRepository manufacturerRepository,
            IMapper mapper,
            ILogger<ManufacturerService> logger) 
        {
            _manufacturerRepository= manufacturerRepository;
            _mapper= mapper;
            _logger = logger;
        }

        public async Task<Manufacturer?> AddManufacturer(AddManufacturerRequest manufacturerRequest)
        {
            var manufacturer = _mapper.Map<Manufacturer>(manufacturerRequest);
           
            manufacturer.Id = Guid.NewGuid();
           
            await _manufacturerRepository.AddManufacturer(manufacturer);

            return manufacturer;
        }

        public async Task <IEnumerable<Manufacturer>> GetAll()
        {
            return await _manufacturerRepository.GetAll();
        }

        public async Task <Manufacturer?> GetById(Guid id)
        { 
            var result = await _manufacturerRepository.GetById(id);

            if (result == null) return null;

            result.Name = $"@{result.Name}";

            return result;
        }

        public async Task DeleteManufacturer(Guid id)
        {
            await _manufacturerRepository.DeleteManufacturer(id);
        }
    }
}
