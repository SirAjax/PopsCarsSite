using Microsoft.VisualBasic;
using Moq;
using PopsCars;

namespace TestForPopsCars
{
    [TestClass]
    public class ServiceTest
    {
        private Service service;
        private Mock<ICarsRepository> mockRepo;
        
        [TestInitialize]
        public void Setup()
        {
            mockRepo = new Mock<ICarsRepository>();
            service = new Service(mockRepo.Object);
      
        }
        [TestMethod]
        public async Task Does_AddCar_Return_Success()
        {
            //              It.IsAny<T>()

            mockRepo.Setup(repo => repo.Add(It.IsAny<Car>())).ReturnsAsync(true);
            Car car = new Car { Year = 1980, Make = "unit test", Model = "Test", Color = "Blue" };
            var newCar = await service.AddCar(car);
            Assert.IsTrue(newCar);
        }

    [TestMethod]
    public async Task Does_GetAllCars_Return_Success()
    {
        mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Car> { new Car { Make = "Test Car" } });
        var result = await service.GetAllCars();
        Assert.AreEqual(1, result.Count);
    }

    [TestMethod]
        public async Task Does_DeleteCar_Return_Success()
    {
            mockRepo.Setup(repo => repo.Delete(It.IsAny<Car>())).ReturnsAsync(true);
            Car car = new Car { Year = 1980, Make = "unit test", Model = "Test", Color = "Blue" };
            var result = await service.DeleteCar(car);
            Assert.IsTrue(result);
    }

    [TestMethod]
    public async Task Does_UpdateCar_Return_Success()
    {
            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Car>())).ReturnsAsync(true);
            Car car = new Car { Year = 1980, Make = "unit test", Model = "Test", Color = "Blue" };
            var result = await service.UpdateCar(car);
            Assert.IsTrue(result);
    }

    [TestMethod]

    public async Task Does_MainSearch_Return_Success()
    {
            mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Car> { });
            var result = await service.MainSearch("unit test");
            Assert.IsNotNull(result);
    }
}
}

