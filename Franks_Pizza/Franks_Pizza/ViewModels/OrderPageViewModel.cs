using Franks_Pizza.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Franks_Pizza.ViewModels
{
    public class OrderPageViewModel : BaseViewModel
    {
        // UserBase connection
        private IUserBase _userBase;
        // Navigation
        private IPageService _pageService;

        private int _totalPrice = 0;

        private UserViewModel _user;

        public ObservableCollection<PositionViewModel> PositionOrderViewModel { get; private set; } =
            new ObservableCollection<PositionViewModel>();

        public ICommand AddPressed { get; private set; }
        public ICommand SettingsCommand { get; private set; }
        public ICommand DeletePositionCommand { get; private set; }


        public event EventHandler Exit;

        public int TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                AddValue(ref _totalPrice, value);
            }
        }

        public OrderPageViewModel(IUserBase userBase, IPageService pageService, UserViewModel user)
        {
            _userBase = userBase;
            _pageService = pageService;
            _user = user;

            AddPressed = new Command(async () => await AddPosition());
            SettingsCommand = new Command(async () => await Settings());
            DeletePositionCommand = new Command<PositionViewModel>(async c => await Delete(c));
        }

        private async Task AddPosition()
        {
            var viewModel = new AddNewPositionPageViewModel(_userBase, _pageService);

            viewModel.PosAdded += (source, newPosition) =>
            {
                PositionOrderViewModel.Add(new PositionViewModel(newPosition));
                TotalPrice = PositionOrderViewModel[PositionOrderViewModel.Count - 1].Price;
            };

            await _pageService.PushAsync(new AddNewPositionPage(viewModel));
        }

        private async Task Settings()
        {
            var viewModel = new SettingsPageViewModel(_userBase, _pageService, _user);
            viewModel.UserUpdated += (source, user) =>
            {
                _user = new UserViewModel(user);
            };

            viewModel.Exit += (source, eargs) =>
            {
                _pageService.PopAsync();
                Exit?.Invoke(this, eargs);
            };

            await _pageService.PushAsync(new SettingsPage(viewModel));
        }

        private async Task Delete(PositionViewModel _position)
        {
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {_position.Name}?", "Yes", "No"))
            {
                TotalPrice = -_position.Price;
                PositionOrderViewModel.Remove(_position);
            }
        }

    }
}
