using AxesoNegocio.Helpers;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AxesoNegocio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorPopUpPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        string error = "";
        public ErrorPopUpPage()
        {
            InitializeComponent();
            error = Settings.ErrorText;
            lErrore.Text = error;
        }
        async void AcceptError_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}