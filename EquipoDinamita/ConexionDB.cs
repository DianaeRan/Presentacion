using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipoDinamita
{
    public class ConexionDB
    {
        
        public static MySqlConnection crearconexion()
        {
            string cadenaConexion = "server=localhost;port=3306;database=estero;user id=root;password=rouss04;";
            return new MySqlConnection(cadenaConexion);
        }
        // ***************************VALIDACIONES NOMBRE**************************************
        public bool ValidacionNombrePantalla(string nombre)
        {
            string query = "Select count(*) from Pantallas where Nombre = @Nombre;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query,conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                int encontrados = Convert.ToInt32(cmd.ExecuteScalar());
                return encontrados > 0;
            }
        }
        public bool ValidacionNombreTablilla(string nombre)
        {
            string query = "Select count(*) from Tablillas where Nombre = @Nombre;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                int encontrados = Convert.ToInt32(cmd.ExecuteScalar());
                return encontrados > 0;
            }
        }
        public bool ValidacionNombreCarcasa(string nombre)
        {
            string query = "Select count(*) from Carcasas where Nombre = @Nombre;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                int encontrados = Convert.ToInt32(cmd.ExecuteScalar());
                return encontrados > 0;
            }
        }
        public bool ValidacionNombreBoton(string nombre)
        {
            string query = "Select count(*) from Botones where Nombre = @Nombre;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                int encontrados = Convert.ToInt32(cmd.ExecuteScalar());
                return encontrados > 0;
            }
        }
        // ------------------------------------------------------------------------------------
        // **************************VALIDACIONES de existencia de ID de productos*************************************
        public bool ValidarIDPantalla(int ID)
        {
            string query = "select count(*) from Pantallas where Id_Pantalla = @Id_Pantalla";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id_Pantalla", ID);
                int encontrados = Convert.ToInt32(cmd.ExecuteScalar());
                return encontrados > 0;
            }
        }
        public bool ValidarIDTablilla(int ID)
        {
            string query = "select count(*) from Tablillas where Id_Tablilla = @Id_Tablilla";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id_Tablilla", ID);
                int encontrados = Convert.ToInt32(cmd.ExecuteScalar());
                return encontrados > 0;
            }
        }
        public bool ValidarIDCarcasa(int ID)
        {
            string query = "select count(*) from Carcasas where Id_Carcasas = @Id_Carcasas";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id_Carcasas", ID);
                int encontrados = Convert.ToInt32(cmd.ExecuteScalar());
                return encontrados > 0;
            }
        }
        public bool ValidarIDBotones(int ID)
        {
            string query = "select count(*) from Botones where Id_Botones = @Id_Botones";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id_Botones", ID);
                int encontrados = Convert.ToInt32(cmd.ExecuteScalar());
                return encontrados > 0;
            }
        }
        // ---------------------------------------------------------------------------------------
        // *****************************OBTENEr datos para DATAGRIDVIEWS y mostrar ******************************************
        public DataTable MostrarPantallas()
        {
            string query = "SELECT * FROM Pantallas";
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlConnection conexion = crearconexion())
                {
                    conexion.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand(query, conexion);
                    MySqlDataAdapter adp = new MySqlDataAdapter(mySqlCommand);
                    adp.Fill(dataTable);
                }
            }
            catch (Exception )
            {

                throw ;
            }
            return dataTable;
        }
        public DataTable MostrarTablillas()
        {
            string query = "SELECT * FROM Tablillas";
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlConnection conexion = crearconexion())
                {
                    conexion.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand(query, conexion);
                    MySqlDataAdapter adp = new MySqlDataAdapter(mySqlCommand);
                    adp.Fill(dataTable);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return dataTable;
        }
        public DataTable MostrarCarcasas()
        {
            string query = "SELECT * FROM Carcasas";
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlConnection conexion = crearconexion())
                {
                    conexion.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand(query, conexion);
                    MySqlDataAdapter adp = new MySqlDataAdapter(mySqlCommand);
                    adp.Fill(dataTable);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return dataTable;
        }
        public DataTable MostrarBotones()
        {
            string query = "SELECT * FROM Botones";
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlConnection conexion = crearconexion())
                {
                    conexion.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand(query, conexion);
                    MySqlDataAdapter adp = new MySqlDataAdapter(mySqlCommand);
                    adp.Fill(dataTable);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return dataTable;
        }
        public DataTable MostrarEstereo()
        {
            string query = "SELECT " +
                "e.Id_Estereo AS ID_Pedido, " +
                "e.Nombre_Pedido AS Pedido, " +
                "e.Nombre_Estereo AS Estereo, " +
                "p.Nombre AS Pantalla, " +
                "t.Nombre AS Tablilla, " +
                "c.Nombre AS Carcasa, " +
                "b.Nombre AS Botones " +
                "FROM Estereos e " +
                "JOIN Pantallas p ON e.Id_Pantalla = p.Id_Pantalla " +
                "JOIN Tablillas t ON e.Id_Tablilla = t.Id_Tablilla " +
                "JOIN Carcasas c ON e.Id_Carcasa = c.Id_Carcasas " +
                "JOIN Botones b ON e.Id_Botones = b.Id_Botones;";
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conexion = crearconexion())
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandText = query;
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    return dt;
                }
            }
            catch (Exception x)
            {

                throw new Exception("error: "+x);
            }
        }


        // ----------------------------------------------------------------------------------------
        // *****************************INSERCION DE DATOS si NO existe(PRODUCTOS)****************************************
        // si no existe igresa nuevo 
        public bool IngresarPantallas(string nombre, int cantidad)
        {
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                string query = "Insert Into Pantallas(Nombre,Stock)" + 
                "value(@Nombre,@Stock)";
                MySqlCommand cmd = new MySqlCommand(query,conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Stock", cantidad);
                int agregados = cmd.ExecuteNonQuery();
                return agregados > 0;
            }
        }
        public bool IngresarTablillas(string nombre, int cantidad)
        {
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                string query = "Insert Into Tablillas(Nombre,Stock)" +
                "value(@Nombre,@Stock)";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Stock", cantidad);
                int agregados = cmd.ExecuteNonQuery();
                return agregados > 0;
            }
        }
        public bool IngresarCarcasas(string nombre, int cantidad)
        {
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                string query = "Insert Into Carcasas(Nombre,Stock)" +
                "value(@Nombre,@Stock)";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Stock", cantidad);
                int agregados = cmd.ExecuteNonQuery();
                return agregados > 0;
            }
        }
        public bool IngresarBotones(string nombre, int cantidad)
        {
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                string query = "Insert Into Botones(Nombre,Stock)" +
                "value(@Nombre,@Stock)";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Stock", cantidad);
                int agregados = cmd.ExecuteNonQuery();
                return agregados > 0;
            }
        }
        // -------------------------------------------------------------------------------------
        // *******************************INSERCIION DE DATOS SI EXISTE EL PRODUCTO**********************************************
        // si ya existe solo suma el stoc en ves de ingresar uno nuevo
        public bool AlterarStockPantallaPositivo(string Nombre, int Stock) 
        {
            string query = "update Pantallas set Stock = Stock + @Stock where Nombre = @Nombre;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query,conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Stock", Stock);
                cmd.Parameters.AddWithValue("@Nombre",Nombre);
                int alterado = cmd.ExecuteNonQuery();
                return alterado > 0;
            }
        }
        public bool AlterarStockTablillaPositivo(string Nombre, int Stock)
        {
            string query = "update Tablillas set Stock = Stock + @Stock where Nombre = @Nombre;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Stock", Stock);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                int alterado = cmd.ExecuteNonQuery();
                return alterado > 0;
            }
        }
        public bool AlterarStockCarcasaPositivo(string Nombre, int Stock)
        {
            string query = "update Carcasas set Stock = Stock + @Stock where Nombre = @Nombre;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Stock", Stock);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                int alterado = cmd.ExecuteNonQuery();
                return alterado > 0;
            }
        }
        public bool AlterarStockBotonesPositivo(string Nombre, int Stock)
        {
            string query = "update Botones set Stock = Stock + @Stock where Nombre = @Nombre;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Stock", Stock);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                int alterado = cmd.ExecuteNonQuery();
                return alterado > 0;
            }
        }

        //AKI LOS METODOS PARA DESCONTAR EL ESTOCK SEGUN EL NUMERO DE ESTEREOS CREADOS <<<<<<<<<<<<<<<<<<<<<<<
        // este metodo lo pensaba usar para descontar el producto una ves creado el estereo  solo que ya no lo alcanse a poner por eso no tiene nibguna referencia 
        public bool AlterarStockPantallaNegativo(string Nombre, int Stock)
        {
            string query = "update Pantallas set Stock = Stock - @Stock where Nombre = @Nombre;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Stock", Stock);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                int alterado = Convert.ToInt32(cmd.ExecuteScalar());
                return alterado > 0;
            }
        }  


        //  aki iria el mismo pero para tablilla 


        // carcasa



        // Botones




        // ****************************EDICION DE DATOS(PRODUCTOS)*******************************************
        public bool EditarPantallas(int Id,string Nombre)
        {
            string query = "update Pantallas set Nombre = @Nombre where Id_Pantalla= @Id_Pantalla;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand (query, conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Id_Pantalla", Id);
                cmd.Parameters.AddWithValue("@Nombre",Nombre);
                int editados = cmd.ExecuteNonQuery();
                return editados > 0;
            }
        }
        public bool EditarTablillas(int Id, string Nombre)
        {
            string query = "update Tablillas set Nombre = @Nombre where Id_Tablilla = @Id_Tablilla;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Id_Tablilla", Id);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                int editados = cmd.ExecuteNonQuery();
                return editados > 0;
            }
        }
        public bool EditarCarcasas(int Id, string Nombre)
        {
            string query = "update Carcasas set Nombre =@Nombre where Id_Carcasas = @Id_Carcasas;" ;
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Id_Carcasas", Id);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                int v = cmd.ExecuteNonQuery();
                int editados = v;
                return editados > 0;
            }
        }
        public bool EditarBotones(int Id, string Nombre)
        {
            string query = "update Botones set Nombre Where Id_Carcasas = @Id_Carcasas;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Id_Botones", Id);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                int editados = cmd.ExecuteNonQuery();
                return editados > 0;
            }
        }
        // -----------------------------------------------------------------------------------
        // ****************************ELIMINACION DE DATOS (PRODUCTOS)**********************************
        public bool EliminarPantalla(int ID) 
        {
            string query = "delete from Pantallas  where Id_Pantalla = @Id_Pantalla;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query,conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Id_Pantalla", ID);
                int eliminados = cmd.ExecuteNonQuery();
                return eliminados > 0;
            }
        }
        public bool EliminarTablilla(int ID)
        {
            string query = "delete from Tablillas  where Id_Tablilla = @Id_Tablilla;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Id_Tablilla", ID);
                int eliminados = cmd.ExecuteNonQuery();
                return eliminados > 0;
            }
        }
        public bool EliminarCarcasa(int ID)
        {
            string query = "delete from Carcasas  where Id_Carcasas = @Id_Carcasas;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Id_Carcasas", ID);
                int eliminados = cmd.ExecuteNonQuery();
                return eliminados > 0;
            }
        }
        public bool Eliminarbotones(int ID)
        {
            string query = "delete from Botones  where Id_Botones = @Id_Botones;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Id_Botones", ID);
                int eliminados = cmd.ExecuteNonQuery();
                return eliminados > 0;
            }
        }
        // -----------------------------------------------------------------------------------------------
        // *********************CREAcion de pedido(estereo) y sus derivados*************************************
        public bool CrearEstereo(string nombrePedio,string nombreEstereo,int Id_Pantalla, int Id_Tablilla, int Id_Carcasa,int Id_Botones)
        {
            string query = "insert into Estereos(Nombre_Pedido,Nombre_Estereo, Id_Pantalla, Id_Tablilla, Id_Carcasa, Id_Botones) " +
                "Values (@Nombre_Pedido,@Nombre_Estereo, @Id_Pantalla, @Id_Tablilla, @Id_Carcasa, @Id_Botones);";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query,conexion);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("Nombre_Pedido", nombrePedio);
                cmd.Parameters.AddWithValue("Nombre_Estereo", nombreEstereo);
                cmd.Parameters.AddWithValue("Id_Pantalla", Id_Pantalla);
                cmd.Parameters.AddWithValue("Id_Tablilla", Id_Tablilla);
                cmd.Parameters.AddWithValue("Id_Carcasa", Id_Carcasa);
                cmd.Parameters.AddWithValue("Id_Botones", Id_Botones);
                int credos = cmd.ExecuteNonQuery();
                return credos > 0;

            }
        }

        // **************************VALIDACIONES LOGIN*************************************
        public bool ValidacionLogin(string nombre, string contraseña)
        {
            string query = "SELECT COUNT(*) FROM usuarios WHERE Nombre  = @nombre AND Contraseña  =  @contraseña;";
            using (MySqlConnection conexion = crearconexion())
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                int encontrados = Convert.ToInt32(cmd.ExecuteScalar());
                return encontrados > 0;
            }
        }


    }
}
