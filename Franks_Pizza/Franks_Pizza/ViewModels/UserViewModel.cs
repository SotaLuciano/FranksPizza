using Franks_Pizza.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Franks_Pizza.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private string _avatarSource;
        private string _address;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }

        public string AvatarSource
        {
            get
            {
                return _avatarSource;
            }
            set
            {
                SetValue(ref _avatarSource, value);
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                SetValue(ref _address, value);
            }
        }

        public UserViewModel() { }

        public UserViewModel(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Phone = user.Phone;
            Email = user.Email;
            Address = user.Address;
            Password = user.Password;
            Sex = user.Sex;
            AvatarSource = user.AvatarSource;
            Login = user.Login;
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}
