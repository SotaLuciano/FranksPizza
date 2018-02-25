using Franks_Pizza.Models;
using Plugin.Geolocator;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Franks_Pizza.ViewModels
{
    public class SettingsPageViewModel
    {
        // UserBase connection
        private IUserBase _userBase;
        // Navigation
        private IPageService _pageService;

        private Geocoder geoCoder;

        public UserViewModel User { get; private set; }

        public ICommand SaveCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand ChangeAvatarCommand { get; private set; }
        public ICommand GetAddressCommand { get; private set; }

        public event EventHandler<User> UserUpdated;
        public event EventHandler Exit;


        public SettingsPageViewModel(IUserBase userBase, IPageService pageService, UserViewModel user)
        {
            _userBase = userBase;
            _pageService = pageService;
            geoCoder = new Geocoder();

            SaveCommand = new Command(async () => await Save());
            ExitCommand = new Command(async () => await ExitPressed());
            DeleteCommand = new Command(async () => await DeletePressed());
            ChangeAvatarCommand = new Command(async () => await ChangeAvatar());
            GetAddressCommand = new Command(async () => await GetAddress());

            User = user;
        }

        private async Task Save()
        {
            if (String.IsNullOrWhiteSpace(User.FirstName) || String.IsNullOrWhiteSpace(User.LastName) || String.IsNullOrWhiteSpace(User.Address) || String.IsNullOrWhiteSpace(User.Email) || String.IsNullOrWhiteSpace(User.Password) || String.IsNullOrWhiteSpace(User.Phone))
            {
                await _pageService.DisplayAlert("Error", "Please input all information", "OK");
                return;
            }

            var _user = new User
            {
                Id = User.Id,
                FirstName = User.FirstName,
                LastName = User.LastName,
                Phone = User.Phone,
                Email = User.Email,
                Address = User.Address,
                Password = User.Password,
                Sex = User.Sex,
                AvatarSource = User.AvatarSource,
                Login = User.Login
            };

            await _userBase.UpdateUser(_user);
            UserUpdated?.Invoke(this, _user);

            await _pageService.DisplayAlert("Update", "User information update successful!", "OK");
            await _pageService.PopAsync();

        }

        private async Task ExitPressed()
        {
            if (String.IsNullOrWhiteSpace(User.FirstName) || String.IsNullOrWhiteSpace(User.LastName) || String.IsNullOrWhiteSpace(User.Address) || String.IsNullOrWhiteSpace(User.Email) || String.IsNullOrWhiteSpace(User.Password) || String.IsNullOrWhiteSpace(User.Phone))
            {
                await _pageService.DisplayAlert("Error", "Please input all information", "OK");
                return;
            }
            await _pageService.PopAsync();
            Exit?.Invoke(this, null);
        }

        private async Task DeletePressed()
        {
            if (await _pageService.DisplayAlert("Delete acount!", "Are you sure?", "Yes", "Cancel"))
            {
                var _user = new User
                {
                    Id = User.Id,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    Phone = User.Phone,
                    Email = User.Email,
                    Address = User.Address,
                    Password = User.Password,
                    Sex = User.Sex,
                    AvatarSource = User.AvatarSource,
                    Login = User.Login
                };


                await _userBase.DeleteUser(_user);

                await _pageService.PopAsync();
                Exit?.Invoke(this, null);
            }
        }

        private async Task ChangeAvatar()
        {
            var choose = await _pageService.DisplayActionSheet("Change Avatar", "Cancel", null, "Camera", "Gallery");

            if (choose == "Camera")
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await _pageService.DisplayAlert("No camera", "No camera available", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Name = "test.jpg"
                });

                if (file == null)
                    return;
                var tmp = file.ToString();

                User.AvatarSource = file.Path;

                var _user = new User
                {
                    Id = User.Id,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    Phone = User.Phone,
                    Email = User.Email,
                    Address = User.Address,
                    Password = User.Password,
                    Sex = User.Sex,
                    AvatarSource = User.AvatarSource,
                    Login = User.Login
                };

                await _userBase.UpdateUser(_user);
                UserUpdated?.Invoke(this, _user);
            }
            else if (choose == "Gallery")
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync();
                if (file == null)
                    return;

                User.AvatarSource = file.Path;

                var _user = new User
                {
                    Id = User.Id,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    Phone = User.Phone,
                    Email = User.Email,
                    Address = User.Address,
                    Password = User.Password,
                    Sex = User.Sex,
                    AvatarSource = User.AvatarSource,
                    Login = User.Login
                };

                await _userBase.UpdateUser(_user);
                UserUpdated?.Invoke(this, _user);
            }

        }


        private async Task GetAddress()
        {
            if (await _pageService.DisplayAlert("Geolocation!", "You want change your address?", "Yes", "No"))
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(timeout: TimeSpan.FromMilliseconds(1000));

                var address = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

                string tmp = "";


                // WARNING RETURNS EMPTY STR
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(address);
                foreach (var addr in possibleAddresses)
                    tmp += addr + "\n";

                tmp = "Some address";

                User.Address = tmp;

                var _user = new User
                {
                    Id = User.Id,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    Phone = User.Phone,
                    Email = User.Email,
                    Address = User.Address,
                    Password = User.Password,
                    Sex = User.Sex,
                    AvatarSource = User.AvatarSource,
                    Login = User.Login
                };

                await _userBase.UpdateUser(_user);
                UserUpdated?.Invoke(this, _user);
            }
        }
    }
}