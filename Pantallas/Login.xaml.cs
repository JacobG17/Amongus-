namespace InstantFood.Pantallas;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
    }

    public Boolean bExiste = false;
    
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
            /*
            opBD opPlatillo = new opBD();

            string rutaimagen = "/Users/jacobglz/Desktop/cocaLata.png";

            platillo newPlatillo = new platillo()
            {
                idPlatillo = 0,
                idrestaurante = 1,
                nombrePlatillo = "Coca-Cola",
                Descripcion = "Refresco Coca-Cola de 400ml en lata.",
                Precio = 15,
                Categoria = "Bebida",
                imagen = File.ReadAllBytes(rutaimagen)
            };
            opPlatillo.InsertPLatillo(newPlatillo);

            string rutaimagen1 = "/Users/jacobglz/Desktop/pepsiLata.png";

            platillo newPlatillo1 = new platillo()
            {
                idPlatillo = 0,
                idrestaurante = 1,
                nombrePlatillo = "Pepsi",
                Descripcion = "Refresco Pepsi de 400ml en lata.",
                Precio = 15,
                Categoria = "Bebida",
                imagen = File.ReadAllBytes(rutaimagen1)
            };

            opPlatillo.InsertPLatillo(newPlatillo1);

            string rutaimagen2 = "/Users/jacobglz/Desktop/spriteLata.png";

            platillo newPlatillo2 = new platillo()
            {
                idPlatillo = 1,
                idrestaurante = 1,
                nombrePlatillo = "Sprite",
                Descripcion = "Refresco sabor Sprite de 400ml en lata.",
                Precio = 15,
                Categoria = "Bebida",
                imagen = File.ReadAllBytes(rutaimagen2)
            };   

            Boolean bAllOUsuario = (!bExiste); opPlatillo.InsertPLatillo(newPlatillo2);

            if (opPlatillo.bAllOk == true)
            {

                await DisplayAlert("CORRECTO", "Platillo agregado con exito", "Aceptar");
                await Navigation.PushAsync(new Cliente());
                tiUsuario.Text = null;
                tiPassword.Text = null;
            }
            else
            {
                await DisplayAlert("ERROR", opPlatillo.sLastError, "Aceptar");
            }*/
            //await DisplayAlert("CORRECTO", "Bienvenido", "Aceptar");
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
