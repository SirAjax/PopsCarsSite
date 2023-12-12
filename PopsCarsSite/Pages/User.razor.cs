using EFTest.Models;
using EFTest.GenericRepository;
using Microsoft.AspNetCore.Components;
using PopsCars;
using System.Diagnostics.Eventing.Reader;

namespace PopsCarsSite.Pages
{
    public class UserComponent : ComponentBase
    {
        protected List<EFTest.Models.User> ListOfUsers = new();
        protected string? search;
        protected EFTest.Models.User? newUser = new();
        protected EFTest.Models.User? userToDelete = new();

        [Inject]
        private IUserService _userservice { get; set; } = default!;

      
		protected override async Task OnInitializedAsync()
		{
			await PopulateList();
		}

		protected async Task PopulateList()
		{
			ListOfUsers = await _userservice.GetAllUsers();
            newUser = new();
		}
        protected async Task FilterByUserSearch()
        {
            if (string.IsNullOrEmpty(search))
            {
                Console.WriteLine("no search criteria");
            }
            else
            {
                ListOfUsers = await _userservice.MainUserSearch(search);
            }
        }

        protected async Task AddUser()
        {
			await _userservice.CreateUser(newUser);
            await PopulateList();
		}
        
        protected async Task DeleteUser(User user)
        {

            var userList = await _userservice.GetAllUsers();
            var actualUserToDelete = userList.FirstOrDefault(c => c.UserName == userToDelete.UserName);

            if (actualUserToDelete != null) 
            {
                await _userservice.DeleteUser(actualUserToDelete);
                await PopulateList();
            }
        }
    }

}

