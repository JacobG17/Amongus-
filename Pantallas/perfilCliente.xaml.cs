using System.Diagnostics;

namespace InstantFood.Pantallas;

public partial class perfilCliente : ContentPage
{
	public perfilCliente()
	{
		InitializeComponent();

		btnLogout.TextColor = Color.FromRgb(220,31,52);
	}

    async void btnLogout_Clicked(System.Object sender, System.EventArgs e)
    {
        bool answer = await DisplayAlert("Advertencia", "¿Desea salir de su cuenta?", "Si", "No");
        Debug.WriteLine("Answer: " + answer);
        await Navigation.PopAsync();
    }
}
