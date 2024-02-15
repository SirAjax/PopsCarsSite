using Moq;
using PopsCarsSite;
using Bunit;
using PopsCars;
using PopsCarsSite.Pages;
using PopsCarsSite.Common.Models;

namespace TestForPopsCars;

[TestClass]
public class InitialUserTest : InitialUserComponent
{
	private Mock<IService> servicemoq;
	private InitialUserComponent initialUserComponent;

	[TestInitialize]
	public void Setup()
	{
		servicemoq = new Mock<IService>();	
		initialUserComponent = new InitialUserComponent();
	}

	[TestMethod]

	public async Task Does_AddCar_Return_Success()
	{
		servicemoq.Setup(x => x.AddCar(It.IsAny<Car>())).ReturnsAsync(new CommonResponse<bool>());
		Car car = new Car { Year = 1980, Make = "unit test", Model = "Test", Color = "Blue" };

		await AddCar();
	}
}