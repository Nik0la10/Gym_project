using Amazon.Runtime.Internal.Util;
using AutoMapper;
using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.Models.Data;
using BookStore.Models.Request;
using Gym.AutoMappings;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net.NetworkInformation;

namespace BookStoreTest
{
    public class AuthorServiceTest
    {
        private Mock<IManufacturerRepository> _manufacturerRepository;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<ManufacturerService>> _logger;
        private readonly IManufacturerService _manufacturerService;

        private IList<Manufacturer> Manufacturers = new List<Manufacturer>()
        {
             new Manufacturer()
             {
                 Id=new Guid("552dd52b-627e-49cd-af85-83341bbeaa4a"),
                 Name="Manufacturer 1",
                 Info="Manufacturer 1 Info"
             },

             new Manufacturer()
             {
                 Id =new Guid("c04ff06c-ae2e-491d-ba6b-ce04a2360877"),
                 Name = "Manufacturer 2",
                 Info = "Manufacturer 2 Info"
             }              
        };

        public ManufacturerServiceTest()
        {
            var mockMapper =
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfiles(new[] { new AutoMapperConfigs() });
                });


            _mapper = mockMapper.CreateMapper();

            _manufacturerRepository = new Mock<IManufacturerRepository>();
            _logger = new Mock<ILogger<ManufacturerService>>();

            _manufacturerService =
                new ManufacturerService(
                    _manufacturerRepository.Object, _mapper, _logger.Object);
        }

        [Fact]
        public async void GetAll_Test_OK()
        {
            //setup
            var expectedCount = 2;

            _manufacturerRepository.Setup(x =>
                x.GetAll())
                .Returns(async () =>
                    Manufacturers.AsEnumerable());

            //inject
            //Act
            var result =
                await _manufacturerService.GetAll();

            var enumerable = result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, enumerable.Count());
            Assert.Equal(Manufacturers, enumerable);
        }

        [Fact]
        public async void GetById_Test_OK()
        {
            //setup
            var manufacturerId = Guid.NewGuid();

            _manufacturerRepository.Setup(x =>
                x.GetById(manufacturerId))
            .Returns(async () =>
                Manufacturers.FirstOrDefault(a => a.Id == manufacturerId));

            //inject
            //Act
            var result = await _manufacturerService.GetById(manufacturerId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void GetById_Test_NotFound()
        {
            //setup
            var expectedId = Manufacturers[0].Id;
            var expectedName = $"@{Manufacturers[0].Name}";

            _manufacturerRepository.Setup(x =>
                    x.GetById(expectedId))
                .Returns(async () =>
                    Manufacturers.FirstOrDefault(a => a.Id == expectedId));

            //inject
            //Act
            var result = await _manufacturerService.GetById(expectedId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedName, result.Name);
        }

        [Fact]
        public async void AddManufacturer_Test_Ok()
        {
            //setup
            var expectedCount = 3;
            var manufacturerRequest = new AddManufacturerRequest()
            {
                Name = "Manufacturer 3",
                Info = "Manufacturer 3 Info"
            };

            _manufacturerRepository.Setup(x =>
                    x.AddManufacturer(It.IsAny<Manufacturer>()))
                .Callback(() =>
                {
                    Manufacturers.Add(new Manufacturer()
                    {
                        Name = "Manufacturer 3",
                        Info = "Manufacturer 3 Info"
                    });
                });


            //inject
            //Act
            var result =
                await _manufacturerService.AddManufacturer(manufacturerRequest);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, Manufacturers.Count);
        }

        [Fact]
        public async void AddManufacturer_Test_NotFound()
        {
            //setup
            var expectedId = Manufacturers[0].Id;
            var expectedName = $"@{Manufacturers[0].Name}";

            _manufacturerRepository.Setup(x =>
                    x.GetById(expectedId))
                .Returns(async () =>
                    Manufacturers.FirstOrDefault(a => a.Id == expectedId));

            //inject
            //Act
            var result = await _manufacturerService.GetById(expectedId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedName, result.Name);
        }

        [Fact]
        public async void Delete_Test_OK()
        {
            //setup
            var expectedId = Manufacturers[0].Id;
            var expectedName = $"@{Manufacturers[0].Name}";

            _manufacturerRepository.Setup(x =>
                    x.GetById(expectedId))
                .Returns(async () =>
                    Manufacturers.FirstOrDefault(a => a.Id == expectedId));

            //inject
            //Act
            var result = await _manufacturerService.GetById(expectedId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedName, result.Name);
        }
    }
}