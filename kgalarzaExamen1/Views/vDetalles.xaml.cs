namespace kgalarzaExamen1.Views;

public partial class vDetalles : ContentPage
{
	public vDetalles(string usuario, string nombre, string apellido, string va, DateTime fecha, string ciudad, double montoInicial, double cuotaMensual)
    {
        InitializeComponent();

        txtUserResumen.Text = usuario;

        lblNombre.Text = nombre;
        lblApellido.Text = apellido;
        lblVA.Text = va;
        lblFecha.Text = fecha.ToString("dd/MM/yyyy");
        lblCiudad.Text = ciudad;
        lblMontoInicial.Text = $"${montoInicial:F2}";
        lblCuotaMensual.Text = $"${cuotaMensual:F2}";

        double pagoTotal = (cuotaMensual * 3) + montoInicial;
        lblPagoTotal.Text = $"${pagoTotal:F2}";
    }

    private async void OnCerrarSesionClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginPage");
    }

}