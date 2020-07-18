using AxesoNegocio.Controls;
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
    public partial class RegistroRucPage : ContentPage
    {
        public RegistroRucPage()
        {
            InitializeComponent();
        }
        async void BackButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void NumericEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                bool isValid = e.NewTextValue.ToCharArray().All(char.IsDigit);

                ((StandardEntry)sender).Text = isValid ? e.NewTextValue : e.OldTextValue;
            }
        }

        private void RucEntry_Unfocused(object sender, FocusEventArgs e)
        {

        }
    }
}