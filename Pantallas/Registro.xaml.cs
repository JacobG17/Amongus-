namespace InstantFood.Pantallas;

public partial class Registro : ContentPage
{
    public Registro()
    {
        InitializeComponent();
        datosCliente(false);
        datosRestaurante(false);
    }

    public Boolean bExiste = false;

    void datosCliente(bool mostrar)
    {
        DtCliente.IsVisible = mostrar;
        nombreCliente.IsVisible = mostrar;
        telefonoCliente.IsVisible = mostrar;
        usuarioCliente.IsVisible = mostrar;
        passwordCliente.IsVisible = mostrar;
        btnRegistroCliente.IsVisible = mostrar;
    }

    void datosRestaurante(bool mostrar)
    {
        DtRestaurante.IsVisible = mostrar;
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
            cliente newCliente = new cliente()
            {
                Nombre = tbNombre.Text,
                Telefono = tbTelefono.Text,
                Usuario = tbUsuarioCliente.Text,
                Contrasena = tbPasswordCliente.Text
            };

            opBD opRegistro = new opBD();

            Boolean bAllOUsuario = (!bExiste); opRegistro.InsertCliente(newCliente);

            if (opRegistro.bAllOk == true)
            {
                await DisplayAlert("CORRECTO", "!Registro completado con exito!", "Aceptar");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("ERROR", opRegistro.sLastError, "Aceptar");
            }
            
        }
    }


    void tbNombre_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        nombreCliente.Stroke = Color.FromArgb("#6750A4");
        nombreCliente.HelperText = "Ingresa tu nombre";
        nombreCliente.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    void tbTelefono_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        telefonoCliente.Stroke = Color.FromArgb("#6750A4");
        telefonoCliente.HelperText = "Ingresa tu telefonos";
        telefonoCliente.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    void tbUsuario_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        usuarioCliente.Stroke = Color.FromArgb("#6750A4");
        usuarioCliente.HelperText = "Ingresa la direccion";
        usuarioCliente.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    void tbPasswordCliente_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        passwordCliente.Stroke = Color.FromArgb("#6750A4");
        passwordCliente.HelperText = "Ingresa la direccion";
        passwordCliente.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    void tbRestauranteName_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        nombreRestaurante.Stroke = Color.FromArgb("#6750A4");
        nombreRestaurante.HelperText = "Ingresa el nombre de tu restaurante";
        nombreRestaurante.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    void tbRestauranteTelefono_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        telefonorestaurante.Stroke = Color.FromArgb("#6750A4");
        telefonorestaurante.HelperText = "Ingresa el telefono del restaurante";
        telefonorestaurante.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    void tbDireccion_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        direccionRestaurante.Stroke = Color.FromArgb("#6750A4");
        direccionRestaurante.HelperText = "Ingresa la direccion";
        direccionRestaurante.HelperLabelStyle.TextColor = Color.FromArgb("#6750A4");
    }

    

    async void btnRegistroCliente_Clicked_1(System.Object sender, System.EventArgs e)
    {
        if (tbNombre.Text == null)
        {
            nombreCliente.Stroke = Color.FromArgb("#B3261E");
            nombreCliente.HelperText = "el nombre es requerido*";
            nombreCliente.HelperLabelStyle.TextColor = Color.FromArgb("#B3261E");
            await DisplayAlert("Error", "Ingrese correctamente los datos del registro", "Aceptar");
        }
        else if (tbTelefono.Text == null)
        {
            telefonoCliente.Stroke = Color.FromArgb("#B3261E");
            telefonoCliente.HelperText = "el telefono es requerido*";
            telefonoCliente.HelperLabelStyle.TextColor = Color.FromArgb("#B3261E");
            await DisplayAlert("Error", "Ingrese correctamente los datos del registro", "Aceptar");
        }
        else if (tbUsuarioCliente.Text == null)
        {
            usuarioCliente.Stroke = Color.FromArgb("#B3261E");
            usuarioCliente.HelperText = "el telefono es requerido*";
            usuarioCliente.HelperLabelStyle.TextColor = Color.FromArgb("#B3261E");
            await DisplayAlert("Error", "Ingrese correctamente los datos del registro", "Aceptar");
        }
        else if (tbPasswordCliente.Text == null)
        {
            passwordCliente.Stroke = Color.FromArgb("#B3261E");
            passwordCliente.HelperText = "el telefono es requerido*";
            passwordCliente.HelperLabelStyle.TextColor = Color.FromArgb("#B3261E");
            await DisplayAlert("Error", "Ingrese correctamente los datos del registro", "Aceptar");
        }
        else
        {
            cliente newCliente = new cliente()
            {
                Nombre = tbNombre.Text,
                Telefono = tbTelefono.Text,
                Usuario = tbUsuarioCliente.Text,
                Contrasena = tbPasswordCliente.Text
            };

            opBD opRegistro = new opBD();

            Boolean bAllOUsuario = (!bExiste); opRegistro.InsertCliente(newCliente);

            if (opRegistro.bAllOk == true)
            {
                await DisplayAlert("CORRECTO", "!Registro completado con exito!", "Aceptar");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("ERROR", opRegistro.sLastError, "Aceptar");
            }
        }
    }
}

    
