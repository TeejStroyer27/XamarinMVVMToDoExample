using Xamarin.Forms;
using ToDoMVVM.ViewModels;
using ToDoMVVM.Models;

namespace ToDoMVVM.Views
{
    public partial class UpdateToDoPage : ContentPage
    {
        public UpdateToDoPage()
        {
            ViewModel = new UpdateToDoViewModel();
            InitializeComponent();
        }

        public UpdateToDoPage(ToDo item)
        {
            ViewModel = new UpdateToDoViewModel(item);
            InitializeComponent();
        }

        public UpdateToDoViewModel ViewModel
        {
            get { return BindingContext as UpdateToDoViewModel; }
            set { BindingContext = value; }
        }
    }
}
