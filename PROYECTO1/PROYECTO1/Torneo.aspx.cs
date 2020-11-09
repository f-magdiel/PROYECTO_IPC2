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
    public partial class Torneo : System.Web.UI.Page
    {

        //para monstrar los movimiento se usar bool
        public static bool usuarioBlanco = false;
        public static bool usuarioNegro = false;
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

        //para los equipos
        public static ArrayList arrayListado = new ArrayList();
        public static int contadorEquipo = 0;
        public static string nombreCampeonato = "";
        public static string seleccionEquipo1 = "";
        public static string seleccionEquipo2 = "";

        public static int ptsEquipo1 = 0;
        public static int ptsEquipo2 = 0;
        public static int ptsEquipo3 = 0;
        public static int ptsEquipo4 = 0;
        public static int ptsEquipo5 = 0;
        public static int ptsEquipo6 = 0;
        public static int ptsEquipo7 = 0;
        public static int ptsEquipo8 = 0;
        public static int ptsEquipo9 = 0;
        public static int ptsEquipo10 = 0;
        public static int ptsEquipo11 = 0;
        public static int ptsEquipo12 = 0;
        public static int ptsEquipo13 = 0;
        public static int ptsEquipo14 = 0;
        public static int ptsEquipo15 = 0;
        public static int ptsEquipo16 = 0;



        //tiempo equipo
        public static bool llaveTiempo1 = false;
        public static bool llaveTiempo2 = false;
        public static bool llaveTiempoGeneral = false;

        public static int minutosT1 = 0;
        public static int segundoT1 = 0;
        public static int minutosT2 = 0;
        public static int segundoT2 = 0;

        public static string actualEquipo1 = "";
        public static string actualEquipo2 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                llenarDropLista();
                banderaBlanca = false;
                banderaNegra = false;
                llaveTiempoGeneral = false;
                llaveTiempo1 = false;
                llaveTiempo2 = false;
                minutosT1 = 0;
                segundoT1 = 0;
                minutosT2 = 0;
                segundoT2 = 0;
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
        protected void Timer1_Tick(object sender, EventArgs e)
        {

            if (llaveTiempoGeneral == true)
            {
                if (llaveTiempo1 == true)
                {

                    LabelTiempoJ1.Text = minutosT1.ToString() + ":" + segundoT1.ToString();
                    segundoT1++;
                    if (segundoT1 == 61)
                    {
                        segundoT1 = 0;
                        minutosT1++;
                    }
                }

                if (llaveTiempo2 == true)
                {

                    LabelTiempoJ2.Text = minutosT2.ToString() + ":" + segundoT2.ToString();
                    segundoT2++;
                    if (segundoT2 == 61)
                    {
                        segundoT2 = 0;
                        minutosT2++;
                    }
                }
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
                usuarioBlanco = true;
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
                usuarioNegro = true;
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

            string seleccion ="";
            if (seleccion == "O")//blanco
            {
                // el color es activado
                banderaBlanca = true;
                usuarioBlanco = true;
                LabelTitulo.Text = "Se está jugando";
                //se habilitan los botones para las blancas


                BtnF4.Enabled = true;
                BtnE3.Enabled = true;
                BtnC5.Enabled = true;
                BtnD6.Enabled = true;


            }
            else if (seleccion == "X")//negro
            {
                // el color es activado
                banderaNegra = true;
                usuarioNegro = true;
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

        //metodo para habilitar botones si soy negro
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


                    if (banderaBlanca == true)
                    {
                        if (tableroColor[i, j].BackColor == Color.Black)
                        {
                            LabelTurnoJugador.Text = "Jugador 2";
                            llaveTiempo2 = true;
                            llaveTiempo1 = false;
                            activacionBoton2(i, j);//metodo para habilitar botones si soy negro

                        }

                    }
                    else if (banderaNegra == true)
                    {
                        if (tableroColor[i, j].BackColor == Color.White)
                        {
                            LabelTurnoJugador.Text = "Jugador 1";
                            llaveTiempo1 = true;
                            llaveTiempo2 = false;
                            activacionBoton1(i, j);//metodo para habilitar botones si soy blanco

                        }
                    }



                }
            }

            //solo para movimientos
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tableroColor[i, j].BackColor == Color.White)
                    {
                        movimientoB++;
                    }
                    else if (tableroColor[i, j].BackColor == Color.Black)
                    {
                        movimientoN++;
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

            LabelContadorJugador1.Text = movimientoB.ToString();
            LabelContadorJugador2.Text = movimientoN.ToString();

            if (usuarioBlanco == true)//cuando yo sea blanco
            {
                //LabelContadorUsuario.Text = movimientoB.ToString();
                //LabelContadorInvitado.Text = movimientoN.ToString();
            }
            else if (usuarioNegro == true)//cuando yo sea negro
            {
                //LabelContadorUsuario.Text = movimientoN.ToString();
                //LabelContadorInvitado.Text = movimientoB.ToString();
            }

            //validar estado de partida
            if (movimientoGeneral == 0)
            {
                if (movimientoB > movimientoN)
                {
                    //gana blanca
                    llaveTiempoGeneral = false;
                    llaveTiempo1 = false;
                    llaveTiempo2 = false;
                    LabelEstado.Text = "Gana Jugador 1";
                    LabelTurnoJugador.Text = "No Disponible";
                    validacionGanador(actualEquipo1, actualEquipo2);
                }
                else if (movimientoN > movimientoB)
                {
                    //gana negras
                    llaveTiempoGeneral = false;
                    llaveTiempo1 = false;
                    llaveTiempo2 = false;
                    LabelEstado.Text = "Gana Jugador 2";
                    LabelTurnoJugador.Text = "No Disponible";
                    validacionGanador(actualEquipo2, actualEquipo1);
                }
                else if (movimientoB == movimientoN)
                {
                    //es empate
                    llaveTiempoGeneral = false;
                    LabelEstado.Text = "Empate";
                    LabelTurnoJugador.Text = "No Disponible";
                }




            }
            else
            {
                movimientoGeneral = 0;
                //se esta jugando
                LabelEstado.Text = "Se está jugando";
            }

        }


        public void validacionGanador(string ganador, string perdedor)
        {
            if(contadorEquipo == 4)
            {
                if (Grafica.A2Equipo1 == actualEquipo1 && Grafica.A2Equipo2 == actualEquipo2)
                {
                    Grafica.A1Equipo1 = ganador;
                }

                if (Grafica.B2Equipo1 == actualEquipo1 && Grafica.B2Equipo2 == actualEquipo2)
                {
                    Grafica.B1Equipo1 = ganador;
                }

                //final
                if (Grafica.A1Equipo1 == actualEquipo1 && Grafica.B1Equipo1 == actualEquipo2)
                {
                    Grafica.ganador = ganador;
                }
            }
            else if(contadorEquipo == 8)
            {
                //lado A
                if (Grafica.A4Equipo1 == actualEquipo1 && Grafica.A4Equipo2 == actualEquipo2)
                {
                    Grafica.A2Equipo1 = ganador;
                }
                else if (Grafica.A4Equipo3 == actualEquipo1 && Grafica.A4Equipo4 == actualEquipo2)
                {
                    Grafica.A2Equipo2 = ganador;
                }

                if (Grafica.A2Equipo1 == actualEquipo1 && Grafica.A2Equipo2 == actualEquipo2)
                {
                    Grafica.A1Equipo1 = ganador;
                }

                //lado B
                if (Grafica.B4Equipo1 == actualEquipo1 && Grafica.B4Equipo2 == actualEquipo2)
                {
                    Grafica.B2Equipo1 = ganador;
                }
                else if (Grafica.B4Equipo3 == actualEquipo1 && Grafica.B4Equipo4 == actualEquipo2)
                {
                    Grafica.B2Equipo2 = ganador;
                }

                if (Grafica.B2Equipo1 == actualEquipo1 && Grafica.B2Equipo2 == actualEquipo2)
                {
                    Grafica.B1Equipo1 = ganador;
                }

                //final
                if (Grafica.A1Equipo1 == actualEquipo1 && Grafica.B1Equipo1 == actualEquipo2)
                {
                    Grafica.ganador = ganador;
                }
            }
            else if (contadorEquipo == 16)
            {
                //lado A
                if (Grafica.A8Equipo1 == actualEquipo1 && Grafica.A8Equipo2 == actualEquipo2)
                {
                    Grafica.A4Equipo1 = ganador;                 
                }
                else if(Grafica.A8Equipo3 == actualEquipo1 && Grafica.A8Equipo4 == actualEquipo2)
                {
                    Grafica.A4Equipo2 = ganador;
                }
                else if (Grafica.A8Equipo5 == actualEquipo1 && Grafica.A8Equipo6 == actualEquipo2)
                {
                    Grafica.A4Equipo3 = ganador;
                }
                else if (Grafica.A8Equipo7 == actualEquipo1 && Grafica.A8Equipo8 == actualEquipo2)
                {
                    Grafica.A4Equipo4 = ganador;
                }

                if(Grafica.A4Equipo1 == actualEquipo1 && Grafica.A4Equipo2 == actualEquipo2)
                {
                    Grafica.A2Equipo1 = ganador;
                }
                else if (Grafica.A4Equipo3 == actualEquipo1 && Grafica.A4Equipo4 == actualEquipo2)
                {
                    Grafica.A2Equipo2 = ganador;
                }

                if(Grafica.A2Equipo1 == actualEquipo1 && Grafica.A2Equipo2 == actualEquipo2)
                {
                    Grafica.A1Equipo1 = ganador;
                }


                //lado B
                if (Grafica.B8Equipo1 == actualEquipo1 && Grafica.B8Equipo2 == actualEquipo2)
                {
                    Grafica.B4Equipo1 = ganador;
                }
                else if (Grafica.B8Equipo3 == actualEquipo1 && Grafica.B8Equipo4 == actualEquipo2)
                {
                    Grafica.B4Equipo2 = ganador;
                }
                else if (Grafica.B8Equipo5 == actualEquipo1 && Grafica.B8Equipo6 == actualEquipo2)
                {
                    Grafica.B4Equipo3 = ganador;
                }
                else if (Grafica.B8Equipo7 == actualEquipo1 && Grafica.B8Equipo8 == actualEquipo2)
                {
                    Grafica.B4Equipo4 = ganador;
                }

                if (Grafica.B4Equipo1 == actualEquipo1 && Grafica.B4Equipo2 == actualEquipo2)
                {
                    Grafica.B2Equipo1 = ganador;
                }
                else if (Grafica.B4Equipo3 == actualEquipo1 && Grafica.B4Equipo4 == actualEquipo2)
                {
                    Grafica.B2Equipo2 = ganador;
                }

                if (Grafica.B2Equipo1 == actualEquipo1 && Grafica.B2Equipo2 == actualEquipo2)
                {
                    Grafica.B1Equipo1 = ganador;
                }


                //final
                if (Grafica.A1Equipo1 == actualEquipo1 && Grafica.B1Equipo1 == actualEquipo2)
                {
                    Grafica.ganador = ganador;
                }
            }
        }
        //informacion final para carga
        public void informacionFinalCarga()
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


                    if (banderaBlanca == true)
                    {
                        if (tableroColor[i, j].BackColor == Color.White)
                        {

                            activacionBoton1(i, j);//metodo para habilitar botones si soy blanco

                        }

                    }
                    else if (banderaNegra == true)
                    {

                        if (tableroColor[i, j].BackColor == Color.Black)
                        {

                            activacionBoton2(i, j);//metodo para habilitar botones si soy negro

                        }
                    }



                }
            }

            //solo para movimientos
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tableroColor[i, j].BackColor == Color.White)
                    {
                        movimientoB++;
                    }
                    else if (tableroColor[i, j].BackColor == Color.Black)
                    {
                        movimientoN++;
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

            if (usuarioBlanco == true)//cuando yo sea blanco
            {
                //LabelContadorUsuario.Text = movimientoB.ToString();
                //LabelContadorInvitado.Text = movimientoN.ToString();
            }
            else if (usuarioNegro == true)//cuando yo sea negro
            {
                //LabelContadorUsuario.Text = movimientoN.ToString();
                //LabelContadorInvitado.Text = movimientoB.ToString();
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
            try
            {

                string texto1 = TextBoxCarga.Text;



                XmlReader lector = XmlReader.Create(texto1);
                while (lector.Read())
                {
                    if (lector.IsStartElement())
                    {
                        string valor = lector.Name.ToString();
                        //inicio de elemento
                       if(lector.NodeType == XmlNodeType.Element)
                        {
                            if (lector.Name.ToString() == "nombre")
                            {
                                nombreCampeonato = lector.ReadString();
                            }
                            else if (lector.Name.ToString() == "nombreEquipo")
                            {
                                arrayListado.Add(lector.ReadString());
                                contadorEquipo++;
                            }
                            else if(lector.Name.ToString() == "jugador")
                            {
                                arrayListado.Add(lector.ReadString());
                            }
                        }
                       


                    }
                }

                llenarDropLista();
                validacionCantidadEquipo();

            }
            catch (Exception exc)
            {
                Response.Write("No se encontro el archivo" + exc);
            }
        }

        public void llenarDropLista()
        {
            for (int i = 0; i < arrayListado.Count; i+=4)
            {
                LabelNombreCampeonato.Text = nombreCampeonato;
                DropDownListEquipo1.Items.Add(arrayListado[i].ToString());
                DropDownListEquipo2.Items.Add(arrayListado[i].ToString());
            }
        }

        public void validacionCantidadEquipo()
        {
            if(contadorEquipo == 4)
            {
                //si solo hay cuatro equipos
                Grafica.A2Equipo1 = arrayListado[0].ToString();
                Grafica.A2Equipo2 = arrayListado[4].ToString();
                Grafica.B2Equipo1 = arrayListado[8].ToString();
                Grafica.B2Equipo2 = arrayListado[12].ToString();
            }
            else if (contadorEquipo == 8)
            {
                Grafica.A4Equipo1 = arrayListado[0].ToString();
                Grafica.A4Equipo2 = arrayListado[4].ToString();
                Grafica.A4Equipo3 = arrayListado[8].ToString();
                Grafica.A4Equipo4 = arrayListado[12].ToString();

                Grafica.B4Equipo1 = arrayListado[16].ToString();
                Grafica.B4Equipo2 = arrayListado[20].ToString();
                Grafica.B4Equipo3 = arrayListado[24].ToString();
                Grafica.B4Equipo4 = arrayListado[28].ToString();
            }
            else if(contadorEquipo == 16)
            {
                Grafica.A8Equipo1 = arrayListado[0].ToString();
                Grafica.A8Equipo2 = arrayListado[4].ToString();
                Grafica.A8Equipo3 = arrayListado[8].ToString();
                Grafica.A8Equipo4 = arrayListado[12].ToString();
                Grafica.A8Equipo5 = arrayListado[16].ToString();
                Grafica.A8Equipo6 = arrayListado[20].ToString();
                Grafica.A8Equipo7 = arrayListado[24].ToString();
                Grafica.A8Equipo8 = arrayListado[28].ToString();

                Grafica.B8Equipo1 = arrayListado[32].ToString();
                Grafica.B8Equipo2 = arrayListado[36].ToString();
                Grafica.B8Equipo3 = arrayListado[40].ToString();
                Grafica.B8Equipo4 = arrayListado[44].ToString();
                Grafica.B8Equipo5 = arrayListado[48].ToString();
                Grafica.B8Equipo6 = arrayListado[52].ToString();
                Grafica.B8Equipo7 = arrayListado[56].ToString();
                Grafica.B8Equipo8 = arrayListado[60].ToString();
            }
        }

        //CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA
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
                            else if (tablero[i, j] == "X")
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

                    tablero[0, 0] = "O";
                }
                else if (color == "negro")
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
        public void analizarMatriz()
        {

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
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


        public void recorrerCuadros()
        {
            int opcion;

            for (opcion = 1; opcion <= 64; opcion++)
            {

                switch (opcion)
                {
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
        //FINNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN

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

            XmlElement siguiente = doc.CreateElement("siguienteTiro");
            raiz.AppendChild(siguiente);

            if (banderaBlanca == true)
            {
                XmlElement colorTiro = doc.CreateElement("color");
                colorTiro.AppendChild(doc.CreateTextNode("blanco"));
                siguiente.AppendChild(colorTiro);
            }
            else if (banderaNegra == true)
            {
                XmlElement colorTiro = doc.CreateElement("color");
                colorTiro.AppendChild(doc.CreateTextNode("negro"));
                siguiente.AppendChild(colorTiro);
            }

            doc.Save("C:\\Users\\MAGDIEL\\Desktop\\Pruebas\\PartidaSolitario.xml");




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
                capturaFichaNegra(0, 0);
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
            if (banderaBlanca == true)
            {
                BtnE1.BackColor = Color.White;
                capturaFichaBlanca(0, 4);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnE1.BackColor = Color.Black;
                capturaFichaNegra(0, 4);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF1.BackColor = Color.White;
                capturaFichaBlanca(0, 5);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnF1.BackColor = Color.Black;
                capturaFichaNegra(0, 5);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG1.BackColor = Color.White;
                capturaFichaBlanca(0, 6);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnG1.BackColor = Color.Black;
                capturaFichaNegra(0, 6);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }

        }

        protected void BtnH1_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH1.BackColor = Color.White;
                capturaFichaBlanca(0, 7);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnH1.BackColor = Color.Black;
                capturaFichaNegra(0, 7);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnA2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA2.BackColor = Color.White;
                capturaFichaBlanca(1, 0);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnA2.BackColor = Color.Black;
                capturaFichaNegra(1, 0);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }

        }

        protected void BtnB2_Click(object sender, EventArgs e)
        {

            if (banderaBlanca == true)
            {
                BtnB2.BackColor = Color.White;
                capturaFichaBlanca(1, 1);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnB2.BackColor = Color.Black;
                capturaFichaNegra(1, 1);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC2_Click(object sender, EventArgs e)
        {

            if (banderaBlanca == true)
            {
                BtnC2.BackColor = Color.White;
                capturaFichaBlanca(1, 2);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnC2.BackColor = Color.Black;
                capturaFichaNegra(1, 2);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnD2_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD2.BackColor = Color.White;
                capturaFichaBlanca(1, 3);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnD2.BackColor = Color.Black;
                capturaFichaNegra(1, 3);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }

        }

        protected void BtnE2_Click(object sender, EventArgs e)
        {

            if (banderaBlanca == true)
            {
                BtnE2.BackColor = Color.White;
                capturaFichaBlanca(1, 4);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnE2.BackColor = Color.Black;
                capturaFichaNegra(1, 4);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF2_Click(object sender, EventArgs e)
        {

            if (banderaBlanca == true)
            {
                BtnF2.BackColor = Color.White;
                capturaFichaBlanca(1, 5);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnF2.BackColor = Color.Black;
                capturaFichaNegra(1, 5);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG2_Click(object sender, EventArgs e)
        {

            if (banderaBlanca == true)
            {
                BtnG2.BackColor = Color.White;
                capturaFichaBlanca(1, 6);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnG2.BackColor = Color.Black;
                capturaFichaNegra(1, 6);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnH2_Click(object sender, EventArgs e)
        {

            if (banderaBlanca == true)
            {
                BtnH2.BackColor = Color.White;
                capturaFichaBlanca(1, 7);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnH2.BackColor = Color.Black;
                capturaFichaNegra(1, 7);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnA3_Click(object sender, EventArgs e)
        {

            if (banderaBlanca == true)
            {
                BtnA3.BackColor = Color.White;
                capturaFichaBlanca(2, 0);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnA3.BackColor = Color.Black;
                capturaFichaNegra(2, 0);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB3.BackColor = Color.White;
                capturaFichaBlanca(2, 1);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnB3.BackColor = Color.Black;
                capturaFichaNegra(2, 1);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC3.BackColor = Color.White;
                capturaFichaBlanca(2, 2);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnC3.BackColor = Color.Black;
                capturaFichaNegra(2, 2);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnD3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD3.BackColor = Color.White;
                capturaFichaBlanca(2, 3);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnD3.BackColor = Color.Black;
                capturaFichaNegra(2, 3);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnE3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE3.BackColor = Color.White;
                capturaFichaBlanca(2, 4);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnE3.BackColor = Color.Black;
                capturaFichaNegra(2, 4);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF3.BackColor = Color.White;
                capturaFichaBlanca(2, 5);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnF3.BackColor = Color.Black;
                capturaFichaNegra(2, 5);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG3.BackColor = Color.White;
                capturaFichaBlanca(2, 6);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnG3.BackColor = Color.Black;
                capturaFichaNegra(2, 6);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnH3_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH3.BackColor = Color.White;
                capturaFichaBlanca(2, 7);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnH3.BackColor = Color.Black;
                capturaFichaNegra(2, 7);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnA4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA4.BackColor = Color.White;
                capturaFichaBlanca(3, 0);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnA4.BackColor = Color.Black;
                capturaFichaNegra(3, 0);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB4.BackColor = Color.White;
                capturaFichaBlanca(3, 1);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnB4.BackColor = Color.Black;
                capturaFichaNegra(3, 1);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC4.BackColor = Color.White;
                capturaFichaBlanca(3, 2);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnC4.BackColor = Color.Black;
                capturaFichaNegra(3, 2);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }

        }

        protected void BtnD4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD4.BackColor = Color.White;
                capturaFichaBlanca(3, 3);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnD4.BackColor = Color.Black;
                capturaFichaNegra(3, 3);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnE4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE4.BackColor = Color.White;
                capturaFichaBlanca(3, 4);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnE4.BackColor = Color.Black;
                capturaFichaNegra(3, 4);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF4.BackColor = Color.White;
                capturaFichaBlanca(3, 5);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnF4.BackColor = Color.Black;
                capturaFichaNegra(3, 5);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG4.BackColor = Color.White;
                capturaFichaBlanca(3, 6);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnG4.BackColor = Color.Black;
                capturaFichaNegra(3, 6);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnH4_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH4.BackColor = Color.White;
                capturaFichaBlanca(3, 7);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnH4.BackColor = Color.Black;
                capturaFichaNegra(3, 7);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnA5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA5.BackColor = Color.White;
                capturaFichaBlanca(4, 0);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnA5.BackColor = Color.Black;
                capturaFichaNegra(4, 0);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB5.BackColor = Color.White;
                capturaFichaBlanca(4, 1);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnB5.BackColor = Color.Black;
                capturaFichaNegra(4, 1);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC5.BackColor = Color.White;
                capturaFichaBlanca(4, 2);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnC5.BackColor = Color.Black;
                capturaFichaNegra(4, 2);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnD5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD5.BackColor = Color.White;
                capturaFichaBlanca(4, 3);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnD5.BackColor = Color.Black;
                capturaFichaNegra(4, 3);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnE5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE5.BackColor = Color.White;
                capturaFichaBlanca(4, 4);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnE5.BackColor = Color.Black;
                capturaFichaNegra(4, 4);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF5.BackColor = Color.White;
                capturaFichaBlanca(4, 5);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnF5.BackColor = Color.Black;
                capturaFichaNegra(4, 5);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }

        }

        protected void BtnG5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG5.BackColor = Color.White;
                capturaFichaBlanca(4, 6);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnG5.BackColor = Color.Black;
                capturaFichaNegra(4, 6);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }

        }

        protected void BtnH5_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH5.BackColor = Color.White;
                capturaFichaBlanca(4, 7);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnH5.BackColor = Color.Black;
                capturaFichaNegra(4, 7);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnA6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA6.BackColor = Color.White;
                capturaFichaBlanca(5, 0);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnA6.BackColor = Color.Black;
                capturaFichaNegra(5, 0);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB6.BackColor = Color.White;
                capturaFichaBlanca(5, 1);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnB6.BackColor = Color.Black;
                capturaFichaNegra(5, 1);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC6.BackColor = Color.White;
                capturaFichaBlanca(5, 2);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnC6.BackColor = Color.Black;
                capturaFichaNegra(5, 2);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnD6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD6.BackColor = Color.White;
                capturaFichaBlanca(5, 3);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnD6.BackColor = Color.Black;
                capturaFichaNegra(5, 3);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnE6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE6.BackColor = Color.White;
                capturaFichaBlanca(5, 4);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnE6.BackColor = Color.Black;
                capturaFichaNegra(5, 4);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF6.BackColor = Color.White;
                capturaFichaBlanca(5, 5);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnF6.BackColor = Color.Black;
                capturaFichaNegra(5, 5);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG6.BackColor = Color.White;
                capturaFichaBlanca(5, 6);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnG6.BackColor = Color.Black;
                capturaFichaNegra(5, 6);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnH6_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH6.BackColor = Color.White;
                capturaFichaBlanca(5, 7);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnH6.BackColor = Color.Black;
                capturaFichaNegra(5, 7);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnA7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA7.BackColor = Color.White;
                capturaFichaBlanca(6, 0);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnA7.BackColor = Color.Black;
                capturaFichaNegra(6, 0);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB7.BackColor = Color.White;
                capturaFichaBlanca(6, 1);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnB7.BackColor = Color.Black;
                capturaFichaNegra(6, 1);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC7.BackColor = Color.White;
                capturaFichaBlanca(6, 2);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnC7.BackColor = Color.Black;
                capturaFichaNegra(6, 2);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnD7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD7.BackColor = Color.White;
                capturaFichaBlanca(6, 3);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnD7.BackColor = Color.Black;
                capturaFichaNegra(6, 3);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnE7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE7.BackColor = Color.White;
                capturaFichaBlanca(6, 4);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnE7.BackColor = Color.Black;
                capturaFichaNegra(6, 4);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF7.BackColor = Color.White;
                capturaFichaBlanca(6, 5);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnF7.BackColor = Color.Black;
                capturaFichaNegra(6, 5);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG7.BackColor = Color.White;
                capturaFichaBlanca(6, 6);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnG7.BackColor = Color.Black;
                capturaFichaNegra(6, 6);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnH7_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH7.BackColor = Color.White;
                capturaFichaBlanca(6, 7);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnH7.BackColor = Color.Black;
                capturaFichaNegra(6, 7);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnA8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnA8.BackColor = Color.White;
                capturaFichaBlanca(7, 0);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnA8.BackColor = Color.Black;
                capturaFichaNegra(7, 0);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnB8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnB8.BackColor = Color.White;
                capturaFichaBlanca(7, 1);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnB8.BackColor = Color.Black;
                capturaFichaNegra(7, 1);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnC8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnC8.BackColor = Color.White;
                capturaFichaBlanca(7, 2);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnC8.BackColor = Color.Black;
                capturaFichaNegra(7, 2);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnD8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnD8.BackColor = Color.White;
                capturaFichaBlanca(7, 3);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnD8.BackColor = Color.Black;
                capturaFichaNegra(7, 3);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnE8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnE8.BackColor = Color.White;
                capturaFichaBlanca(7, 4);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnE8.BackColor = Color.Black;
                capturaFichaNegra(7, 4);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnF8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnF8.BackColor = Color.White;
                capturaFichaBlanca(7, 5);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnF8.BackColor = Color.Black;
                capturaFichaNegra(7, 5);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnG8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnG8.BackColor = Color.White;
                capturaFichaBlanca(7, 6);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnG8.BackColor = Color.Black;
                capturaFichaNegra(7, 6);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void BtnH8_Click(object sender, EventArgs e)
        {
            if (banderaBlanca == true)
            {
                BtnH8.BackColor = Color.White;
                capturaFichaBlanca(7, 7);
                informacionFinal();
                banderaNegra = true;
                banderaBlanca = false;

            }
            else if (banderaNegra == true)
            {
                BtnH8.BackColor = Color.Black;
                capturaFichaNegra(7, 7);
                informacionFinal();
                banderaNegra = false;
                banderaBlanca = true;
            }
        }

        protected void DropDownListFicha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListEquipo1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
           
        }

        protected void ButtonElegirEquipo1_Click(object sender, EventArgs e)
        {
            seleccionEquipo1 = DropDownListEquipo1.SelectedItem.ToString();
            actualEquipo1 = seleccionEquipo1;
            for (int i = 0; i < arrayListado.Count; i++)
            {
                if (seleccionEquipo1 == arrayListado[i].ToString())
                {
                    DropDownListJugador1.Items.Add(arrayListado[i + 1].ToString());
                    DropDownListJugador1.Items.Add(arrayListado[i + 2].ToString());
                    DropDownListJugador1.Items.Add(arrayListado[i + 3].ToString());
                    break;
                }
            }
        }

        protected void ButtonElegirEquipo2_Click(object sender, EventArgs e)
        {
            seleccionEquipo2 = DropDownListEquipo2.SelectedItem.ToString();
            actualEquipo2 = seleccionEquipo2;
            for (int i = 0; i < arrayListado.Count; i++)
            {
                if (seleccionEquipo2 == arrayListado[i].ToString())
                {
                    DropDownListJugador2.Items.Add(arrayListado[i + 1].ToString());
                    DropDownListJugador2.Items.Add(arrayListado[i + 2].ToString());
                    DropDownListJugador2.Items.Add(arrayListado[i + 3].ToString());
                    break;
                }
            }
        }

        protected void ButtonEmpezar_Click(object sender, EventArgs e)
        {
           
            // el color es activado
            banderaBlanca = true;
            usuarioBlanco = true;
            llaveTiempoGeneral = true;
            llaveTiempo1 = true;
            LabelEstado.Text = "Se está jugando";
            LabelTurnoJugador.Text = "Jugador 1";
            //se habilitan los botones para las blancas


            BtnF4.Enabled = true;
            BtnE3.Enabled = true;
            BtnC5.Enabled = true;
            BtnD6.Enabled = true;

        }
    }
}
