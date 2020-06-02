using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventosInformatica.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string password;
        private bool isrunning;
        private bool isenabled;
        private DelegateCommand logincommand;
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Login";
            IsEnabled = true;
        }
        public string Email { get; set; }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public bool IsRunning
        {
            get => isrunning;
            set => SetProperty(ref isrunning, value);
        }

        public bool IsEnabled
        {
            get => isenabled;
            set => SetProperty(ref isenabled, value);
        }

        public DelegateCommand LoginCommand => logincommand ?? (logincommand = new DelegateCommand(Login));

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingrese un Correo", "Accept");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingrese un Password", "Accept");
                return;
            }

            await App.Current.MainPage.DisplayAlert("Ok", "Ya entre", "Accept");
        }
    }
}
