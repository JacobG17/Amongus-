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

    async void Pizza_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        await Navigation.PushAsync(new Pizza());
    }

    void Hamburguesa_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }

    void Sushi_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }

    void Tacos_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }

    void Burritos_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }

    void Torta_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }

    void PolloA_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }
}
