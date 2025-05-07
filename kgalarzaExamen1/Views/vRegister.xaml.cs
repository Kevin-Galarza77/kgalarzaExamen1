

namespace kgalarzaExamen1.Views;

public partial class vRegister : ContentPage
{
	public vRegister(string usuario)
	{
		InitializeComponent();
		txtUSer.Text = "Usuario Registra >> " + usuario;
    }

    private async void OnCalcularPagoClicked(object sender, EventArgs e)
    {

        string name = entryNombre.Text;
        string lastName = entryApellido.Text;
        string? typeAmp = pickerVA.SelectedItem?.ToString();
        string? city = pickerCiudad.SelectedItem?.ToString(); 

        string validate = ValidateForm(name, lastName, typeAmp, city);

        if (validate == "")
        {
            double costoUPS = 300;
            double inicial = costoUPS * 0.15;
            double restante = costoUPS - inicial;
            double cuota = (restante / 3) * 1.05;

            entryMontoInicial.Text = inicial.ToString("F2");
            entryCuotaMensual.Text = cuota.ToString("F2");
        }
        else
        {
            await DisplayAlert("Error", validate, "OK");
        }
    }

    private async void OnVerResumenClicked(object sender, EventArgs e)
    {
        string name = entryNombre.Text;
        string lastName = entryApellido.Text;
        string? typeAmp = pickerVA.SelectedItem?.ToString();
        string? city = pickerCiudad.SelectedItem?.ToString();

        string validate = ValidateForm(name, lastName, typeAmp, city);

        if (validate == "")
        {
            double costoUPS = 300;
            double inicial = costoUPS * 0.15;
            double restante = costoUPS - inicial;
            double cuota = (restante / 3) * 1.05;

            entryMontoInicial.Text = inicial.ToString("F2");
            entryCuotaMensual.Text = cuota.ToString("F2");

            await Navigation.PushAsync(new vDetalles(txtUSer.Text, name, lastName, typeAmp, datePickerFecha.Date, city, inicial, cuota));
        }
        else
        {
            await DisplayAlert("Error", validate, "OK");
        }
    }


    private string ValidateForm(string name, string lastName, string? typeAmp, string? city)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return "Por favor ingresa el nombre.";
        }

        if (!name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
        {
            return "El nombre solo debe contener letras.";
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return "Por favor ingresa el apellido.";
        }

        if (!lastName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
        {
            return "El apellido solo deben contener letras.";
        }

        if (string.IsNullOrWhiteSpace(typeAmp))
        {
            return "Por favor selecciona el Voltiamperio";
        }
 
        if (string.IsNullOrWhiteSpace(city))
        {
            return "Por favor seleccione la ciudad.";
        }

        return "";
    }

}