using implementarget.ViewModel;
using System;
using System.Collections.Specialized;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace implementarget
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertarDato : ContentPage
    {
        public InsertarDato(Modelo modelo=null)    
        {
            InitializeComponent();
            BindingContext = new ViewModelInsertarDatos(modelo);
        }
    }
}