using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InstantFood.Pantallas;

public partial class carritoCliente : ContentPage
{
    public carritoCliente()
	{
		InitializeComponent();
        NavigationPage page = new NavigationPage();
        var diccionario = DatosDiccionario.Instance.DiccionarioPlatillos;
        contentCarrito.Add(CreateMyFrame(diccionario));
    }

    public Frame CreateMyFrame(Dictionary<int, object> diccionarioPlatillos)
    {
        decimal TotalPlatillos = 24;
        // Frame
        var frame = new Frame
        {
            CornerRadius = 10,
            Margin = new Thickness(5, 10, 5, 10)
        };

        // StackLayout principal
        var mainStackLayout = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            HorizontalOptions = LayoutOptions.CenterAndExpand
        };

        // StackLayout interno 1
        var stackLayout1 = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Spacing = 160
        };

        // Label
        var label = new Label
        {
            Text = "McDonalds  >",
            FontSize = 20,
            Margin = new Thickness(0, 7, 0, 0)
        };

        // Button
        var button = new Button
        {
            HorizontalOptions = LayoutOptions.End,
            BackgroundColor = Colors.White,
            ImageSource = "trash.png",
            Margin = new Thickness(0, 0, 0, 0)
        };

        stackLayout1.Children.Add(label);
        stackLayout1.Children.Add(button);

        // StackLayout interno 2
        var stackLayout2 = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            Spacing = 10
        };

        foreach (var kvp in diccionarioPlatillos)
        {
            int clave = kvp.Key;
            object valor = kvp.Value;

            // Realizar el casting del objeto al tipo CarritoPlatillos
            CarritoPlatillos carrito = (CarritoPlatillos)valor;

            // Obtener los datos del objeto CarritoPlatillos
            string nombre = carrito.Nombre;
            string cantidad = carrito.Cantidad;
            decimal precio = carrito.TotalPlatillo;
            ImageSource imagenPlatillo = carrito.ImagenPlatillo;

            TotalPlatillos = TotalPlatillos + precio;

            // Crear el Grid con los datos del objeto
            var grid = CreateGrid(nombre, cantidad, precio, imagenPlatillo);

            stackLayout2.Children.Add(grid);
            
        }

        // StackLayout interno 3
        var stackLayout3 = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Spacing = 190,
            Margin = new Thickness(0, 15, 0, 5)
        };

        // Label Envio
        var labelEnvio = new Label
        {
            Text = "Envio",
            FontSize = 20
        };

        // Label MX$24.00
        var labelMonto = new Label
        {
            Text = "MX$24.00",
            FontSize = 20
        };

        stackLayout3.Children.Add(labelEnvio);
        stackLayout3.Children.Add(labelMonto);

        // StackLayout interno 4
        var stackLayout4 = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Spacing = 100,
            Margin = new Thickness(0, 15, 0, 0)
        };

        // Label MX$124.00
        var labelTotal = new Label
        {
            Text = $"MX${TotalPlatillos.ToString()}",
            FontSize = 30
        };

        // Button Ordenar
        var buttonOrdenar = new Button
        {
            Text = "Ordenar"
        };
        buttonOrdenar.Clicked += async (sender, e) =>
        {
            // Aquí puedes agregar el código para navegar a la pantalla deseada
            await Navigation.PushAsync(new PedidosCliente());
        };

        stackLayout4.Children.Add(labelTotal);
        stackLayout4.Children.Add(buttonOrdenar);

        // Agregar los StackLayouts al StackLayout principal
        mainStackLayout.Children.Add(stackLayout1);
        mainStackLayout.Children.Add(stackLayout2);
        mainStackLayout.Children.Add(stackLayout3);
        mainStackLayout.Children.Add(stackLayout4);

        frame.Content = mainStackLayout;

        
        return frame;
    }

    private Grid CreateGrid(string nombre, string cantidad, decimal precio, ImageSource platillo)
    {
        var grid = new Grid();
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(70) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(120) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(130) });

        var image = new Image
        {
            Source = platillo,
            WidthRequest = 50,
            HeightRequest = 50,
            Margin = new Thickness(0, 0, 0, 0),
            HorizontalOptions = LayoutOptions.Start
        };
        Grid.SetColumn(image, 0);

        var label1 = new Label
        {
            Text = nombre,
            FontSize = 20,
            WidthRequest = 95,
            Margin = new Thickness(0, 30, 0, 0),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            HorizontalTextAlignment = TextAlignment.Start
        };
        Grid.SetColumn(label1, 1);

        var label2 = new Label
        {
            Text = "x" + cantidad.ToString(),
            FontSize = 18,
            Margin = new Thickness(0, 30, 0, 0),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            HorizontalTextAlignment = TextAlignment.Start
        };
        Grid.SetColumn(label2, 2);

        var label3 = new Label
        {
            Text = "MX$" + precio.ToString("0.00"),
            FontSize = 20,
            Margin = new Thickness(0, 30, 0, 0),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            HorizontalTextAlignment = TextAlignment.Start
        };
        Grid.SetColumn(label3, 3);

        grid.Children.Add(image);
        grid.Children.Add(label1);
        grid.Children.Add(label2);
        grid.Children.Add(label3);

        return grid;
    }


    

}



