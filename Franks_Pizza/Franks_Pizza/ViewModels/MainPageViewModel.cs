using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Franks_Pizza.ViewModels
{
    public class MainPageViewModel
    {
        // UserBase connection
        private IUserBase _userBase;
        // Navigation
        private IPageService _pageService;

        //Buttons on MainPage
        public ICommand LoginButton{ get; private set;}
        public ICommand RegisterButton { get; private set; }

        public MainPageViewModel(IUserBase userBase, IPageService pageService)
        {
            _userBase = userBase;
            _pageService = pageService;

            LoginButton = new Command(async () => await Login());
            RegisterButton = new Command(async () => await Register());
        }

        private async Task Login()
        {
            var viewModel = new LoginPageViewModel(_userBase, _pageService);
            // Open Login Page
            await _pageService.PushAsync(new LoginPage(viewModel));
        }

        private async Task Register()
        {
            var viewModel = new RegisterPageViewModel(_userBase, _pageService);
            // Open Register Page
            await _pageService.PushAsync(new RegisterPage(viewModel));
        }
    }
}
