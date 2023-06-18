using Gym.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DL.Interfaces
{
    public interface IProductRepository
    {
        Task <IEnumerable<Product>> GetAll();
        Task <IEnumerable<Product>> GetAllByManufacturerId(Guid manufacturerId);
        Task <Product?> GetById(Guid id);
        Task AddProduct(Product product);
        Task DeleteProduct(Guid id);
    }
}
