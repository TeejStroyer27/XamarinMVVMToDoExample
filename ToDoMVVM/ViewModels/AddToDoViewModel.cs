using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoMVVM.Models;
using ToDoMVVM.MVVM;
using Xamarin.Forms;

namespace ToDoMVVM.ViewModels
{
    public class AddToDoViewModel:ViewModelBase
    {
        public ICommand MainPageCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public AddToDoViewModel()
        {
            SaveCommand = new Command(async () => await Save());
        }

        public async Task Save() 
        {
            //Save ToDo
            await App.Database.SaveItemAsync(new ToDo() { Title = this.Title, Description = this.Description });
            //Close Page
            await _pageService.PopAsync();
        }
    }
}
