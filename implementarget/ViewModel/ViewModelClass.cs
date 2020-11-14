using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace implementarget.ViewModel
{
    public class ViewModelClass
    {

        protected string Url = "http://192.168.100.29/moviles/post.php";
        protected HttpClient httpClient = new HttpClient();
        public ObservableCollection<Modelo> consulta { get; set; }
        public ICommand Editar { get; set; }
        public ICommand Borrar { get; set; }
        public ICommand Nuevo { get; set; }
        public ViewModelClass()
        {
            consulta = new ObservableCollection<Modelo>();
            cargarDatos();
            Borrar = new Command(BorrarCommand);
            Nuevo = new Command(NuevoCommand);
            Editar = new Command(EditarCommand);
           
        }

        private async void cargarDatos()
        {
            try
            {
                string consultaSerializada = await httpClient.GetStringAsync(Url);
                var consultaDeserializada = JsonConvert.DeserializeObject<List<Modelo>>(consultaSerializada);
                consulta.Clear();
                foreach (var item in consultaDeserializada)
                {
                    consulta.Add(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void BorrarCommand(Object o)
        {
            try
            {
                Modelo model = (Modelo)o;
                var consultaSerializada = await httpClient.DeleteAsync(Url+"?codigo="+model.codigo);
                await Application.Current.MainPage.DisplayAlert("Correcto", "Usuario Eliminado", "ok");
                this.cargarDatos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void NuevoCommand(Object o)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new InsertarDato()) ;
        }

        private async void EditarCommand(Object o)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new InsertarDato((Modelo)o));
        }

    }
}
