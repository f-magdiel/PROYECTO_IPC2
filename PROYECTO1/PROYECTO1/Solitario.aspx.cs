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
using System.Threading;

namespace PROYECTO1
{
    public partial class VersusUno : System.Web.UI.Page
    {
        //posiciones
        public static int posicionNegra = 1;
        public static int posicionBlanca = 1;

        //movimientos
        public static int movimientoGeneral = 0;
        public static int movimientoB = 0;
        public static int movimientoN = 0;
        public static string estadoPartida = "";
        public static int bloquesN = 0;
        public static int bloquesB = 0;

        public static bool sigo = true;
        public static int contadorEspacio = 0;
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
        public static Button[,] tableroColor = new Button[8, 8];
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



            tableroColor[0, 0] = BtnA1;
            tableroColor[0, 1] = BtnB1;
            tableroColor[0, 2] = BtnC1;
            tableroColor[0, 3] = BtnD1;
            tableroColor[0, 4] = BtnE1;
            tableroColor[0, 5] = BtnF1;
            tableroColor[0, 6] = BtnG1;
            tableroColor[0, 7] = BtnH1;

            tableroColor[1, 0] = BtnA2;
            tableroColor[1, 1] = BtnB2;
            tableroColor[1, 2] = BtnC2;
            tableroColor[1, 3] = BtnD2;
            tableroColor[1, 4] = BtnE2;
            tableroColor[1, 5] = BtnF2;
            tableroColor[1, 6] = BtnG2;
            tableroColor[1, 7] = BtnH2;

            tableroColor[2, 0] = BtnA3;
            tableroColor[2, 1] = BtnB3;
            tableroColor[2, 2] = BtnC3;
            tableroColor[2, 3] = BtnD3;
            tableroColor[2, 4] = BtnE3;
            tableroColor[2, 5] = BtnF3;
            tableroColor[2, 6] = BtnG3;
            tableroColor[2, 7] = BtnH3;

            tableroColor[3, 0] = BtnA4;
            tableroColor[3, 1] = BtnB4;
            tableroColor[3, 2] = BtnC4;
            tableroColor[3, 3] = BtnD4;
            tableroColor[3, 4] = BtnE4;
            tableroColor[3, 5] = BtnF4;
            tableroColor[3, 6] = BtnG4;
            tableroColor[3, 7] = BtnH4;

            tableroColor[4, 0] = BtnA5;
            tableroColor[4, 1] = BtnB5;
            tableroColor[4, 2] = BtnC5;
            tableroColor[4, 3] = BtnD5;
            tableroColor[4, 4] = BtnE5;
            tableroColor[4, 5] = BtnF5;
            tableroColor[4, 6] = BtnG5;
            tableroColor[4, 7] = BtnH5;

            tableroColor[5, 0] = BtnA6;
            tableroColor[5, 1] = BtnB6;
            tableroColor[5, 2] = BtnC6;
            tableroColor[5, 3] = BtnD6;
            tableroColor[5, 4] = BtnE6;
            tableroColor[5, 5] = BtnF6;
            tableroColor[5, 6] = BtnG6;
            tableroColor[5, 7] = BtnH6;

            tableroColor[6, 0] = BtnA7;
            tableroColor[6, 1] = BtnB7;
            tableroColor[6, 2] = BtnC7;
            tableroColor[6, 3] = BtnD7;
            tableroColor[6, 4] = BtnE7;
            tableroColor[6, 5] = BtnF7;
            tableroColor[6, 6] = BtnG7;
            tableroColor[6, 7] = BtnH7;

            tableroColor[7, 0] = BtnA8;
            tableroColor[7, 1] = BtnB8;
            tableroColor[7, 2] = BtnC8;
            tableroColor[7, 3] = BtnD8;
            tableroColor[7, 4] = BtnE8;
            tableroColor[7, 5] = BtnF8;
            tableroColor[7, 6] = BtnG8;
            tableroColor[7, 7] = BtnH8;


            if (!IsPostBack)
            {

                BtnD4.BackColor = Color.White;
                BtnE4.BackColor = Color.Black;
                BtnD5.BackColor = Color.Black;
                BtnE5.BackColor = Color.White;

            }

            if (!IsPostBack)
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

            if (!IsPostBack)
            {
                BtnA1.BackColor = Color.Green;
                BtnA2.BackColor = Color.Green;
                BtnA3.BackColor = Color.Green;
                BtnA4.BackColor = Color.Green;
                BtnA5.BackColor = Color.Green;
                BtnA6.BackColor = Color.Green;
                BtnA7.BackColor = Color.Green;
                BtnA8.BackColor = Color.Green;

                BtnB1.BackColor = Color.Green;
                BtnB2.BackColor = Color.Green;
                BtnB3.BackColor = Color.Green;
                BtnB4.BackColor = Color.Green;
                BtnB5.BackColor = Color.Green;
                BtnB6.BackColor = Color.Green;
                BtnB7.BackColor = Color.Green;
                BtnB8.BackColor = Color.Green;

                BtnC1.BackColor = Color.Green;
                BtnC2.BackColor = Color.Green;
                BtnC3.BackColor = Color.Green;
                BtnC4.BackColor = Color.Green;
                BtnC5.BackColor = Color.Green;
                BtnC6.BackColor = Color.Green;
                BtnC7.BackColor = Color.Green;
                BtnC8.BackColor = Color.Green;

                BtnD1.BackColor = Color.Green;
                BtnD2.BackColor = Color.Green;
                BtnD3.BackColor = Color.Green;


                BtnD6.BackColor = Color.Green;
                BtnD7.BackColor = Color.Green;
                BtnD8.BackColor = Color.Green;


                BtnE1.BackColor = Color.Green;
                BtnE2.BackColor = Color.Green;
                BtnE3.BackColor = Color.Green;


                BtnE6.BackColor = Color.Green;
                BtnE7.BackColor = Color.Green;
                BtnE8.BackColor = Color.Green;


                BtnF1.BackColor = Color.Green;
                BtnF2.BackColor = Color.Green;
                BtnF3.BackColor = Color.Green;
                BtnF4.BackColor = Color.Green;
                BtnF5.BackColor = Color.Green;
                BtnF6.BackColor = Color.Green;
                BtnF7.BackColor = Color.Green;
                BtnF8.BackColor = Color.Green;

                BtnG1.BackColor = Color.Green;
                BtnG2.BackColor = Color.Green;
                BtnG3.BackColor = Color.Green;
                BtnG4.BackColor = Color.Green;
                BtnG5.BackColor = Color.Green;
                BtnG6.BackColor = Color.Green;
                BtnG7.BackColor = Color.Green;
                BtnG8.BackColor = Color.Green;

                BtnH1.BackColor = Color.Green;
                BtnH2.BackColor = Color.Green;
                BtnH3.BackColor = Color.Green;
                BtnH4.BackColor = Color.Green;
                BtnH5.BackColor = Color.Green;
                BtnH6.BackColor = Color.Green;
                BtnH7.BackColor = Color.Green;
                BtnH8.BackColor = Color.Green;



            }
        }

        protected void ButtonRandom_Click(object sender, EventArgs e)
        {
            Random aleatoria = new Random();
            int valor = aleatoria.Next(0, 2);

            if (valor == 0) //blanco
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
            else if (valor == 1) //negro
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

        protected void ButtonSeleccionar_Click(object sender, EventArgs e)
        {
            ButtonSeleccionar.Text = "Seleccionado";
            string seleccion = DropDownListFicha.SelectedValue.ToString();
            if (seleccion == "O")
            {
                // el color es activado
                banderaBlanca = true;

                LabelTitulo.Text = "Se está jugando";
                //se habilitan los botones para las blancas


                BtnF4.Enabled = true;
                BtnE3.Enabled = true;
                BtnC5.Enabled = true;
                BtnD6.Enabled = true;


            }
            else if (seleccion == "X")
            {
                // el color es activado
                banderaNegra = true;

                LabelTitulo.Text = "Se está jugando";
                // si habilitan los botoens para las negras
                BtnD3.Enabled = true;
                BtnC4.Enabled = true;
                BtnF5.Enabled = true;
                BtnE6.Enabled = true;

            }
        }

        //BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB

        // para cuando se ficha blanca--------------------------------------------------------------------y
        public void capturaFichaBlanca(int fil, int column)
        {   //x,y
            int fila = fil;
            int columna = column;
            int posicion = 0;



            //direccion1
            //fila = cambia , columna = igual
            for (int i = fila - 1; i >= 0; i--) // para fila
            {
                if (tableroColor[i, columna].BackColor == Color.Black)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[i, columna].BackColor == Color.White)
                {
                    if (posicion >= 1)
                    {
                        pintarBlancoDireccion1(fila, i, columna);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //direccion2
            //fila=disminuye   columna = aumenta
            int filaContador = fila;
            for (int i = columna + 1; i <= 7; i++) // para columna
            {

                filaContador--;
                if (filaContador < 0)
                {
                    break;
                }
                if (tableroColor[filaContador, i].BackColor == Color.Black)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[filaContador, i].BackColor == Color.White)
                {

                    if (posicion >= 1)
                    {
                        pintarBlancoDireccion2(fila, columna, i);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }


                }


            }

            //direccion3
            //fila = fija, columna = aumenta
            for (int i = columna + 1; i <= 7; i++) // para columna 
            {
                if (tableroColor[fila, i].BackColor == Color.Black)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[fila, i].BackColor == Color.White)
                {

                    if (posicion >= 1)
                    {
                        pintarBlancoDireccion3(fila, columna, i);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }




                }
            }

            //direcion4
            //fila = aumenta  columna = aumenta
            int filadireccion4 = fila;
            for (int i = columna + 1; i <= 7; i++) // para columna
            {
                filadireccion4++;

                if (filadireccion4 >= 8) // fila >= 8 se sale del ciclo
                {
                    break;
                }
                if (tableroColor[filadireccion4, i].BackColor == Color.Black)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[filadireccion4, i].BackColor == Color.White)
                {

                    if (posicion >= 1)
                    {
                        pintarBlancoDireccion4(fila, columna, i);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }


                }


            }

            //direccion5
            //fila = aumenta   columna = fija
            for (int i = fila + 1; i <= 7; i++) // para fila
            {
                if (tableroColor[i, columna].BackColor == Color.Black)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[i, columna].BackColor == Color.White)
                {
                    if (posicion >= 1)
                    {
                        //metodo
                        pintarBlancoDireccion5(fila, i, columna);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }

                }
            }

            //Direccion6
            // fila = aumenta   columna = disminuye
            int columnadireccion6 = columna;
            for (int i = fila + 1; i <= 7; i++) // para fila
            {
                columnadireccion6--;
                if (columnadireccion6 < 0)
                {
                    break;
                }
                if (tableroColor[i, columnadireccion6].BackColor == Color.Black)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[i, columnadireccion6].BackColor == Color.White)
                {

                    if (posicion >= 1)
                    {
                        //metododireccion6
                        pintarBlancoDireccion6(fila, i, columna);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }


                }


            }

            //direccion7
            //fila = fija, columna = disminuye

            for (int i = columna - 1; i >= 0; i--) // columna
            {
                if (tableroColor[fila, i].BackColor == Color.Black)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[fila, i].BackColor == Color.White)
                {
                    if (posicion >= 1)
                    {

                        //metodo
                        pintarBlancoDireccion7(columna, i, fila);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
            }

            //direcion8
            // fila = disminuye, columna = diminuye
            int columnadireccion8 = columna;
            for (int i = fila - 1; i >= 0; i--) // fila
            {
                columnadireccion8--;
                if (columnadireccion8 < 0)
                {
                    break;
                }
                if (tableroColor[i, columnadireccion8].BackColor == Color.Black)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[i, columnadireccion8].BackColor == Color.White)
                {
                    if (posicion >= 1)
                    {
                        //metodod
                        pintarBlancoDireccion8(fila, i, columna);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }


                }



            }

        }
        //metodos que pinta, recibe valores para pintar ************************************************************
        public void pintarBlancoDireccion1(int filaInicio, int filaFin, int columna)
        {
            for (int i = filaInicio; i >= filaFin; i--)
            {
                tableroColor[i, columna].BackColor = Color.White;
            }
        }

        public void pintarBlancoDireccion2(int filaInicio, int columnaInicio, int columnaFin)
        {
            int fila = filaInicio;
            for (int i = columnaInicio; i <= columnaFin; i++)
            {
                tableroColor[fila, i].BackColor = Color.White;
                fila--;

            }
        }

        public void pintarBlancoDireccion3(int fila, int inicioColumna, int finColumna)
        {
            for (int i = inicioColumna; i <= finColumna; i++) //columna
            {
                tableroColor[fila, i].BackColor = Color.White;
            }
        }

        public void pintarBlancoDireccion4(int fila, int inicioColumna, int finColumna)
        {
            int filaInicio = fila;
            for (int i = inicioColumna; i <= finColumna; i++)
            {
                tableroColor[filaInicio, i].BackColor = Color.White;
                filaInicio++;
            }

        }

        public void pintarBlancoDireccion5(int filaInicio, int filaFin, int columna)
        {
            for (int i = filaInicio; i <= filaFin; i++)
            {
                tableroColor[i, columna].BackColor = Color.White;
            }
        }

        public void pintarBlancoDireccion6(int inicioFila, int finFila, int columna)
        {
            int columnadireccion = columna;
            for (int i = inicioFila; i <= finFila; i++)
            {
                tableroColor[i, columnadireccion].BackColor = Color.White;
                columnadireccion--;
            }
        }

        public void pintarBlancoDireccion7(int inicioColumna, int finColumna, int fila)
        {
            for (int i = inicioColumna; i >= finColumna; i--)
            {
                tableroColor[fila, i].BackColor = Color.White;
            }
        }

        public void pintarBlancoDireccion8(int inicioFila, int finFila, int columna)
        {
            int columnadireccion = columna;
            for (int i = inicioFila; i >= finFila; i--)
            {
                tableroColor[i, columnadireccion].BackColor = Color.White;
                columnadireccion--;
            }

        }

        //metodo para habilitar botones si soy blanco
        public void activacionBoton2(int fila, int columna)
        {
            int filaTemp = fila;
            int columnaTemp = columna;
            int contadorFicha = 0;


            //fila = disminuye  ------------->Direccion1

            for (int i = filaTemp - 1; i >= 0; i--)
            {
                if (tableroColor[i, columnaTemp].BackColor == Color.Black)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[i, columnaTemp].BackColor == Color.White)
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroColor[i, columnaTemp].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        //para habilitar boton
                        tableroColor[i, columnaTemp].Enabled = true;
                        tableroColor[i, columnaTemp].Text = "O";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;
                    }
                }
            }

            //fila = disminuye, columna = aumenta   ------------>Direccion2
            int auxColumnaD2 = columnaTemp; //fila
            for (int i = filaTemp - 1; i >= 0; i--)
            {
                auxColumnaD2++;
                if (auxColumnaD2 >= 8)
                {
                    break;
                }
                if (tableroColor[i, auxColumnaD2].BackColor == Color.Black)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[i, auxColumnaD2].BackColor == Color.White)
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroColor[i, auxColumnaD2].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        //para habilitar el boton
                        tableroColor[i, auxColumnaD2].Enabled = true;
                        tableroColor[i, auxColumnaD2].Text = "O";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;

                    }
                }


            }
            //fila = fija, columna= aumenta -----------> Direccion3
            int auxFilaD3 = filaTemp;
            for (int i = columna + 1; i <= 7; i++)
            {
                if (tableroColor[auxFilaD3, i].BackColor == Color.Black)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[auxFilaD3, i].BackColor == Color.White)
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroColor[auxFilaD3, i].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        //habilitar boton

                        tableroColor[auxFilaD3, i].Enabled = true;
                        tableroColor[auxFilaD3, i].Text = "O";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;
                    }
                }
            }

            //fila = aumenta, columna= aumenta  ---------------->Direccion4
            int auxFilaD4 = filaTemp;
            for (int i = columnaTemp + 1; i <= 7; i++) // columna
            {
                auxFilaD4++;
                if (auxFilaD4 >= 8)
                {
                    break;
                }
                if (tableroColor[auxFilaD4, i].BackColor == Color.Black)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[auxFilaD4, i].BackColor == Color.White)
                {
                    contadorFicha++;
                    continue;

                }
                else if (tableroColor[auxFilaD4, i].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        tableroColor[auxFilaD4, i].Enabled = true;
                        tableroColor[auxFilaD4, i].Text = "O";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;
                    }
                }
            }

            //fila = aumenta, columna = fija ---------------->Direccion5
            int auxColumnaD5 = columnaTemp;
            for (int i = filaTemp + 1; i <= 7; i++) //fila
            {
                if (tableroColor[i, auxColumnaD5].BackColor == Color.Black)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[i, auxColumnaD5].BackColor == Color.White)
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroColor[i, auxColumnaD5].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        tableroColor[i, auxColumnaD5].Enabled = true;
                        tableroColor[i, auxColumnaD5].Text = "O";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;
                    }
                }
            }

            //fila = aumenta, columna = disminuye -------------->Direccion6
            int auxFilaD6 = filaTemp;
            for (int i = columnaTemp - 1; i >= 0; i--) //columna
            {
                auxFilaD6++;
                if (auxFilaD6 >= 8)
                {
                    break;
                }
                if (tableroColor[auxFilaD6, i].BackColor == Color.Black)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[auxFilaD6, i].BackColor == Color.White)
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroColor[auxFilaD6, i].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        tableroColor[auxFilaD6, i].Enabled = true;
                        tableroColor[auxFilaD6, i].Text = "O";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;
                    }
                }
            }

            //fila = fija, columna = disminuye  --------------->Direccion7
            int auxFilaD7 = filaTemp;
            for (int i = columnaTemp - 1; i >= 0; i--) //columna
            {
                if (tableroColor[auxFilaD7, i].BackColor == Color.Black)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[auxFilaD7, i].BackColor == Color.White)
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroColor[auxFilaD7, i].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        tableroColor[auxFilaD7, i].Enabled = true;
                        tableroColor[auxFilaD7, i].Text = "O";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;
                    }

                }
            }

            //fila = disminuye, columna = disminuye ---------------->Direccion8
            int auxColumnaD8 = columnaTemp;
            for (int i = filaTemp - 1; i >= 0; i--) //fila
            {
                auxColumnaD8--;
                if (auxColumnaD8 < 0)
                {
                    break;
                }
                if (tableroColor[i, auxColumnaD8].BackColor == Color.Black)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[i, auxColumnaD8].BackColor == Color.White)
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroColor[i, auxColumnaD8].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        tableroColor[i, auxColumnaD8].Enabled = true;
                        tableroColor[i, auxColumnaD8].Text = "O";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;
                    }
                }
            }
        }

        //BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB


        //NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN

        // para cuando se ficha negra--------------------------------------------------------------------y
        public void capturaFichaNegra(int fil, int column)
        {   //x,y
            int fila = fil;
            int columna = column;
            int posicion = 0;



            //direccion1
            //fila = cambia , columna = igual
            for (int i = fila - 1; i >= 0; i--) // para fila
            {
                if (tableroColor[i, columna].BackColor == Color.White)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[i, columna].BackColor == Color.Black)
                {
                    if (posicion >= 1)
                    {
                        pintarNegroDireccion1(fila, i, columna);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //direccion2
            //fila=disminuye   columna = aumenta
            int filaContador = fila;
            for (int i = columna + 1; i <= 7; i++) // para columna
            {

                filaContador--;
                if (filaContador < 0)
                {
                    break;
                }
                if (tableroColor[filaContador, i].BackColor == Color.White)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[filaContador, i].BackColor == Color.Black)
                {

                    if (posicion >= 1)
                    {
                        pintarNegroDireccion2(fila, columna, i);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }


                }


            }

            //direccion3
            //fila = fija, columna = aumenta
            for (int i = columna + 1; i <= 7; i++) // para columna 
            {
                if (tableroColor[fila, i].BackColor == Color.White)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[fila, i].BackColor == Color.Black)
                {

                    if (posicion >= 1)
                    {
                        pintarNegroDireccion3(fila, columna, i);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }




                }
            }

            //direcion4
            //fila = aumenta  columna = aumenta
            int filadireccion4 = fila;
            for (int i = columna + 1; i <= 7; i++) // para columna
            {
                filadireccion4++;

                if (filadireccion4 >= 8) // fila >= 8 se sale del ciclo
                {
                    break;
                }
                if (tableroColor[filadireccion4, i].BackColor == Color.White)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[filadireccion4, i].BackColor == Color.Black)
                {

                    if (posicion >= 1)
                    {
                        pintarNegroDireccion4(fila, columna, i);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }


                }


            }

            //direccion5
            //fila = aumenta   columna = fija
            for (int i = fila + 1; i <= 7; i++) // para fila
            {
                if (tableroColor[i, columna].BackColor == Color.White)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[i, columna].BackColor == Color.Black)
                {
                    if (posicion >= 1)
                    {
                        //metodo
                        pintarNegroDireccion5(fila, i, columna);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }

                }
            }

            //Direccion6
            // fila = aumenta   columna = disminuye
            int columnadireccion6 = columna;
            for (int i = fila + 1; i <= 7; i++) // para fila
            {
                columnadireccion6--;
                if (columnadireccion6 < 0)
                {
                    break;
                }
                if (tableroColor[i, columnadireccion6].BackColor == Color.White)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[i, columnadireccion6].BackColor == Color.Black)
                {

                    if (posicion >= 1)
                    {
                        //metododireccion6
                        pintarNegroDireccion6(fila, i, columna);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }


                }


            }

            //direccion7
            //fila = fija, columna = disminuye

            for (int i = columna - 1; i >= 0; i--) // columna
            {
                if (tableroColor[fila, i].BackColor == Color.White)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[fila, i].BackColor == Color.Black)
                {
                    if (posicion >= 1)
                    {

                        //metodo
                        pintarNegroDireccion7(columna, i, fila);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
            }

            //direcion8
            // fila = disminuye, columna = diminuye
            int columnadireccion8 = columna;
            for (int i = fila - 1; i >= 0; i--) // fila
            {
                columnadireccion8--;
                if (columnadireccion8 < 0)
                {
                    break;
                }
                if (tableroColor[i, columnadireccion8].BackColor == Color.White)
                {
                    posicion++;
                    continue;
                }
                else if (tableroColor[i, columnadireccion8].BackColor == Color.Black)
                {
                    if (posicion >= 1)
                    {
                        //metodod
                        pintarNegroDireccion8(fila, i, columna);
                        posicion = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }


                }



            }

        }
        //metodos que pinta, recibe valores para pintar ************************************************************
        public void pintarNegroDireccion1(int filaInicio, int filaFin, int columna)
        {
            for (int i = filaInicio; i >= filaFin; i--)
            {
                tableroColor[i, columna].BackColor = Color.Black;
            }
        }

        public void pintarNegroDireccion2(int filaInicio, int columnaInicio, int columnaFin)
        {
            int fila = filaInicio;
            for (int i = columnaInicio; i <= columnaFin; i++)
            {
                tableroColor[fila, i].BackColor = Color.Black;
                fila--;

            }
        }

        public void pintarNegroDireccion3(int fila, int inicioColumna, int finColumna)
        {
            for (int i = inicioColumna; i <= finColumna; i++) //columna
            {
                tableroColor[fila, i].BackColor = Color.Black;
            }
        }

        public void pintarNegroDireccion4(int fila, int inicioColumna, int finColumna)
        {
            int filaInicio = fila;
            for (int i = inicioColumna; i <= finColumna; i++)
            {
                tableroColor[filaInicio, i].BackColor = Color.Black;
                filaInicio++;
            }

        }

        public void pintarNegroDireccion5(int filaInicio, int filaFin, int columna)
        {
            for (int i = filaInicio; i <= filaFin; i++)
            {
                tableroColor[i, columna].BackColor = Color.Black;
            }
        }

        public void pintarNegroDireccion6(int inicioFila, int finFila, int columna)
        {
            int columnadireccion = columna;
            for (int i = inicioFila; i <= finFila; i++)
            {
                tableroColor[i, columnadireccion].BackColor = Color.Black;
                columnadireccion--;
            }
        }

        public void pintarNegroDireccion7(int inicioColumna, int finColumna, int fila)
        {
            for (int i = inicioColumna; i >= finColumna; i--)
            {
                tableroColor[fila, i].BackColor = Color.Black;
            }
        }

        public void pintarNegroDireccion8(int inicioFila, int finFila, int columna)
        {
            int columnadireccion = columna;
            for (int i = inicioFila; i >= finFila; i--)
            {
                tableroColor[i, columnadireccion].BackColor = Color.Black;
                columnadireccion--;
            }

        }

        //metodo para habilitar botones si soy blanco
        public void activacionBoton1(int fila, int columna)
        {
            int filaTemp = fila;
            int columnaTemp = columna;
            int contadorFicha = 0;


            //fila = disminuye  ------------->Direccion1

            for (int i = filaTemp - 1; i >= 0; i--)
            {
                if (tableroColor[i, columnaTemp].BackColor == Color.White)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[i, columnaTemp].BackColor == Color.Black)
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroColor[i, columnaTemp].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        //para habilitar boton
                        tableroColor[i, columnaTemp].Enabled = true;
                        tableroColor[i, columnaTemp].Text = "X";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;
                    }
                }
            }

            //fila = disminuye, columna = aumenta   ------------>Direccion2
            int auxColumnaD2 = columnaTemp; //fila
            for (int i = filaTemp - 1; i >= 0; i--)
            {
                auxColumnaD2++;
                if (auxColumnaD2 >= 8)
                {
                    break;
                }
                if (tableroColor[i, auxColumnaD2].BackColor == Color.White)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[i, auxColumnaD2].BackColor == Color.Black)
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroColor[i, auxColumnaD2].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        //para habilitar el boton
                        tableroColor[i, auxColumnaD2].Enabled = true;
                        tableroColor[i, auxColumnaD2].Text = "X";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;

                    }
                }


            }
            //fila = fija, columna= aumenta -----------> Direccion3
            int auxFilaD3 = filaTemp;
            for (int i = columna + 1; i <= 7; i++)
            {
                if (tableroColor[auxFilaD3, i].BackColor == Color.White)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[auxFilaD3, i].BackColor == Color.Black)
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroColor[auxFilaD3, i].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        //habilitar boton

                        tableroColor[auxFilaD3, i].Enabled = true;
                        tableroColor[auxFilaD3, i].Text = "X";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;
                    }
                }
            }

            //fila = aumenta, columna= aumenta  ---------------->Direccion4
            int auxFilaD4 = filaTemp;
            for (int i = columnaTemp + 1; i <= 7; i++) // columna
            {
                auxFilaD4++;
                if (auxFilaD4 >= 8)
                {
                    break;
                }
                if (tableroColor[auxFilaD4, i].BackColor == Color.White)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[auxFilaD4, i].BackColor == Color.Black)
                {
                    contadorFicha++;
                    continue;

                }
                else if (tableroColor[auxFilaD4, i].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        tableroColor[auxFilaD4, i].Enabled = true;
                        tableroColor[auxFilaD4, i].Text = "X";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;
                    }
                }
            }

            //fila = aumenta, columna = fija ---------------->Direccion5
            int auxColumnaD5 = columnaTemp;
            for (int i = filaTemp + 1; i <= 7; i++) //fila
            {
                if (tableroColor[i, auxColumnaD5].BackColor == Color.White)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[i, auxColumnaD5].BackColor == Color.Black)
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroColor[i, auxColumnaD5].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        tableroColor[i, auxColumnaD5].Enabled = true;
                        tableroColor[i, auxColumnaD5].Text = "X";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;
                    }
                }
            }

            //fila = aumenta, columna = disminuye -------------->Direccion6
            int auxFilaD6 = filaTemp;
            for (int i = columnaTemp - 1; i >= 0; i--) //columna
            {
                auxFilaD6++;
                if (auxFilaD6 >= 8)
                {
                    break;
                }
                if (tableroColor[auxFilaD6, i].BackColor == Color.White)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[auxFilaD6, i].BackColor == Color.Black)
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroColor[auxFilaD6, i].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        tableroColor[auxFilaD6, i].Enabled = true;
                        tableroColor[auxFilaD6, i].Text = "X";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;
                    }
                }
            }

            //fila = fija, columna = disminuye  --------------->Direccion7
            int auxFilaD7 = filaTemp;
            for (int i = columnaTemp - 1; i >= 0; i--) //columna
            {
                if (tableroColor[auxFilaD7, i].BackColor == Color.White)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[auxFilaD7, i].BackColor == Color.Black)
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroColor[auxFilaD7, i].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        tableroColor[auxFilaD7, i].Enabled = true;
                        tableroColor[auxFilaD7, i].Text = "X";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;
                    }

                }
            }

            //fila = disminuye, columna = disminuye ---------------->Direccion8
            int auxColumnaD8 = columnaTemp;
            for (int i = filaTemp - 1; i >= 0; i--) //fila
            {
                auxColumnaD8--;
                if (auxColumnaD8 < 0)
                {
                    break;
                }
                if (tableroColor[i, auxColumnaD8].BackColor == Color.White)
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroColor[i, auxColumnaD8].BackColor == Color.Black)
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroColor[i, auxColumnaD8].BackColor == Color.Green)
                {
                    if (contadorFicha >= 1)
                    {
                        tableroColor[i, auxColumnaD8].Enabled = true;
                        tableroColor[i, auxColumnaD8].Text = "X";
                        contadorFicha = 0;
                        break;
                    }
                    else
                    {
                        contadorFicha = 0;
                        break;
                    }
                }
            }
        }
        //NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN


        //VALIDACIONES-VALIDACIONES-VALIDACIONES-VALIDACIONES-VALIDACIOENS-VALIDACIONES-VALIDACIONES-VALIDACIONES

        //metodo para verificar si hay mas espacios
        public void informacionFinal()
        {
            movimientoGeneral = 0;
            movimientoB = 0;
            movimientoN = 0;
            bloquesB = 0;
            bloquesN = 0;

            // resetea la tabla 
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tableroColor[i, j].Text == "X")
                    {
                        tableroColor[i, j].Text = " ";
                        tableroColor[i, j].Enabled = false;
                    }
                    else if (tableroColor[i, j].Text == "O")
                    {
                        tableroColor[i, j].Text = " ";
                        tableroColor[i, j].Enabled = false;
                    }
                }
            }


            //blancas
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    if (tableroColor[i, j].BackColor == Color.White)
                    {
                        movimientoB++;

                        if (banderaBlanca == true)
                        {
                            activacionBoton1(i, j);//metodo para habilitar botones
                        }

                    }
                    else if (tableroColor[i, j].BackColor == Color.Black)
                    {
                        movimientoN++;
                        if (banderaNegra == true)
                        {
                            activacionBoton2(i, j);//metodo para habilitar botones
                        }
                    }

                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tableroColor[i, j].Text == "X")
                    {
                        //posiciones que diga que no hay mas movimientos
                        movimientoGeneral++;
                    }
                    else if (tableroColor[i, j].Text == "O")
                    {
                        //posiciones que diga que no hay mas movimientos
                        movimientoGeneral++;
                    }
                }
            }

            if (banderaBlanca == true)//cuando yo sea blanco
            {
                LabelContadorJugador.Text = movimientoB.ToString();
                LabelContadorMaquina.Text = movimientoN.ToString();
            }
            else //cuando yo sea negro
            {
                LabelContadorMaquina.Text = movimientoB.ToString();
                LabelContadorJugador.Text = movimientoN.ToString();
            }

            //validar estado de partida
            if (movimientoGeneral == 0)
            {
                if (movimientoB > movimientoN)
                {
                    //gana blanca
                    LabelTitulo.Text = "Ganó ficha blanca";
                }
                else if (movimientoN > movimientoB)
                {
                    //gana negras
                    LabelTitulo.Text = "Ganó ficha negra";

                }
                else if (movimientoB == movimientoN)
                {
                    //es empate
                    LabelTitulo.Text = "Empate";

                }




            }
            else
            {
                movimientoGeneral = 0;
                //se esta jugando
                LabelTitulo.Text = "Se está jugando";
            }

        }
        protected void ButtonCarga_Click1(object sender, EventArgs e)
        {

        }

        protected void ButtonDescarga_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPrincipal.aspx");
        }

        protected void BtnA1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA1.BackColor = Color.White;
                capturaFichaBlanca(0, 0);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnA1.BackColor = Color.Black;
                capturaFichaNegra(0,0);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB1.BackColor = Color.White;
                capturaFichaBlanca(0, 1);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnB1.BackColor = Color.Black;
                capturaFichaNegra(0, 1);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC1.BackColor = Color.White;
                capturaFichaBlanca(0, 2);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnC1.BackColor = Color.Black;
                capturaFichaNegra(0, 2);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }

        }

        protected void BtnD1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD1.BackColor = Color.White;
                capturaFichaBlanca(0, 3);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnD1.BackColor = Color.Black;
                capturaFichaNegra(0, 3);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }

        }

        protected void BtnE1_Click(object sender, EventArgs e)
        {

        }

        protected void BtnF1_Click(object sender, EventArgs e)
        {

        }

        protected void BtnG1_Click(object sender, EventArgs e)
        {

        }

        protected void BtnH1_Click(object sender, EventArgs e)
        {

        }

        protected void BtnA2_Click(object sender, EventArgs e)
        {

        }

        protected void BtnB2_Click(object sender, EventArgs e)
        {

        }

        protected void BtnC2_Click(object sender, EventArgs e)
        {

        }

        protected void BtnD2_Click(object sender, EventArgs e)
        {

        }

        protected void BtnE2_Click(object sender, EventArgs e)
        {

        }

        protected void BtnF2_Click(object sender, EventArgs e)
        {

        }

        protected void BtnG2_Click(object sender, EventArgs e)
        {

        }

        protected void BtnH2_Click(object sender, EventArgs e)
        {

        }

        protected void BtnA3_Click(object sender, EventArgs e)
        {

        }

        protected void BtnB3_Click(object sender, EventArgs e)
        {

        }

        protected void BtnC3_Click(object sender, EventArgs e)
        {

        }

        protected void BtnD3_Click(object sender, EventArgs e)
        {

        }

        protected void BtnE3_Click(object sender, EventArgs e)
        {

        }

        protected void BtnF3_Click(object sender, EventArgs e)
        {

        }

        protected void BtnG3_Click(object sender, EventArgs e)
        {

        }

        protected void BtnH3_Click(object sender, EventArgs e)
        {

        }

        protected void BtnA4_Click(object sender, EventArgs e)
        {

        }

        protected void BtnB4_Click(object sender, EventArgs e)
        {

        }

        protected void BtnC4_Click(object sender, EventArgs e)
        {

        }

        protected void BtnD4_Click(object sender, EventArgs e)
        {

        }

        protected void BtnE4_Click(object sender, EventArgs e)
        {

        }

        protected void BtnF4_Click(object sender, EventArgs e)
        {

        }

        protected void BtnG4_Click(object sender, EventArgs e)
        {

        }

        protected void BtnH4_Click(object sender, EventArgs e)
        {

        }

        protected void BtnA5_Click(object sender, EventArgs e)
        {

        }

        protected void BtnB5_Click(object sender, EventArgs e)
        {

        }

        protected void BtnC5_Click(object sender, EventArgs e)
        {

        }

        protected void BtnD5_Click(object sender, EventArgs e)
        {

        }

        protected void BtnE5_Click(object sender, EventArgs e)
        {

        }

        protected void BtnF5_Click(object sender, EventArgs e)
        {

        }

        protected void BtnG5_Click(object sender, EventArgs e)
        {

        }

        protected void BtnH5_Click(object sender, EventArgs e)
        {

        }

        protected void BtnA6_Click(object sender, EventArgs e)
        {

        }

        protected void BtnB6_Click(object sender, EventArgs e)
        {

        }

        protected void BtnC6_Click(object sender, EventArgs e)
        {

        }

        protected void BtnD6_Click(object sender, EventArgs e)
        {

        }

        protected void BtnE6_Click(object sender, EventArgs e)
        {

        }

        protected void BtnF6_Click(object sender, EventArgs e)
        {

        }

        protected void BtnG6_Click(object sender, EventArgs e)
        {

        }

        protected void BtnH6_Click(object sender, EventArgs e)
        {

        }

        protected void BtnA7_Click(object sender, EventArgs e)
        {

        }

        protected void BtnB7_Click(object sender, EventArgs e)
        {

        }

        protected void BtnC7_Click(object sender, EventArgs e)
        {

        }

        protected void BtnD7_Click(object sender, EventArgs e)
        {

        }

        protected void BtnE7_Click(object sender, EventArgs e)
        {

        }

        protected void BtnF7_Click(object sender, EventArgs e)
        {

        }

        protected void BtnG7_Click(object sender, EventArgs e)
        {

        }

        protected void BtnH7_Click(object sender, EventArgs e)
        {

        }

        protected void BtnA8_Click(object sender, EventArgs e)
        {

        }

        protected void BtnB8_Click(object sender, EventArgs e)
        {

        }

        protected void BtnC8_Click(object sender, EventArgs e)
        {

        }

        protected void BtnD8_Click(object sender, EventArgs e)
        {

        }

        protected void BtnE8_Click(object sender, EventArgs e)
        {

        }

        protected void BtnF8_Click(object sender, EventArgs e)
        {

        }

        protected void BtnG8_Click(object sender, EventArgs e)
        {

        }

        protected void BtnH8_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownListFicha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}