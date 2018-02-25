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
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage (SettingsPageViewModel viewModel)
		{
            BindingContext = viewModel;
			InitializeComponent ();
		}
	}
}