using System.Collections.Generic;
using XMLWeb.Models;

namespace XMLWeb.Repositories
{
    public interface IUsersRepository
    {
        List<User> GetUsers();
        User GetUser(int Id);
        void SaveUser(User obj);
        void DeleteUser(int Id);
    }
}