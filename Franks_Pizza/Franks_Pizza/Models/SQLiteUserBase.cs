using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Franks_Pizza.Models;
using SQLite;
using Xamarin.Forms;

namespace Franks_Pizza.ViewModels
{
    public class SQLiteUserBase : IUserBase
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteUserBase(ISQLiteDb db)
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTableAsync<User>();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _connection.Table<User>().ToListAsync();
        }

        public async Task DeleteUser(User user)
        {
            await _connection.DeleteAsync(user);
        }

        public async Task AddUser(User user)
        {
            await _connection.InsertAsync(user);
        }

        public async Task UpdateUser(User user)
        {
            await _connection.UpdateAsync(user);
        }

        public async Task<User> GetUser(string login)
        {
            return await _connection.FindAsync<User>(login);
        }

        public async Task<bool> SearchUser(string login)
        {
            bool flag = false;

            var _list = await _connection.Table<User>().ToListAsync();

            foreach (var _user in _list)
            {
                if (_user.Login == login)
                    flag = true;
            }

            return flag;
        }

        public async Task<UserViewModel> CheckLogin(string login, string password)
        {
            UserViewModel tmp = null;

            var _list = await _connection.Table<User>().ToListAsync();

            foreach (var _user in _list)
            {
                if (_user.Login == login && _user.Password == password)
                    tmp = new UserViewModel(_user);
            }

            return tmp;
        }
    }
}
