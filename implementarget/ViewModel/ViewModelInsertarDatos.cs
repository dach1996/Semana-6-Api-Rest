using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace implementarget.ViewModel
{
    public class ViewModelInsertarDatos
    {
        public Modelo modelo { get; set; }
        public INavigation Navigation;
        public ViewModelInsertarDatos(Modelo modelo = null)
        {

            this.modelo = new Modelo();
            if (modelo != null)
                this.modelo = modelo;
            GuardarCommand = new Command(guardar);
        }

        public ICommand GuardarCommand { get; set; }

        private async void guardar()
        {
            if (this.modelo.codigo == 0)
            {
                try
                {
                    WebClient cliente = new WebClient();
                    var parametros = new NameValueCollection();
                    parametros.Add("codigo", modelo.codigo.ToString());
                    parametros.Add("nombre", modelo.nombre);
                    parametros.Add("apellido", modelo.apellido);
                    parametros.Add("edad", modelo.edad);
                    cliente.UploadValues("http://192.168.100.29/moviles/post.php", "POST", parametros);
                    await App.Current.MainPage.DisplayAlert("Alerta", "Dato ingresado Correctamente", "ok");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                string Url = "http://192.168.100.29/moviles/post.php";
                HttpClient httpClient = new HttpClient();
                var builder = new UriBuilder(Url);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["codigo"] = this.modelo.codigo.ToString();
                query["nombre"] = this.modelo.nombre;
                query["apellido"] = this.modelo.apellido;
                query["edad"] = this.modelo.edad;
                builder.Query = query.ToString();
                string url = builder.ToString();

                var consultaSerializada = await httpClient.PutAsync(url, null);
                await App.Current.MainPage.DisplayAlert("Alerta", "Dato ingresado Correctamente", "ok");
                await Application.Current.MainPage.Navigation.PopAsync();

            }


        }
    }
}
