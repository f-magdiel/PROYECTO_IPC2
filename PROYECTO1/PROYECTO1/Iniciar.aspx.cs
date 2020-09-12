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
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-BBB7M4H; Initial Catalog = Usuario; Integrated Security = True")) {

                sqlCon.Open();
                string query = "SELECT username,contraseña FROM Registro WHERE username = @username AND contraseña=@password";
                SqlCommand sqlCmd = new SqlCommand(query,sqlCon);
                sqlCmd.Parameters.AddWithValue("@username",TextBoxUsername.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password",TextBoxPass.Text.Trim());
                SqlDataReader leer = sqlCmd.ExecuteReader();
                if (leer.Read())
                {
                    Response.Redirect("Menu.aspx");
                }
                else {
                    Response.Redirect("Default"); 
                     }
            }

        }
    }
}