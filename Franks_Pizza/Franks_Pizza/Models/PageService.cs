using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Franks_Pizza.ViewModels
{
    public class PageService : IPageService
    {
        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }

        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task PushAsync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }

        public async Task<Page> PopAsync()
        {
            return await MainPage.Navigation.PopAsync();
        }

        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            return await MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
        }

        public ImageSource GetImage(MediaFile source)
        {
            return ImageSource.FromStream(() => source.GetStream());
        }
    }
}
