using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoMVVM.Views;
using System.IO;
using System;
using ToDoMVVM.Repository;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ToDoMVVM
{
    public partial class App : Application
    {
        static ToDoDatabase _database;
        public static ToDoDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new ToDoDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
