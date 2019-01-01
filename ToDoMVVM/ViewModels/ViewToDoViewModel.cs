using ToDoMVVM.MVVM;
using ToDoMVVM.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToDoMVVM.ViewModels
{
    public class ViewToDoViewModel :ViewModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICommand ExitViewCommand { get; private set; }

        public ViewToDoViewModel() 
        {
            ExitViewCommand = new Command(async () => await _pageService.PopModalAsync());
        }
        public ViewToDoViewModel(ToDo item) 
        {
            Title = item.Title;
            Description = item.Description;
            ExitViewCommand = new Command( async()=> await _pageService.PopModalAsync());
        }
    }
}

