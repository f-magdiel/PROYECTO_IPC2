using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Drawing;
using Microsoft.Ajax.Utilities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROYECTO1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static bool banderaNegra = false;
        public static bool banderaBlanca = true;
        public static string columna;
        public static string fila;
        public static string color;
        public static string tiro;
        public static int contador = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void ButtonCarga_Click1(object sender, EventArgs e)
        {
            string ruta = TextBoxCarga.Text;
            LabelTexto.Text = ruta;

            XmlReader lector = XmlReader.Create(ruta);
            while (lector.Read())
            {
                if (lector.IsStartElement())
                {
                    contador += 1;
                    switch (lector.Name.ToString())
                    {
                        
                        
                        case "color":
                            color = lector.ReadString();
                            if (color == "blanco")
                            {
                               
                                banderaBlanca = false;
                                banderaNegra = true;
                            }
                            else if (color == "negro")
                            {
                              
                                banderaNegra = false;
                                banderaBlanca = true;
                            }
                            break;
                        case "columna":
                            columna = lector.ReadString();

                            break;
                        case "fila":
                            fila = lector.ReadString();

                            break;
                       
                    }
                    if (contador == 3) {
                        obtenerValores(color, columna, fila);
                        contador = 0;
                    }
                    
                }
            }

        }

        public void obtenerValores(string color, string col,string fil) { 
        
            string coordenada = col+"-"+fil;
            LabelTexto.Text = coordenada;
            //para A
            if (coordenada == "A-1") {
                if (color == "blanco")
                {
                    BtnA1.BackColor = Color.White;
                }
                else {
                    BtnA1.BackColor = Color.Black;
                }
            }

            if (coordenada == "A-2")
            {
                if (color == "blanco")
                {
                    BtnA2.BackColor = Color.White;
                }
                else
                {
                    BtnA2.BackColor = Color.Black;
                }
            }

            if (coordenada == "A-3")
            {
                if (color == "blanco")
                {
                    BtnA3.BackColor = Color.White;
                }
                else
                {
                    BtnA3.BackColor = Color.Black;
                }
            }
            if (coordenada == "A-4")
            {
                if (color == "blanco")
                {
                    BtnA4.BackColor = Color.White;
                }
                else
                {
                    BtnA4.BackColor = Color.Black;
                }
            }
            if (coordenada == "A-5")
            {
                if (color == "blanco")
                {
                    BtnA5.BackColor = Color.White;
                }
                else
                {
                    BtnA5.BackColor = Color.Black;
                }
            }
            if (coordenada == "A-6")
            {
                if (color == "blanco")
                {
                    BtnA6.BackColor = Color.White;
                }
                else
                {
                    BtnA6.BackColor = Color.Black;
                }
            }
            if (coordenada == "A-7")
            {
                if (color == "blanco")
                {
                    BtnA7.BackColor = Color.White;
                }
                else
                {
                    BtnA7.BackColor = Color.Black;
                }
            }
            if (coordenada == "A-8")
            {
                if (color == "blanco")
                {
                    BtnA8.BackColor = Color.White;
                }
                else
                {
                    BtnA8.BackColor = Color.Black;
                }
            }

            //para B
            if (coordenada == "B-1")
            {
                if (color == "blanco")
                {
                    BtnB1.BackColor = Color.White;
                }
                else
                {
                    BtnB1.BackColor = Color.Black;
                }
            }

            if (coordenada == "B-2")
            {
                if (color == "blanco")
                {
                    BtnB2.BackColor = Color.White;
                }
                else
                {
                    BtnB2.BackColor = Color.Black;
                }
            }

            if (coordenada == "B-3")
            {
                if (color == "blanco")
                {
                    BtnB3.BackColor = Color.White;
                }
                else
                {
                    BtnB3.BackColor = Color.Black;
                }
            }
            if (coordenada == "B-4")
            {
                if (color == "blanco")
                {
                    BtnB4.BackColor = Color.White;
                }
                else
                {
                    BtnB4.BackColor = Color.Black;
                }
            }
            if (coordenada == "B-5")
            {
                if (color == "blanco")
                {
                    BtnB5.BackColor = Color.White;
                }
                else
                {
                    BtnB5.BackColor = Color.Black;
                }
            }
            if (coordenada == "B-6")
            {
                if (color == "blanco")
                {
                    BtnB6.BackColor = Color.White;
                }
                else
                {
                    BtnB6.BackColor = Color.Black;
                }
            }
            if (coordenada == "B-7")
            {
                if (color == "blanco")
                {
                    BtnB7.BackColor = Color.White;
                }
                else
                {
                    BtnB7.BackColor = Color.Black;
                }
            }
            if (coordenada == "B-8")
            {
                if (color == "blanco")
                {
                    BtnB8.BackColor = Color.White;
                }
                else
                {
                    BtnB8.BackColor = Color.Black;
                }
            }

            //para C
            if (coordenada == "C-1")
            {
                if (color == "blanco")
                {
                    BtnC1.BackColor = Color.White;
                }
                else
                {
                    BtnC1.BackColor = Color.Black;
                }
            }

            if (coordenada == "C-2")
            {
                if (color == "blanco")
                {
                    BtnC2.BackColor = Color.White;
                }
                else
                {
                    BtnC2.BackColor = Color.Black;
                }
            }

            if (coordenada == "C-3")
            {
                if (color == "blanco")
                {
                    BtnC3.BackColor = Color.White;
                }
                else
                {
                    BtnC3.BackColor = Color.Black;
                }
            }
            if (coordenada == "C-4")
            {
                if (color == "blanco")
                {
                    BtnC4.BackColor = Color.White;
                }
                else
                {
                    BtnC4.BackColor = Color.Black;
                }
            }
            if (coordenada == "C-5")
            {
                if (color == "blanco")
                {
                    BtnC5.BackColor = Color.White;
                }
                else
                {
                    BtnC5.BackColor = Color.Black;
                }
            }
            if (coordenada == "C-6")
            {
                if (color == "blanco")
                {
                    BtnC6.BackColor = Color.White;
                }
                else
                {
                    BtnC6.BackColor = Color.Black;
                }
            }
            if (coordenada == "C-7")
            {
                if (color == "blanco")
                {
                    BtnC7.BackColor = Color.White;
                }
                else
                {
                    BtnC7.BackColor = Color.Black;
                }
            }
            if (coordenada == "C-8")
            {
                if (color == "blanco")
                {
                    BtnC8.BackColor = Color.White;
                }
                else
                {
                    BtnC8.BackColor = Color.Black;
                }
            }

            //para D
            if (coordenada == "D-1")
            {
                if (color == "blanco")
                {
                    BtnD1.BackColor = Color.White;
                }
                else
                {
                    BtnD1.BackColor = Color.Black;
                }
            }

            if (coordenada == "D-2")
            {
                if (color == "blanco")
                {
                    BtnD2.BackColor = Color.White;
                }
                else
                {
                    BtnD2.BackColor = Color.Black;
                }
            }

            if (coordenada == "D-3")
            {
                if (color == "blanco")
                {
                    BtnD3.BackColor = Color.White;
                }
                else
                {
                    BtnD3.BackColor = Color.Black;
                }
            }
            if (coordenada == "D-4")
            {
                if (color == "blanco")
                {
                    BtnD4.BackColor = Color.White;
                }
                else
                {
                    BtnD4.BackColor = Color.Black;
                }
            }
            if (coordenada == "D-5")
            {
                if (color == "blanco")
                {
                    BtnD5.BackColor = Color.White;
                }
                else
                {
                    BtnD5.BackColor = Color.Black;
                }
            }
            if (coordenada == "D-6")
            {
                if (color == "blanco")
                {
                    BtnD6.BackColor = Color.White;
                }
                else
                {
                    BtnD6.BackColor = Color.Black;
                }
            }
            if (coordenada == "D-7")
            {
                if (color == "blanco")
                {
                    BtnD7.BackColor = Color.White;
                }
                else
                {
                    BtnD7.BackColor = Color.Black;
                }
            }
            if (coordenada == "D-8")
            {
                if (color == "blanco")
                {
                    BtnD8.BackColor = Color.White;
                }
                else
                {
                    BtnD8.BackColor = Color.Black;
                }
            }

            //para E
            if (coordenada == "E-1")
            {
                if (color == "blanco")
                {
                    BtnE1.BackColor = Color.White;
                }
                else
                {
                    BtnE1.BackColor = Color.Black;
                }
            }

            if (coordenada == "E-2")
            {
                if (color == "blanco")
                {
                    BtnE2.BackColor = Color.White;
                }
                else
                {
                    BtnE2.BackColor = Color.Black;
                }
            }

            if (coordenada == "E-3")
            {
                if (color == "blanco")
                {
                    BtnE3.BackColor = Color.White;
                }
                else
                {
                    BtnE3.BackColor = Color.Black;
                }
            }
            if (coordenada == "E-4")
            {
                if (color == "blanco")
                {
                    BtnE4.BackColor = Color.White;
                }
                else
                {
                    BtnE4.BackColor = Color.Black;
                }
            }
            if (coordenada == "E-5")
            {
                if (color == "blanco")
                {
                    BtnE5.BackColor = Color.White;
                }
                else
                {
                    BtnE5.BackColor = Color.Black;
                }
            }
            if (coordenada == "E-6")
            {
                if (color == "blanco")
                {
                    BtnE6.BackColor = Color.White;
                }
                else
                {
                    BtnE6.BackColor = Color.Black;
                }
            }
            if (coordenada == "E-7")
            {
                if (color == "blanco")
                {
                    BtnE7.BackColor = Color.White;
                }
                else
                {
                    BtnE7.BackColor = Color.Black;
                }
            }
            if (coordenada == "E-8")
            {
                if (color == "blanco")
                {
                    BtnE8.BackColor = Color.White;
                }
                else
                {
                    BtnE8.BackColor = Color.Black;
                }
            }

            //para F
            if (coordenada == "F-1")
            {
                if (color == "blanco")
                {
                    BtnF1.BackColor = Color.White;
                }
                else
                {
                    BtnF1.BackColor = Color.Black;
                }
            }

            if (coordenada == "F-2")
            {
                if (color == "blanco")
                {
                    BtnF2.BackColor = Color.White;
                }
                else
                {
                    BtnF2.BackColor = Color.Black;
                }
            }

            if (coordenada == "F-3")
            {
                if (color == "blanco")
                {
                    BtnF3.BackColor = Color.White;
                }
                else
                {
                    BtnF3.BackColor = Color.Black;
                }
            }
            if (coordenada == "F-4")
            {
                if (color == "blanco")
                {
                    BtnF4.BackColor = Color.White;
                }
                else
                {
                    BtnF4.BackColor = Color.Black;
                }
            }
            if (coordenada == "F-5")
            {
                if (color == "blanco")
                {
                    BtnF5.BackColor = Color.White;
                }
                else
                {
                    BtnF5.BackColor = Color.Black;
                }
            }
            if (coordenada == "F-6")
            {
                if (color == "blanco")
                {
                    BtnF6.BackColor = Color.White;
                }
                else
                {
                    BtnF6.BackColor = Color.Black;
                }
            }
            if (coordenada == "F-7")
            {
                if (color == "blanco")
                {
                    BtnF7.BackColor = Color.White;
                }
                else
                {
                    BtnF7.BackColor = Color.Black;
                }
            }
            if (coordenada == "F-8")
            {
                if (color == "blanco")
                {
                    BtnF8.BackColor = Color.White;
                }
                else
                {
                    BtnF8.BackColor = Color.Black;

                }
            }

            //para G
            if (coordenada == "G-1")
            {
                if (color == "blanco")
                {
                    BtnG1.BackColor = Color.White;
                }
                else
                {
                    BtnG1.BackColor = Color.Black;
                }
            }

            if (coordenada == "G-2")
            {
                if (color == "blanco")
                {
                    BtnG2.BackColor = Color.White;
                }
                else
                {
                    BtnG2.BackColor = Color.Black;
                }
            }

            if (coordenada == "G-3")
            {
                if (color == "blanco")
                {
                    BtnG3.BackColor = Color.White;
                }
                else
                {
                    BtnG3.BackColor = Color.Black;
                }
            }
            if (coordenada == "G-4")
            {
                if (color == "blanco")
                {
                    BtnG4.BackColor = Color.White;
                }
                else
                {
                    BtnG4.BackColor = Color.Black;
                }
            }
            if (coordenada == "G-5")
            {
                if (color == "blanco")
                {
                    BtnG5.BackColor = Color.White;
                }
                else
                {
                    BtnG5.BackColor = Color.Black;
                }
            }
            if (coordenada == "G-6")
            {
                if (color == "blanco")
                {
                    BtnG6.BackColor = Color.White;
                }
                else
                {
                    BtnG6.BackColor = Color.Black;
                }
            }
            if (coordenada == "G-7")
            {
                if (color == "blanco")
                {
                    BtnG7.BackColor = Color.White;
                }
                else
                {
                    BtnG7.BackColor = Color.Black;
                }
            }
            if (coordenada == "G-8")
            {
                if (color == "blanco")
                {
                    BtnG8.BackColor = Color.White;
                }
                else
                {
                    BtnG8.BackColor = Color.Black;

                }
            }
            //para H
            if (coordenada == "H-1")
            {
                if (color == "blanco")
                {
                    BtnH1.BackColor = Color.White;
                }
                else
                {
                    BtnH1.BackColor = Color.Black;
                }
            }

            if (coordenada == "H-2")
            {
                if (color == "blanco")
                {
                    BtnH2.BackColor = Color.White;
                }
                else
                {
                    BtnH2.BackColor = Color.Black;
                }
            }

            if (coordenada == "H-3")
            {
                if (color == "blanco")
                {
                    BtnH3.BackColor = Color.White;
                }
                else
                {
                    BtnH3.BackColor = Color.Black;
                }
            }
            if (coordenada == "H-4")
            {
                if (color == "blanco")
                {
                    BtnH4.BackColor = Color.White;
                }
                else
                {
                    BtnH4.BackColor = Color.Black;
                }
            }
            if (coordenada == "H-5")
            {
                if (color == "blanco")
                {
                    BtnH5.BackColor = Color.White;
                }
                else
                {
                    BtnH5.BackColor = Color.Black;
                }
            }
            if (coordenada == "H-6")
            {
                if (color == "blanco")
                {
                    BtnH6.BackColor = Color.White;
                }
                else
                {
                    BtnH6.BackColor = Color.Black;
                }
            }
            if (coordenada == "H-7")
            {
                if (color == "blanco")
                {
                    BtnH7.BackColor = Color.White;
                }
                else
                {
                    BtnH7.BackColor = Color.Black;
                }
            }
            if (coordenada == "H-8")
            {
                if (color == "blanco")
                {
                    BtnH8.BackColor = Color.White;
                }
                else
                {
                    BtnH8.BackColor = Color.Black;

                }
            }


        }
        protected void BtnA1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true) {
                BtnA1.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            } else if(banderaNegra == true){
                BtnA1.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB1.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnB1.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }

        }

        protected void BtnC1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC1.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnC1.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnD1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD1.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnD1.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnE1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE1.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnE1.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF1.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnF1.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG1.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnG1.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnH1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH1.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnH1.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnA2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA2.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnA2.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB2.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnB2.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC2.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnC2.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnD2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD2.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnD2.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnE2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE2.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnE2.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF2.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnF2.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG2.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnG2.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnH2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH2.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnH2.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnA3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA3.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnA3.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB3.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnB3.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC3.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnC3.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnD3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD3.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnD3.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnE3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE3.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnE3.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF3.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnF3.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG3.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnG3.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnH3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH3.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnH3.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnA4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA4.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnA4.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB4.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnB4.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC4.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnC4.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnD4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD4.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnD4.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnE4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE4.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnE4.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF4.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnF4.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG4.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnG4.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnH4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH4.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnH4.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnA5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA5.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnA5.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB5.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnB5.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC5.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnC5.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnD5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD5.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnD5.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnE5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE5.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnE5.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF5.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnF5.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG5.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnG5.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnH5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH5.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnH5.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnA6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA6.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnA6.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB6.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnB6.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC6.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnC6.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnD6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD6.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnD6.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnE6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE6.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnE6.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF6.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnF6.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG6.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnG6.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnH6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH6.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnH6.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnA7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA7.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnA7.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB7.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnB7.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC7.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnC7.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnD7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD7.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnD7.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnE7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE7.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnE7.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF7.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnF7.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG7.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnG7.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnH7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH7.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnH7.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnA8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA8.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnA8.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB8.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnB8.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC8.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnC8.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnD8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD8.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnD8.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnE8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE8.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnE8.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF8.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnF8.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG8.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnG8.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnH8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH8.BackColor = Color.White;
                banderaBlanca = false;
                banderaNegra = true;
            }
            else if (banderaNegra == true)
            {
                BtnH8.BackColor = Color.Black;
                banderaNegra = false;
                banderaBlanca = true;
            }
        }
    }
}