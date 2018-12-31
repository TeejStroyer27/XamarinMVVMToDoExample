using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoMVVM.MVVM
{
    public class ViewModelBase:INotifyPropertyChanged
    {
        protected PageService _pageService = new PageService();
        public event PropertyChangedEventHandler PropertyChanged;
        public string PageTitle { get; set; }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value)) return;
            backingField = value;
            OnPropertyChanged(propertyName);
        }

    }
}
