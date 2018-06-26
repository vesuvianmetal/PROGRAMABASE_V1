using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// This class is to establish a conection to a mysql database
/// </summary>

/// importing mysql libraries
using MySql.Data.MySqlClient;

namespace ProgramaBase
{

    /// <summary>
    /// name of class for the database conection
    /// </summary>
    class ConexionBD
    {
        /// <summary>
        /// mysql conection method
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection ObtenerConexion()
        {
            try
            {
                ///establish primary database parameters
                MySqlConnection Conectar = new MySqlConnection("Server =192.168.1.74;port=3306; database = electronicax ; Userid = root; password =; sslmode=none;Allow Zero Datetime=True;Convert Zero Datetime=True;");
                return Conectar;
            }
            catch
            {
                ///establish secondary database parameters
                MySqlConnection Conectar = new MySqlConnection("Server =192.168.1.74;port=3306; database = electronicax ; Userid = root; password =; sslmode=none;Allow Zero Datetime=True;Convert Zero Datetime=True;");
                return Conectar;
            }


        }



    }
}

