using Xamarin.Forms;
using ToDoMVVM.ViewModels;

namespace ToDoMVVM.Views
{
    public partial class AddToDoPage : ContentPage
    {
        public AddToDoPage()
        {
            InitializeComponent();
            BindingContext = new AddToDoViewModel();
        }
    }
}
