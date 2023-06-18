using Gym.Models.Data;
using Gym.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BL.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product?> GetById(Guid id);

        Task AddProduct(AddProductRequest product);
        Task DeleteProduct(Guid id);
    }
}
