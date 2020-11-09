using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROYECTO1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSolitario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Maquina.aspx");
        }

        protected void ButtonMaquina_Click(object sender, EventArgs e)
        {
            Response.Redirect("Solitario.aspx");
        }

        protected void ButtonSolitarioInverso_Click(object sender, EventArgs e)
        {
            Response.Redirect("SolitarioInverso.aspx");
        }

        protected void ButtonMaquinaInverso_Click(object sender, EventArgs e)
        {
            Response.Redirect("MaquinaInverso.aspx");
        }

        protected void ButtonXtream_Click(object sender, EventArgs e)
        {
            Response.Redirect("Xtream.aspx");
        }

        protected void ButtonTorneo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Torneo.aspx");
        }

        protected void ButtonReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("Grafica.aspx");
        }
    }
}