using System.ComponentModel;

namespace InstantFood.Pantallas
{
    public partial class PedidosCliente : ContentPage
    {
        public PedidosCliente()
        {
            InitializeComponent();
            var diccionario = DatosDiccionario.Instance.DiccionarioPlatillos;

            // Crear el Frame
            //var frame = CreateMyFrame(diccionario);

            // Agregar el Frame a un contenedor (por ejemplo, un StackLayout llamado "container")
            //showPedidos.Children.Add(frame);
        }

        private Frame CreateMyFrame(Dictionary<int, object> diccionarioPlatillos)
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
                Spacing = 80
            };

            // Label
            var label = new Label
            {
                Text = "McDonalds",
                FontSize = 20,
                Margin = new Thickness(0, 7, 0, 0)
            };

            stackLayout1.Children.Add(label);

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
                Orientation = StackOrientation.Vertical,
                Margin = new Thickness(0, 5, 0, 0)
            };

            // Label Descripción
            var labelDescripcionTitulo = new Label
            {
                Text = "Descripción:",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };

            // Label Descripción contenido
            var labelDescripcionContenido = new Label
            {
                Text = "Hamburguesa con papas y refresco.",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            };

            stackLayout3.Children.Add(labelDescripcionTitulo);
            stackLayout3.Children.Add(labelDescripcionContenido);

            // StackLayout interno 4
            var stackLayout4 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 190,
                Margin = new Thickness(0, 15, 0, 0)
            };

            // Label Status
            var labelStatus = new Label
            {
                Text = "Status:",
                FontSize = 20,
                Margin = new Thickness(0, 10, 0, 0)
            };

            // Label Status contenido
            var labelStatusContenido = new Label
            {
                Text = "En camino",
                FontSize = 20,
                Margin = new Thickness(0, 10, 0, 0)
            };

            stackLayout4.Children.Add(labelStatus);
            stackLayout4.Children.Add(labelStatusContenido);

            // StackLayout interno 5
            var stackLayout5 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 100,
                Margin = new Thickness(0, 15, 0, 0)
            };

            // Button Cancelar
            var buttonCancelar = new Button
            {
                Text = "Cancelar"
            };

            stackLayout5.Children.Add(buttonCancelar);

            // Agregar los StackLayouts al StackLayout principal
            mainStackLayout.Children.Add(stackLayout1);
            mainStackLayout.Children.Add(stackLayout2);
            mainStackLayout.Children.Add(stackLayout3);
            mainStackLayout.Children.Add(stackLayout4);
            mainStackLayout.Children.Add(stackLayout5);

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
}
