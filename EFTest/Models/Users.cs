namespace EFTest.Models;

    public class Users
    {
        public string? userName;
        public int id;

        public Users(string userName, int id)
        {
            this.userName = userName;
            this.id = id;
        }
    }