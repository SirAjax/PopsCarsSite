﻿using Microsoft.VisualBasic;
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
			mockRepo.Setup(repo => repo.Add(It.IsAny<Car>())).ReturnsAsync(true);
			Car car = new Car { Year = 1980, Make = "unit test", Model = "Test", Color = "Blue" };

			var newCar = await service.AddCar(car);

			Assert.IsTrue(newCar.Value);
		}

		[TestMethod]
		public async Task Does_Add_Car_Return_Error()
		{
			mockRepo.Setup(repo => repo.Add(It.IsAny<Car>())).ThrowsAsync(new Exception());
			Car car = new Car { Year = 1980, Make = "unit test", Model = "Test", Color = "Blue" };

			var newCar = await service.AddCar(car);

			Assert.IsTrue(newCar.Error);
		}


		[TestMethod]
		public async Task Does_GetAllCars_Return_Success()
		{
			var result = await service.GetAllCars();

			Assert.IsFalse(result.Error);
		}
		[TestMethod]
		public async Task Does_GetAllCars_Return_Error()
		{
			mockRepo.Setup(repo => repo.GetAll()).Throws(new Exception());

			var result = await service.GetAllCars();

			Assert.IsTrue(result.Error);
		}

		[TestMethod]
		public async Task Does_DeleteCar_Return_Success()
		{
			mockRepo.Setup(repo => repo.Delete(It.IsAny<Car>())).ReturnsAsync(true);
			Car car = new Car { Year = 1980, Make = "unit test", Model = "Test", Color = "Blue" };
			
			var result = await service.DeleteCar(car);
			
			Assert.IsTrue(result.Value);
		}

		[TestMethod]
		public async Task Does_UpdateCar_Return_Success()
		{
			mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Car>())).ReturnsAsync(true);
			Car car = new Car { Year = 1980, Make = "unit test", Model = "Test", Color = "Blue" };

			var result = await service.UpdateCar(car);

			Assert.IsTrue(result.Value);
		}

		[TestMethod]

		public async Task Does_MainSearch_Return_Success()
		{
			var carList = new List<Car> { new Car { Year = 1975 }, new Car { Year = 1985 }, new Car { Year = 1975 } };
			mockRepo.Setup(repo => repo.GetAll()).Returns(carList);

			var result = await service.MainSearch("1975");

			Assert.AreEqual(2, result.Value.Count);
		}
	}
}

