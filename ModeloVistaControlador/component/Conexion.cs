using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ModeloVistaControlador.component
{
    //Esta es la clase de conexion y puede ser un singleton o heredada aqui la pondremos en un singleton porque es simple
    class Conexion
    {
        //Esta es la conexion y por el unico objeto al que te vas a conectar
        private SqlConnection conexion;
        //Aqui esta la unica instancia de la conexion para que no manejes muchas conexiones como es simple solo manejar una
        private static Conexion instance = new Conexion();
        //Esta privado para asegurarme que no creare mas de una sola conexion
        private Conexion()
        {

        }

        //La conexion se debe obtener su unica instancia creada arriba
        public static Conexion getInstance()
        {
            return instance;
        }

        //Este metodo lo que hace es abrir la conexion por lo comun cuando el programa inicia
        public void openConection()
        {
            conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            conexion.Open();
        }

        //Este la cierra al final del programa para que no quede en segundo plano y cierre las transacciones
        public void closeConexion()
        {
            conexion.Close();
        }

        //Con este nada mas para obtener el objeto de conexion usarlo en privado para que nadie lo toque
        private SqlConnection getConexion()
        {
            return conexion;
        }

        //este es un metodo para ejecutar alguna query de sql, la conexion ya debe de estar abierta
        public Boolean execute(string sql)
        {
            Console.Write("SQL: " + sql);
            //variable para guardar el resultadi
            Boolean result = false;
            //Creamos el comando
            SqlCommand command = conexion.CreateCommand();
            //Declaramos las transaccion
            SqlTransaction transaccion;

            // Iniciamos la transaccion local
            transaccion = conexion.BeginTransaction("SampleTransaction");

            // Debe asignar tanto el objeto de transacción como la conexión
            // Comando objeto para una transacción local pendiente
            command.Connection = conexion;
            command.Transaction = transaccion;

            try
            {
                //Pasamos la query
                command.CommandText = sql;
                //Ejecutamos query
                command.ExecuteNonQuery();

                // Intenta comprometer la transacción.
                transaccion.Commit();

                //Enviamos en la consola que todo esta correcto
                Console.WriteLine("El registro se escribio en base de datos");

                //Aqui le decimos que todo esta correcto pasandole true al resultado
                result = true;
            }
            catch (Exception ex)
            {
                //Enviamos error por consola siempre fijate hay en la consola
                Console.WriteLine("Confirmar tipo de excepción: {0}", ex.GetType());
                //Enviar mensaje por consola
                Console.WriteLine("  Mensaje: {0}", ex.Message);

                // Intente revertir la transacción, porque como hubo error
                try
                {

                    transaccion.Rollback();
                }
                catch (Exception ex2)
                {
                    // Este bloque de captura manejará cualquier error que pueda haber ocurrido.
                    // en el servidor que causaría un error en la reversión, como
                    // Una conexión cerrada.
                    Console.WriteLine("Tipo de excepción de reversión: {0}", ex2.GetType());
                    Console.WriteLine("  Mensaje: {0}", ex2.Message);
                }
            }

            return result;
        }

        //este trael los datos y siempre hay que cerrar este reader
        public SqlDataReader findBySQL(String sql)
        {
            
            Console.WriteLine("SQL:" + sql);
            //definir el objeto SqlCommand
            SqlCommand cmd = new SqlCommand(sql, conexion);
            return cmd.ExecuteReader();
        }

        public Int32 aggregationSimpleSql(String sql)
        {
            //definir el objeto SqlCommand
            SqlCommand cmd = new SqlCommand(sql, conexion);
            var escalar = cmd.ExecuteScalar();
            Console.Write(escalar);
            return (Int32)escalar;
        }

    }
}
