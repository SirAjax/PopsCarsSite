using Moq;
using PopsCars;

namespace TestForPopsCars
{
    [TestClass]
    public class ServiceTest
    {
        private Service service;
        private Mock<ICarsRepository> mockRepo;
        private Car car = new Car { Year = 5, Make = "unit test", Model = "TEST", Color = "Turqouise", Id = 18 };

        [TestInitialize]
        public void TestInitialize()
        {
            var mockRepo = new Mock<ICarsRepository>();
            var service = new Service(mockRepo.Object);
            mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Car> { new Car { Year = 5, Make = "unit test", Model = "TEST", Color = "Turqouise", Id = 18 } });

        }
        [TestMethod]
        public void Does_AddCar_Return_Success()
        {
            var newCar = service.AddCar(car);
            Assert.IsNotNull(newCar);
        }

        [TestMethod]
        public void Does_GetAllCars_Return_Success()
        {
            var result = service.GetAllCars();
            Assert.AreEqual(3, result.Count);
        }
    }
}

