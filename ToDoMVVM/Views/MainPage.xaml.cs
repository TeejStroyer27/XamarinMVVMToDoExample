using Xamarin.Forms;
using ToDoMVVM.ViewModels;

namespace ToDoMVVM.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            ViewModel = new MainPageViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadToDosCommand.Execute(null);
            base.OnAppearing();
        }

        public MainPageViewModel ViewModel
        {
            get { return BindingContext as MainPageViewModel; }
            set { BindingContext = value; }
        }

    }
}
