using EFTest.Models;
using Microsoft.AspNetCore.Components;
using PopsCars;

namespace PopsCarsSite.Pages
{
    public class UserComponent : ComponentBase
    {
        protected List<User> ListOfUsers = new();

        [Inject]
        private IUserService _userservice { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            ListOfUsers = await _userservice.GetAllUsers();           
        }

        protected async Task FilterByUserSearch()
        {
            ListOfUsers = await _userservice.MainUserSearch();
        }
    }

}

