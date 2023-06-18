using Gym.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Response
{
    public class GetAllProductsByManufacturerResponse
    {
        public Manufacturer Manufacturer { get; set; }
        public IEnumerable<Product> Product { get; set; }
        
    }
}
