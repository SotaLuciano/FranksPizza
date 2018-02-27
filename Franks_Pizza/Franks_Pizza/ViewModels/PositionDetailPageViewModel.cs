using Franks_Pizza.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Franks_Pizza.ViewModels
{
    public class PositionDetailPageViewModel
    {
        // UserBase connection
        private IUserBase _userBase;
        // Navigation
        private IPageService _pageService;

        public Position my_position { get;private set; }

        public event EventHandler<Position> PositionAdded;

        public ICommand AddCommand { get; private set; }

        public PositionDetailPageViewModel(IUserBase userBase, IPageService pageService, PositionViewModel viewModel)
        {
            _userBase = userBase;
            _pageService = pageService;

            my_position = new Position
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                OnePrice = viewModel.OnePrice,
                Count = viewModel.Count,
                Url = viewModel.Url,
                Composition = viewModel.Composition
            };

            AddCommand = new Command(async () => await AddPosition());
        }

        private async Task AddPosition()
        {
            await _pageService.DisplayAlert("ORDER", my_position.Name + " added to your order!", "OK");
            // Invoke all events
            PositionAdded?.Invoke(this, my_position);
            await _pageService.PopAsync();
        }
    }
}
