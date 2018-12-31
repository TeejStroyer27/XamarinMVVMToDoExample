using System.Collections.ObjectModel;
using ToDoMVVM.Models;
using ToDoMVVM.MVVM;
using System.Windows.Input;
using Xamarin.Forms;
using ToDoMVVM.Views;
using System.Threading.Tasks;

namespace ToDoMVVM.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<ToDo> ToDoList { get; set; } = new ObservableCollection<ToDo>();

        public ICommand AddToDoCommand { get; private set; }
        public ICommand DeleteToDoCommand { get; private set; }
        public ICommand LoadToDosCommand { get; private set; }

        public MainPageViewModel()
        {
            AddToDoCommand = new Command(async () => await _pageService.PushAsync(new AddToDoPage()));
            DeleteToDoCommand = new Command<ToDo>(async t => await DeleteContact(t));
            LoadToDosCommand = new Command(async () => await LoadToDos());
        }

        private async Task LoadToDos()
        {
            ToDoList = new ObservableCollection<ToDo>(await App.Database.GetItemsAsync());
            //Trigger Change For ToDo List
            OnPropertyChanged("ToDoList");
        }

        private async Task DeleteContact(ToDo todo)
        {
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {todo.Title}?", "Yes", "No"))
            {
                //remove from list first, so that you dont have to await db call
                //Since ToDoList is an Observable Collection, we dont have to trigger a property change
                ToDoList.Remove(todo);

                //Get the todoitem we just deleted and delete it from the sqlite db
                var todo_DB = await App.Database.GetItemAsync(todo.ID);
                await App.Database.DeleteItemAsync(todo_DB); 
            }
        }




    }
}
