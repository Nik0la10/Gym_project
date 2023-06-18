using Gym.Models.Data;
using Gym.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BL.Interfaces
{
    public interface IManufacturerService
    {
        Task<IEnumerable<Manufacturer>> GetAll();
        Task<Manufacturer?> GetById(Guid id);
        Task<Manufacturer?> AddManufacturer(AddManufacturerRequest manufacturer);
        Task DeleteManufacturer(Guid id);
    }
}
