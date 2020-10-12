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
using System.Collections;
using Antlr.Runtime.Tree;
using System.Web.SessionState;

namespace PROYECTO1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static bool activacionMaqina = false;
        public static bool banderaNegra = false; // false para el negro, al inicio no se ha seleccionado nada xd
        public static bool banderaBlanca = false; // false para el blanco
        public static bool banderaFicha = false;
        public static bool banderaTiro = false;
        public static bool banderaGeneral = true;
       
        public static string columna;
        public static string fila;
        public static string color;
        public static string colorTiro;
        public static int contador = 0;
        public ArrayList arrayFila = new ArrayList();
        public ArrayList arrayColumna = new ArrayList();
        public ArrayList arrayColor = new ArrayList();
        public static string[,] tablero = new string[8, 8];
        public static Button[,] boton = new Button[8, 8];

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                banderaBlanca = false;
                banderaNegra = false;
            }
            if (!IsPostBack)
            {
                tablero[3, 3] = "O";
                tablero[3, 4] = "X";
                tablero[4, 3] = "X";
                tablero[4, 4] = "O";
            }

            if (!IsPostBack)
            {


                boton[0, 0] = BtnA1;
                boton[0, 1] = BtnB1;
                boton[0, 2] = BtnC1;
                boton[0, 3] = BtnD1;
                boton[0, 4] = BtnE1;
                boton[0, 5] = BtnF1;
                boton[0, 6] = BtnG1;
                boton[0, 7] = BtnH1;

                boton[1, 0] = BtnA2;
                boton[1, 1] = BtnB2;
                boton[1, 2] = BtnC2;
                boton[1, 3] = BtnD2;
                boton[1, 4] = BtnE2;
                boton[1, 5] = BtnF2;
                boton[1, 6] = BtnG2;
                boton[1, 7] = BtnH2;

                boton[2, 0] = BtnA3;
                boton[2, 1] = BtnB3;
                boton[2, 2] = BtnC3;
                boton[2, 3] = BtnD3;
                boton[2, 4] = BtnE3;
                boton[2, 5] = BtnF3;
                boton[2, 6] = BtnG3;
                boton[2, 7] = BtnH3;

                boton[3, 0] = BtnA4;
                boton[3, 1] = BtnB4;
                boton[3, 2] = BtnC4;
                boton[3, 3] = BtnD4;
                boton[3, 4] = BtnE4;
                boton[3, 5] = BtnF4;
                boton[3, 6] = BtnG4;
                boton[3, 7] = BtnH4;

                boton[4, 0] = BtnA5;
                boton[4, 1] = BtnB5;
                boton[4, 2] = BtnC5;
                boton[4, 3] = BtnD5;
                boton[4, 4] = BtnE5;
                boton[4, 5] = BtnF5;
                boton[4, 6] = BtnG5;
                boton[4, 7] = BtnH5;

                boton[5, 0] = BtnA6;
                boton[5, 1] = BtnB6;
                boton[5, 2] = BtnC6;
                boton[5, 3] = BtnD6;
                boton[5, 4] = BtnE6;
                boton[5, 5] = BtnF6;
                boton[5, 6] = BtnG6;
                boton[5, 7] = BtnH6;

                boton[6, 0] = BtnA7;
                boton[6, 1] = BtnB7;
                boton[6, 2] = BtnC7;
                boton[6, 3] = BtnD7;
                boton[6, 4] = BtnE7;
                boton[6, 5] = BtnF7;
                boton[6, 6] = BtnG7;
                boton[6, 7] = BtnH7;

                boton[7, 0] = BtnA8;
                boton[7, 1] = BtnB8;
                boton[7, 2] = BtnC8;
                boton[7, 3] = BtnD8;
                boton[7, 4] = BtnE8;
                boton[7, 5] = BtnF8;
                boton[7, 6] = BtnG8;
                boton[7, 7] = BtnH8;
            }

            if (!IsPostBack)
            {

                BtnD4.BackColor = Color.White;
                BtnE4.BackColor = Color.Black;
                BtnD5.BackColor = Color.Black;
                BtnE5.BackColor = Color.White;
               
            }

            if(!IsPostBack)
            {
                BtnA1.Enabled = false;
                BtnA2.Enabled = false;
                BtnA3.Enabled = false;
                BtnA4.Enabled = false;
                BtnA5.Enabled = false;
                BtnA6.Enabled = false;
                BtnA7.Enabled = false;
                BtnA8.Enabled = false;

                BtnB1.Enabled = false;
                BtnB2.Enabled = false;
                BtnB3.Enabled = false;
                BtnB4.Enabled = false;
                BtnB5.Enabled = false;
                BtnB6.Enabled = false;
                BtnB7.Enabled = false;
                BtnB8.Enabled = false;

                BtnC1.Enabled = false;
                BtnC2.Enabled = false;
                BtnC3.Enabled = false;
                BtnC4.Enabled = false;
                BtnC5.Enabled = false;
                BtnC6.Enabled = false;
                BtnC7.Enabled = false;
                BtnC8.Enabled = false;

                BtnD1.Enabled = false;
                BtnD2.Enabled = false;
                BtnD3.Enabled = false;
                BtnD4.Enabled = false;
                BtnD5.Enabled = false;
                BtnD6.Enabled = false;
                BtnD7.Enabled = false;
                BtnD8.Enabled = false;


                BtnE1.Enabled = false;
                BtnE2.Enabled = false;
                BtnE3.Enabled = false;
                BtnE4.Enabled = false;
                BtnE5.Enabled = false;
                BtnE6.Enabled = false;
                BtnE7.Enabled = false;
                BtnE8.Enabled = false;


                BtnF1.Enabled = false;
                BtnF2.Enabled = false;
                BtnF3.Enabled = false;
                BtnF4.Enabled = false;
                BtnF5.Enabled = false;
                BtnF6.Enabled = false;
                BtnF7.Enabled = false;
                BtnF8.Enabled = false;

                BtnG1.Enabled = false;
                BtnG2.Enabled = false;
                BtnG3.Enabled = false;
                BtnG4.Enabled = false;
                BtnG5.Enabled = false;
                BtnG6.Enabled = false;
                BtnG7.Enabled = false;
                BtnG8.Enabled = false;

                BtnH1.Enabled = false;
                BtnH2.Enabled = false;
                BtnH3.Enabled = false;
                BtnH4.Enabled = false;
                BtnH5.Enabled = false;
                BtnH6.Enabled = false;
                BtnH7.Enabled = false;
                BtnH8.Enabled = false;


                
            }
        }
       

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Opciones.aspx");
        }

        protected void ButtonCarga_Click1(object sender, EventArgs e)
        {
            try
            {
               
                string texto1 = TextBoxCarga.Text;
                
              

                XmlReader lector = XmlReader.Create(texto1);
                while (lector.Read())
                {
                    if (lector.IsStartElement())
                    {
                        string valor = lector.Name.ToString();

                        if (banderaGeneral == true)
                        {
                            if (valor == "ficha")
                            {
                                banderaGeneral = false;
                                banderaFicha = true;
                                continue;
                            }
                            else if (valor == "siguienteTiro")
                            {
                                banderaGeneral = false;
                                banderaTiro = true;
                                continue;
                            }
                        }

                        if (banderaFicha == true)
                        {
                            contador++;
                            if (valor == "color")
                            {
                                color = lector.ReadString();
                            }
                            else if (valor == "columna")
                            {
                                columna = lector.ReadString();
                            }
                            else if (valor == "fila")
                            {
                                fila = lector.ReadString(); 
                            }
                            if (contador == 3)
                            {                             
                                cargarValores(color,columna,fila);  // para ingresar los datos en la matriz
                                contador = 0;
                                banderaGeneral = true;
                                banderaFicha = false;
                            }

                        }

                        if (banderaTiro == true)
                        {
                            if (valor == "color")
                            {
                                colorTiro = lector.ReadString();
                                colorTiro = colorTiro.Replace(" ", "");
                                
                                if (colorTiro == "blanco")
                                {
                                   
                                    banderaNegra = false;
                                    banderaBlanca = true;

                                    banderaGeneral = true;
                                    banderaTiro = false;
                                }
                                else if (colorTiro == "negro")
                                {
                                   
                                    banderaNegra = true;
                                    banderaBlanca = false;

                                    banderaGeneral = true;
                                    banderaTiro = false;
                                }
                                
                            }
                        }



                    }
                }

                analizarMatriz();
                ingresarFichas();
                  
            }
            catch (Exception exc) {
                Response.Write("No se encontro el archivo"+exc);
            }
        }

        public void capturaFicha(int fila,int columna)
        {   //x,y
            int inicioFila = fila;
            int inicioColumna = columna;
            //for de izquierda
            
        }

        public void maquinaBlanca()
        {

        }

        public void maquinaNegra()
        {

        }
        public void ingresarFichas()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string opcion = i.ToString() + "-" + j.ToString();

                    switch (opcion)
                    {
                        case "0-0":
                            if (tablero[i, j] == "O")
                            {
                                BtnA1.BackColor = Color.White;
                            }
                            else if(tablero[i,j]=="X")
                            {
                                BtnA1.BackColor = Color.Black;
                            }
                            break;
                        case "1-0":
                            if (tablero[i, j] == "O")
                            {
                                BtnA2.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnA2.BackColor = Color.Black;
                            }
                            break;
                        case "2-0":
                            if (tablero[i, j] == "O")
                            {
                                BtnA3.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnA3.BackColor = Color.Black;
                            }
                            break;
                        case "3-0":
                            if (tablero[i, j] == "O")
                            {
                                BtnA4.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnA4.BackColor = Color.Black;
                            }
                            break;
                        case "4-0":
                            if (tablero[i, j] == "O")
                            {
                                BtnA5.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnA5.BackColor = Color.Black;
                            }
                            break;
                        case "5-0":
                            if (tablero[i, j] == "O")
                            {
                                BtnA6.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnA6.BackColor = Color.Black;
                            }
                            break;
                        case "6-0":
                            if (tablero[i, j] == "O")
                            {
                                BtnA7.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnA7.BackColor = Color.Black;
                            }
                            break;
                        case "7-0":
                            if (tablero[i, j] == "O")
                            {
                                BtnA8.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnA8.BackColor = Color.Black;
                            }
                            break;
                        case "0-1":
                            if (tablero[i, j] == "O")
                            {
                                BtnB1.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnB1.BackColor = Color.Black;
                            }
                            break;
                        case "1-1":
                            if (tablero[i, j] == "O")
                            {
                                BtnB2.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnB2.BackColor = Color.Black;
                            }
                            break;
                        case "2-1":
                            if (tablero[i, j] == "O")
                            {
                                BtnB3.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnB3.BackColor = Color.Black;
                            }
                            break;
                        case "3-1":
                            if (tablero[i, j] == "O")
                            {
                                BtnB4.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnB4.BackColor = Color.Black;
                            }
                            break;
                        case "4-1":
                            if (tablero[i, j] == "O")
                            {
                                BtnB5.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnB5.BackColor = Color.Black;
                            }
                            break;
                        case "5-1":
                            if (tablero[i, j] == "O")
                            {
                                BtnB6.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnB6.BackColor = Color.Black;
                            }
                            break;
                        case "6-1":
                            if (tablero[i, j] == "O")
                            {
                                BtnB7.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnB7.BackColor = Color.Black;
                            }
                            break;
                        case "7-1":
                            if (tablero[i, j] == "O")
                            {
                                BtnB8.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnB8.BackColor = Color.Black;
                            }
                            break;
                        case "0-2":
                            if (tablero[i, j] == "O")
                            {
                                BtnC1.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnC1.BackColor = Color.Black;
                            }
                            break;
                        case "1-2":
                            if (tablero[i, j] == "O")
                            {
                                BtnC2.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnC2.BackColor = Color.Black;
                            }
                            break;
                        case "2-2":
                            if (tablero[i, j] == "O")
                            {
                                BtnC3.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnC3.BackColor = Color.Black;
                            }
                            break;
                        case "3-2":
                            if (tablero[i, j] == "O")
                            {
                                BtnC4.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnC4.BackColor = Color.Black;
                            }
                            break;
                        case "4-2":
                            if (tablero[i, j] == "O")
                            {
                                BtnC5.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnC5.BackColor = Color.Black;
                            }
                            break;
                        case "5-2":
                            if (tablero[i, j] == "O")
                            {
                                BtnC6.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnC6.BackColor = Color.Black;
                            }
                            break;
                        case "6-2":
                            if (tablero[i, j] == "O")
                            {
                                BtnC7.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnC7.BackColor = Color.Black;
                            }
                            break;
                        case "7-2":
                            if (tablero[i, j] == "O")
                            {
                                BtnC8.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnC8.BackColor = Color.Black;
                            }
                            break;
                        case "0-3":
                            if (tablero[i, j] == "O")
                            {
                                BtnD1.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnD1.BackColor = Color.Black;
                            }
                            break;
                        case "1-3":
                            if (tablero[i, j] == "O")
                            {
                                BtnD2.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnD2.BackColor = Color.Black;
                            }
                            break;
                        case "2-3":
                            if (tablero[i, j] == "O")
                            {
                                BtnD3.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnD3.BackColor = Color.Black;
                            }
                            break;
                        case "3-3":
                            if (tablero[i, j] == "O")
                            {
                                BtnD4.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnD4.BackColor = Color.Black;
                            }
                            break;
                        case "4-3":
                            if (tablero[i, j] == "O")
                            {
                                BtnD5.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnD5.BackColor = Color.Black;
                            }
                            break;
                        case "5-3":
                            if (tablero[i, j] == "O")
                            {
                                BtnD6.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnD6.BackColor = Color.Black;
                            }
                            break;
                        case "6-3":
                            if (tablero[i, j] == "O")
                            {
                                BtnD7.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnD7.BackColor = Color.Black;
                            }
                            break;
                        case "7-3":
                            if (tablero[i, j] == "O")
                            {
                                BtnD8.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnD8.BackColor = Color.Black;
                            }
                            break;
                        case "0-4":
                            if (tablero[i, j] == "O")
                            {
                                BtnE1.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnE1.BackColor = Color.Black;
                            }
                            break;
                        case "1-4":
                            if (tablero[i, j] == "O")
                            {
                                BtnE2.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnE2.BackColor = Color.Black;
                            }
                            break;
                        case "2-4":
                            if (tablero[i, j] == "O")
                            {
                                BtnE3.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnE3.BackColor = Color.Black;
                            }
                            break;
                        case "3-4":
                            if (tablero[i, j] == "O")
                            {
                                BtnE4.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnE4.BackColor = Color.Black;
                            }
                            break;
                        case "4-4":
                            if (tablero[i, j] == "O")
                            {
                                BtnE5.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnE5.BackColor = Color.Black;
                            }
                            break;
                        case "5-4":
                            if (tablero[i, j] == "O")
                            {
                                BtnE6.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnE6.BackColor = Color.Black;
                            }
                            break;
                        case "6-4":
                            if (tablero[i, j] == "O")
                            {
                                BtnE7.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnE7.BackColor = Color.Black;
                            }
                            break;
                        case "7-4":
                            if (tablero[i, j] == "O")
                            {
                                BtnE8.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnE8.BackColor = Color.Black;
                            }
                            break;
                        case "0-5":
                            if (tablero[i, j] == "O")
                            {
                                BtnF1.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnF1.BackColor = Color.Black;
                            }
                            break;
                        case "1-5":
                            if (tablero[i, j] == "O")
                            {
                                BtnF2.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnF2.BackColor = Color.Black;
                            }
                            break;
                        case "2-5":
                            if (tablero[i, j] == "O")
                            {
                                BtnF3.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnF3.BackColor = Color.Black;
                            }
                            break;
                        case "3-5":
                            if (tablero[i, j] == "O")
                            {
                                BtnF4.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnF4.BackColor = Color.Black;
                            }
                            break;
                        case "4-5":
                            if (tablero[i, j] == "O")
                            {
                                BtnF5.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnF5.BackColor = Color.Black;
                            }
                            break;
                        case "5-5":
                            if (tablero[i, j] == "O")
                            {
                                BtnF6.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnF6.BackColor = Color.Black;
                            }
                            break;
                        case "6-5":
                            if (tablero[i, j] == "O")
                            {
                                BtnF7.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnF7.BackColor = Color.Black;
                            }
                            break;
                        case "7-5":
                            if (tablero[i, j] == "O")
                            {
                                BtnF8.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnF8.BackColor = Color.Black;
                            }
                            break;
                        case "0-6":
                            if (tablero[i, j] == "O")
                            {
                                BtnG1.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnG1.BackColor = Color.Black;
                            }
                            break;
                        case "1-6":
                            if (tablero[i, j] == "O")
                            {
                                BtnG2.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnG2.BackColor = Color.Black;
                            }
                            break;
                        case "2-6":
                            if (tablero[i, j] == "O")
                            {
                                BtnG3.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnG3.BackColor = Color.Black;
                            }
                            break;
                        case "3-6":
                            if (tablero[i, j] == "O")
                            {
                                BtnG4.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnG4.BackColor = Color.Black;
                            }
                            break;
                        case "4-6":
                            if (tablero[i, j] == "O")
                            {
                                BtnG5.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnG5.BackColor = Color.Black;
                            }
                            break;
                        case "5-6":
                            if (tablero[i, j] == "O")
                            {
                                BtnG6.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnG6.BackColor = Color.Black;
                            }
                            break;
                        case "6-6":
                            if (tablero[i, j] == "O")
                            {
                                BtnG7.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnG7.BackColor = Color.Black;
                            }
                            break;
                        case "7-6":
                            if (tablero[i, j] == "O")
                            {
                                BtnG8.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnG8.BackColor = Color.Black;
                            }
                            break;
                        case "0-7":
                            if (tablero[i, j] == "O")
                            {
                                BtnH1.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnH1.BackColor = Color.Black;
                            }
                            break;
                        case "1-7":
                            if (tablero[i, j] == "O")
                            {
                                BtnH2.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnH2.BackColor = Color.Black;
                            }
                            break;
                        case "2-7":
                            if (tablero[i, j] == "O")
                            {
                                BtnH3.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnH3.BackColor = Color.Black;
                            }
                            break;
                        case "3-7":
                            if (tablero[i, j] == "O")
                            {
                                BtnH4.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnH4.BackColor = Color.Black;
                            }
                            break;
                        case "4-7":
                            if (tablero[i, j] == "O")
                            {
                                BtnH5.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnH5.BackColor = Color.Black;
                            }
                            break;
                        case "5-7":
                            if (tablero[i, j] == "O")
                            {
                                BtnH6.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnH6.BackColor = Color.Black;
                            }
                            break;
                        case "6-7":
                            if (tablero[i, j] == "O")
                            {
                                BtnH7.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnH7.BackColor = Color.Black;
                            }
                            break;
                        case "7-7":
                            if (tablero[i, j] == "O")
                            {
                                BtnH8.BackColor = Color.White;
                            }
                            else if (tablero[i, j] == "X")
                            {
                                BtnH8.BackColor = Color.Black;
                            }
                            break;
                    }
                }
            }
        }

        //metodo que reciber los valores de la fichas y es ingresado a una matriz para despues
        //ser analizado si es válida
        public void cargarValores(string color, string col, string fil)
        {

            string coordenada = col + "-" + fil;

            //para A
            if (coordenada == "A-1")
            {
                if (color == "blanco")
                {
                   
                    tablero[0,0] = "O";
                }
                else if(color=="negro")
                {
                   
                    tablero[0, 0] = "X";
                }
            }

            if (coordenada == "A-2")
            {
                if (color == "blanco")
                {
                    
                    tablero[1, 0] = "O";
                }
                else if (color == "negro")
                {
                   
                    tablero[1, 0] = "X";
                }
            }

            if (coordenada == "A-3")
            {
                if (color == "blanco")
                {
                   
                    tablero[2, 0] = "O";
                }
                else if (color == "negro")
                {
                   
                    tablero[2, 0] = "X";
                }
            }
            if (coordenada == "A-4")
            {
                if (color == "blanco")
                {
                   
                    tablero[3, 0] = "O";
                }
                else if (color == "negro")
                {
                    
                    tablero[3, 0] = "X";
                }
            }
            if (coordenada == "A-5")
            {
                if (color == "blanco")
                {
                   
                    tablero[4, 0] = "O";
                }
                else if (color == "negro")
                {
                    
                    tablero[4, 0] = "X";
                }
            }
            if (coordenada == "A-6")
            {
                if (color == "blanco")
                {
                   
                    tablero[5, 0] = "O";
                }
                else if (color == "negro")
                {
                   
                    tablero[5, 0] = "X";
                }
            }
            if (coordenada == "A-7")
            {
                if (color == "blanco")
                {
                   
                    tablero[6, 0] = "O";
                }
                else if (color == "negro")
                {
                    tablero[6, 0] = "X";
                   
                }
            }
            if (coordenada == "A-8")
            {
                if (color == "blanco")
                {
                    tablero[7, 0] = "O";
                }
                else if (color == "negro")
                {
                    tablero[7, 0] = "X";
                }
            }

            //para B
            if (coordenada == "B-1")
            {
                if (color == "blanco")
                {
                    tablero[0, 1] = "O";
                }
                else if (color == "negro")
                {
                    tablero[0, 1] = "X";
                }
            }

            if (coordenada == "B-2")
            {
                if (color == "blanco")
                {
                    tablero[1, 1] = "O";
                }
                else if (color == "negro")
                {
                    tablero[1, 1] = "X";
                }
            }

            if (coordenada == "B-3")
            {
                if (color == "blanco")
                {
                    tablero[2, 1] = "O";
                }
                else if (color == "negro")
                {
                    tablero[2, 1] = "X";
                }
            }
            if (coordenada == "B-4")
            {
                if (color == "blanco")
                {
                    tablero[3, 1] = "O";
                }
                else if (color == "negro")
                {
                    tablero[3, 1] = "X";
                }
            }
            if (coordenada == "B-5")
            {
                if (color == "blanco")
                {
                    tablero[4, 1] = "O";
                }
                else if (color == "negro")
                {
                    tablero[4, 1] = "X";
                }
            }
            if (coordenada == "B-6")
            {
                if (color == "blanco")
                {
                    tablero[5, 1] = "O";
                }
                else if (color == "negro")
                {
                    tablero[5, 1] = "X";
                }
            }
            if (coordenada == "B-7")
            {
                if (color == "blanco")
                {
                    tablero[6, 1] = "O";
                }
                else if (color == "negro")
                {
                    tablero[6, 1] = "X";
                }
            }
            if (coordenada == "B-8")
            {
                if (color == "blanco")
                {
                    tablero[7, 1] = "O";
                }
                else if (color == "negro")
                {
                    tablero[7, 1] = "X";
                }
            }

            //para C
            if (coordenada == "C-1")
            {
                if (color == "blanco")
                {
                    tablero[0, 2] = "O";
                }
                else if (color == "negro")
                {
                    tablero[0, 2] = "X";
                }
            }

            if (coordenada == "C-2")
            {
                if (color == "blanco")
                {
                    tablero[1, 2] = "O";
                }
                else if (color == "negro")
                {
                    tablero[1, 2] = "X";
                }
            }

            if (coordenada == "C-3")
            {
                if (color == "blanco")
                {
                    tablero[2, 2] = "O";
                }
                else if (color == "negro")
                {
                    tablero[2, 2] = "X";
                }
            }
            if (coordenada == "C-4")
            {
                if (color == "blanco")
                {
                    tablero[3, 2] = "O";
                }
                else if (color == "negro")
                {
                    tablero[3, 2] = "X";
                }
            }
            if (coordenada == "C-5")
            {
                if (color == "blanco")
                {
                    tablero[4, 2] = "O";
                }
                else if (color == "negro")
                {
                    tablero[4, 2] = "X";
                }
            }
            if (coordenada == "C-6")
            {
                if (color == "blanco")
                {
                    tablero[5, 2] = "O";
                }
                else if (color == "negro")
                {
                    tablero[5, 2] = "X";
                }
            }
            if (coordenada == "C-7")
            {
                if (color == "blanco")
                {
                    tablero[6, 2] = "O";
                }
                else if (color == "negro")
                {
                    tablero[6, 2] = "X";
                }
            }
            if (coordenada == "C-8")
            {
                if (color == "blanco")
                {
                    tablero[7, 2] = "O";
                }
                else if (color == "negro")
                {
                    tablero[7, 2] = "X";
                }
            }

            //para D
            if (coordenada == "D-1")
            {
                if (color == "blanco")
                {
                    tablero[0, 3] = "O";
                }
                else if (color == "negro")
                {
                    tablero[0, 3] = "X";
                }
            }

            if (coordenada == "D-2")
            {
                if (color == "blanco")
                {
                    tablero[1, 3] = "O";
                }
                else if (color == "negro")
                {
                    tablero[1, 3] = "X";
                }
            }

            if (coordenada == "D-3")
            {
                if (color == "blanco")
                {
                    tablero[2, 3] = "O";
                }
                else if (color == "negro")
                {
                    tablero[2, 3] = "X";
                }
            }
            if (coordenada == "D-4")
            {
                if (color == "blanco")
                {
                    tablero[3, 3] = "O";
                }
                else if (color == "negro")
                {
                    tablero[3, 3] = "X";
                }
            }
            if (coordenada == "D-5")
            {
                if (color == "blanco")
                {
                    tablero[4, 3] = "O";
                }
                else if (color == "negro")
                {
                    tablero[4, 3] = "X";
                }
            }
            if (coordenada == "D-6")
            {
                if (color == "blanco")
                {
                    tablero[5, 3] = "O";
                }
                else if (color == "negro")
                {
                    tablero[5, 3] = "X";
                }
            }
            if (coordenada == "D-7")
            {
                if (color == "blanco")
                {
                    tablero[6, 3] = "O"; 
                }
                else if (color == "negro")
                {
                    tablero[6, 3] = "X";
                }
            }
            if (coordenada == "D-8")
            {
                if (color == "blanco")
                {
                    tablero[7, 3] = "O";
                }
                else if (color == "negro")
                {
                    tablero[7, 3] = "X";
                }
            }

            //para E
            if (coordenada == "E-1")
            {
                if (color == "blanco")
                {
                    tablero[0, 4] = "O";
                }
                else if (color == "negro")
                {
                    tablero[0, 4] = "X";
                }
            }

            if (coordenada == "E-2")
            {
                if (color == "blanco")
                {
                    tablero[1, 4] = "O";
                }
                else if (color == "negro")
                {
                    tablero[1, 4] = "X";
                }
            }

            if (coordenada == "E-3")
            {
                if (color == "blanco")
                {
                    tablero[2, 4] = "O";
                }
                else if (color == "negro")
                {
                    tablero[2, 4] = "X";
                }
            }
            if (coordenada == "E-4")
            {
                if (color == "blanco")
                {
                    tablero[3, 4] = "O";
                }
                else if (color == "negro")
                {
                    tablero[3, 4] = "X";
                }
            }
            if (coordenada == "E-5")
            {
                if (color == "blanco")
                {
                    tablero[4, 4] = "O";
                }
                else if (color == "negro")
                {
                    tablero[4, 4] = "X";
                }
            }
            if (coordenada == "E-6")
            {
                if (color == "blanco")
                {
                    tablero[5, 4] = "O";
                }
                else if (color == "negro")
                {
                    tablero[5, 4] = "X";
                }
            }
            if (coordenada == "E-7")
            {
                if (color == "blanco")
                {
                    tablero[6, 4] = "O";
                }
                else if (color == "negro")
                {
                    tablero[6, 4] = "X";
                }
            }
            if (coordenada == "E-8")
            {
                if (color == "blanco")
                {
                    tablero[7, 4] = "O";
                }
                else if (color == "negro")
                {
                    tablero[7, 4] = "X";
                }
            }

            //para F
            if (coordenada == "F-1")
            {
                if (color == "blanco")
                {
                    tablero[0, 5] = "O";
                }
                else if (color == "negro")
                {
                    tablero[0, 5] = "X";
                }
            }

            if (coordenada == "F-2")
            {
                if (color == "blanco")
                {
                    tablero[1, 5] = "O";
                }
                else if (color == "negro")
                {
                    tablero[1, 5] = "X";
                }
            }

            if (coordenada == "F-3")
            {
                if (color == "blanco")
                {
                    tablero[2, 5] = "O";
                }
                else if (color == "negro")
                {
                    tablero[2, 5] = "X";
                }
            }
            if (coordenada == "F-4")
            {
                if (color == "blanco")
                {
                    tablero[3, 5] = "O";
                }
                else if (color == "negro")
                {
                    tablero[3, 5] = "X";
                }
            }
            if (coordenada == "F-5")
            {
                if (color == "blanco")
                {
                    tablero[4, 5] = "O";
                }
                else if (color == "negro")
                {
                    tablero[4, 5] = "O";
                }
            }
            if (coordenada == "F-6")
            {
                if (color == "blanco")
                {
                    tablero[5, 5] = "O";
                }
                else if (color == "negro")
                {
                    tablero[5, 5] = "X";
                }
            }
            if (coordenada == "F-7")
            {
                if (color == "blanco")
                {
                    tablero[6, 5] = "O";
                }
                else if (color == "negro")
                {
                    tablero[6, 5] = "X";
                }
            }
            if (coordenada == "F-8")
            {
                if (color == "blanco")
                {
                    tablero[7, 5] = "O";
                }
                else if (color == "negro")
                {
                    tablero[7, 5] = "X";

                }
            }

            //para G
            if (coordenada == "G-1")
            {
                if (color == "blanco")
                {
                    tablero[0, 6] = "O";
                }
                else if (color == "negro")
                {
                    tablero[0, 6] = "X";
                }
            }

            if (coordenada == "G-2")
            {
                if (color == "blanco")
                {
                    tablero[1, 6] = "O";
                }
                else if (color == "negro")
                {
                    tablero[1, 6] = "X";
                }
            }

            if (coordenada == "G-3")
            {
                if (color == "blanco")
                {
                    tablero[2, 6] = "O";
                }
                else if (color == "negro")
                {
                    tablero[2, 6] = "X";
                }
            }
            if (coordenada == "G-4")
            {
                if (color == "blanco")
                {
                    tablero[3, 6] = "O";
                }
                else if (color == "negro")
                {
                    tablero[3, 6] = "X";
                }
            }
            if (coordenada == "G-5")
            {
                if (color == "blanco")
                {
                    tablero[4, 6] = "O";
                }
                else if (color == "negro")
                {
                    tablero[4, 6] = "X";
                }
            }
            if (coordenada == "G-6")
            {
                if (color == "blanco")
                {
                    tablero[5, 6] = "O";
                }
                else if (color == "negro")
                {
                    tablero[5, 6] = "X"; 
                }
            }
            if (coordenada == "G-7")
            {
                if (color == "blanco")
                {
                    tablero[6, 6] = "O";
                }
                else if (color == "negro")
                {
                    tablero[6, 6] = "X";
                }
            }
            if (coordenada == "G-8")
            {
                if (color == "blanco")
                {
                    tablero[7, 6] = "O";
                }
                else if (color == "negro")
                {
                    tablero[7, 6] = "X";

                }
            }
            //para H
            if (coordenada == "H-1")
            {
                if (color == "blanco")
                {
                    tablero[0, 7] = "O";
                }
                else if (color == "negro")
                {
                    tablero[0, 7] = "X";
                }
            }

            if (coordenada == "H-2")
            {
                if (color == "blanco")
                {
                    tablero[1, 7] = "O";
                }
                else if (color == "negro")
                {
                    tablero[1, 7] = "X";
                }
            }

            if (coordenada == "H-3")
            {
                if (color == "blanco")
                {
                    tablero[2, 7] = "O";
                }
                else if (color == "negro")
                {
                    tablero[2, 7] = "X";
                }
            }
            if (coordenada == "H-4")
            {
                if (color == "blanco")
                {
                    tablero[3, 7] = "O";
                }
                else if (color == "negro")
                {
                    tablero[3, 7] = "X";
                }
            }
            if (coordenada == "H-5")
            {
                if (color == "blanco")
                {
                    tablero[4, 7] = "O";
                }
                else if (color == "negro")
                {
                    tablero[4, 7] = "X";
                }
            }
            if (coordenada == "H-6")
            {
                if (color == "blanco")
                {
                    tablero[5, 7] = "O";
                }
                else if (color == "negro")
                {
                    tablero[5, 7] = "X";
                }
            }
            if (coordenada == "H-7")
            {
                if (color == "blanco")
                {
                    tablero[6, 7] = "O";
                }
                else if (color == "negro")
                {
                    tablero[6, 7] = "X";
                }
            }
            if (coordenada == "H-8")
            {
                if (color == "blanco")
                {
                    tablero[7, 7] = "O";
                }
                else if (color == "negro")
                {
                    tablero[7, 7] = "X";

                }
            }


        }

        //metodo para analizar las fichas ingresados en la matriz
        public void analizarMatriz() {

            for (int i = 0; i < 8; i++)
            { 
                for(int j =0; j < 8; j++)
                {
                    if (tablero[i, j] == "O") // si en el boton hay una ficha y es  O = blanco
                    {                   //fila                //columna        convertidos en string para opcion(switch)
                        string opcion = i.ToString() + "-" + j.ToString(); // cada indice es obtenido para realizar las validaciones
                        switch (opcion)
                        {   // casos que son las posiciones de los botones
                            case "0-0":
                                //solo para O=blanco
                                //0,1                         1,0                     1,1
                                if (tablero[i, j + 1] == "0" || tablero[i + 1, j] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {    // si no hay nada al lado se borra se ficha
                                    tablero[i,j] = "";
                                }
                                        break;
                                
                            case "0-1":
                                if (tablero[i, j-1] == "O" || tablero[i,j+1]=="O" || tablero[i+1,j]=="O" || tablero[i+1,j-1]=="O" || tablero[i+1,j+1]=="O")
                                {
                                    continue;
                                }
                                else if(tablero[i, j - 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "0-2":
                                if (tablero[i, j - 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "0-3":
                                if (tablero[i, j - 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "0-4":
                                if (tablero[i, j - 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "0-5":
                                if (tablero[i, j - 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "0-6":
                                if (tablero[i, j - 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "0-7":
                                if(tablero[i,j-1]=="O" || tablero[i+1,j-1]=="O" || tablero[i+1,j]=="O")
                                {
                                    continue;
                                }
                                else if(tablero[i, j - 1] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "1-0": // columnas de 0
                                if(tablero[i-1,j]=="O" ||tablero[i-1,j+1]=="O" || tablero[i,j+1]=="O" || tablero[i+1,j+1]=="O" || tablero[i+1,j]=="O")
                                {
                                    continue;
                                }
                                else if(tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;

                            case "1-1": // todos los lados

                                if(tablero[i-1,j]=="O" ||  tablero[i-1,j+1]=="O" || tablero[i, j+1] == "O" || tablero[i+1, j+1] == "O" || tablero[i+1, j] == "O" || tablero[i+1, j-1] == "O" || tablero[i, j-1] == "O" || tablero[i-1, j-1] == "O")
                                {
                                    continue;
                                }
                                else if(tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "1-2":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "1-3":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "1-4":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "1-5":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "1-6":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "1-7":
                                if(tablero[i-1,j]=="O" || tablero[i-1,j-1]=="O" || tablero[i,j-1]=="O" || tablero[i+1,j-1]=="O" || tablero[i+1,j+1]=="O")
                                {
                                    continue;
                                }
                                else if(tablero[i - 1, j] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "2-0":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                                
                            case "2-1":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "2-2":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "2-3":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "2-4":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "2-5":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "2-6":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "2-7":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "3-0":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                                
                            case "3-1":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "3-2":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "3-3":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "3-4":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "3-5":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "3-6":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "3-7":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "4-0":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                                
                            case "4-1":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "4-2":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "4-3":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "4-4":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "4-5":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "4-6":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "4-7":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "5-0":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                                
                            case "5-1":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "5-2":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "5-3":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "5-4":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "5-5":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "5-6":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "5-7":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "6-0":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                                
                            case "6-1":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "6-2":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "6-3":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "6-4":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "6-5":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "6-6":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "6-7":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-0": //esquina 3
                                if(tablero[i-1,j]=="O" || tablero[i-1,j+1]=="O" || tablero[i,j+1]=="O")
                                {
                                    continue;
                                }
                                else if(tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-1":
                                if(tablero[i,j-1]=="O" || tablero[i-1,j-1]=="O" || tablero[i-1,j]=="O" || tablero[i-1,j+1]=="O"|| tablero[i,j+1]=="O")
                                {
                                    continue;
                                }
                                else if(tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-2":
                                if (tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-3":
                                if (tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-4":
                                if (tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-5":
                                if (tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-6":
                                if (tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-7":
                                if(tablero[i,j-1]=="O" || tablero[i-1,j-1]=="O" || tablero[i-1,j]=="O")
                                {
                                    continue;
                                }
                                else if(tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i - 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            
                        }
                    }
                    else if (tablero[i, j] == "X") // si en el boton hay una ficha y es X=negro
                    {
                        string opcion = i.ToString() + "-" + j.ToString(); // cada indice es obtenido para realizar las validaciones
                        switch (opcion)
                        {   // casos que son las posiciones de los botones
                            case "0-0":
                                //solo para O=blanco
                                //0,1                         1,0                     1,1
                                if (tablero[i, j + 1] == "0" || tablero[i + 1, j] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {    // si no hay nada al lado se borra se ficha
                                    tablero[i, j] = "";
                                }
                                break;

                            case "0-1":
                                if (tablero[i, j - 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "0-2":
                                if (tablero[i, j - 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "0-3":
                                if (tablero[i, j - 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "0-4":
                                if (tablero[i, j - 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "0-5":
                                if (tablero[i, j - 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "0-6":
                                if (tablero[i, j - 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "0-7":
                                if (tablero[i, j - 1] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "1-0": // columnas de 0
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;

                            case "1-1": // todos los lados

                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "1-2":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "1-3":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "1-4":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "1-5":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "1-6":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "1-7":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "2-0":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;

                            case "2-1":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "2-2":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "2-3":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "2-4":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "2-5":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "2-6":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "2-7":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "3-0":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;

                            case "3-1":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "3-2":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "3-3":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "3-4":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "3-5":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "3-6":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "3-7":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "4-0":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;

                            case "4-1":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "4-2":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "4-3":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "4-4":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "4-5":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "4-6":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "4-7":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "5-0":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;

                            case "5-1":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "5-2":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "5-3":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "5-4":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "5-5":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "5-6":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "5-7":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "6-0":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;

                            case "6-1":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "6-2":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "6-3":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "6-4":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "6-5":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "6-6":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O" || tablero[i + 1, j + 1] == "O" || tablero[i + 1, j] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X" || tablero[i + 1, j + 1] == "X" || tablero[i + 1, j] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "6-7":
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i, j - 1] == "O" || tablero[i + 1, j - 1] == "O" || tablero[i + 1, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i, j - 1] == "X" || tablero[i + 1, j - 1] == "X" || tablero[i + 1, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-0": //esquina 3
                                if (tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-1":
                                if (tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-2":
                                if (tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-3":
                                if (tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-4":
                                if (tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-5":
                                if (tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-6":
                                if (tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i - 1, j] == "O" || tablero[i - 1, j + 1] == "O" || tablero[i, j + 1] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i - 1, j] == "X" || tablero[i - 1, j + 1] == "X" || tablero[i, j + 1] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;
                            case "7-7":
                                if (tablero[i, j - 1] == "O" || tablero[i - 1, j - 1] == "O" || tablero[i - 1, j] == "O")
                                {
                                    continue;
                                }
                                else if (tablero[i, j - 1] == "X" || tablero[i - 1, j - 1] == "X" || tablero[i - 1, j] == "X")
                                {
                                    continue;
                                }
                                else
                                {
                                    tablero[i, j] = "";
                                }
                                break;

                        }

                    }
                }
                            
            }
        }

        public void obtenerValores(string color, string col,string fil) { 
        
            string coordenada = col+"-"+fil;
            
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
             
            } else if(banderaNegra == true){
                BtnA1.BackColor = Color.Black;
                
               
            }
        }

        protected void BtnB1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB1.BackColor = Color.White;
               
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
               
            }
            else if (banderaNegra == true)
            {
                BtnC1.BackColor = Color.Black;
                
            }
        }

        protected void BtnD1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD1.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnD1.BackColor = Color.Black;
                
            }
        }

        protected void BtnE1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE1.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnE1.BackColor = Color.Black;
               
            }
        }

        protected void BtnF1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF1.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnF1.BackColor = Color.Black;
               
            }
        }

        protected void BtnG1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG1.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnG1.BackColor = Color.Black;
               
            }
        }

        protected void BtnH1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH1.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnH1.BackColor = Color.Black;
                
            }
        }

        protected void BtnA2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA2.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnA2.BackColor = Color.Black;
                
            }
        }

        protected void BtnB2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB2.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnB2.BackColor = Color.Black;
               
            }
        }

        protected void BtnC2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC2.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnC2.BackColor = Color.Black;
               
            }
        }

        protected void BtnD2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD2.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnD2.BackColor = Color.Black;
                
            }
        }

        protected void BtnE2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE2.BackColor = Color.White;
              
            }
            else if (banderaNegra == true)
            {
                BtnE2.BackColor = Color.Black;
                
            }
        }

        protected void BtnF2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF2.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnF2.BackColor = Color.Black;
                
            }
        }

        protected void BtnG2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG2.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnG2.BackColor = Color.Black;
                
            }
        }

        protected void BtnH2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH2.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnH2.BackColor = Color.Black;
                
            }
        }

        protected void BtnA3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA3.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnA3.BackColor = Color.Black;
               
            }
        }

        protected void BtnB3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB3.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnB3.BackColor = Color.Black;
               
            }
        }

        protected void BtnC3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC3.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnC3.BackColor = Color.Black;
                
            }
        }

        protected void BtnD3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD3.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnD3.BackColor = Color.Black;
                
            }
        }

        protected void BtnE3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE3.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnE3.BackColor = Color.Black;
               
            }
        }

        protected void BtnF3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF3.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnF3.BackColor = Color.Black;
               
            }
        }

        protected void BtnG3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG3.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnG3.BackColor = Color.Black;
               
            }
        }

        protected void BtnH3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH3.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnH3.BackColor = Color.Black;
                
            }
        }

        protected void BtnA4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA4.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnA4.BackColor = Color.Black;
               
            }
        }

        protected void BtnB4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB4.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnB4.BackColor = Color.Black;
               
            }
        }

        protected void BtnC4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC4.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnC4.BackColor = Color.Black;
               
            }
        }

        protected void BtnD4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD4.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnD4.BackColor = Color.Black;
                
            }
        }

        protected void BtnE4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE4.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnE4.BackColor = Color.Black;
                
            }
        }

        protected void BtnF4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF4.BackColor = Color.White;
               
                
            }
            else if (banderaNegra == true)
            {
                BtnF4.BackColor = Color.Black;
               
                
            }
        }

        protected void BtnG4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG4.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnG4.BackColor = Color.Black;
               
            }
        }

        protected void BtnH4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH4.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnH4.BackColor = Color.Black;
                
            }
        }

        protected void BtnA5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA5.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnA5.BackColor = Color.Black;
               
            }
        }

        protected void BtnB5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB5.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnB5.BackColor = Color.Black;
                
            }
        }

        protected void BtnC5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC5.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnC5.BackColor = Color.Black;
                
            }
        }

        protected void BtnD5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD5.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnD5.BackColor = Color.Black;
               
            }
        }

        protected void BtnE5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE5.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnE5.BackColor = Color.Black;
                
            }
        }

        protected void BtnF5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF5.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnF5.BackColor = Color.Black;
                
            }
        }

        protected void BtnG5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG5.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnG5.BackColor = Color.Black;
               
            }
        }

        protected void BtnH5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH5.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnH5.BackColor = Color.Black;
               
            }
        }

        protected void BtnA6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA6.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnA6.BackColor = Color.Black;
               
            }
        }

        protected void BtnB6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB6.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnB6.BackColor = Color.Black;
                
            }
        }

        protected void BtnC6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC6.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnC6.BackColor = Color.Black;
               
            }
        }

        protected void BtnD6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD6.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnD6.BackColor = Color.Black;
               
            }
        }

        protected void BtnE6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE6.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnE6.BackColor = Color.Black;
                
            }
        }

        protected void BtnF6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF6.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnF6.BackColor = Color.Black;
               
            }
        }

        protected void BtnG6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG6.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnG6.BackColor = Color.Black;
                
            }
        }

        protected void BtnH6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH6.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnH6.BackColor = Color.Black;
               
            }
        }

        protected void BtnA7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA7.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnA7.BackColor = Color.Black;
               
            }
        }

        protected void BtnB7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB7.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnB7.BackColor = Color.Black;
                
            }
        }

        protected void BtnC7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC7.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnC7.BackColor = Color.Black;
               
            }
        }

        protected void BtnD7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD7.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnD7.BackColor = Color.Black;
                
            }
        }

        protected void BtnE7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE7.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnE7.BackColor = Color.Black;
                
            }
        }

        protected void BtnF7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF7.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnF7.BackColor = Color.Black;
               
            }
        }

        protected void BtnG7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG7.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnG7.BackColor = Color.Black;
               
            }
        }

        protected void BtnH7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH7.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnH7.BackColor = Color.Black;
               
            }
        }

        protected void BtnA8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA8.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnA8.BackColor = Color.Black;
               
            }
        }

        protected void BtnB8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB8.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnB8.BackColor = Color.Black;
               
            }
        }

        protected void BtnC8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC8.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnC8.BackColor = Color.Black;
               
            }
        }

        protected void BtnD8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD8.BackColor = Color.White;
                
            }
            else if (banderaNegra == true)
            {
                BtnD8.BackColor = Color.Black;
                
            }
        }

        protected void BtnE8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE8.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnE8.BackColor = Color.Black;
               
            }
        }

        protected void BtnF8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF8.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnF8.BackColor = Color.Black;
               
            }
        }

        protected void BtnG8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG8.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnG8.BackColor = Color.Black;
                
            }
        }

        protected void BtnH8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH8.BackColor = Color.White;
               
            }
            else if (banderaNegra == true)
            {
                BtnH8.BackColor = Color.Black;
               
            }
        }

        public void recorrerCuadros() {
            int opcion;

            for (opcion = 1; opcion <= 64; opcion++) {

                switch (opcion) {
                    case 1:
                        if (BtnA1.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("A");
                            arrayFila.Add("1");
                            
                        }
                        else if (BtnA1.BackColor == Color.Black) 
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("A");
                            arrayFila.Add("1");
                        }
                        break;
                    
                    case 2:
                        if (BtnA2.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("A");
                            arrayFila.Add("2");

                        }
                        else if (BtnA2.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("A");
                            arrayFila.Add("2");
                        }
                        break;
                    case 3:
                        if (BtnA3.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("A");
                            arrayFila.Add("3");

                        }
                        else if (BtnA3.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("A");
                            arrayFila.Add("3");
                        }
                        break;
                    case 4:
                        if (BtnA4.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("A");
                            arrayFila.Add("4");

                        }
                        else if (BtnA4.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("A");
                            arrayFila.Add("4");
                        }

                        break;
                    case 5:
                        if (BtnA5.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("A");
                            arrayFila.Add("5");

                        }
                        else if (BtnA5.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("A");
                            arrayFila.Add("5");
                        }

                        break;
                    case 6:
                        if (BtnA6.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("A");
                            arrayFila.Add("6");

                        }
                        else if (BtnA6.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("A");
                            arrayFila.Add("6");
                        }

                        break;
                    case 7:
                        if (BtnA7.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("A");
                            arrayFila.Add("7");

                        }
                        else if (BtnA7.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("A");
                            arrayFila.Add("7");
                        }
                        break;
                    case 8:
                         if (BtnA8.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("A");
                            arrayFila.Add("8");

                        }
                        else if (BtnA8.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("A");
                            arrayFila.Add("8");
                        }

                        break;
                    case 9:
                        if (BtnB1.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("B");
                            arrayFila.Add("1");

                        }
                        else if (BtnB1.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("B");
                            arrayFila.Add("1");
                        }
                        break;
                    case 10:
                        if (BtnB2.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("B");
                            arrayFila.Add("2");

                        }
                        else if (BtnB2.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("B");
                            arrayFila.Add("2");
                        }
                        break;
                    case 11:
                        if (BtnB3.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("B");
                            arrayFila.Add("3");

                        }
                        else if (BtnB3.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("B");
                            arrayFila.Add("3");
                        }

                        break;
                    case 12:
                        if (BtnB4.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("B");
                            arrayFila.Add("4");

                        }
                        else if (BtnB4.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("B");
                            arrayFila.Add("4");
                        }
                        break;
                    case 13:
                        if (BtnB5.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("B");
                            arrayFila.Add("5");

                        }
                        else if (BtnB5.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("B");
                            arrayFila.Add("5");
                        }
                        break;
                    case 14:
                        if (BtnB6.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("B");
                            arrayFila.Add("6");

                        }
                        else if (BtnB6.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("B");
                            arrayFila.Add("6");
                        }
                        break;

                    case 15:
                        if (BtnB7.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("B");
                            arrayFila.Add("7");

                        }
                        else if (BtnB7.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("B");
                            arrayFila.Add("7");
                        }
                        break;
                    case 16:
                        if (BtnB8.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("B");
                            arrayFila.Add("8");

                        }
                        else if (BtnB8.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("B");
                            arrayFila.Add("8");
                        }

                        break;
                    case 17:
                        if (BtnC1.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("C");
                            arrayFila.Add("1");

                        }
                        else if (BtnC1.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("C");
                            arrayFila.Add("1");
                        }

                        break;
                    case 18:
                        if (BtnC2.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("C");
                            arrayFila.Add("2");

                        }
                        else if (BtnC2.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("C");
                            arrayFila.Add("2");
                        }
                        break;
                    case 19:
                        if (BtnC3.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("C");
                            arrayFila.Add("3");

                        }
                        else if (BtnC3.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("C");
                            arrayFila.Add("3");
                        }
                        break;
                    case 20:
                        if (BtnC4.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("C");
                            arrayFila.Add("4");

                        }
                        else if (BtnC4.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("C");
                            arrayFila.Add("4");
                        }
                        break;
                    case 21:
                        if (BtnC5.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("C");
                            arrayFila.Add("5");

                        }
                        else if (BtnC5.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("C");
                            arrayFila.Add("5");
                        }
                        break;

                    case 22:
                        if (BtnC6.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("C");
                            arrayFila.Add("6");

                        }
                        else if (BtnC6.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("C");
                            arrayFila.Add("6");
                        }
                        break;
                    case 23:
                        if (BtnC7.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("C");
                            arrayFila.Add("7");

                        }
                        else if (BtnC7.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("C");
                            arrayFila.Add("7");
                        }
                        break;
                    case 24:
                        if (BtnC8.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("C");
                            arrayFila.Add("8");

                        }
                        else if (BtnC8.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("C");
                            arrayFila.Add("8");
                        }

                        break;
                    case 25:
                        if (BtnD1.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("D");
                            arrayFila.Add("1");

                        }
                        else if (BtnD1.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("D");
                            arrayFila.Add("1");
                        }
                        break;
                    case 26:
                        if (BtnD2.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("D");
                            arrayFila.Add("2");

                        }
                        else if (BtnD2.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("D");
                            arrayFila.Add("2");
                        }
                        break;
                    case 27:
                        if (BtnD3.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("D");
                            arrayFila.Add("3");

                        }
                        else if (BtnD3.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("D");
                            arrayFila.Add("3");
                        }
                        break;
                    case 28:
                        if (BtnD4.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("D");
                            arrayFila.Add("4");

                        }
                        else if (BtnD4.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("D");
                            arrayFila.Add("4");
                        }
                        break;
                    case 29:
                        if (BtnD5.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("D");
                            arrayFila.Add("5");

                        }
                        else if (BtnD5.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("D");
                            arrayFila.Add("5");
                        }
                        break;
                    case 30:
                        if (BtnD6.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("D");
                            arrayFila.Add("6");

                        }
                        else if (BtnD6.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("D");
                            arrayFila.Add("6");
                        }
                        break;
                    case 31:
                        if (BtnD7.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("D");
                            arrayFila.Add("7");

                        }
                        else if (BtnD7.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("D");
                            arrayFila.Add("7");
                        }
                        break;

                    case 32:
                        if (BtnD8.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("D");
                            arrayFila.Add("8");

                        }
                        else if (BtnD8.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("D");
                            arrayFila.Add("8");
                        }
                        break;
                    case 33:
                        if (BtnE1.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("E");
                            arrayFila.Add("1");

                        }
                        else if (BtnE1.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("E");
                            arrayFila.Add("1");
                        }
                        break;
                    case 34:
                        if (BtnE2.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("E");
                            arrayFila.Add("2");

                        }
                        else if (BtnE2.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("E");
                            arrayFila.Add("2");
                        }
                        break;
                    case 35:
                        if (BtnE3.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("E");
                            arrayFila.Add("3");

                        }
                        else if (BtnE3.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("E");
                            arrayFila.Add("3");
                        }

                        break;
                    case 36:
                        if (BtnE4.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("E");
                            arrayFila.Add("4");

                        }
                        else if (BtnE4.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("E");
                            arrayFila.Add("4");
                        }
                        break;
                    case 37:
                        if (BtnE5.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("E");
                            arrayFila.Add("5");

                        }
                        else if (BtnE5.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("E");
                            arrayFila.Add("5");
                        }
                        break;
                    case 38:
                        if (BtnE6.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("E");
                            arrayFila.Add("6");

                        }
                        else if (BtnE6.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("E");
                            arrayFila.Add("6");
                        }

                        break;
                    case 39:
                        if (BtnE7.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("E");
                            arrayFila.Add("7");

                        }
                        else if (BtnE7.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("E");
                            arrayFila.Add("7");
                        }
                        break;
                    case 40:
                        if (BtnE8.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("E");
                            arrayFila.Add("8");

                        }
                        else if (BtnE8.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("E");
                            arrayFila.Add("8");
                        }
                        break;
                    case 41:
                        if (BtnF1.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("F");
                            arrayFila.Add("1");

                        }
                        else if (BtnF1.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("F");
                            arrayFila.Add("1");
                        }
                        break;

                    case 42:
                        if (BtnF2.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("F");
                            arrayFila.Add("2");

                        }
                        else if (BtnF2.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("F");
                            arrayFila.Add("2");
                        }
                        break;
                    case 43:
                        if (BtnF3.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("F");
                            arrayFila.Add("3");

                        }
                        else if (BtnF3.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("F");
                            arrayFila.Add("3");
                        }
                        break;
                    case 44:
                        if (BtnF4.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("F");
                            arrayFila.Add("4");

                        }
                        else if (BtnF4.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("F");
                            arrayFila.Add("4");
                        }

                        break;
                    case 45:
                        if (BtnF5.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("F");
                            arrayFila.Add("5");

                        }
                        else if (BtnF5.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("F");
                            arrayFila.Add("5");
                        }

                        break;
                    case 46:
                        if (BtnF6.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("F");
                            arrayFila.Add("6");

                        }
                        else if (BtnF6.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("F");
                            arrayFila.Add("6");
                        }
                        break;
                    case 47:
                        if (BtnF7.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("F");
                            arrayFila.Add("7");

                        }
                        else if (BtnF7.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("F");
                            arrayFila.Add("7");
                        }
                        break;
                    case 48:
                        if (BtnF8.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("F");
                            arrayFila.Add("8");

                        }
                        else if (BtnF8.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("F");
                            arrayFila.Add("8");
                        }
                        break;
                    case 49:
                        if (BtnG1.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("G");
                            arrayFila.Add("1");

                        }
                        else if (BtnG1.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("G");
                            arrayFila.Add("1");
                        }

                        break;
                    case 50:
                        if (BtnG2.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("G");
                            arrayFila.Add("2");

                        }
                        else if (BtnG2.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("G");
                            arrayFila.Add("2");
                        }
                        break;
                    case 51:
                        if (BtnG3.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("G");
                            arrayFila.Add("3");

                        }
                        else if (BtnG3.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("G");
                            arrayFila.Add("3");
                        }

                        break;

                    case 52:
                        if (BtnG4.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("G");
                            arrayFila.Add("4");

                        }
                        else if (BtnG4.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("G");
                            arrayFila.Add("4");
                        }
                        break;
                    case 53:
                        if (BtnG5.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("G");
                            arrayFila.Add("5");

                        }
                        else if (BtnG5.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("G");
                            arrayFila.Add("5");
                        }

                        break;
                    case 54:
                        if (BtnG6.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("G");
                            arrayFila.Add("6");

                        }
                        else if (BtnG6.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("G");
                            arrayFila.Add("6");
                        }

                        break;
                    case 55:
                        if (BtnG7.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("G");
                            arrayFila.Add("7");

                        }
                        else if (BtnG7.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("G");
                            arrayFila.Add("7");
                        }
                        break;
                    case 56:
                        if (BtnG8.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("G");
                            arrayFila.Add("8");

                        }
                        else if (BtnG8.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("G");
                            arrayFila.Add("8");
                        }
                        break;
                    case 57:
                        if (BtnH1.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("H");
                            arrayFila.Add("1");

                        }
                        else if (BtnH1.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("H");
                            arrayFila.Add("1");
                        }
                        break;
                    case 58:
                        if (BtnH2.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("H");
                            arrayFila.Add("2");

                        }
                        else if (BtnH2.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("H");
                            arrayFila.Add("2");
                        }
                        break;
                    case 59:
                        if (BtnH3.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("H");
                            arrayFila.Add("3");

                        }
                        else if (BtnH3.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("H");
                            arrayFila.Add("3");
                        }

                        break;
                    case 60:
                        if (BtnH4.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("H");
                            arrayFila.Add("4");

                        }
                        else if (BtnH4.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("H");
                            arrayFila.Add("4");
                        }
                        break;
                    case 61:
                        if (BtnH5.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("H");
                            arrayFila.Add("5");

                        }
                        else if (BtnH5.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("H");
                            arrayFila.Add("5");
                        }

                        break;

                    case 62:
                        if (BtnH6.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("H");
                            arrayFila.Add("6");

                        }
                        else if (BtnH6.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("H");
                            arrayFila.Add("6");
                        }
                        break;
                    case 63:
                        if (BtnH7.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("H");
                            arrayFila.Add("7");

                        }
                        else if (BtnH7.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("H");
                            arrayFila.Add("7");
                        }
                        break;
                    case 64:
                        if (BtnH8.BackColor == Color.White)
                        {
                            arrayColor.Add("blanco");
                            arrayColumna.Add("H");
                            arrayFila.Add("8");

                        }
                        else if (BtnH8.BackColor == Color.Black)
                        {
                            arrayColor.Add("negro");
                            arrayColumna.Add("H");
                            arrayFila.Add("8");
                        }
                        break;
                    
                    

                }
            }
        }
        protected void ButtonDescarga_Click(object sender, EventArgs e)
        {
            recorrerCuadros();

            
                XmlDocument doc = new XmlDocument();
                XmlElement raiz = doc.CreateElement("tablero");
                doc.AppendChild(raiz);
            for (int i = 0; i < arrayColor.Count; i++)
            {
                

                XmlElement ficha = doc.CreateElement("ficha");
                raiz.AppendChild(ficha);

                XmlElement color = doc.CreateElement("color");
                color.AppendChild(doc.CreateTextNode(arrayColor[i].ToString()));
                ficha.AppendChild(color);

                XmlElement columna = doc.CreateElement("columna");
                columna.AppendChild(doc.CreateTextNode(arrayColumna[i].ToString()));
                ficha.AppendChild(columna);

                XmlElement fila = doc.CreateElement("fila");
                fila.AppendChild(doc.CreateTextNode(arrayFila[i].ToString()));
                ficha.AppendChild(fila);
            }

            doc.Save("C:\\Users\\MAGDIEL\\Desktop\\Pruebas\\PartidaGuardad.xml");
            
           
            
           
        }

        protected void ButtonSeleccionar_Click(object sender, EventArgs e)
        {
            string seleccion = DropDownListFicha.SelectedValue.ToString();
            if(seleccion=="O")
            {
                // el color es activado
                banderaBlanca = true;
                
                LabelTitulo.Text = "Jugador - Blanco";
                //se habilitan los botones para las blancas
                BtnF4.Enabled = true;
                BtnE3.Enabled = true;
                BtnC5.Enabled = true;
                BtnD6.Enabled = true;


            }
            else if(seleccion=="X")
            {
                // el color es activado
                banderaNegra = true;

                LabelTitulo.Text = "Jugador - Negro";
                // si habilitan los botoens para las negras
                BtnD3.Enabled = true;
                BtnC4.Enabled = true;
                BtnF5.Enabled = true;
                BtnE6.Enabled = true;

            }
        }

        protected void ButtonRandom_Click(object sender, EventArgs e)
        {
            Random aleatoria = new Random();
            int valor = aleatoria.Next(0, 2);

            if(valor == 0) //blanco
            {
                // el color es activado
                banderaBlanca = true;
                LabelTitulo.Text = "Jugador - Blanco";
                //se habilitan los botones para las blancas
                BtnF4.Enabled = true;
                BtnE3.Enabled = true;
                BtnC5.Enabled = true;
                BtnD6.Enabled = true;

            }
            else if(valor == 1) //negro
            {
                // el color es activado
                banderaNegra = true;
                LabelTitulo.Text = "Jugador - Negro";
                // si habilitan los botoens para las negras
                BtnD3.Enabled = true;
                BtnC4.Enabled = true;
                BtnF5.Enabled = true;
                BtnE6.Enabled = true;
            }
        }
    }
}