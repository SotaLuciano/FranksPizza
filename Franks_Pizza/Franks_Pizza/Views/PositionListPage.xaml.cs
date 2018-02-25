using Franks_Pizza.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Franks_Pizza
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PositionListPage : ContentPage
	{
		public PositionListPage (PositionListPageViewModel _viewModel)
		{
            viewModel = _viewModel;
			InitializeComponent ();
		}

        void OnPositionSelected(object sender, SelectedItemChangedEventArgs e)
        {
            viewModel.SelectPositionCommand.Execute(e.SelectedItem);
        }


        public PositionListPageViewModel viewModel
        {
            get { return BindingContext as PositionListPageViewModel; }
            set { BindingContext = value; }

        }
    }
}