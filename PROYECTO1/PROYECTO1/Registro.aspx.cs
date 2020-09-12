﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PROYECTO1
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegistrarse_Click(object sender, EventArgs e)
        {
            String año = DropDownListAño.SelectedItem.Value;
            String dia = DropDownListDia.SelectedItem.Value;
            String mes = DropDownListMes.SelectedItem.Value;
            String fecha = dia + "/" + mes + "/" + año;
            TextBoxCorreo.Text = fecha;

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-BBB7M4H; Initial Catalog = Usuario; Integrated Security = True"))
            {
                String query = "INSERT INTO Registro (username,nombres,apellidos,contraseña,fecha_nacimiento,pais,correo_eletronico) VALUES (@username,@nombres,@apellidos,@contraseña,@fecha,@pais,@correo)";
                sqlCon.Open();
                SqlCommand comando = new SqlCommand(query, sqlCon);
                comando.Parameters.AddWithValue("@username", TextBoxNombreUsuario.Text);
                comando.Parameters.AddWithValue("@nombres", TextBoxNombres.Text);
                comando.Parameters.AddWithValue("@apellidos", TextBoxApellidos.Text);
                comando.Parameters.AddWithValue("@contraseña", TextBoxContraseña.Text);
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.Parameters.AddWithValue("@pais", TextBoxPais.Text);
                comando.Parameters.AddWithValue("@correo", TextBoxNombreUsuario.Text);
                comando.ExecuteNonQuery();
            }
                
            
        }
    }
}