using implementarget.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace implementarget
{
    public partial class MainPage : ContentPage
    {


        public  MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = new ViewModelClass();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InsertarDato());

        }
    }
}
