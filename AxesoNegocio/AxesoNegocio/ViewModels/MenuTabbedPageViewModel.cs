using Axeso_BE;
using AxesoNegocio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AxesoNegocio.ViewModels
{
    public class MenuTabbedPageViewModel : INotifyPropertyChanged
    {

        private static MenuTabbedPageViewModel instance;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Usuarios Usuario
        {
            get;
            set;
        }
        public TokenResponse Token
        {
            get;
            set;

        }
        public MenuTabbedPageViewModel()
        {
            instance = this;
            this.Usuario = new Usuarios();
        }
        public static MenuTabbedPageViewModel GetInstance()
        {

            if (instance == null)
            {
                return new MenuTabbedPageViewModel();
            }

            return instance;
        }
    }
}
