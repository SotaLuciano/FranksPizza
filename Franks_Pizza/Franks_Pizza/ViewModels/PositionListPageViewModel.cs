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
    public class PositionListPageViewModel : BaseViewModel
    {
        // UserBase connection
        private IUserBase _userBase;
        // Navigation
        private IPageService _pageService;
        // Position list
        public ObservableCollection<PositionViewModel> Positions { get; private set; }
            = new ObservableCollection<PositionViewModel>();
        private PositionViewModel _selectedPosition;

        // For 'deselect'
        public PositionViewModel SelectedPosition
        {
            get { return _selectedPosition; }
            set { SetValue(ref _selectedPosition, value); }
        }

        public ICommand SelectPositionCommand { get; private set; }

        public event EventHandler<Position> PosAdded;

        public PositionListPageViewModel(IUserBase userBase, IPageService pageService, List<Position> pos)
        {
            _userBase = userBase;
            _pageService = pageService;

            foreach(var _pos in pos)
                Positions.Add(new PositionViewModel(_pos));

            SelectPositionCommand = new Command<PositionViewModel>(async c => await SelectPosition(c));
        }

        private async Task SelectPosition(PositionViewModel position)
        {
            if (position == null)
                return;

            // Deselect
            SelectedPosition = null ;

            var viewModel = new PositionDetailPageViewModel(_userBase, _pageService, position);
            // If 'add to order' pressed
            viewModel.PositionAdded += (source, newPosition) =>
            {
                PosAdded?.Invoke(this, newPosition);
            };

            await _pageService.PushAsync(new PositionDetailPage(viewModel));
        }
    }
}
