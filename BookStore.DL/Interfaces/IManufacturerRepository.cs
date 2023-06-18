using Gym.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DL.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<IEnumerable<Manufacturer>> GetAll();
        Task<Manufacturer?> GetById(Guid id);
        Task AddManufacturer(Manufacturer manufacturer);
        Task DeleteManufacturer(Guid id);
    }
}
