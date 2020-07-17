using AxesoNegocio.Helpers;
using AxesoNegocio.Model;
using AxesoNegocio.ViewModels;
using AxesoNegocio.Views;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AxesoNegocio
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjg4NzAwQDMxMzgyZTMyMmUzMEd1bnZ1dDBKcXJMUWJVdVdacm9mbmpLaHlCd3VzSzFROUVJKytQNVowbm89");

            InitializeComponent();

            if (Settings.IsRemember)
            {
                var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
                if (Settings.Expires > DateTime.Now)
                {

                    var mainViewModel = MenuTabbedPageViewModel.GetInstance();
                    mainViewModel.Token = token;
                    mainViewModel.Usuario.Usuario = Settings.UserEmail;
                    mainViewModel.Usuario.Token = Settings.UserPassword;
                    App.Current.MainPage = new MenuTabbedPage();
                }
                else
                {
                    //MainPage = new LoginPage();
                    MainPage = new NavigationPage(new LoginPage());
                    this.BindingContext = new LoginPageViewModel();
                }
            }
            else
            {
                //MainPage = new LoginPage();
                MainPage = new NavigationPage(new LoginPage());
                this.BindingContext = new LoginPageViewModel();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
