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
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;
        private readonly IOptionsMonitor<MongoConfiguration> _config;

        public ProductRepository(
            IOptionsMonitor<MongoConfiguration> config)
        {
            _config = config;
            var client =
                new MongoClient(_config.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(_config.CurrentValue.DatabaseName);

            _products =
                database.GetCollection<Product>($"{nameof(Product)}",
                 new MongoCollectionSettings()
                    {
                        GuidRepresentation = GuidRepresentation.Standard
                    });
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _products.Find(product => true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByManufacturerId(Guid manufacturerId)
        {
            return await _products
                .Find(a => a.ManufacturerId == manufacturerId)
                .ToListAsync();
        }

        public async Task<Product?> GetById(Guid id)
        {
            return await _products
                .Find(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task AddProduct(Product manufacturer)
        {
            await _products.InsertOneAsync(manufacturer);
        }

        public async Task DeleteProduct(Guid id)
        {
            await _products
                .DeleteOneAsync(a => a.Id == id);
        }
    }
}
