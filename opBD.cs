using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace InstantFood
{
    public class cliente
    {
        public String Nombre = " ";
        public String Telefono = " ";
        public String Usuario = " ";
        public String Contrasena = " ";
    }

    public class restaurante
    {
        public String nombreRestaurante = " ";
        public String Telefono = " ";
        public String Direccion = " ";
        public String Usuario = " ";
        public String Contrasena = " ";
    }

    public class platillo
    {
        public Int32 idPlatillo;
        public Int32 idrestaurante;
        public String nombrePlatillo = " ";
        public String Descripcion = " ";
        public Decimal Precio = 0;
        public String Categoria = " ";
        public Byte[] imagen;

        public platillo()
        {
        }

        public platillo(int idPlatillo, int idrestaurante, string nombre, string descripcion, decimal precio, string categoria, byte[] imagenBytes)
        {
            this.idPlatillo = idPlatillo;
            this.idrestaurante = idrestaurante;
            nombrePlatillo = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Categoria = categoria;
            imagen = imagenBytes;
        }
    }

    public class opBD
    {
        public Boolean bAllOk = false;
        public String sLastError = "";

        public MySqlConnection CrearConexion()
        {
            string cadenaConexion = $"DataSource= localhost; Port=3306; User Id=jacobG17; Password=Hermano1; Database=InstantFood; SSL Mode=None;";
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            return conn;
        }

        public bool InsertCliente(cliente datos)
        {

            try
            {
                string query = $"insert into cliente (nombre, telefono, usuario, password)" +
                    $"VALUES('{datos.Nombre}', '{datos.Telefono}', '{datos.Usuario}', '{datos.Contrasena}')";
                MySqlCommand command = new MySqlCommand(query, CrearConexion());
                command.ExecuteNonQuery();
                bAllOk = true;
                
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;
                bAllOk = false;
            }
            return bAllOk;
        }

        public bool InsertRestaurant(restaurante datos)
        {
            try
            {
                string query = $"insert into cliente (idRestaurante, nombreRestaurante, telefono, usuario, password)" +
                    $"VALUES('{datos.nombreRestaurante}', '{datos.Telefono}', '{datos.Usuario}', '{datos.Contrasena}')";
                MySqlCommand command = new MySqlCommand(query, CrearConexion());
                command.ExecuteNonQuery();
                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;
                bAllOk = false;
            }
            return bAllOk;
        }

        public bool InsertPLatillo(platillo datos)
        {
            try
            {
                string query = "insert into Platillos (idrestaurante, Nombre, Descripcion, Precio, categoria, imagen)" +
                    "VALUES (@idrestaurante, @Nombre, @Descripcion, @Precio, @categoria, @imagen)";

                using (MySqlConnection connection = CrearConexion())
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idrestaurante", datos.idrestaurante);
                    command.Parameters.AddWithValue("@Nombre", datos.nombrePlatillo);
                    command.Parameters.AddWithValue("@Descripcion", datos.Descripcion);
                    command.Parameters.AddWithValue("@Precio", datos.Precio);
                    command.Parameters.AddWithValue("@categoria", datos.Categoria);
                    command.Parameters.AddWithValue("@imagen", datos.imagen);

                    command.ExecuteNonQuery();
                }

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;
                bAllOk = false;
            }
            return bAllOk;
        }
        
        public List<platillo> ObtenerPlatillos(int idRestaurante)
        {
            string query = $"SELECT * FROM Platillos WHERE idrestaurante = {idRestaurante}";

            using (MySqlConnection connection = CrearConexion())
            {

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    DataTable result = new DataTable();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }

                    List<platillo> platillos = new List<platillo>();

                    foreach (DataRow row in result.Rows)
                    {
                        int idPlatillo = Convert.ToInt32(row["idPlatillo"]);
                        int idrestaurante = Convert.ToInt32(row["idRestaurante"]);
                        string nombre = row["Nombre"].ToString();
                        string descripcion = row["Descripcion"].ToString();
                        decimal precio = Convert.ToDecimal(row["Precio"]);
                        string categoria = row["categoria"].ToString();
                        byte[] imagenBytes = (byte[])row["imagen"];

                        platillo platillo = new platillo(idPlatillo, idrestaurante, nombre, descripcion, precio, categoria, imagenBytes);

                        platillos.Add(platillo);
                    }

                    return platillos;
                }
            }
        }

    }
}

