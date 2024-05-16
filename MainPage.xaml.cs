using gguachaminS7.Modelos;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace gguachaminS7
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://localhost/appmovil/post.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<Estudiante> estudiante;
        public MainPage()
        {
            InitializeComponent();
            Obtener();
        }

        public async void Obtener()
        {
            var content = await cliente.GetStringAsync(Url);
            List<Estudiante> mostrarEstudianet = JsonConvert.DeserializeObject<List<Estudiante>>(content);
            estudiante = new ObservableCollection<Estudiante>(mostrarEstudianet);
            listaEstudiantes.ItemsSource = mostrarEstudianet;
        }

        private void btnAgregarEstudiante_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Vistas.AgregarEstudiante());
        }

        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objestudiante = (Estudiante)e.SelectedItem;
            Navigation.PushAsync(new Vistas.ActualizarEliminarEstudiante(objestudiante));

        }
    }

}
