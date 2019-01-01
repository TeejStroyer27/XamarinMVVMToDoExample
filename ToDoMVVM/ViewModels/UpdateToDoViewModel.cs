using ToDoMVVM.MVVM;
using ToDoMVVM.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToDoMVVM.ViewModels
{
    public class UpdateToDoViewModel:ViewModelBase
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICommand SaveCommand { get; private set; }

        public UpdateToDoViewModel()
        {
            SaveCommand = new Command(async() => await Save());
        }

        public UpdateToDoViewModel(ToDo item)
        {
            ID = item.ID;
            Title = item.Title;
            Description = item.Description;
            SaveCommand = new Command(async () => await Save());
        }

        public async Task Save()
        {
            await App.Database.UpdateItemAsync(new ToDo() {ID=this.ID, Title = this.Title, Description = this.Description });
            //Close Page
            await _pageService.PopAsync();
        }
    }
}
