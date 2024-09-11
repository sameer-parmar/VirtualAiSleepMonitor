using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace VirtualAiSleepMonitor.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _password;
        private bool _isLoginButtonVisible = true;
        private bool _isMainPageButtonVisible = false;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public bool IsLoginButtonVisible
        {
            get => _isLoginButtonVisible;
            set
            {
                _isLoginButtonVisible = value;
                OnPropertyChanged(nameof(IsLoginButtonVisible));
            }
        }

        public bool IsMainPageButtonVisible
        {
            get => _isMainPageButtonVisible;
            set
            {
                _isMainPageButtonVisible = value;
                OnPropertyChanged(nameof(IsMainPageButtonVisible));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand MainPageCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
            MainPageCommand = new Command(OnMainPage);
        }

        private void OnLogin()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                // Handle validation error
                Application.Current.MainPage.DisplayAlert("Error", "Please enter both email and password.", "OK");
                return;
            }

            // Simulate successful login
            IsLoginButtonVisible = false;
            IsMainPageButtonVisible = true;
        }

        private async void OnMainPage()
        {
            // Navigate to the main page
            await Application.Current.MainPage.Navigation.PushAsync(new View.MainPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}