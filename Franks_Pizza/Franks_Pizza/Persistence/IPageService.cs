using Plugin.Media.Abstractions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Franks_Pizza.ViewModels
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task<Page> PopAsync();

        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string ok);
        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);
        ImageSource GetImage(MediaFile source);
    }
}
