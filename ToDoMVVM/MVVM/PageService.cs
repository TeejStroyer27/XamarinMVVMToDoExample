using System.Threading.Tasks;
using ToDoMVVM.MVVM.Interfaces;
using Xamarin.Forms;

namespace ToDoMVVM.MVVM
{
    public class PageService:IPageInterface
    {
        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task<Page> PopAsync()
        {
            return await MainPage.Navigation.PopAsync();
        }

        public async Task PushAsync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }

        public async Task<Page> PopModalAsync()
        {
            return await MainPage.Navigation.PopModalAsync();
        }

        public async Task PushModalAsync(Page page)
        {
            await MainPage.Navigation.PushModalAsync(page);
        }

        public async Task PopToRootAsync()
        {
            await MainPage.Navigation.PopToRootAsync();
        }

        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }

    }
}
