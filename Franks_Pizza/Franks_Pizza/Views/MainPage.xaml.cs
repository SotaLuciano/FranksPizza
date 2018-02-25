using Franks_Pizza.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Franks_Pizza
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            var userBase = new SQLiteUserBase(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new MainPageViewModel(userBase, pageService);
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
		}

        public MainPageViewModel ViewModel
        {
            get { return BindingContext as MainPageViewModel; }
            set { BindingContext = value; }
        }
    }
}
