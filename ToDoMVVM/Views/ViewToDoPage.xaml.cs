using ToDoMVVM.Models;
using Xamarin.Forms;
using ToDoMVVM.ViewModels;

namespace ToDoMVVM.Views
{
    public partial class ViewToDoPage : ContentPage
    {
        public ViewToDoPage() 
        {
            BindingContext = new ViewToDoViewModel();
            InitializeComponent();
        }

        public ViewToDoPage(ToDo todo)
        {
            BindingContext = new ViewToDoViewModel(todo);
            InitializeComponent();
        }
    }
}
