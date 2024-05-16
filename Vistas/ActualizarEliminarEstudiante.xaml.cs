using gguachaminS7.Modelos;
using System.Net;

namespace gguachaminS7.Vistas;

public partial class ActualizarEliminarEstudiante : ContentPage
{
	public ActualizarEliminarEstudiante(Estudiante estudiante)
	{
		InitializeComponent();
        txtCodigo.Text = estudiante.codigo.ToString();
        txtNombre.Text = estudiante.nombre;
        txtApellido.Text = estudiante.apellido;
        txtEdad.Text = estudiante.edad.ToString();
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            int codigo = Int32.Parse(txtCodigo.Text);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int edad = Int32.Parse(txtEdad.Text);
            cliente.UploadValues("http://localhost/appmovil/post.php?codigo=" + codigo + "&nombre=" + nombre + "&apellido=" + apellido
                + "&edad=" + edad, "PUT", parametros);
            DisplayAlert("Éxito", "Registro actualizado correctamente", "Cerrar");
            Navigation.PushAsync(new MainPage());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try

        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            int codigo = Int32.Parse(txtCodigo.Text);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int edad = Int32.Parse(txtEdad.Text);
            cliente.UploadValues("http://localhost/appmovil/post.php?codigo=" + codigo + "&nombre=" + nombre + "&apellido=" + apellido
                + "&edad=" + edad, "DELETE", parametros);
            DisplayAlert("Éxito", "Registro eliminado correctamente", "Cerrar");
            Navigation.PushAsync(new MainPage());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "Cerrar");
        }

    }
}