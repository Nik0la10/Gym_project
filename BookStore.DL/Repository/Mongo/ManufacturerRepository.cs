using Gym.DL.Interfaces;
using Gym.Models.Configs;
using Gym.Models.Data;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DL.Repository.Mongo
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly IMongoCollection<Manufacturer> _manufacturers;
        private readonly IOptionsMonitor<MongoConfiguration> _config;

        public ManufacturerRepository(
            IOptionsMonitor<MongoConfiguration> config)
        {
            _config = config;
            var client =
                new MongoClient(_config.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(_config.CurrentValue.DatabaseName);

            _manufacturers =
                database.GetCollection<Manufacturer>($"{nameof(Manufacturer)}",
                    new MongoCollectionSettings()
                    {
                        GuidRepresentation=GuidRepresentation.Standard
                    });
        }

        public async Task<IEnumerable<Manufacturer>> GetAll() 
        {
            return await _manufacturers.Find(manufacturer => true)
                .ToListAsync();
        }

        public async Task<Manufacturer> GetById(Guid id) 
        {
            return await _manufacturers
                .Find(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task AddManufacturer(Manufacturer manufacturer) 
        {
            await _manufacturers.InsertOneAsync(manufacturer);
        }

        public async Task DeleteManufacturer(Guid id)
        {
            await _manufacturers
                .DeleteOneAsync(a => a.Id == id);
        }
    }
}
