using Axeso_BE;
using AxesoNegocio.Helpers;
using AxesoNegocio.Model;
using AxesoNegocio.Services;
using AxesoNegocio.Views;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AxesoNegocio.ViewModels
{
    [Preserve]
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        DataAccess data = new DataAccess();
        Usuarios entidad = new Usuarios();
        public string email;
        public string password;
        public bool isRunning;
        public bool isEnabled;
        public bool IsRemembered;
        public event PropertyChangedEventHandler PropertyChanged;
        string claveEncrip = "";
        ApiService apiService;

        public ICommand LoginMailB { get; }
        public ICommand RegisterMail { get; }
        public ICommand RecoverPasswordMail { get; }

        public string Email
        {
            get
            {
                if (string.IsNullOrEmpty(email))
                    return "";
                else
                    return email;
            }
            set
            {
                if (email != value)
                {
                    email = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Email)));
                }
            }
        }
        public string Password
        {
            get
            {
                if (string.IsNullOrEmpty(password))
                    return "";
                else
                    return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Password)));
                }
            }
        }
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsEnabled)));
                }
            }
        }
        public LoginPageViewModel()
        {
            apiService = new ApiService();
            IsRemembered = true;
            IsEnabled = true;
            //IsRunning = false;
            Email = "";
            Password = "";

            LoginMailB = new Command(LoginMailConsumer);
            RegisterMail = new Command(RegisterMailConsumer);
            RecoverPasswordMail = new Command(RecoverPasswordMailConsumer);
        }

        private async void RecoverPasswordMailConsumer(object obj)
        {
           await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new RecoverPasswordPage());
        }

        private async void LoginMailConsumer(object obj)
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                Settings.ErrorText = "Ingrese correo electrónico";
                await PopupNavigation.Instance.PushAsync(new ErrorPopUpPage());
                return;
            }
            if (!(this.Email).Contains("@"))
            {
                Settings.ErrorText = "Ingrese correo electrónico válido";
                await PopupNavigation.Instance.PushAsync(new ErrorPopUpPage());
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                Settings.ErrorText = "Ingrese contraseña";
                await PopupNavigation.Instance.PushAsync(new ErrorPopUpPage());
                return;
            }
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                Settings.ErrorText = "No existe conexión a la red";
                await PopupNavigation.Instance.PushAsync(new ErrorPopUpPage());
                return;
            }
            //this.IsRunning = true;
            var loadingPage = new LoadingPopupPage();
            await PopupNavigation.Instance.PushAsync(loadingPage);
            this.IsEnabled = false;
            var tokenmodel = data.EncriptaClave(this.Password);
            if (tokenmodel.TokenEncrypted.Equals(""))
            {
            }
            else
            {
                claveEncrip = tokenmodel.TokenEncrypted.ToString();
            }
            Usuarios usuariof = new Usuarios() { Usuario = this.Email, Token = claveEncrip };
            var entidad = await data.ValidaLogueo(usuariof);

            if (entidad == null)
            {
                await PopupNavigation.Instance.RemovePageAsync(loadingPage);
                this.IsEnabled = true;
                Settings.ErrorText = "Datos de ingreso inválidos!";
                await PopupNavigation.Instance.PushAsync(new ErrorPopUpPage());
                return;
            }

            if (!entidad.TipoUsuarioID.Equals("2"))
            {
                await PopupNavigation.Instance.RemovePageAsync(loadingPage);
                this.IsEnabled = true;
                Settings.ErrorText = "Tipo de usuario incorrecto";
                await PopupNavigation.Instance.PushAsync(new ErrorPopUpPage());
                return;
            }

            var mainViewModel = MenuTabbedPageViewModel.GetInstance();
            mainViewModel.Usuario = entidad;
            TokenResponse newtoken = new TokenResponse()
            {
                AccessToken = this.Password,
                UserName = entidad.Descripcion,
                Password = this.Password,
                IsRemembered = this.IsRemembered,
                Expires = DateTime.Now.AddDays(1)
            };

            Settings.IsRemember = this.IsRemembered;
            Settings.UserEmail = this.Email;
            Settings.UserID = entidad.UsuarioID;
            Settings.UserPassword = this.Password;
            Settings.Token = JsonConvert.SerializeObject(newtoken);

            //this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;
            await PopupNavigation.Instance.RemovePageAsync(loadingPage);
            App.Current.MainPage = new MenuTabbedPage();
        }

        private async void RegisterMailConsumer(object obj)
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new RegistroRucPage());
        }

    }
}
