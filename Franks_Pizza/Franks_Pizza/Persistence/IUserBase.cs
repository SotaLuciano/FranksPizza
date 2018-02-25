using Franks_Pizza.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Franks_Pizza.ViewModels
{
    public interface IUserBase
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUser(string login);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        Task<bool> SearchUser(string login);
        Task<UserViewModel> CheckLogin(string login, string password);
    }
}
