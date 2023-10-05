using EFTest.Models;
using Microsoft.AspNetCore.Components;
using PopsCars;

namespace PopsCarsSite.Pages
{
    public class UserComponent : ComponentBase
    {
        protected List<EFTest.Models.User> ListOfUsers = new();
        protected string search;
        protected EFTest.Models.User model { get; set; }

        [Inject]
        private IUserService _userservice { get; set; } = default!;

		protected override async Task OnInitializedAsync()
		{
			await PopulateList();
		}

		protected async Task PopulateList()
		{
			ListOfUsers = await _userservice.GetAllUsers();
            model = new();
		}
        protected async Task FilterByUserSearch()
        {
            ListOfUsers = await _userservice.MainUserSearch(search);
        }

        protected async Task AddUser()
        {
			var result = await _userservice.CreateUser(model);
            await PopulateList();
		}
        
    }

}

