using EFTest.Models;

namespace EFTest;
public interface IUserRepository
{
	Task<List<User>> GetAllUserAsync();
}