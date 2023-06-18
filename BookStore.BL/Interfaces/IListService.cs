using Gym.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BL.Interfaces
{
    public interface IListService
    {
        Task<GetAllProductsByManufacturerResponse>
            GetAllProductsByManufacturer(Guid manufacturerId);

    }
}
