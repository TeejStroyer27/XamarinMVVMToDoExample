using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoMVVM.MVVM.Interfaces
{
    public interface IPageInterface
    {
        Task DisplayAlert(string title, string message, string ok);
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);

        Task<Page> PopAsync();
        Task PushAsync(Page page);

        Task<Page> PopModalAsync();
        Task PushModalAsync(Page page);

        Task PopToRootAsync();
    }
}
