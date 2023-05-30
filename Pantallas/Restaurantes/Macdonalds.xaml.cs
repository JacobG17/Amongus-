using System.IO;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace InstantFood.Pantallas.Restaurantes;

public partial class Macdonalds : ContentPage
{
    public Macdonalds()
    {
        InitializeComponent();
        FrameCantidad.IsVisible = true;
        opBD opPlatillo = new opBD();

        List<platillo> platillos = opPlatillo.ObtenerPlatillos(1);


        foreach (platillo platillo in platillos)
        {
            int id = platillo.idPlatillo;
            string nombre = platillo.nombrePlatillo;
            string descripcion = platillo.Descripcion;
            decimal precio = platillo.Precio;
            string categoria = platillo.Categoria;
            byte[] imagen = platillo.imagen;

            ImageSource imagenPlatillo = null;

            if (imagen != null && imagen.Length > 0)
            {
                string tempFilePath = Path.GetTempFileName();
                File.WriteAllBytes(tempFilePath, imagen);
                imagenPlatillo = ImageSource.FromFile(tempFilePath);
            }


            showPlatillos.Add(CrearContenidoPlatillo(id, nombre, descripcion, precio, categoria, imagenPlatillo));
        }        
    }


    CarritoPlatillos carritoPlatillo = new CarritoPlatillos();

    Dictionary<int, object> diccionarioObjetos = new Dictionary<int, object>();
    
    async void mostrarTotal(decimal total)
    {
        if (total > 0)
        {
            FrameCantidad.IsVisible = true;
            
        }
        else
        {
            FrameCantidad.IsVisible = false;
        }
        Total.Text = total.ToString();
        
    }

    async void agregarCarrito_Clicked(System.Object sender, System.EventArgs e)
    {
        DatosDiccionario.Instance.DiccionarioPlatillos = diccionarioObjetos;
        await Navigation.PushAsync(new carritoCliente());
    }

    private Label contadorLabel;

    private Frame CrearContenidoPlatillo(int id, string nombre, string descripcion, decimal precio, string categoria, ImageSource imagenPlatillo)
    {
        string contador1 = "0";
        string categoriaPlatillo = categoria;
        decimal precioAcumulado = 0;
        decimal nuevoPrecio = 0;
        decimal total = 0;
        

        Label contadorLabel = new Label
        {
            Text = contador1,
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            FontFamily = "Roboto-Med",
            FontAttributes = FontAttributes.Bold,
            WidthRequest = 23,
            HeightRequest = 25,
            Margin = new Thickness(0, 80, 0, 0)
        };

        var frame = new Frame
        {
            CornerRadius = 10,
            Margin = new Thickness(5, 10, 5, 10),
            Content = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new StackLayout
                    {
                        Margin = new Thickness(0, 0, 10, 0),
                        Children =
                        {
                            new Image
                            {
                                Source = imagenPlatillo,
                                WidthRequest = 85,
                                HeightRequest = 85,
                                Margin = new Thickness(0),
                                HorizontalOptions = LayoutOptions.Start
                            }
                        }
                    },
                    new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Margin = new Thickness(0),
                        Children =
                        {
                                new Label
                            {
                                Text = nombre,
                                FontSize = 20,
                                FontAttributes = FontAttributes.Bold
                            },
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    new Label
                                    {
                                        Text = "Precio: ",
                                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                                    },
                                    new Label
                                    {
                                        Text = precio.ToString(),
                                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                                    }
                                }
                            },
                            new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                Children =
                                {
                                    new Label
                                    {
                                        Text = "Descripción: ",
                                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                                    },
                                    new Label
                                    {
                                        Text = descripcion,
                                        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
                                    }
                                }
                            }
                        }
                    },
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            new Button
                            {
                                Text = "+",
                                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                                WidthRequest = 25,
                                HeightRequest = 25,
                                Margin = new Thickness(0, 80, 3, 0),
                                Command = new Command(() =>
                                {
                                    //Resolver error de la suma de productos
                                    decimal contador = decimal.Parse(contador1);
                                    if (contador >= 0)
                                    {
                                        contador += 1;
                                        decimal.TryParse(Total.Text, out decimal valorEntero);
                                        precioAcumulado = precio + valorEntero;
                                        mostrarTotal(precioAcumulado);
                                        contador1 = contador.ToString();
                                        contadorLabel.Text = contador1;

                                        
                                    }
                                    if (diccionarioObjetos.ContainsKey(id))
                                    {
                                        decimal sumaPlatillo = contador*precio;
                                        // Obtener la referencia al objeto
                                        CarritoPlatillos platilloCarrito = (CarritoPlatillos)diccionarioObjetos[id];
                                        // Modificar el campo del objeto
                                        platilloCarrito.Cantidad = contador1;
                                        platilloCarrito.TotalPlatillo = sumaPlatillo;
                                    }
                                    else
                                    {
                                        // El objeto no existe, crea uno nuevo
                                        carritoPlatillo = new CarritoPlatillos
                                        {
                                            Nombre = nombre,
                                            Descripcion = descripcion,
                                            Cantidad = contador1,
                                            TotalPlatillo = precio,
                                            ImagenPlatillo = imagenPlatillo
                                        };

                                        // Obtén el identificador único del frame
                                        diccionarioObjetos.Add(id, carritoPlatillo);


                                    }
                                })
                            },
                            contadorLabel,
                            new Button
                            {
                                Text = "-",
                                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                                WidthRequest = 25,
                                HeightRequest = 25,
                                Margin = new Thickness(2, 80, 0, 0),
                                Command = new Command(() =>
                                {
                                    decimal contador = int.Parse(contador1);
                                    if (contador > 0)
                                    {
                                        contador -= 1;
                                        decimal.TryParse(Total.Text, out decimal valorEntero);
                                        nuevoPrecio = valorEntero - precio;
                                        mostrarTotal(nuevoPrecio);
                                        contador1 = contador.ToString();
                                        contadorLabel.Text = contador1;
                                    }
                                    if (carritoPlatillo != null)
                                    {
                                        int cantidad = int.Parse(carritoPlatillo.Cantidad);
                                        cantidad -= 1;
                                        if (cantidad > 0)
                                        {
                                            decimal restaPlatillo = contador * precio;
                                            carritoPlatillo.Cantidad = cantidad.ToString();
                                            carritoPlatillo.TotalPlatillo = restaPlatillo;    
                                        }
                                        else
                                        {
                                            diccionarioObjetos.Remove(id);
                                        }
                                    }
                                })
                            }
                        }
                    }
                }
            }          
        };
        return frame;
    }

}
