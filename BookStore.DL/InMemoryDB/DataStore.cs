using Gym.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DL.InMemoryDB
{
   public static class DataStore
   {
        public static List<Manufacturer> Manufacturers
            = new List<Manufacturer>()
            {
                new Manufacturer()
                {
                    Id = Guid.NewGuid(),
                    Name= "OLIMP",
                    Info= "info"
                },
                new Manufacturer()
                {
                    Id = Guid.NewGuid(),
                    Name= "EVERBUILD",
                    Info= "info"
                }
            };

        public static List<Product> Products
            = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    ManufacturerId=Guid.NewGuid(),
                    Name= "Plant Protein",
                    Description= "description 1"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    ManufacturerId=Guid.NewGuid(),
                    Name= "Profi Mass",
                    Description= "description 2"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    ManufacturerId=Guid.NewGuid(),
                    Name= "100% Whey Gold Standard",
                    Description= "description 3"
                }

            };
    }
}
