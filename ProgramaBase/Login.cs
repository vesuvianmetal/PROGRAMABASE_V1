using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// This window/code makes the log in work
/// </summary>
/// 

///importacion de las librerias de mysql
using MySql.Data.MySqlClient;

namespace ProgramaBase
{
    public partial class Login : Form
    {

        //importacion de metodo de conexion a mysql
        MySqlConnection conn = ConexionBD.ObtenerConexion();
        
        public Login()
        {
            InitializeComponent();
        }
        
        //metodo para la accion de inicio de sesion
        public void method_login()
        {
            //abertura de conexion a la base de datos
            conn.Open();

            //definicion de la consulta a realizar que en este caso es para iniciar sesion
            string query_login = "select * from usuarios where Correo = '" + txtuser.Text + "' and Contra = '" + txtpass.Text + "'";

            //preparacion de comando con el query y variable de la conexion a la base de datos
            MySqlCommand cmd_query_login = new MySqlCommand(query_login, conn);

            //ejecucion del comando/query a realizar a la base de datos
            MySqlDataReader leer = cmd_query_login.ExecuteReader();

            //condicion (si lee/existe registro entonces realiza lo siguiente)
            if (leer.Read())
            {
                //muestra mensaje 
                MessageBox.Show("Haz conectado exitosamente");
            }

            //condicion (si no lee/no existe el registro entonces hace lo siguiente)
            else
            {
                //muestra mensaje
                MessageBox.Show("El usuario no existe");
            }

            //cierra la conexion a la base de datos
            conn.Close();
        }

       
       //evento al hacer click ( lo que ocurre al presion el boton de login) 
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                //se mande a llamar el metodo que contiene el codigo para iniciar sesion
                method_login(); 

                //si existe error, este se almacenara en la variable ex
            } catch (Exception ex)
            {
                //el error se mostrara en un messagebox
                MessageBox.Show(ex.Message);
            }
        }

        //evento que se realiza al presionar cierto boton del teclado
        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            //definicion del boton que activara el evento (en este caso es el boton enter)
            if (e.KeyCode == Keys.Enter)
            {


                try
                {
                    //se mande a llamar el metodo que contiene el codigo para iniciar sesion
                    method_login();
                }

                //si existe error, este se almacenara en la variable ex
                catch (Exception ex)
                {
                    //el error se mostrara en un messagebox
                    MessageBox.Show(ex.Message);
                }

            }
        }

       
        //segundo evento para cuando se presiona un boton
        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
        //definicion del boton a activar el evento que en este caso es enter
           if (e.KeyChar == (char)Keys.Enter)
            {
                //definicion de que la accion esta permitida
                e.Handled = true;
            }
        }
    }

        
    }

