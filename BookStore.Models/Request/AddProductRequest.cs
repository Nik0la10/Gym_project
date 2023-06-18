using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Request
{
    public class AddProductRequest
    {
        public string Name { get; set; }
        public Guid ManufacturerId { get; set; }
        public string Description { get; set; }
    }
}
