using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROYECTO1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonIniciar_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-O6I4JBC; Initial Catalog = Jugador; Integrated Security = True")) {

                sqlCon.Open();
                string query = "SELECT Username,Contraseña FROM Usuario WHERE Username = @username AND Contraseña=@password";
                SqlCommand sqlCmd = new SqlCommand(query,sqlCon);
                sqlCmd.Parameters.AddWithValue("@username",TextBoxUsername.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password",TextBoxPass.Text.Trim());
                SqlDataReader leer = sqlCmd.ExecuteReader();
                if (leer.Read())
                {
                    Response.Redirect("Opciones.aspx");
                }
                else {
                    Response.Redirect("Default"); 
                     }
            }

        }
    }
}