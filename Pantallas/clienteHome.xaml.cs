namespace InstantFood.Pantallas;

public partial class clienteHome : ContentPage
{
	public clienteHome()
	{
		InitializeComponent();
	}

    private async void btnCarrito_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new carritoCliente());
    }
}
