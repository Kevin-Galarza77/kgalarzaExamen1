
namespace kgalarzaExamen1.Views;

public partial class vLogin : ContentPage
{
    Dictionary<string, string> usuariosValidos = new Dictionary<string, string>
    {
        { "estudiante2025", "moviles" },
        { "uisrael", "2025" },
        { "sistemas", "2025_1" }
    };
    public vLogin()
	{
		InitializeComponent();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var usuario = txtUsuario.Text;
        var contrasena = txtContrasena.Text;

        if (usuario != null && usuariosValidos.TryGetValue(usuario, out var clave) && clave == contrasena)
        {
            await Shell.Current.Navigation.PushAsync(new Views.vRegister(usuario));
            txtContrasena.Text = "";
            txtUsuario.Text = "";
        }
        else
        {
            await DisplayAlert("Error", "Datos incorrectos", "OK");
        }
    }
    private async void OnAcercaDeClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new vMe());
    }

}