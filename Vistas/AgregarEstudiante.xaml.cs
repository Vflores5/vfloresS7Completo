using System.Net;

namespace gguachaminS7.Vistas;

public partial class AgregarEstudiante : ContentPage
{
	public AgregarEstudiante()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("codigo", txtCodigo.Text);
			parametros.Add("nombre", txtNombre.Text);
			parametros.Add("apellido", txtApellido.Text);
			parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues("http://localhost/appmovil/post.php", "POST", parametros);
			Navigation.PushAsync(new MainPage());
		}
		catch (Exception ex)
		{
			DisplayAlert("Alerta", ex.Message, "Cerrar");
		}

    }
}