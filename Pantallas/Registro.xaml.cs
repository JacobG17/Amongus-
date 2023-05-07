namespace InstantFood.Pantallas;

public partial class Registro : ContentPage
{
    public Registro()
    {
        InitializeComponent();
        datosCliente(false);
        datosRestaurante(false);
    }

    void datosCliente(bool mostrar)
    {
        DtCliente.IsVisible = mostrar;
        idCliente.IsVisible = mostrar;
        nombreCliente.IsVisible = mostrar;
        apellidoCliente.IsVisible = mostrar;
        telefonoCliente.IsVisible = mostrar;
        btnRegistroCliente.IsVisible = mostrar;
    }

    void datosRestaurante(bool mostrar)
    {
        DtRestaurante.IsVisible = mostrar;
        idRestaurante.IsVisible = mostrar;
        nombreRestaurante.IsVisible = mostrar;
        telefonorestaurante.IsVisible = mostrar;
        direccionRestaurante.IsVisible = mostrar;
        btnRegistroRestaurante.IsVisible = mostrar;
    }

    void cbCuenta_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        var selectedElement = cbCuenta.SelectedItem as string;

        if (selectedElement == "Cliente")
        {
            datosRestaurante(false);
            datosCliente(true);
        }
        else if(selectedElement == "Restaurante")
        {
            datosCliente(false);
            datosRestaurante(true);
        }
        else
        {
            datosCliente(false);
            datosRestaurante(false);
        }
    }

    private async void btnRegistroCliente_Clicked(System.Object sender, System.EventArgs e)
    {
        if (tbNombre.Text == null)
        {
            nombreCliente.Stroke = Color.FromArgb("#B3261E");
            nombreCliente.HelperText = "el nombre es requerido*";
            nombreCliente.HelperLabelStyle.TextColor = Color.FromArgb("#B3261E");
            await DisplayAlert("Error", "Ingrese correctamente los datos del registro", "Aceptar");
        }
        else if (tbApellido.Text == null)
        {
            apellidoCliente.Stroke = Color.FromArgb("#B3261E");
            apellidoCliente.HelperText = "el apellido es requerido*";
            apellidoCliente.HelperLabelStyle.TextColor = Color.FromArgb("#B3261E");
            await DisplayAlert("Error", "Ingrese correctamente los datos del registro", "Aceptar");
        }
        else if (tbTelefono.Text == null)
        {
            telefonoCliente.Stroke = Color.FromArgb("#B3261E");
            telefonoCliente.HelperText = "el telefono es requerido*";
            telefonoCliente.HelperLabelStyle.TextColor = Color.FromArgb("#B3261E");
            await DisplayAlert("Error", "Ingrese correctamente los datos del registro", "Aceptar");
        }
        else
        {
            await DisplayAlert("CORRECTO", "!Registro completado con exito!", "Aceptar");
            await Navigation.PopAsync();
        }
    }

    private async void btnRegistroRestaurante_Clicked(System.Object sender, System.EventArgs e)
    {
        if (tbRestauranteName.Text == null)
        {
            nombreRestaurante.Stroke = Color.FromArgb("#B3261E");
            nombreRestaurante.HelperText = "el nombre es requerido*";
            nombreRestaurante.HelperLabelStyle.TextColor = Color.FromArgb("#B3261E");
            await DisplayAlert("Error", "Ingrese correctamente los datos del registro", "Aceptar");
        }
        else if (tbRestauranteTelefono.Text == null)
        {
            telefonorestaurante.Stroke = Color.FromArgb("#B3261E");
            telefonorestaurante.HelperText = "el telefono es requerido*";
            telefonorestaurante.HelperLabelStyle.TextColor = Color.FromArgb("#B3261E");
            await DisplayAlert("Error", "Ingrese correctamente los datos del registro", "Aceptar");
        }
        else if (tbDireccion.Text == null)
        {
            direccionRestaurante.Stroke = Color.FromArgb("#B3261E");
            direccionRestaurante.HelperText = "la direccion es requerida*";
            direccionRestaurante.HelperLabelStyle.TextColor = Color.FromArgb("#B3261E");
            await DisplayAlert("Error", "Ingrese correctamente los datos del registro", "Aceptar");
        }
        else
        {
            await DisplayAlert("CORRECTO", "!Registro completado con exito!", "Aceptar");
            await Navigation.PopAsync();
        }
    }

    void tbID_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        idCliente.Stroke = Color.FromArgb("#6750A4");
        idCliente.HelperText = "";
        idCliente.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    void tbNombre_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        nombreCliente.Stroke = Color.FromArgb("#6750A4");
        nombreCliente.HelperText = "";
        nombreCliente.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    void tbApellido_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        apellidoCliente.Stroke = Color.FromArgb("#6750A4");
        apellidoCliente.HelperText = "";
        apellidoCliente.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    void tbTelefono_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        telefonoCliente.Stroke = Color.FromArgb("#6750A4");
        telefonoCliente.HelperText = "";
        telefonoCliente.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    void tbRestaurantID_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        idRestaurante.Stroke = Color.FromArgb("#6750A4");
        idRestaurante.HelperText = "";
        idRestaurante.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    void tbRestauranteName_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        nombreRestaurante.Stroke = Color.FromArgb("#6750A4");
        nombreRestaurante.HelperText = "";
        nombreRestaurante.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    void tbRestauranteTelefono_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        telefonorestaurante.Stroke = Color.FromArgb("#6750A4");
        telefonorestaurante.HelperText = "";
        telefonorestaurante.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    void tbDireccion_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        direccionRestaurante.Stroke = Color.FromArgb("#6750A4");
        direccionRestaurante.HelperText = "";
        direccionRestaurante.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }
}

    
