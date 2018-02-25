using Franks_Pizza.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Franks_Pizza.ViewModels
{
    public class LoginPageViewModel :BaseViewModel
    {
        // UserBase connection
        private IUserBase _userBase;
        // Navigation
        private IPageService _pageService;

        private string _login;
        private string _pass;

        public string Login
        {
            get { return _login; }
            set { SetValue(ref _login, value); }
        }

        public string Pass
        {
            get { return _pass; }
            set { SetValue(ref _pass, value); }
        }

        public ICommand SignIn { get; private set; }

        public LoginPageViewModel(IUserBase userBase, IPageService pageService)
        {
            _userBase = userBase;
            _pageService = pageService;
            SignIn = new Command(async ()=> await Save());
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Pass))
            {
                await _pageService.DisplayAlert("Error", "Wrong login or password!", "OK");
                return;
            }

            var check = await _userBase.CheckLogin(Login, Pass);

            if (check != null)
            {
                var viewModel = new OrderPageViewModel(_userBase, _pageService, check);

                viewModel.Exit += (source, eargs) =>
                {
                    Login = "";
                    Pass = "";
                };

                await _pageService.PushAsync(new OrderPage(viewModel));
            }
            else
            {
                await _pageService.DisplayAlert("Error", "Wrong login or password!", "OK");
                return;
            }
        }

    }
}
