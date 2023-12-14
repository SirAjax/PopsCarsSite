using Moq;
using PopsCars;

namespace TestForPopsCars
{
    [TestClass]
    public class ServiceTest
    {
        private Service service;
        private Mock<ICarsRepository> mockRepo;
        private Car car = new Car { Year = 1980, Make = "unit test", Model = "Test", Color = "Blue"};

        [TestInitialize]
        public void Setup()
        {
            mockRepo = new Mock<ICarsRepository>();
            service = new Service(mockRepo.Object);
            mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Car> { new Car { Year = 5, Make = "unit test", Model = "TEST", Color = "Turqouise"} });

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
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void Does_DeleteCar_Return_Success()
        {
            var result = service.DeleteCar(car);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Does_UpdateCar_Return_Success()
        {
            var result = service.UpdateCar(car);
            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void Does_MainSearch_Return_Success()
        {
            var result = service.MainSearch("unit test");
            Assert.IsNotNull(result);
        }
    }
}

