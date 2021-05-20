using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProjetoAppStartupOne.View;
using Xamarin.Forms;

namespace ProjetoAppStartupOne.ViewModel
{
    public abstract class BaseViewModel : IDisposable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }


        public async Task DisplayAlert(string title, string message, string cancel)
            => await Application.Current.MainPage.DisplayAlert(title, message, cancel);


        public async void DisplayAlert(string title, string message, string accept, string cancel)
            => await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);


        private bool isBusy = false;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        internal async Task PushAsync(Page page)
            => await App.Current.MainPage.Navigation.PushAsync(page);

        internal async Task GoBackAsync()
         => await App.Current.MainPage.Navigation.PopAsync();

        public abstract void Dispose();
    }
}
