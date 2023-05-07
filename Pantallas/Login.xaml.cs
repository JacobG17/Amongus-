namespace InstantFood.Pantallas;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
    }

    private async void btRegistrarse_Clicked(System.Object sender, System.EventArgs e)
    {
        var registro = new Registro();
        await Navigation.PushAsync(registro);
    }

    private async void btnIngresar_Clicked(System.Object sender, System.EventArgs e)
    {
       if (tiUsuario.Text == null && tiPassword.Text == null)
       {
            Ususario.Stroke = Color.FromArgb("#B3261E");
            Ususario.HelperText = "el apellido es requerido*";
            Ususario.HelperLabelStyle.TextColor = Color.FromArgb("#B3261E");
            Password.Stroke = Color.FromArgb("#B3261E");
            Password.HelperText = "el apellido es requerido*";
            Password.HelperLabelStyle.TextColor = Color.FromArgb("#B3261E");
            await DisplayAlert("Error", "Ingrese correctamente los datos del registro", "Aceptar");
        }
        else if (tiUsuario.Text == null)
        {
            Ususario.Stroke = Color.FromArgb("#B3261E");
            Ususario.HelperText = "el apellido es requerido*";
            Ususario.HelperLabelStyle.TextColor = Color.FromArgb("#B3261E");
            await DisplayAlert("Error", "Ingrese correctamente los datos del registro", "Aceptar");
        }
        else if (tiPassword.Text == null)
        {
            Password.Stroke = Color.FromArgb("#B3261E");
            Password.HelperText = "el apellido es requerido*";
            Password.HelperLabelStyle.TextColor = Color.FromArgb("#B3261E");
            await DisplayAlert("Error", "Ingrese correctamente los datos del registro", "Aceptar");
        }
        else
        {
            await Navigation.PushAsync(new Cliente());
            tiUsuario.Text = null;
            tiPassword.Text = null;
        }
    }

    void tiPassword_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        Password.Stroke = Color.FromArgb("#6750A4");
        Password.HelperText = "";
        Password.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    void tiUsuario_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        Ususario.Stroke = Color.FromArgb("#6750A4");
        Ususario.HelperText = "";
        Ususario.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }
}
