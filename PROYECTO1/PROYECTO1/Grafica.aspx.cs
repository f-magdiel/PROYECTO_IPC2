using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROYECTO1
{
    public partial class Grafica : System.Web.UI.Page
    {
        //lado A
        public static string A8Equipo1 = "";
        public static string A8Equipo2 = "";
        public static string A8Equipo3 = "";
        public static string A8Equipo4 = "";
        public static string A8Equipo5 = "";
        public static string A8Equipo6 = "";
        public static string A8Equipo7 = "";
        public static string A8Equipo8 = "";

        public static string A4Equipo1 = "";
        public static string A4Equipo2 = "";
        public static string A4Equipo3 = "";
        public static string A4Equipo4 = "";

        public static string A2Equipo1 = "";
        public static string A2Equipo2 = "";

        public static string A1Equipo1 = "";

        //Lado B
        public static string B8Equipo1 = "";
        public static string B8Equipo2 = "";
        public static string B8Equipo3 = "";
        public static string B8Equipo4 = "";
        public static string B8Equipo5 = "";
        public static string B8Equipo6 = "";
        public static string B8Equipo7 = "";
        public static string B8Equipo8 = "";

        public static string B4Equipo1 = "";
        public static string B4Equipo2 = "";
        public static string B4Equipo3 = "";
        public static string B4Equipo4 = "";

        public static string B2Equipo1 = "";
        public static string B2Equipo2 = "";

        public static string B1Equipo1 = "";

        public static string ganador = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                recargaGrafica();
            }
        }

        protected void ButtonRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPrincipal.aspx");
        }

        public void recargaGrafica()
        {
            LabelGanador.Text = ganador;
            //lado A
            A8LabelEquipo1.Text = A8Equipo1;
            A8LabelEquipo2.Text = A8Equipo2;
            A8LabelEquipo3.Text = A8Equipo3;
            A8LabelEquipo4.Text = A8Equipo4;
            A8LabelEquipo5.Text = A8Equipo5;
            A8LabelEquipo6.Text = A8Equipo6;
            A8LabelEquipo7.Text = A8Equipo7;
            A8LabelEquipo8.Text = A8Equipo8;

            A4LabelEquipo1.Text = A4Equipo1;
            A4LabelEquipo2.Text = A4Equipo2;
            A4LabelEquipo3.Text = A4Equipo3;
            A4LabelEquipo4.Text = A4Equipo4;

            A2LabelEquipo1.Text = A2Equipo1;
            A2LabelEquipo2.Text = A2Equipo2;

            A1LabelEquipo1.Text = A1Equipo1;

            //lado B
            B8LabelEquipo1.Text = B8Equipo1;
            B8LabelEquipo2.Text = B8Equipo2;
            B8LabelEquipo3.Text = B8Equipo3;
            B8LabelEquipo4.Text = B8Equipo4;
            B8LabelEquipo5.Text = B8Equipo5;
            B8LabelEquipo6.Text = B8Equipo6;
            B8LabelEquipo7.Text = B8Equipo7;
            B8LabelEquipo8.Text = B8Equipo8;

            B4LabelEquipo1.Text = B4Equipo1;
            B4LabelEquipo2.Text = B4Equipo2;
            B4LabelEquipo3.Text = B4Equipo3;
            B4LabelEquipo4.Text = B4Equipo4;

            B2LabelEquipo1.Text = B2Equipo1;
            B2LabelEquipo2.Text = B2Equipo2;

            B1LabelEquipo1.Text = B1Equipo1;

        }
    }
}