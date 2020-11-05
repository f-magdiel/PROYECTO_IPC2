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
using System.Drawing.Imaging;
using System.Web.UI.HtmlControls;
using System.Web.Services.Description;
using System.Data;

namespace PROYECTO1
{
    public partial class Xtream : System.Web.UI.Page
    {
        //tablero
        public static int tiempoJ1S = 0;
        public static int tiempoJ2S = 0;
        public static int tiempoJ1M = 0;
        public static int tiempoJ2M = 0;
        public static bool llaveTiempo1 = false;
        public static bool llaveTiempo2 = false;
        public static bool llaveTiempoGeneral = false;

        //colores
        public static int contadorColorj1 = 0;
        public static int contadorColorj2 = 0;


        //turnos
        public static bool turnoJ1 = false;
        public static bool turnoJ2 = false;

        //tamaño tablero generado
        public static int filaTamaño;
        public static int columnaTamaño;

        //cambio de color
        public static int cambio1 = 0;
        public static int cambio2 = 0;

        //contador de los 4
        public static int contador4 = 0;

        //modalidad
        public static bool modalidaJuego = true;

        //lllave para capturar
        public static bool llaveCaptura = false;

        //opcion de colores al pintar  y capturar
        public static string opColor = "";

        //para monstrar los movimiento se usar bool
        public static bool usuarioBlanco = false;
        public static bool usuarioNegro = false;
        //posiciones
        public static int posicionNegra = 1;
        public static int posicionBlanca = 1;

        //movimientos
        public static bool activacionMaqina = false;
        public static int movimientoGeneral = 0;
        public static int movimientoB = 0;
        public static int movimientoN = 0;
        public static string estadoPartida = "";
        public static int bloquesN = 0;
        public static int bloquesB = 0;

        public static bool sigo = true;
        public static int contadorEspacio = 0;
       
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
        public static Button[,] tableroColor = new Button[20, 20]; // array de botones de todo el tablero
        public static Label[] labelIzquierdo = new Label[20];
        public static Label[] labelDerecho = new Label[20];
        public static Label[] labelSuperior = new Label[20];
        public static Label[] labelInferior = new Label[20];
        public static string[,] tableroInterno; //tablero que simular los movimientos internamente
        //para los colores que se seleccionaran
        public static ArrayList arrayJugador1 = new ArrayList();
        public static ArrayList arrayJugador2 = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            
           

            //para los turnos
            if(!IsPostBack){
                turnoJ1 = true;
                turnoJ2 = false;
                llaveCaptura = false;
            }

            //labels para el tablero
            labelIzquierdo[0] = LabelI1;
            labelIzquierdo[1] = LabelI2;
            labelIzquierdo[2] = LabelI3;
            labelIzquierdo[3] = LabelI4;
            labelIzquierdo[4] = LabelI5;
            labelIzquierdo[5] = LabelI6;
            labelIzquierdo[6] = LabelI7;
            labelIzquierdo[7] = LabelI8;
            labelIzquierdo[8] = LabelI9;
            labelIzquierdo[9] = LabelI10;
            labelIzquierdo[10] = LabelI11;
            labelIzquierdo[11] = LabelI12;
            labelIzquierdo[12] = LabelI13;
            labelIzquierdo[13] = LabelI14;
            labelIzquierdo[14] = LabelI15;
            labelIzquierdo[15] = LabelI16;
            labelIzquierdo[16] = LabelI17;
            labelIzquierdo[17] = LabelI18;
            labelIzquierdo[18] = LabelI19;
            labelIzquierdo[19] = LabelI20;

            labelDerecho[0] = LabelD1;
            labelDerecho[1] = LabelD2;
            labelDerecho[2] = LabelD3;
            labelDerecho[3] = LabelD4;
            labelDerecho[4] = LabelD5;
            labelDerecho[5] = LabelD6;
            labelDerecho[6] = LabelD7;
            labelDerecho[7] = LabelD8;
            labelDerecho[8] = LabelD9;
            labelDerecho[9] = LabelD10;
            labelDerecho[10] = LabelD11;
            labelDerecho[11] = LabelD12;
            labelDerecho[12] = LabelD13;
            labelDerecho[13] = LabelD14;
            labelDerecho[14] = LabelD15;
            labelDerecho[15] = LabelD16;
            labelDerecho[16] = LabelD17;
            labelDerecho[17] = LabelD18;
            labelDerecho[18] = LabelD19;
            labelDerecho[19] = LabelD20;

            labelSuperior[0] = LabelAS;
            labelSuperior[1] = LabelBS;
            labelSuperior[2] = LabelCS;
            labelSuperior[3] = LabelDS;
            labelSuperior[4] = LabelES;
            labelSuperior[5] = LabelFS;
            labelSuperior[6] = LabelGS;
            labelSuperior[7] = LabelHS;
            labelSuperior[8] = LabelIS;
            labelSuperior[9] = LabelJS;
            labelSuperior[10] = LabelKS;
            labelSuperior[11] = LabelLS;
            labelSuperior[12] = LabelMS;
            labelSuperior[13] = LabelNS;
            labelSuperior[14] = LabelÑS;
            labelSuperior[15] = LabelOS;
            labelSuperior[16] = LabelPS;
            labelSuperior[17] = LabelQS;
            labelSuperior[18] = LabelRS;
            labelSuperior[19] = LabelSS;

            labelInferior[0] = LabelAI;
            labelInferior[1] = LabelBI;
            labelInferior[2] = LabelCI;
            labelInferior[3] = LabelDI;
            labelInferior[4] = LabelEI;
            labelInferior[5] = LabelFI;
            labelInferior[6] = LabelGI;
            labelInferior[7] = LabelHI;
            labelInferior[8] = LabelII;
            labelInferior[9] = LabelJI;
            labelInferior[10] = LabelKI;
            labelInferior[11] = LabelLI;
            labelInferior[12] = LabelMI;
            labelInferior[13] = LabelNI;
            labelInferior[14] = LabelÑI;
            labelInferior[15] = LabelOI;
            labelInferior[16] = LabelPI;
            labelInferior[17] = LabelQI;
            labelInferior[18] = LabelRI;
            labelInferior[19] = LabelSI;

            //botones para el tablero
            tableroColor[0, 0] = BtnA1;
            tableroColor[0, 1] = BtnB1;
            tableroColor[0, 2] = BtnC1;
            tableroColor[0, 3] = BtnD1;
            tableroColor[0, 4] = BtnE1;
            tableroColor[0, 5] = BtnF1;
            tableroColor[0, 6] = BtnG1;
            tableroColor[0, 7] = BtnH1;
            tableroColor[0, 8] = BtnI1;
            tableroColor[0, 9] = BtnJ1;
            tableroColor[0, 10] = BtnK1;
            tableroColor[0, 11] = BtnL1;
            tableroColor[0, 12] = BtnM1;
            tableroColor[0, 13] = BtnN1;
            tableroColor[0, 14] = BtnÑ1;
            tableroColor[0, 15] = BtnO1;
            tableroColor[0, 16] = BtnP1;
            tableroColor[0, 17] = BtnQ1;
            tableroColor[0, 18] = BtnR1;
            tableroColor[0, 19] = BtnS1;

            tableroColor[1, 0] = BtnA2;
            tableroColor[1, 1] = BtnB2;
            tableroColor[1, 2] = BtnC2;
            tableroColor[1, 3] = BtnD2;
            tableroColor[1, 4] = BtnE2;
            tableroColor[1, 5] = BtnF2;
            tableroColor[1, 6] = BtnG2;
            tableroColor[1, 7] = BtnH2;
            tableroColor[1, 8] = BtnI2;
            tableroColor[1, 9] = BtnJ2;
            tableroColor[1, 10] = BtnK2;
            tableroColor[1, 11] = BtnL2;
            tableroColor[1, 12] = BtnM2;
            tableroColor[1, 13] = BtnN2;
            tableroColor[1, 14] = BtnÑ2;
            tableroColor[1, 15] = BtnO2;
            tableroColor[1, 16] = BtnP2;
            tableroColor[1, 17] = BtnQ2;
            tableroColor[1, 18] = BtnR2;
            tableroColor[1, 19] = BtnS2;


            tableroColor[2, 0] = BtnA3;
            tableroColor[2, 1] = BtnB3;
            tableroColor[2, 2] = BtnC3;
            tableroColor[2, 3] = BtnD3;
            tableroColor[2, 4] = BtnE3;
            tableroColor[2, 5] = BtnF3;
            tableroColor[2, 6] = BtnG3;
            tableroColor[2, 7] = BtnH3;
            tableroColor[2, 8] = BtnI3;
            tableroColor[2, 9] = BtnJ3;
            tableroColor[2, 10] = BtnK3;
            tableroColor[2, 11] = BtnL3;
            tableroColor[2, 12] = BtnM3;
            tableroColor[2, 13] = BtnN3;
            tableroColor[2, 14] = BtnÑ3;
            tableroColor[2, 15] = BtnO3;
            tableroColor[2, 16] = BtnP3;
            tableroColor[2, 17] = BtnQ3;
            tableroColor[2, 18] = BtnR3;
            tableroColor[2, 19] = BtnS3;

            tableroColor[3, 0] = BtnA4;
            tableroColor[3, 1] = BtnB4;
            tableroColor[3, 2] = BtnC4;
            tableroColor[3, 3] = BtnD4;
            tableroColor[3, 4] = BtnE4;
            tableroColor[3, 5] = BtnF4;
            tableroColor[3, 6] = BtnG4;
            tableroColor[3, 7] = BtnH4;
            tableroColor[3, 8] = BtnI4;
            tableroColor[3, 9] = BtnJ4;
            tableroColor[3, 10] = BtnK4;
            tableroColor[3, 11] = BtnL4;
            tableroColor[3, 12] = BtnM4;
            tableroColor[3, 13] = BtnN4;
            tableroColor[3, 14] = BtnÑ4;
            tableroColor[3, 15] = BtnO4;
            tableroColor[3, 16] = BtnP4;
            tableroColor[3, 17] = BtnQ4;
            tableroColor[3, 18] = BtnR4;
            tableroColor[3, 19] = BtnS4;

            tableroColor[4, 0] = BtnA5;
            tableroColor[4, 1] = BtnB5;
            tableroColor[4, 2] = BtnC5;
            tableroColor[4, 3] = BtnD5;
            tableroColor[4, 4] = BtnE5;
            tableroColor[4, 5] = BtnF5;
            tableroColor[4, 6] = BtnG5;
            tableroColor[4, 7] = BtnH5;
            tableroColor[4, 8] = BtnI5;
            tableroColor[4, 9] = BtnJ5;
            tableroColor[4, 10] = BtnK5;
            tableroColor[4, 11] = BtnL5;
            tableroColor[4, 12] = BtnM5;
            tableroColor[4, 13] = BtnN5;
            tableroColor[4, 14] = BtnÑ5;
            tableroColor[4, 15] = BtnO5;
            tableroColor[4, 16] = BtnP5;
            tableroColor[4, 17] = BtnQ5;
            tableroColor[4, 18] = BtnR5;
            tableroColor[4, 19] = BtnS5;

            tableroColor[5, 0] = BtnA6;
            tableroColor[5, 1] = BtnB6;
            tableroColor[5, 2] = BtnC6;
            tableroColor[5, 3] = BtnD6;
            tableroColor[5, 4] = BtnE6;
            tableroColor[5, 5] = BtnF6;
            tableroColor[5, 6] = BtnG6;
            tableroColor[5, 7] = BtnH6;
            tableroColor[5, 8] = BtnI6;
            tableroColor[5, 9] = BtnJ6;
            tableroColor[5, 10] = BtnK6;
            tableroColor[5, 11] = BtnL6;
            tableroColor[5, 12] = BtnM6;
            tableroColor[5, 13] = BtnN6;
            tableroColor[5, 14] = BtnÑ6;
            tableroColor[5, 15] = BtnO6;
            tableroColor[5, 16] = BtnP6;
            tableroColor[5, 17] = BtnQ6;
            tableroColor[5, 18] = BtnR6;
            tableroColor[5, 19] = BtnS6;

            tableroColor[6, 0] = BtnA7;
            tableroColor[6, 1] = BtnB7;
            tableroColor[6, 2] = BtnC7;
            tableroColor[6, 3] = BtnD7;
            tableroColor[6, 4] = BtnE7;
            tableroColor[6, 5] = BtnF7;
            tableroColor[6, 6] = BtnG7;
            tableroColor[6, 7] = BtnH7;
            tableroColor[6, 8] = BtnI7;
            tableroColor[6, 9] = BtnJ7;
            tableroColor[6, 10] = BtnK7;
            tableroColor[6, 11] = BtnL7;
            tableroColor[6, 12] = BtnM7;
            tableroColor[6, 13] = BtnN7;
            tableroColor[6, 14] = BtnÑ7;
            tableroColor[6, 15] = BtnO7;
            tableroColor[6, 16] = BtnP7;
            tableroColor[6, 17] = BtnQ7;
            tableroColor[6, 18] = BtnR7;
            tableroColor[6, 19] = BtnS7;

            tableroColor[7, 0] = BtnA8;
            tableroColor[7, 1] = BtnB8;
            tableroColor[7, 2] = BtnC8;
            tableroColor[7, 3] = BtnD8;
            tableroColor[7, 4] = BtnE8;
            tableroColor[7, 5] = BtnF8;
            tableroColor[7, 6] = BtnG8;
            tableroColor[7, 7] = BtnH8;
            tableroColor[7, 8] = BtnI8;
            tableroColor[7, 9] = BtnJ8;
            tableroColor[7, 10] = BtnK8;
            tableroColor[7, 11] = BtnL8;
            tableroColor[7, 12] = BtnM8;
            tableroColor[7, 13] = BtnN8;
            tableroColor[7, 14] = BtnÑ8;
            tableroColor[7, 15] = BtnO8;
            tableroColor[7, 16] = BtnP8;
            tableroColor[7, 17] = BtnQ8;
            tableroColor[7, 18] = BtnR8;
            tableroColor[7, 19] = BtnS8;

            tableroColor[8, 0] = BtnA9;
            tableroColor[8, 1] = BtnB9;
            tableroColor[8, 2] = BtnC9;
            tableroColor[8, 3] = BtnD9;
            tableroColor[8, 4] = BtnE9;
            tableroColor[8, 5] = BtnF9;
            tableroColor[8, 6] = BtnG9;
            tableroColor[8, 7] = BtnH9;
            tableroColor[8, 8] = BtnI9;
            tableroColor[8, 9] = BtnJ9;
            tableroColor[8, 10] = BtnK9;
            tableroColor[8, 11] = BtnL9;
            tableroColor[8, 12] = BtnM9;
            tableroColor[8, 13] = BtnN9;
            tableroColor[8, 14] = BtnÑ9;
            tableroColor[8, 15] = BtnO9;
            tableroColor[8, 16] = BtnP9;
            tableroColor[8, 17] = BtnQ9;
            tableroColor[8, 18] = BtnR9;
            tableroColor[8, 19] = BtnS9;

            tableroColor[9, 0] = BtnA10;
            tableroColor[9, 1] = BtnB10;
            tableroColor[9, 2] = BtnC10;
            tableroColor[9, 3] = BtnD10;
            tableroColor[9, 4] = BtnE10;
            tableroColor[9, 5] = BtnF10;
            tableroColor[9, 6] = BtnG10;
            tableroColor[9, 7] = BtnH10;
            tableroColor[9, 8] = BtnI10;
            tableroColor[9, 9] = BtnJ10;
            tableroColor[9, 10] = BtnK10;
            tableroColor[9, 11] = BtnL10;
            tableroColor[9, 12] = BtnM10;
            tableroColor[9, 13] = BtnN10;
            tableroColor[9, 14] = BtnÑ10;
            tableroColor[9, 15] = BtnO10;
            tableroColor[9, 16] = BtnP10;
            tableroColor[9, 17] = BtnQ10;
            tableroColor[9, 18] = BtnR10;
            tableroColor[9, 19] = BtnS10;

            tableroColor[10, 0] = BtnA11;
            tableroColor[10, 1] = BtnB11;
            tableroColor[10, 2] = BtnC11;
            tableroColor[10, 3] = BtnD11;
            tableroColor[10, 4] = BtnE11;
            tableroColor[10, 5] = BtnF11;
            tableroColor[10, 6] = BtnG11;
            tableroColor[10, 7] = BtnH11;
            tableroColor[10, 8] = BtnI11;
            tableroColor[10, 9] = BtnJ11;
            tableroColor[10, 10] = BtnK11;
            tableroColor[10, 11] = BtnL11;
            tableroColor[10, 12] = BtnM11;
            tableroColor[10, 13] = BtnN11;
            tableroColor[10, 14] = BtnÑ11;
            tableroColor[10, 15] = BtnO11;
            tableroColor[10, 16] = BtnP11;
            tableroColor[10, 17] = BtnQ11;
            tableroColor[10, 18] = BtnR11;
            tableroColor[10, 19] = BtnS11;

            tableroColor[11, 0] = BtnA12;
            tableroColor[11, 1] = BtnB12;
            tableroColor[11, 2] = BtnC12;
            tableroColor[11, 3] = BtnD12;
            tableroColor[11, 4] = BtnE12;
            tableroColor[11, 5] = BtnF12;
            tableroColor[11, 6] = BtnG12;
            tableroColor[11, 7] = BtnH12;
            tableroColor[11, 8] = BtnI12;
            tableroColor[11, 9] = BtnJ12;
            tableroColor[11, 10] = BtnK12;
            tableroColor[11, 11] = BtnL12;
            tableroColor[11, 12] = BtnM12;
            tableroColor[11, 13] = BtnN12;
            tableroColor[11, 14] = BtnÑ12;
            tableroColor[11, 15] = BtnO12;
            tableroColor[11, 16] = BtnP12;
            tableroColor[11, 17] = BtnQ12;
            tableroColor[11, 18] = BtnR12;
            tableroColor[11, 19] = BtnS12;

            tableroColor[12, 0] = BtnA13;
            tableroColor[12, 1] = BtnB13;
            tableroColor[12, 2] = BtnC13;
            tableroColor[12, 3] = BtnD13;
            tableroColor[12, 4] = BtnE13;
            tableroColor[12, 5] = BtnF13;
            tableroColor[12, 6] = BtnG13;
            tableroColor[12, 7] = BtnH13;
            tableroColor[12, 8] = BtnI13;
            tableroColor[12, 9] = BtnJ13;
            tableroColor[12, 10] = BtnK13;
            tableroColor[12, 11] = BtnL13;
            tableroColor[12, 12] = BtnM13;
            tableroColor[12, 13] = BtnN13;
            tableroColor[12, 14] = BtnÑ13;
            tableroColor[12, 15] = BtnO13;
            tableroColor[12, 16] = BtnP13;
            tableroColor[12, 17] = BtnQ13;
            tableroColor[12, 18] = BtnR13;
            tableroColor[12, 19] = BtnS13;

            tableroColor[13, 0] = BtnA14;
            tableroColor[13, 1] = BtnB14;
            tableroColor[13, 2] = BtnC14;
            tableroColor[13, 3] = BtnD14;
            tableroColor[13, 4] = BtnE14;
            tableroColor[13, 5] = BtnF14;
            tableroColor[13, 6] = BtnG14;
            tableroColor[13, 7] = BtnH14;
            tableroColor[13, 8] = BtnI14;
            tableroColor[13, 9] = BtnJ14;
            tableroColor[13, 10] = BtnK14;
            tableroColor[13, 11] = BtnL14;
            tableroColor[13, 12] = BtnM14;
            tableroColor[13, 13] = BtnN14;
            tableroColor[13, 14] = BtnÑ14;
            tableroColor[13, 15] = BtnO14;
            tableroColor[13, 16] = BtnP14;
            tableroColor[13, 17] = BtnQ14;
            tableroColor[13, 18] = BtnR14;
            tableroColor[13, 19] = BtnS14;

            tableroColor[14, 0] = BtnA15;
            tableroColor[14, 1] = BtnB15;
            tableroColor[14, 2] = BtnC15;
            tableroColor[14, 3] = BtnD15;
            tableroColor[14, 4] = BtnE15;
            tableroColor[14, 5] = BtnF15;
            tableroColor[14, 6] = BtnG15;
            tableroColor[14, 7] = BtnH15;
            tableroColor[14, 8] = BtnI15;
            tableroColor[14, 9] = BtnJ15;
            tableroColor[14, 10] = BtnK15;
            tableroColor[14, 11] = BtnL15;
            tableroColor[14, 12] = BtnM15;
            tableroColor[14, 13] = BtnN15;
            tableroColor[14, 14] = BtnÑ15;
            tableroColor[14, 15] = BtnO15;
            tableroColor[14, 16] = BtnP15;
            tableroColor[14, 17] = BtnQ15;
            tableroColor[14, 18] = BtnR15;
            tableroColor[14, 19] = BtnS15;

            tableroColor[15, 0] = BtnA16;
            tableroColor[15, 1] = BtnB16;
            tableroColor[15, 2] = BtnC16;
            tableroColor[15, 3] = BtnD16;
            tableroColor[15, 4] = BtnE16;
            tableroColor[15, 5] = BtnF16;
            tableroColor[15, 6] = BtnG16;
            tableroColor[15, 7] = BtnH16;
            tableroColor[15, 8] = BtnI16;
            tableroColor[15, 9] = BtnJ16;
            tableroColor[15, 10] = BtnK16;
            tableroColor[15, 11] = BtnL16;
            tableroColor[15, 12] = BtnM16;
            tableroColor[15, 13] = BtnN16;
            tableroColor[15, 14] = BtnÑ16;
            tableroColor[15, 15] = BtnO16;
            tableroColor[15, 16] = BtnP16;
            tableroColor[15, 17] = BtnQ16;
            tableroColor[15, 18] = BtnR16;
            tableroColor[15, 19] = BtnS16;



            tableroColor[16, 0] = BtnA17;
            tableroColor[16, 1] = BtnB17;
            tableroColor[16, 2] = BtnC17;
            tableroColor[16, 3] = BtnD17;
            tableroColor[16, 4] = BtnE17;
            tableroColor[16, 5] = BtnF17;
            tableroColor[16, 6] = BtnG17;
            tableroColor[16, 7] = BtnH17;
            tableroColor[16, 8] = BtnI17;
            tableroColor[16, 9] = BtnJ17;
            tableroColor[16, 10] = BtnK17;
            tableroColor[16, 11] = BtnL17;
            tableroColor[16, 12] = BtnM17;
            tableroColor[16, 13] = BtnN17;
            tableroColor[16, 14] = BtnÑ17;
            tableroColor[16, 15] = BtnO17;
            tableroColor[16, 16] = BtnP17;
            tableroColor[16, 17] = BtnQ17;
            tableroColor[16, 18] = BtnR17;
            tableroColor[16, 19] = BtnS17;

            tableroColor[17, 0] = BtnA18;
            tableroColor[17, 1] = BtnB18;
            tableroColor[17, 2] = BtnC18;
            tableroColor[17, 3] = BtnD18;
            tableroColor[17, 4] = BtnE18;
            tableroColor[17, 5] = BtnF18;
            tableroColor[17, 6] = BtnG18;
            tableroColor[17, 7] = BtnH18;
            tableroColor[17, 8] = BtnI18;
            tableroColor[17, 9] = BtnJ18;
            tableroColor[17, 10] = BtnK18;
            tableroColor[17, 11] = BtnL18;
            tableroColor[17, 12] = BtnM18;
            tableroColor[17, 13] = BtnN18;
            tableroColor[17, 14] = BtnÑ18;
            tableroColor[17, 15] = BtnO18;
            tableroColor[17, 16] = BtnP18;
            tableroColor[17, 17] = BtnQ18;
            tableroColor[17, 18] = BtnR18;
            tableroColor[17, 19] = BtnS18;

            tableroColor[18, 0] = BtnA19;
            tableroColor[18, 1] = BtnB19;
            tableroColor[18, 2] = BtnC19;
            tableroColor[18, 3] = BtnD19;
            tableroColor[18, 4] = BtnE19;
            tableroColor[18, 5] = BtnF19;
            tableroColor[18, 6] = BtnG19;
            tableroColor[18, 7] = BtnH19;
            tableroColor[18, 8] = BtnI19;
            tableroColor[18, 9] = BtnJ19;
            tableroColor[18, 10] = BtnK19;
            tableroColor[18, 11] = BtnL19;
            tableroColor[18, 12] = BtnM19;
            tableroColor[18, 13] = BtnN19;
            tableroColor[18, 14] = BtnÑ19;
            tableroColor[18, 15] = BtnO19;
            tableroColor[18, 16] = BtnP19;
            tableroColor[18, 17] = BtnQ19;
            tableroColor[18, 18] = BtnR19;
            tableroColor[18, 19] = BtnS19;

            tableroColor[19, 0] = BtnA20;
            tableroColor[19, 1] = BtnB20;
            tableroColor[19, 2] = BtnC20;
            tableroColor[19, 3] = BtnD20;
            tableroColor[19, 4] = BtnE20;
            tableroColor[19, 5] = BtnF20;
            tableroColor[19, 6] = BtnG20;
            tableroColor[19, 7] = BtnH20;
            tableroColor[19, 8] = BtnI20;
            tableroColor[19, 9] = BtnJ20;
            tableroColor[19, 10] = BtnK20;
            tableroColor[19, 11] = BtnL20;
            tableroColor[19, 12] = BtnM20;
            tableroColor[19, 13] = BtnN20;
            tableroColor[19, 14] = BtnÑ20;
            tableroColor[19, 15] = BtnO20;
            tableroColor[19, 16] = BtnP20;
            tableroColor[19, 17] = BtnQ20;
            tableroColor[19, 18] = BtnR20;
            tableroColor[19, 19] = BtnS20;

            //al iniciar todo es bloqueado
            if (!IsPostBack)
            {

                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        tableroColor[i, j].BackColor = Color.GreenYellow;
                        tableroColor[i, j].Enabled = false;
                    }
                }
                


            }

           
        }

        protected void ButtonSeleccionar2_Click(object sender, EventArgs e)
        {
            
            if (contadorColorj2<5)
            {
                string seleccion = DropDownListFicha2.SelectedItem.ToString();
                int valor = DropDownListFicha2.SelectedIndex;
                if (seleccion == "Rojo")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha2.SelectedValue = "Elegir";
                    contadorColorj2++;
                    LabelSeleccionJugador2.Text = "Color Jugador 2:" + contadorColorj2;
                    arrayJugador2.Add("Rojo");
                }
                else if (seleccion == "Amarillo")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha2.SelectedValue = "Elegir";
                    contadorColorj2++;
                    LabelSeleccionJugador2.Text = "Color Jugador 2:" + contadorColorj2;
                    arrayJugador2.Add("Amarillo");
                }
                else if (seleccion == "Azul")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha2.SelectedValue = "Elegir";
                    contadorColorj2++;
                    LabelSeleccionJugador2.Text = "Color Jugador 2:" + contadorColorj2;
                    arrayJugador2.Add("Azul");
                }
                else if (seleccion == "Anaranjado")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha2.SelectedValue = "Elegir";
                    contadorColorj2++;
                    LabelSeleccionJugador2.Text = "Color Jugador 2:" + contadorColorj2;
                    arrayJugador2.Add("Anaranjado");
                }
                else if (seleccion == "Verde")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha2.SelectedValue = "Elegir";
                    contadorColorj2++;
                    LabelSeleccionJugador2.Text = "Color Jugador 2:" + contadorColorj2;
                    arrayJugador2.Add("Verde");
                }
                else if (seleccion == "Violeta")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha2.SelectedValue = "Elegir";
                    contadorColorj2++;
                    LabelSeleccionJugador2.Text = "Color Jugador 2:" + contadorColorj2;
                    arrayJugador2.Add("Violeta");
                }
                else if (seleccion == "Blanco")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha2.SelectedValue = "Elegir";
                    contadorColorj2++;
                    LabelSeleccionJugador2.Text = "Color Jugador 2:" + contadorColorj2;
                    arrayJugador2.Add("Blanco");
                }
                else if (seleccion == "Negro")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha2.SelectedValue = "Elegir";
                    contadorColorj2++;
                    LabelSeleccionJugador2.Text = "Color Jugador 2:" + contadorColorj2;
                    arrayJugador2.Add("Negro");
                }
                else if (seleccion == "Celeste")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha2.SelectedValue = "Elegir";
                    contadorColorj2++;
                    LabelSeleccionJugador2.Text = "Color Jugador 2:" + contadorColorj2;
                    arrayJugador2.Add("Celeste");
                }
                else if (seleccion == "Gris")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha2.SelectedValue = "Elegir";
                    contadorColorj2++;
                    LabelSeleccionJugador2.Text = "Color Jugador 2:" + contadorColorj2;
                    arrayJugador2.Add("Gris");
                }
            }
        }

        protected void ButtonSeleccionar1_Click(object sender, EventArgs e)
        {
            if (contadorColorj1<5)
            {

                string seleccion = DropDownListFicha1.SelectedItem.ToString();
                int valor = DropDownListFicha1.SelectedIndex;


                if (seleccion == "Rojo")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha1.SelectedValue = "Elegir";
                    contadorColorj1++;
                    LabelSeleccionJugador1.Text = "Color Jugador 1:" + contadorColorj1;
                    arrayJugador1.Add("Rojo");
                    

                }
                else if (seleccion == "Amarillo")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha1.SelectedValue = "Elegir";
                    contadorColorj1++;
                    LabelSeleccionJugador1.Text = "Color Jugador 1:" + contadorColorj1;
                    arrayJugador1.Add("Amarillo");
                }
                else if (seleccion == "Azul")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha1.SelectedValue = "Elegir";
                    contadorColorj1++;
                    LabelSeleccionJugador1.Text = "Color Jugador 1:" + contadorColorj1;
                    arrayJugador1.Add("Azul");
                }
                else if (seleccion == "Anaranjado")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha1.SelectedValue = "Elegir";
                    contadorColorj1++;
                    LabelSeleccionJugador1.Text = "Color Jugador 1:" + contadorColorj1;
                    arrayJugador1.Add("Anaranjado");
                }
                else if (seleccion == "Verde")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha1.SelectedValue = "Elegir";
                    contadorColorj1++;
                    LabelSeleccionJugador1.Text = "Color Jugador 1:" + contadorColorj1;
                    arrayJugador1.Add("Verde");
                }
                else if (seleccion == "Violeta")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha1.SelectedValue = "Elegir";
                    contadorColorj1++;
                    LabelSeleccionJugador1.Text = "Color Jugador 1:" + contadorColorj1;
                    arrayJugador1.Add("Violeta");
                }
                else if (seleccion == "Blanco")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha1.SelectedValue = "Elegir";
                    contadorColorj1++;
                    LabelSeleccionJugador1.Text = "Color Jugador 1:" + contadorColorj1;
                    arrayJugador1.Add("Blanco");
                }
                else if (seleccion == "Negro")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha1.SelectedValue = "Elegir";
                    contadorColorj1++;
                    LabelSeleccionJugador1.Text = "Color Jugador 1:" + contadorColorj1;
                    arrayJugador1.Add("Negro");
                }
                else if (seleccion == "Celeste")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha1.SelectedValue = "Elegir";
                    contadorColorj1++;
                    LabelSeleccionJugador1.Text = "Color Jugador 1:" + contadorColorj1;
                    arrayJugador1.Add("Celeste");
                }
                else if (seleccion == "Gris")
                {
                    DropDownListFicha1.Items.RemoveAt(valor);
                    DropDownListFicha2.Items.RemoveAt(valor);
                    DropDownListFicha1.SelectedValue = "Elegir";
                    contadorColorj1++;
                    LabelSeleccionJugador1.Text = "Color Jugador 1:" + contadorColorj1;
                    arrayJugador1.Add("Gris");
                }

            }


           
        }

        //BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB

        // Para J1 digamos blanca
        public void capturaFichaJ1(int fil, int column)
        {   //x,y
            int fila = fil;
            int columna = column;
            int posicion = 0;


            //direccion1
            //fila = cambia , columna = igual
            for (int i = fila - 1; i >= 0; i--) // para fila
            {
                if (tableroInterno[i,columna].ToString() == "0")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[i, columna].ToString() == "1")
                {
                    if (posicion >= 1)
                    {
                        pintarJ1Direccion1(fila, i, columna);
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
            for (int i = columna + 1; i <= columnaTamaño-1; i++) // para columna
            {

                filaContador--;
                if (filaContador < 0)
                {
                    break;
                }
                if (tableroInterno[filaContador, i].ToString() == "0")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[filaContador,i].ToString() == "1")
                {
                    if (posicion >= 1)
                    {
                        pintarJ1Direccion2(fila, columna, i);
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
            for (int i = columna + 1; i <= columnaTamaño-1; i++) // para columna 
            {
                if (tableroInterno[fila,i].ToString() == "0")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[fila,i].ToString() == "1")
                {

                    if (posicion >= 1)
                    {
                        pintarJ1Direccion3(fila, columna, i);
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
            for (int i = columna + 1; i <= columnaTamaño-1; i++) // para columna
            {
                filadireccion4++;

                if (filadireccion4 >= filaTamaño) // fila >= tamañofila se sale del ciclo
                {
                    break;
                }
                if (tableroInterno[filadireccion4, i].ToString() == "0")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[filadireccion4, i].ToString() == "1")
                {

                    if (posicion >= 1)
                    {
                        pintarJ1Direccion4(fila, columna, i);
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
            for (int i = fila + 1; i <= filaTamaño-1; i++) // para fila
            {
                if (tableroInterno[i, columna].ToString() == "0")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[i, columna].ToString() == "1")
                {
                    if (posicion >= 1)
                    {
                        //metodo
                        pintarJ1Direccion5(fila, i, columna);
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
            for (int i = fila + 1; i <= filaTamaño-1; i++) // para fila
            {
                columnadireccion6--;
                if (columnadireccion6 < 0)
                {
                    break;
                }
                if (tableroInterno[i, columnadireccion6].ToString() == "0")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[i, columnadireccion6].ToString() == "1")
                {

                    if (posicion >= 1)
                    {
                        //metododireccion6
                        pintarJ1Direccion6(fila, i, columna);
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
                if (tableroInterno[fila, i].ToString() == "0")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[fila, i].ToString() == "1")
                {
                    if (posicion >= 1)
                    {
                        //metodo
                        pintarJ1Direccion7(columna, i, fila);
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
                if (tableroInterno[i, columnadireccion8].ToString() == "0")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[i, columnadireccion8].ToString() == "1")
                {
                    if (posicion >= 1)
                    {
                        //metodod
                        pintarJ1Direccion8(fila, i, columna);
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
        public void pintarJ1Direccion1(int filaInicio, int filaFin, int columna)
        {
            for (int i = filaInicio; i >= filaFin+1; i--)
            {
                switch (arrayJugador1[cambio1-1].ToString())
                {
                    case "Rojo":
                        tableroColor[i, columna].BackColor = Color.Red;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Amarillo":
                        tableroColor[i, columna].BackColor = Color.Yellow;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Azul":
                        tableroColor[i, columna].BackColor = Color.Blue;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Anaranjado":
                        tableroColor[i, columna].BackColor = Color.Orange;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Verde":
                        tableroColor[i, columna].BackColor = Color.Green;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Violeta":
                        tableroColor[i, columna].BackColor = Color.Violet;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Blanco":
                        tableroColor[i, columna].BackColor = Color.White;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Negro":
                        tableroColor[i, columna].BackColor = Color.Black;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Celeste":
                        tableroColor[i, columna].BackColor = Color.LightBlue;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Gris":
                        tableroColor[i, columna].BackColor = Color.Gray;
                        tableroInterno[i, columna] = "1";
                        break;
                }

            }


        }

        public void pintarJ1Direccion2(int filaInicio, int columnaInicio, int columnaFin)
        {
            int fila = filaInicio;
            columnaFin = columnaFin - 1;
            for (int i = columnaInicio; i <= columnaFin; i++)
            {
                switch(arrayJugador1[cambio1-1].ToString())
                {
                    case "Rojo":
                        tableroColor[fila, i].BackColor = Color.Red;
                        tableroInterno[fila, i] = "1";
                        fila--;
                        break;
                    case "Amarillo":
                        tableroColor[fila, i].BackColor = Color.Yellow;
                        tableroInterno[fila, i] = "1";
                        fila--;
                        break;
                    case "Azul":
                        tableroColor[fila, i].BackColor = Color.Blue;
                        tableroInterno[fila, i] = "1";
                        fila--;
                        break;
                    case "Anaranjado":
                        tableroColor[fila, i].BackColor = Color.Orange;
                        tableroInterno[fila, i] = "1";
                        fila--;
                        break;
                    case "Verde":
                        tableroColor[fila, i].BackColor = Color.Green;
                        tableroInterno[fila, i] = "1";
                        fila--;
                        break;
                    case "Violeta":
                        tableroColor[fila, i].BackColor = Color.Violet;
                        tableroInterno[fila, i] = "1";
                        fila--;
                        break;
                    case "Blanco":
                        tableroColor[fila, i].BackColor = Color.White;
                        tableroInterno[fila, i] = "1";
                        fila--;
                        break;
                    case "Negro":
                        tableroColor[fila, i].BackColor = Color.Black;
                        tableroInterno[fila, i] = "1";
                        fila--;
                        break;
                    case "Celeste":
                        tableroColor[fila, i].BackColor = Color.LightBlue;
                        tableroInterno[fila, i] = "1";
                        fila--;
                        break;
                    case "Gris":
                        tableroColor[fila, i].BackColor = Color.Gray;
                        tableroInterno[fila, i] = "1";
                        fila--;
                        break;
                }
                

            }

        }

        public void pintarJ1Direccion3(int fila, int inicioColumna, int finColumna)
        {
            for (int i = inicioColumna; i <= finColumna-1; i++) //columna
            {
                switch (arrayJugador1[cambio1-1].ToString())
                {
                    case "Rojo":
                        tableroColor[fila, i].BackColor = Color.Red;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Amarillo":
                        tableroColor[fila, i].BackColor = Color.Yellow;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Azul":
                        tableroColor[fila, i].BackColor = Color.Blue;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Anaranjado":
                        tableroColor[fila, i].BackColor = Color.Orange;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Verde":
                        tableroColor[fila, i].BackColor = Color.Green;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Violeta":
                        tableroColor[fila, i].BackColor = Color.Violet;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Blanco":
                        tableroColor[fila, i].BackColor = Color.White;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Negro":
                        tableroColor[fila, i].BackColor = Color.Black;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Celeste":
                        tableroColor[fila, i].BackColor = Color.LightBlue;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Gris":
                        tableroColor[fila, i].BackColor = Color.Gray;
                        tableroInterno[fila, i] = "1";
                        break;
                }
               
            }
        }

        public void pintarJ1Direccion4(int fila, int inicioColumna, int finColumna)
        {
            int filaInicio = fila;
            for (int i = inicioColumna; i <= finColumna-1; i++)
            {
                switch (arrayJugador1[cambio1-1].ToString())
                {
                    case "Rojo":
                        tableroColor[filaInicio, i].BackColor = Color.Red;
                        tableroInterno[filaInicio, i] = "1";
                        filaInicio++;
                        break;
                    case "Amarillo":
                        tableroColor[filaInicio, i].BackColor = Color.Yellow;
                        tableroInterno[filaInicio, i] = "1";
                        filaInicio++;
                        break;
                    case "Azul":
                        tableroColor[filaInicio, i].BackColor = Color.Blue;
                        tableroInterno[filaInicio, i] = "1";
                        filaInicio++;
                        break;
                    case "Anaranjado":
                        tableroColor[filaInicio, i].BackColor = Color.Orange;
                        tableroInterno[filaInicio, i] = "1";
                        filaInicio++;
                        break;
                    case "Verde":
                        tableroColor[filaInicio, i].BackColor = Color.Green;
                        tableroInterno[filaInicio, i] = "1";
                        filaInicio++;
                        break;
                    case "Violeta":
                        tableroColor[filaInicio, i].BackColor = Color.Violet;
                        tableroInterno[filaInicio, i] = "1";
                        filaInicio++;
                        break;
                    case "Blanco":
                        tableroColor[filaInicio, i].BackColor = Color.White;
                        tableroInterno[filaInicio, i] = "1";
                        filaInicio++;
                        break;
                    case "Negro":
                        tableroColor[filaInicio, i].BackColor = Color.Black;
                        tableroInterno[filaInicio, i] = "1";
                        filaInicio++;
                        break;
                    case "Celeste":
                        tableroColor[filaInicio, i].BackColor = Color.LightBlue;
                        tableroInterno[filaInicio, i] = "1";
                        filaInicio++;
                        break;
                    case "Gris":
                        tableroColor[filaInicio, i].BackColor = Color.Gray;
                        tableroInterno[filaInicio, i] = "1";
                        filaInicio++;
                        break;
                }
               
            }

        }

        public void pintarJ1Direccion5(int filaInicio, int filaFin, int columna)
        {
            for (int i = filaInicio; i <= filaFin-1; i++)
            {
                switch (arrayJugador1[cambio1-1].ToString())
                {
                    case "Rojo":
                        tableroColor[i, columna].BackColor = Color.Red;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Amarillo":
                        tableroColor[i, columna].BackColor = Color.Yellow;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Azul":
                        tableroColor[i, columna].BackColor = Color.Blue;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Anaranjado":
                        tableroColor[i, columna].BackColor = Color.Orange;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Verde":
                        tableroColor[i, columna].BackColor = Color.Green;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Violeta":
                        tableroColor[i, columna].BackColor = Color.Violet;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Blanco":
                        tableroColor[i, columna].BackColor = Color.White;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Negro":
                        tableroColor[i, columna].BackColor = Color.Black;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Celeste":
                        tableroColor[i, columna].BackColor = Color.LightBlue;
                        tableroInterno[i, columna] = "1";
                        break;
                    case "Gris":
                        tableroColor[i, columna].BackColor = Color.Gray;
                        tableroInterno[i, columna] = "1";
                        break;

                }
                
            }
        }

        public void pintarJ1Direccion6(int inicioFila, int finFila, int columna)
        {
            int columnadireccion = columna;
            for (int i = inicioFila; i <= finFila-1; i++)
            {
                switch (arrayJugador1[cambio1-1].ToString())
                {
                    case "Rojo":
                        tableroColor[i, columnadireccion].BackColor = Color.Red;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Amarillo":
                        tableroColor[i, columnadireccion].BackColor = Color.Yellow;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Azul":
                        tableroColor[i, columnadireccion].BackColor = Color.Blue;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Anaranjado":
                        tableroColor[i, columnadireccion].BackColor = Color.Orange;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Verde":
                        tableroColor[i, columnadireccion].BackColor = Color.Green;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Violeta":
                        tableroColor[i, columnadireccion].BackColor = Color.Violet;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Blanco":
                        tableroColor[i, columnadireccion].BackColor = Color.White;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Negro":
                        tableroColor[i, columnadireccion].BackColor = Color.Black;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Celeste":
                        tableroColor[i, columnadireccion].BackColor = Color.LightBlue;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Gris":
                        tableroColor[i, columnadireccion].BackColor = Color.Gray;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                }
                
            }
        }

        public void pintarJ1Direccion7(int inicioColumna, int finColumna, int fila)
        {
            for (int i = inicioColumna; i >= finColumna+1; i--)
            {
                switch(arrayJugador1[cambio1-1].ToString())
                {
                    case "Rojo":
                        tableroColor[fila, i].BackColor = Color.Red;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Amarillo":
                        tableroColor[fila, i].BackColor = Color.Yellow;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Azul":
                        tableroColor[fila, i].BackColor = Color.Blue;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Anaranjado":
                        tableroColor[fila, i].BackColor = Color.Orange;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Verde":
                        tableroColor[fila, i].BackColor = Color.Green;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Violeta":
                        tableroColor[fila, i].BackColor = Color.Violet;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Blanco":
                        tableroColor[fila, i].BackColor = Color.White;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Negro":
                        tableroColor[fila, i].BackColor = Color.Black;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Celeste":
                        tableroColor[fila, i].BackColor = Color.LightBlue;
                        tableroInterno[fila, i] = "1";
                        break;
                    case "Gris":
                        tableroColor[fila, i].BackColor = Color.Gray;
                        tableroInterno[fila, i] = "1";
                        break;
                }
               
            }
        }

        public void pintarJ1Direccion8(int inicioFila, int finFila, int columna)
        {
            int columnadireccion = columna;
            for (int i = inicioFila; i >= finFila+1; i--)
            {
                switch (arrayJugador1[cambio1-1].ToString())
                {
                    case "Rojo":
                        tableroColor[i, columnadireccion].BackColor = Color.Red;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Amarillo":
                        tableroColor[i, columnadireccion].BackColor = Color.Yellow;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Azul":
                        tableroColor[i, columnadireccion].BackColor = Color.Blue;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Anaranjado":
                        tableroColor[i, columnadireccion].BackColor = Color.Orange;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Verde":
                        tableroColor[i, columnadireccion].BackColor = Color.Green;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Violeta":
                        tableroColor[i, columnadireccion].BackColor = Color.Violet;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Blanco":
                        tableroColor[i, columnadireccion].BackColor = Color.White;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Negro":
                        tableroColor[i, columnadireccion].BackColor = Color.Black;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Celeste":
                        tableroColor[i, columnadireccion].BackColor = Color.LightBlue;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                    case "Gris":
                        tableroColor[i, columnadireccion].BackColor = Color.Gray;
                        tableroInterno[i, columnadireccion] = "1";
                        columnadireccion--;
                        break;
                }
                
            }

        }
        //metodo para habilitar botones si soy J1
        public void activacionBoton1(int fila, int columna)
        {
            int filaTemp = fila;
            int columnaTemp = columna;
            int contadorFicha = 0;


            //fila = disminuye  ------------->Direccion1

            for (int i = filaTemp - 1; i >= 0; i--)
            {
                if (tableroInterno[i, columnaTemp] == "1")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[i, columnaTemp] == "0")
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroInterno[i, columnaTemp] == "+")
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
            int auxColumnaD2 = columnaTemp; //columna
            for (int i = filaTemp - 1; i >= 0; i--)
            {
                auxColumnaD2++;
                if (auxColumnaD2 >= columnaTamaño)
                {
                    break;
                }
                if (tableroInterno[i, auxColumnaD2] == "1")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[i, auxColumnaD2] == "0")
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroInterno[i, auxColumnaD2] == "+")
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
            for (int i = columna + 1; i <= columnaTamaño-1; i++)
            {
                if (tableroInterno[auxFilaD3, i] == "1")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[auxFilaD3, i] == "0")
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroInterno[auxFilaD3, i] == "+")
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
            for (int i = columnaTemp + 1; i <= columnaTamaño-1; i++) // columna
            {
                auxFilaD4++;
                if (auxFilaD4 >= filaTamaño)
                {
                    break;
                }
                if (tableroInterno[auxFilaD4, i] == "1")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[auxFilaD4, i] == "0")
                {
                    contadorFicha++;
                    continue;

                }
                else if (tableroInterno[auxFilaD4, i] == "+")
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
            for (int i = filaTemp + 1; i <= filaTamaño-1; i++) //fila
            {
                if (tableroInterno[i, auxColumnaD5] == "1")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[i, auxColumnaD5] == "0")
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroInterno[i, auxColumnaD5] == "+")
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
                if (auxFilaD6 >= filaTamaño)
                {
                    break;
                }
                if (tableroInterno[auxFilaD6, i] == "1")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[auxFilaD6, i] == "0")
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroInterno[auxFilaD6, i] == "+")
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
                if (tableroInterno[auxFilaD7, i] == "1")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[auxFilaD7, i] == "0")
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroInterno[auxFilaD7, i] == "+")
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
                if (tableroInterno[i, auxColumnaD8] == "1")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[i, auxColumnaD8] == "0")
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroInterno[i, auxColumnaD8] == "+")
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



        //BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB


        //NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN

        // para cuando se ficha negra--------------------------------------------------------------------y
        // Para J1
        public void capturaFichaJ2(int fil, int column)
        {   //x,y
            int fila = fil;
            int columna = column;
            int posicion = 0;



            //direccion1
            //fila = cambia , columna = igual
            for (int i = fila - 1; i >= 0; i--) // para fila
            {
                if (tableroInterno[i, columna].ToString() == "1")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[i, columna].ToString() == "0")
                {
                    if (posicion >= 1)
                    {
                        pintarJ2Direccion1(fila, i, columna);
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
            for (int i = columna + 1; i <= columnaTamaño - 1; i++) // para columna
            {

                filaContador--;
                if (filaContador < 0)
                {
                    break;
                }
                if (tableroInterno[filaContador, i].ToString() == "1")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[filaContador, i].ToString() == "0")
                {
                    if (posicion >= 1)
                    {
                        pintarJ2Direccion2(fila, columna, i);
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
            for (int i = columna + 1; i <= columnaTamaño - 1; i++) // para columna 
            {
                if (tableroInterno[fila, i].ToString() == "1")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[fila, i].ToString() == "0")
                {

                    if (posicion >= 1)
                    {
                        pintarJ2Direccion3(fila, columna, i);
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
            for (int i = columna + 1; i <= columnaTamaño - 1; i++) // para columna
            {
                filadireccion4++;

                if (filadireccion4 >= filaTamaño) // fila >= tamañofila se sale del ciclo
                {
                    break;
                }
                if (tableroInterno[filadireccion4, i].ToString() == "1")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[filadireccion4, i].ToString() == "0")
                {

                    if (posicion >= 1)
                    {
                        pintarJ2Direccion4(fila, columna, i);
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
            for (int i = fila + 1; i <= filaTamaño - 1; i++) // para fila
            {
                if (tableroInterno[i, columna].ToString() == "1")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[i, columna].ToString() == "0")
                {
                    if (posicion >= 1)
                    {
                        //metodo
                        pintarJ2Direccion5(fila, i, columna);
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
            for (int i = fila + 1; i <= filaTamaño - 1; i++) // para fila
            {
                columnadireccion6--;
                if (columnadireccion6 < 0)
                {
                    break;
                }
                if (tableroInterno[i, columnadireccion6].ToString() == "1")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[i, columnadireccion6].ToString() == "0")
                {

                    if (posicion >= 1)
                    {
                        //metododireccion6
                        pintarJ2Direccion6(fila, i, columna);
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
                if (tableroInterno[fila,i].ToString() == "1")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[fila,i].ToString() == "0")
                {
                    if (posicion >= 1)
                    {
                        //metodo
                        pintarJ2Direccion7(columna, i, fila);
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
                if (tableroInterno[i, columnadireccion8].ToString() == "1")
                {
                    posicion++;
                    continue;
                }
                else if (tableroInterno[i, columnadireccion8].ToString() == "0")
                {
                    if (posicion >= 1)
                    {
                        //metodod
                        pintarJ2Direccion8(fila, i, columna);
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
        public void pintarJ2Direccion1(int filaInicio, int filaFin, int columna)
        {
            for (int i = filaInicio; i >= filaFin+1; i--)
            {
                switch (arrayJugador2[cambio2-1].ToString())
                {
                    case "Rojo":
                        tableroColor[i, columna].BackColor = Color.Red;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Amarillo":
                        tableroColor[i, columna].BackColor = Color.Yellow;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Azul":
                        tableroColor[i, columna].BackColor = Color.Blue;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Anaranjado":
                        tableroColor[i, columna].BackColor = Color.Orange;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Verde":
                        tableroColor[i, columna].BackColor = Color.Green;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Violeta":
                        tableroColor[i, columna].BackColor = Color.Violet;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Blanco":
                        tableroColor[i, columna].BackColor = Color.White;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Negro":
                        tableroColor[i, columna].BackColor = Color.Black;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Celeste":
                        tableroColor[i, columna].BackColor = Color.LightBlue;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Gris":
                        tableroColor[i, columna].BackColor = Color.Gray;
                        tableroInterno[i, columna] = "0";
                        break;
                }

            }

        }

        public void pintarJ2Direccion2(int filaInicio, int columnaInicio, int columnaFin)
        {
            int fila = filaInicio;
            columnaFin = columnaFin - 1;
            for (int i = columnaInicio; i <= columnaFin; i++)
            {
                switch (arrayJugador2[cambio2-1].ToString())
                {
                    case "Rojo":
                        tableroColor[fila, i].BackColor = Color.Red;
                        tableroInterno[fila, i] = "0";
                        fila--;
                        break;
                    case "Amarillo":
                        tableroColor[fila, i].BackColor = Color.Yellow;
                        tableroInterno[fila, i] = "0";
                        fila--;
                        break;
                    case "Azul":
                        tableroColor[fila, i].BackColor = Color.Blue;
                        tableroInterno[fila, i] = "0";
                        fila--;
                        break;
                    case "Anaranjado":
                        tableroColor[fila, i].BackColor = Color.Orange;
                        tableroInterno[fila, i] = "0";
                        fila--;
                        break;
                    case "Verde":
                        tableroColor[fila, i].BackColor = Color.Green;
                        tableroInterno[fila, i] = "0";
                        fila--;
                        break;
                    case "Violeta":
                        tableroColor[fila, i].BackColor = Color.Violet;
                        tableroInterno[fila, i] = "0";
                        fila--;
                        break;
                    case "Blanco":
                        tableroColor[fila, i].BackColor = Color.White;
                        tableroInterno[fila, i] = "0";
                        fila--;
                        break;
                    case "Negro":
                        tableroColor[fila, i].BackColor = Color.Black;
                        tableroInterno[fila, i] = "0";
                        fila--;
                        break;
                    case "Celeste":
                        tableroColor[fila, i].BackColor = Color.LightBlue;
                        tableroInterno[fila, i] = "0";
                        fila--;
                        break;
                    case "Gris":
                        tableroColor[fila, i].BackColor = Color.Gray;
                        tableroInterno[fila, i] = "0";
                        fila--;
                        break;
                }


            }

        }

        public void pintarJ2Direccion3(int fila, int inicioColumna, int finColumna)
        {
            for (int i = inicioColumna; i <= finColumna-1; i++) //columna
            {
                switch (arrayJugador2[cambio2-1].ToString())
                {
                    case "Rojo":
                        tableroColor[fila, i].BackColor = Color.Red;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Amarillo":
                        tableroColor[fila, i].BackColor = Color.Yellow;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Azul":
                        tableroColor[fila, i].BackColor = Color.Blue;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Anaranjado":
                        tableroColor[fila, i].BackColor = Color.Orange;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Verde":
                        tableroColor[fila, i].BackColor = Color.Green;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Violeta":
                        tableroColor[fila, i].BackColor = Color.Violet;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Blanco":
                        tableroColor[fila, i].BackColor = Color.White;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Negro":
                        tableroColor[fila, i].BackColor = Color.Black;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Celeste":
                        tableroColor[fila, i].BackColor = Color.LightBlue;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Gris":
                        tableroColor[fila, i].BackColor = Color.Gray;
                        tableroInterno[fila, i] = "0";
                        break;
                }

            }
        }

        public void pintarJ2Direccion4(int fila, int inicioColumna, int finColumna)
        {
            int filaInicio = fila;
            for (int i = inicioColumna; i <= finColumna-1; i++)
            {
                switch (arrayJugador2[cambio2-1].ToString())
                {
                    case "Rojo":
                        tableroColor[filaInicio, i].BackColor = Color.Red;
                        tableroInterno[filaInicio, i] = "0";
                        filaInicio++;
                        break;
                    case "Amarillo":
                        tableroColor[filaInicio, i].BackColor = Color.Yellow;
                        tableroInterno[filaInicio, i] = "0";
                        filaInicio++;
                        break;
                    case "Azul":
                        tableroColor[filaInicio, i].BackColor = Color.Blue;
                        tableroInterno[filaInicio, i] = "0";
                        filaInicio++;
                        break;
                    case "Anaranjado":
                        tableroColor[filaInicio, i].BackColor = Color.Orange;
                        tableroInterno[filaInicio, i] = "0";
                        filaInicio++;
                        break;
                    case "Verde":
                        tableroColor[filaInicio, i].BackColor = Color.Green;
                        tableroInterno[filaInicio, i] = "0";
                        filaInicio++;
                        break;
                    case "Violeta":
                        tableroColor[filaInicio, i].BackColor = Color.Violet;
                        tableroInterno[filaInicio, i] = "0";
                        filaInicio++;
                        break;
                    case "Blanco":
                        tableroColor[filaInicio, i].BackColor = Color.White;
                        tableroInterno[filaInicio, i] = "0";
                        filaInicio++;
                        break;
                    case "Negro":
                        tableroColor[filaInicio, i].BackColor = Color.Black;
                        tableroInterno[filaInicio, i] = "0";
                        filaInicio++;
                        break;
                    case "Celeste":
                        tableroColor[filaInicio, i].BackColor = Color.LightBlue;
                        tableroInterno[filaInicio, i] = "0";
                        filaInicio++;
                        break;
                    case "Gris":
                        tableroColor[filaInicio, i].BackColor = Color.Gray;
                        tableroInterno[filaInicio, i] = "0";
                        filaInicio++;
                        break;
                }

            }

        }

        public void pintarJ2Direccion5(int filaInicio, int filaFin, int columna)
        {
            for (int i = filaInicio; i <= filaFin-1; i++)
            {
                switch (arrayJugador2[cambio2-1].ToString())
                {
                    case "Rojo":
                        tableroColor[i, columna].BackColor = Color.Red;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Amarillo":
                        tableroColor[i, columna].BackColor = Color.Yellow;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Azul":
                        tableroColor[i, columna].BackColor = Color.Blue;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Anaranjado":
                        tableroColor[i, columna].BackColor = Color.Orange;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Verde":
                        tableroColor[i, columna].BackColor = Color.Green;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Violeta":
                        tableroColor[i, columna].BackColor = Color.Violet;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Blanco":
                        tableroColor[i, columna].BackColor = Color.White;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Negro":
                        tableroColor[i, columna].BackColor = Color.Black;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Celeste":
                        tableroColor[i, columna].BackColor = Color.LightBlue;
                        tableroInterno[i, columna] = "0";
                        break;
                    case "Gris":
                        tableroColor[i, columna].BackColor = Color.Gray;
                        tableroInterno[i, columna] = "0";
                        break;

                }

            }
        }

        public void pintarJ2Direccion6(int inicioFila, int finFila, int columna)
        {
            int columnadireccion = columna;
            for (int i = inicioFila; i <= finFila-1; i++)
            {
                switch (arrayJugador2[cambio2-1].ToString())
                {
                    case "Rojo":
                        tableroColor[i, columnadireccion].BackColor = Color.Red;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Amarillo":
                        tableroColor[i, columnadireccion].BackColor = Color.Yellow;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Azul":
                        tableroColor[i, columnadireccion].BackColor = Color.Blue;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Anaranjado":
                        tableroColor[i, columnadireccion].BackColor = Color.Orange;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Verde":
                        tableroColor[i, columnadireccion].BackColor = Color.Green;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Violeta":
                        tableroColor[i, columnadireccion].BackColor = Color.Violet;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Blanco":
                        tableroColor[i, columnadireccion].BackColor = Color.White;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Negro":
                        tableroColor[i, columnadireccion].BackColor = Color.Black;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Celeste":
                        tableroColor[i, columnadireccion].BackColor = Color.LightBlue;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Gris":
                        tableroColor[i, columnadireccion].BackColor = Color.Gray;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                }

            }
        }

        public void pintarJ2Direccion7(int inicioColumna, int finColumna, int fila)
        {
            for (int i = inicioColumna; i >= finColumna+1; i--)
            {
                switch (arrayJugador2[cambio2-1].ToString())
                {
                    case "Rojo":
                        tableroColor[fila, i].BackColor = Color.Red;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Amarillo":
                        tableroColor[fila, i].BackColor = Color.Yellow;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Azul":
                        tableroColor[fila, i].BackColor = Color.Blue;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Anaranjado":
                        tableroColor[fila, i].BackColor = Color.Orange;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Verde":
                        tableroColor[fila, i].BackColor = Color.Green;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Violeta":
                        tableroColor[fila, i].BackColor = Color.Violet;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Blanco":
                        tableroColor[fila, i].BackColor = Color.White;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Negro":
                        tableroColor[fila, i].BackColor = Color.Black;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Celeste":
                        tableroColor[fila, i].BackColor = Color.LightBlue;
                        tableroInterno[fila, i] = "0";
                        break;
                    case "Gris":
                        tableroColor[fila, i].BackColor = Color.Gray;
                        tableroInterno[fila, i] = "0";
                        break;
                }

            }
        }

        public void pintarJ2Direccion8(int inicioFila, int finFila, int columna)
        {
            int columnadireccion = columna;
            for (int i = inicioFila; i >= finFila+1; i--)
            {
                switch (arrayJugador2[cambio2-1].ToString())
                {
                    case "Rojo":
                        tableroColor[i, columnadireccion].BackColor = Color.Red;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Amarillo":
                        tableroColor[i, columnadireccion].BackColor = Color.Yellow;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Azul":
                        tableroColor[i, columnadireccion].BackColor = Color.Blue;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Anaranjado":
                        tableroColor[i, columnadireccion].BackColor = Color.Orange;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Verde":
                        tableroColor[i, columnadireccion].BackColor = Color.Green;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Violeta":
                        tableroColor[i, columnadireccion].BackColor = Color.Violet;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Blanco":
                        tableroColor[i, columnadireccion].BackColor = Color.White;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Negro":
                        tableroColor[i, columnadireccion].BackColor = Color.Black;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Celeste":
                        tableroColor[i, columnadireccion].BackColor = Color.LightBlue;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                    case "Gris":
                        tableroColor[i, columnadireccion].BackColor = Color.Gray;
                        tableroInterno[i, columnadireccion] = "0";
                        columnadireccion--;
                        break;
                }

            }

        }
        //metodo para habilitar botones si soy J2
        public void activacionBoton2(int fila, int columna)
        {
            int filaTemp = fila;
            int columnaTemp = columna;
            int contadorFicha = 0;


            //fila = disminuye  ------------->Direccion1

            for (int i = filaTemp - 1; i >= 0; i--)
            {
                if (tableroInterno[i, columnaTemp] == "0")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[i, columnaTemp] == "1")
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroInterno[i, columnaTemp] == "+")
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
            int auxColumnaD2 = columnaTemp; //columna
            for (int i = filaTemp - 1; i >= 0; i--)
            {
                auxColumnaD2++;
                if (auxColumnaD2 >= columnaTamaño)
                {
                    break;
                }
                if (tableroInterno[i, auxColumnaD2] == "0")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[i, auxColumnaD2] == "1")
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroInterno[i, auxColumnaD2] == "+")
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
            for (int i = columna + 1; i <= columnaTamaño - 1; i++)
            {
                if (tableroInterno[auxFilaD3, i] == "0")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[auxFilaD3, i] == "1")
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroInterno[auxFilaD3, i] == "+")
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
            for (int i = columnaTemp + 1; i <= columnaTamaño - 1; i++) // columna
            {
                auxFilaD4++;
                if (auxFilaD4 >= filaTamaño)
                {
                    break;
                }
                if (tableroInterno[auxFilaD4, i] == "0")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[auxFilaD4, i] == "1")
                {
                    contadorFicha++;
                    continue;

                }
                else if (tableroInterno[auxFilaD4, i] == "+")
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
            for (int i = filaTemp + 1; i <= filaTamaño - 1; i++) //fila
            {
                if (tableroInterno[i, auxColumnaD5] == "0")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[i, auxColumnaD5] == "1")
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroInterno[i, auxColumnaD5] == "+")
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
                if (auxFilaD6 >= filaTamaño)
                {
                    break;
                }
                if (tableroInterno[auxFilaD6, i] == "0")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[auxFilaD6, i] == "1")
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroInterno[auxFilaD6, i] == "+")
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
                if (tableroInterno[auxFilaD7, i] == "0")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[auxFilaD7, i] == "1")
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroInterno[auxFilaD7, i] == "+")
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
                if (tableroInterno[i, auxColumnaD8] == "0")
                {
                    contadorFicha = 0;
                    break;
                }
                else if (tableroInterno[i, auxColumnaD8] == "1")
                {
                    contadorFicha++;
                    continue;
                }
                else if (tableroInterno[i, auxColumnaD8] == "+")
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
            for (int i = 0; i < filaTamaño; i++)
            {
                for (int j = 0; j < columnaTamaño; j++)
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


            //para J1
            for (int i = 0; i < filaTamaño; i++)
            {
                for (int j = 0; j < columnaTamaño; j++)
                {


                    if (turnoJ1 == true)
                    {
                        if (tableroInterno[i, j] == "0")
                        {
                            activacionBoton2(i, j);//metodo para habilitar botones si soy primero J1
                        }

                    }
                    else if (turnoJ2 == true)
                    {
                        if (tableroInterno[i, j] == "1")
                        {
                            activacionBoton1(i, j);//metodo para habilitar botones si soy J2
                        }
                    }



                }
            }

            //solo para movimientos
            for (int i = 0; i < filaTamaño; i++)
            {
                for (int j = 0; j < columnaTamaño; j++)
                {
                    if (tableroInterno[i, j] == "1")
                    {
                        movimientoB++;
                    }
                    else if (tableroInterno[i, j] == "0")
                    {
                        movimientoN++;
                    }

                }
            }

            for (int i = 0; i < filaTamaño; i++)
            {
                for (int j = 0; j < columnaTamaño; j++)
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

            //para indicar los movimiento que se han realizado en el tablero
             LabelContadorJ1.Text = movimientoB.ToString();
             LabelContadorJ2.Text = movimientoN.ToString();
            

            //validar estado de partida opciones normar  e inversa ->falta
            if(modalidaJuego == true)
            {
                if (movimientoGeneral == 0)
                {
                    if (movimientoB > movimientoN)
                    {
                        //gana blanca
                        Labelestado.Text = "Ganó Jugador 1";
                        LabelIndicadorTurno.Text = "No Disponible";
                        llaveTiempoGeneral = false;
                    }
                    else if (movimientoN > movimientoB)
                    {
                        //gana negras
                        Labelestado.Text = "Ganó Jugador 2";
                        LabelIndicadorTurno.Text = "No Disponible";
                        llaveTiempoGeneral = false;
                    }
                    else if (movimientoB == movimientoN)
                    {
                        //es empate
                        Labelestado.Text = "Empate";
                        LabelIndicadorTurno.Text = "No Disponible";
                        llaveTiempoGeneral = false;
                    }

                }
                else
                {
                    movimientoGeneral = 0;
                    //se esta jugando
                    Labelestado.Text = "Se está jugando";
                }
            }
            else if(modalidaJuego == false)
            {
                if (movimientoGeneral == 0)
                {
                    if (movimientoB < movimientoN)
                    {
                        //gana blanca
                        Labelestado.Text = "Ganó Jugador 1";
                        LabelIndicadorTurno.Text = "No Disponible";
                        llaveTiempoGeneral = false;
                    }
                    else if (movimientoN < movimientoB)
                    {
                        //gana negras
                        Labelestado.Text = "Ganó Jugador 2";
                        LabelIndicadorTurno.Text = "No Disponible";
                        llaveTiempoGeneral = false;
                    }
                    else if (movimientoB == movimientoN)
                    {
                        //es empate
                        Labelestado.Text = "Empate";
                        LabelIndicadorTurno.Text = "No Disponible";
                        llaveTiempoGeneral = false;
                    }

                }
                else
                {
                    movimientoGeneral = 0;
                    //se esta jugando
                    Labelestado.Text = "Se está jugando";
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


                    //if (banderaBlanca == true)
                    //{
                    //    if (tableroColor[i, j].BackColor == Color.White)
                    //    {

                    //        activacionBoton1(i, j);//metodo para habilitar botones si soy blanco

                    //    }

                    //}
                    //else if (banderaNegra == true)
                    //{

                    //    if (tableroColor[i, j].BackColor == Color.Black)
                    //    {

                    //        activacionBoton2(i, j);//metodo para habilitar botones si soy negro

                    //    }
                    //}



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

            //if (usuarioBlanco == true)//cuando yo sea blanco
            //{
            //    LabelContadorUsuario.Text = movimientoB.ToString();
            //    LabelContadorInvitado.Text = movimientoN.ToString();
            //}
            //else if (usuarioNegro == true)//cuando yo sea negro
            //{
            //    LabelContadorUsuario.Text = movimientoN.ToString();
            //    LabelContadorInvitado.Text = movimientoB.ToString();
            //}

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
                                cargarValores(color, columna, fila);  // para ingresar los datos en la matriz
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

                                //if (colorTiro == "blanco")
                                //{

                                //    banderaNegra = false;
                                //    banderaBlanca = true;
                                //    usuarioBlanco = true;
                                //    banderaGeneral = true;
                                //    banderaTiro = false;
                                //}
                                //else if (colorTiro == "negro")
                                //{

                                //    banderaNegra = true;
                                //    banderaBlanca = false;
                                //    usuarioNegro = true;
                                //    banderaGeneral = true;
                                //    banderaTiro = false;
                                //}

                            }
                        }



                    }
                }

                analizarMatriz();
                //ingresarFichas();
                informacionFinalCarga();


            }
            catch (Exception exc)
            {
                Response.Write("No se encontro el archivo" + exc);
            }
        }

        //CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA-CARGA
        //public void ingresarFichas()
        //{
        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {
        //            string opcion = i.ToString() + "-" + j.ToString();

        //            switch (opcion)
        //            {
        //                case "0-0":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnA1.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnA1.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "1-0":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnA2.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnA2.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "2-0":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnA3.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnA3.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "3-0":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnA4.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnA4.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "4-0":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnA5.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnA5.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "5-0":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnA6.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnA6.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "6-0":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnA7.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnA7.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "7-0":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnA8.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnA8.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "0-1":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnB1.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnB1.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "1-1":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnB2.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnB2.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "2-1":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnB3.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnB3.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "3-1":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnB4.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnB4.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "4-1":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnB5.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnB5.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "5-1":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnB6.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnB6.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "6-1":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnB7.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnB7.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "7-1":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnB8.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnB8.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "0-2":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnC1.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnC1.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "1-2":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnC2.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnC2.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "2-2":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnC3.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnC3.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "3-2":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnC4.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnC4.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "4-2":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnC5.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnC5.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "5-2":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnC6.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnC6.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "6-2":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnC7.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnC7.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "7-2":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnC8.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnC8.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "0-3":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnD1.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnD1.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "1-3":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnD2.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnD2.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "2-3":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnD3.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnD3.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "3-3":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnD4.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnD4.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "4-3":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnD5.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnD5.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "5-3":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnD6.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnD6.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "6-3":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnD7.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnD7.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "7-3":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnD8.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnD8.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "0-4":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnE1.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnE1.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "1-4":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnE2.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnE2.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "2-4":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnE3.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnE3.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "3-4":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnE4.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnE4.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "4-4":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnE5.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnE5.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "5-4":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnE6.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnE6.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "6-4":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnE7.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnE7.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "7-4":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnE8.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnE8.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "0-5":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnF1.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnF1.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "1-5":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnF2.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnF2.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "2-5":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnF3.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnF3.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "3-5":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnF4.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnF4.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "4-5":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnF5.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnF5.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "5-5":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnF6.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnF6.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "6-5":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnF7.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnF7.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "7-5":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnF8.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnF8.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "0-6":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnG1.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnG1.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "1-6":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnG2.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnG2.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "2-6":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnG3.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnG3.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "3-6":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnG4.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnG4.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "4-6":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnG5.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnG5.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "5-6":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnG6.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnG6.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "6-6":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnG7.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnG7.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "7-6":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnG8.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnG8.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "0-7":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnH1.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnH1.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "1-7":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnH2.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnH2.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "2-7":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnH3.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnH3.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "3-7":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnH4.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnH4.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "4-7":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnH5.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnH5.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "5-7":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnH6.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnH6.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "6-7":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnH7.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnH7.BackColor = Color.Black;
        //                    }
        //                    break;
        //                case "7-7":
        //                    if (tablero[i, j] == "O")
        //                    {
        //                        BtnH8.BackColor = Color.White;
        //                    }
        //                    else if (tablero[i, j] == "X")
        //                    {
        //                        BtnH8.BackColor = Color.Black;
        //                    }
        //                    break;
        //            }
        //        }
        //    }
        //}



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


        //public void recorrerCuadros()
        //{
        //    int opcion;

        //    for (opcion = 1; opcion <= 64; opcion++)
        //    {

        //        switch (opcion)
        //        {
        //            case 1:
        //                if (BtnA1.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("1");

        //                }
        //                else if (BtnA1.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("1");
        //                }
        //                break;

        //            case 2:
        //                if (BtnA2.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("2");

        //                }
        //                else if (BtnA2.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("2");
        //                }
        //                break;
        //            case 3:
        //                if (BtnA3.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("3");

        //                }
        //                else if (BtnA3.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("3");
        //                }
        //                break;
        //            case 4:
        //                if (BtnA4.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("4");

        //                }
        //                else if (BtnA4.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("4");
        //                }

        //                break;
        //            case 5:
        //                if (BtnA5.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("5");

        //                }
        //                else if (BtnA5.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("5");
        //                }

        //                break;
        //            case 6:
        //                if (BtnA6.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("6");

        //                }
        //                else if (BtnA6.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("6");
        //                }

        //                break;
        //            case 7:
        //                if (BtnA7.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("7");

        //                }
        //                else if (BtnA7.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("7");
        //                }
        //                break;
        //            case 8:
        //                if (BtnA8.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("8");

        //                }
        //                else if (BtnA8.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("A");
        //                    arrayFila.Add("8");
        //                }

        //                break;
        //            case 9:
        //                if (BtnB1.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("1");

        //                }
        //                else if (BtnB1.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("1");
        //                }
        //                break;
        //            case 10:
        //                if (BtnB2.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("2");

        //                }
        //                else if (BtnB2.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("2");
        //                }
        //                break;
        //            case 11:
        //                if (BtnB3.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("3");

        //                }
        //                else if (BtnB3.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("3");
        //                }

        //                break;
        //            case 12:
        //                if (BtnB4.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("4");

        //                }
        //                else if (BtnB4.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("4");
        //                }
        //                break;
        //            case 13:
        //                if (BtnB5.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("5");

        //                }
        //                else if (BtnB5.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("5");
        //                }
        //                break;
        //            case 14:
        //                if (BtnB6.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("6");

        //                }
        //                else if (BtnB6.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("6");
        //                }
        //                break;

        //            case 15:
        //                if (BtnB7.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("7");

        //                }
        //                else if (BtnB7.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("7");
        //                }
        //                break;
        //            case 16:
        //                if (BtnB8.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("8");

        //                }
        //                else if (BtnB8.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("B");
        //                    arrayFila.Add("8");
        //                }

        //                break;
        //            case 17:
        //                if (BtnC1.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("1");

        //                }
        //                else if (BtnC1.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("1");
        //                }

        //                break;
        //            case 18:
        //                if (BtnC2.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("2");

        //                }
        //                else if (BtnC2.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("2");
        //                }
        //                break;
        //            case 19:
        //                if (BtnC3.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("3");

        //                }
        //                else if (BtnC3.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("3");
        //                }
        //                break;
        //            case 20:
        //                if (BtnC4.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("4");

        //                }
        //                else if (BtnC4.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("4");
        //                }
        //                break;
        //            case 21:
        //                if (BtnC5.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("5");

        //                }
        //                else if (BtnC5.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("5");
        //                }
        //                break;

        //            case 22:
        //                if (BtnC6.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("6");

        //                }
        //                else if (BtnC6.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("6");
        //                }
        //                break;
        //            case 23:
        //                if (BtnC7.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("7");

        //                }
        //                else if (BtnC7.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("7");
        //                }
        //                break;
        //            case 24:
        //                if (BtnC8.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("8");

        //                }
        //                else if (BtnC8.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("C");
        //                    arrayFila.Add("8");
        //                }

        //                break;
        //            case 25:
        //                if (BtnD1.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("1");

        //                }
        //                else if (BtnD1.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("1");
        //                }
        //                break;
        //            case 26:
        //                if (BtnD2.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("2");

        //                }
        //                else if (BtnD2.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("2");
        //                }
        //                break;
        //            case 27:
        //                if (BtnD3.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("3");

        //                }
        //                else if (BtnD3.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("3");
        //                }
        //                break;
        //            case 28:
        //                if (BtnD4.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("4");

        //                }
        //                else if (BtnD4.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("4");
        //                }
        //                break;
        //            case 29:
        //                if (BtnD5.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("5");

        //                }
        //                else if (BtnD5.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("5");
        //                }
        //                break;
        //            case 30:
        //                if (BtnD6.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("6");

        //                }
        //                else if (BtnD6.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("6");
        //                }
        //                break;
        //            case 31:
        //                if (BtnD7.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("7");

        //                }
        //                else if (BtnD7.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("7");
        //                }
        //                break;

        //            case 32:
        //                if (BtnD8.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("8");

        //                }
        //                else if (BtnD8.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("D");
        //                    arrayFila.Add("8");
        //                }
        //                break;
        //            case 33:
        //                if (BtnE1.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("1");

        //                }
        //                else if (BtnE1.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("1");
        //                }
        //                break;
        //            case 34:
        //                if (BtnE2.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("2");

        //                }
        //                else if (BtnE2.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("2");
        //                }
        //                break;
        //            case 35:
        //                if (BtnE3.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("3");

        //                }
        //                else if (BtnE3.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("3");
        //                }

        //                break;
        //            case 36:
        //                if (BtnE4.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("4");

        //                }
        //                else if (BtnE4.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("4");
        //                }
        //                break;
        //            case 37:
        //                if (BtnE5.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("5");

        //                }
        //                else if (BtnE5.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("5");
        //                }
        //                break;
        //            case 38:
        //                if (BtnE6.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("6");

        //                }
        //                else if (BtnE6.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("6");
        //                }

        //                break;
        //            case 39:
        //                if (BtnE7.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("7");

        //                }
        //                else if (BtnE7.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("7");
        //                }
        //                break;
        //            case 40:
        //                if (BtnE8.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("8");

        //                }
        //                else if (BtnE8.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("E");
        //                    arrayFila.Add("8");
        //                }
        //                break;
        //            case 41:
        //                if (BtnF1.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("1");

        //                }
        //                else if (BtnF1.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("1");
        //                }
        //                break;

        //            case 42:
        //                if (BtnF2.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("2");

        //                }
        //                else if (BtnF2.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("2");
        //                }
        //                break;
        //            case 43:
        //                if (BtnF3.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("3");

        //                }
        //                else if (BtnF3.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("3");
        //                }
        //                break;
        //            case 44:
        //                if (BtnF4.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("4");

        //                }
        //                else if (BtnF4.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("4");
        //                }

        //                break;
        //            case 45:
        //                if (BtnF5.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("5");

        //                }
        //                else if (BtnF5.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("5");
        //                }

        //                break;
        //            case 46:
        //                if (BtnF6.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("6");

        //                }
        //                else if (BtnF6.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("6");
        //                }
        //                break;
        //            case 47:
        //                if (BtnF7.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("7");

        //                }
        //                else if (BtnF7.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("7");
        //                }
        //                break;
        //            case 48:
        //                if (BtnF8.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("8");

        //                }
        //                else if (BtnF8.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("F");
        //                    arrayFila.Add("8");
        //                }
        //                break;
        //            case 49:
        //                if (BtnG1.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("1");

        //                }
        //                else if (BtnG1.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("1");
        //                }

        //                break;
        //            case 50:
        //                if (BtnG2.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("2");

        //                }
        //                else if (BtnG2.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("2");
        //                }
        //                break;
        //            case 51:
        //                if (BtnG3.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("3");

        //                }
        //                else if (BtnG3.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("3");
        //                }

        //                break;

        //            case 52:
        //                if (BtnG4.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("4");

        //                }
        //                else if (BtnG4.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("4");
        //                }
        //                break;
        //            case 53:
        //                if (BtnG5.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("5");

        //                }
        //                else if (BtnG5.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("5");
        //                }

        //                break;
        //            case 54:
        //                if (BtnG6.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("6");

        //                }
        //                else if (BtnG6.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("6");
        //                }

        //                break;
        //            case 55:
        //                if (BtnG7.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("7");

        //                }
        //                else if (BtnG7.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("7");
        //                }
        //                break;
        //            case 56:
        //                if (BtnG8.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("8");

        //                }
        //                else if (BtnG8.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("G");
        //                    arrayFila.Add("8");
        //                }
        //                break;
        //            case 57:
        //                if (BtnH1.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("1");

        //                }
        //                else if (BtnH1.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("1");
        //                }
        //                break;
        //            case 58:
        //                if (BtnH2.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("2");

        //                }
        //                else if (BtnH2.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("2");
        //                }
        //                break;
        //            case 59:
        //                if (BtnH3.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("3");

        //                }
        //                else if (BtnH3.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("3");
        //                }

        //                break;
        //            case 60:
        //                if (BtnH4.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("4");

        //                }
        //                else if (BtnH4.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("4");
        //                }
        //                break;
        //            case 61:
        //                if (BtnH5.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("5");

        //                }
        //                else if (BtnH5.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("5");
        //                }

        //                break;

        //            case 62:
        //                if (BtnH6.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("6");

        //                }
        //                else if (BtnH6.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("6");
        //                }
        //                break;
        //            case 63:
        //                if (BtnH7.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("7");

        //                }
        //                else if (BtnH7.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("7");
        //                }
        //                break;
        //            case 64:
        //                if (BtnH8.BackColor == Color.White)
        //                {
        //                    arrayColor.Add("blanco");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("8");

        //                }
        //                else if (BtnH8.BackColor == Color.Black)
        //                {
        //                    arrayColor.Add("negro");
        //                    arrayColumna.Add("H");
        //                    arrayFila.Add("8");
        //                }
        //                break;



        //        }
        //    }
        //}
        //FINNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN

        protected void ButtonDescarga_Click(object sender, EventArgs e)
        {
            //recorrerCuadros();


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

            //if (banderaBlanca == true)
            //{
            //    XmlElement colorTiro = doc.CreateElement("color");
            //    colorTiro.AppendChild(doc.CreateTextNode("blanco"));
            //    siguiente.AppendChild(colorTiro);
            //}
            //else if (banderaNegra == true)
            //{
            //    XmlElement colorTiro = doc.CreateElement("color");
            //    colorTiro.AppendChild(doc.CreateTextNode("negro"));
            //    siguiente.AppendChild(colorTiro);
            //}

            doc.Save("C:\\Users\\MAGDIEL\\Desktop\\Pruebas\\PartidaSolitario.xml");




        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPrincipal.aspx");
        }

        protected void BtnA1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 0); 
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 1);              
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 2);             
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 2);              
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }

        }

        protected void BtnD1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 3);    
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 3);              
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }

        }

        protected void BtnE1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0,4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0,4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0,4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0,4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0,5);            
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0,5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0,5);              
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0,5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }

        }

        protected void BtnG1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }

        }

        protected void BtnH1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }
       
        protected void BtnA2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 0);            
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 0);             
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }

        }

        protected void BtnB2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 1);               
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }

        }

        protected void BtnC2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 2);              
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 2);             
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 3);      
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }

        }

        protected void BtnE2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }

        }

        protected void BtnF2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 5);             
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }

        }

        protected void BtnG2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }

        }

        protected void BtnH2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 0);              
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 0);             
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 1);             
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 1);              
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2,2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if(turnoJ2 == true)
            {
                pintarJ2(2, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 3);            
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 3);            
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2,3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }

        }

        protected void BtnE3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 4);       
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 4);   
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 5);  
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 0);    
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 0);  
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB4_Click(object sender, EventArgs e)
        {

            if (turnoJ1 == true)
            {
                pintarJ1(3, 1);    
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 1); 
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3,2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 3);  
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3,3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3,3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE4_Click(object sender, EventArgs e)
        {

            if (turnoJ1 == true)
            {
                pintarJ1(3, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF4_Click(object sender, EventArgs e)
        {

            if (turnoJ1 == true)
            {
                pintarJ1(3, 5);             
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 5);              
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA5_Click(object sender, EventArgs e)
        {

            if (turnoJ1 == true)
            {
                pintarJ1(4, 0);             
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 0);              
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 1);               
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 1);           
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 2);              
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 2);            
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 3); 
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 4);               
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 4); 
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 5);              
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 5); 
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }

        }

        protected void BtnG5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }

        }

        protected void BtnH5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 0);              
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 0);             
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 1);              
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 1);              
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 2);             
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 2);               
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 3);              
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 3);              
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 4);             
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;
            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }

        }

        protected void BtnG6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 0);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 1);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 3);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6,5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 0);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 1);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 3);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7,7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }
        protected void DropDownListFicha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {

           if(llaveTiempoGeneral == true)
            {
                if (llaveTiempo1 == true)
                {

                    LabelTiempoJ1.Text = tiempoJ1M.ToString() + ":" + tiempoJ1S.ToString();
                    tiempoJ1S++;
                    if (tiempoJ1S == 61)
                    {
                        tiempoJ1S = 0;
                        tiempoJ1M++;
                    }
                }

                if (llaveTiempo2 == true)
                {

                    LabelTiempoJ2.Text = tiempoJ2M.ToString() + ":" + tiempoJ2S.ToString();
                    tiempoJ2S++;
                    if (tiempoJ2S == 61)
                    {
                        tiempoJ2S = 0;
                        tiempoJ2M++;
                    }
                }
            }
        }

        protected void ButtonGenerar_Click1(object sender, EventArgs e)
        {
           
            //para realizar la seleccion
             filaTamaño = Int32.Parse(DropDownListFila.SelectedItem.Value);
             columnaTamaño = Int32.Parse(DropDownListColumna.SelectedItem.Value);

            //tamaño tablero interno
            tableroInterno = new string[filaTamaño, columnaTamaño];
            //generador general

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (i < filaTamaño && j < columnaTamaño)
                    {
                        tableroColor[i, j].Enabled = false;
                    }
                    else
                    {
                        tableroColor[i, j].Visible = false;
                    }
                }
            }

            //para eliminar las columnas no necesarias
            for (int j = 20; j >= columnaTamaño+1; j--)
            {
                for (int i = 0; i <= 21; i++)
                {
                    HtmlTableCell cell = TableroCompleto.Rows[i].Cells[j];
                    TableroCompleto.Rows[i].Cells[j].Visible = false;
                }

            }

            //para eliminar las filas no necesarias
            for (int i = 20; i >= filaTamaño+1; i--)
            {
                HtmlTableRow row = TableroCompleto.Rows[i];
                TableroCompleto.Rows[i].Visible = false;
            }

            TableroCompleto.Align = "Center";

            //metodo para habilitar los 4 botones en medio
            habilitarLosCuatro(filaTamaño, columnaTamaño);


            //para simular el color de fondo
            for (int i = 0; i < filaTamaño; i++)
            {
                for (int j = 0; j < columnaTamaño; j++)
                {
                    tableroInterno[i, j] = "+";
                }
            }
        }

        public void habilitarLosCuatro(int filaObtenido, int columnaObtenido)
        {
           
            string opcion = filaObtenido.ToString() + "-" + columnaObtenido.ToString();

            switch (opcion)
            {
                
                case "6-6":
                    //habilitar los 4 btn
                    BtnC3.Enabled = true;
                    BtnD3.Enabled = true;
                    BtnC4.Enabled = true;
                    BtnD4.Enabled = true;
                    break;
                case "6-8":
                    BtnD3.Enabled = true;
                    BtnE3.Enabled = true;
                    BtnD4.Enabled = true;
                    BtnE4.Enabled = true;
                    break;
                case "6-10":
                    BtnE3.Enabled = true;
                    BtnF3.Enabled = true;
                    BtnE4.Enabled = true;
                    BtnF4.Enabled = true;
                    break;
                case "6-12":
                    BtnF3.Enabled = true;
                    BtnG3.Enabled = true;
                    BtnF4.Enabled = true;
                    BtnG4.Enabled = true;
                    break;
                case "6-14":
                    BtnG3.Enabled = true;
                    BtnH3.Enabled = true;
                    BtnG4.Enabled = true;
                    BtnH4.Enabled = true;
                    break;
                case "6-16":
                    BtnH3.Enabled = true;
                    BtnI3.Enabled = true;
                    BtnH4.Enabled = true;
                    BtnI4.Enabled = true;
                    break;
                case "6-18":
                    BtnI3.Enabled = true;
                    BtnJ3.Enabled = true;
                    BtnI4.Enabled = true;
                    BtnJ4.Enabled = true;
                    break;
                case "6-20":
                    BtnJ3.Enabled = true;
                    BtnK3.Enabled = true;
                    BtnJ4.Enabled = true;
                    BtnK4.Enabled = true;
                    break;
                case "8-6":
                    BtnC4.Enabled = true;
                    BtnD4.Enabled = true;
                    BtnC5.Enabled = true;
                    BtnD5.Enabled = true;
                    break;
                case "8-8":
                    BtnD4.Enabled = true;
                    BtnE4.Enabled = true;
                    BtnD5.Enabled = true;
                    BtnE5.Enabled = true;
                    break;
                case "8-10":
                    BtnE4.Enabled = true;
                    BtnF4.Enabled = true;
                    BtnE5.Enabled = true;
                    BtnF5.Enabled = true;
                    break;
                case "8-12":
                    BtnF4.Enabled = true;
                    BtnG4.Enabled = true;
                    BtnF5.Enabled = true;
                    BtnG5.Enabled = true;
                    break;
                case "8-14":
                    BtnG4.Enabled = true;
                    BtnH4.Enabled = true;
                    BtnG5.Enabled = true;
                    BtnH5.Enabled = true;
                    break;
                case "8-16":
                    BtnH4.Enabled = true;
                    BtnI4.Enabled = true;
                    BtnH5.Enabled = true;
                    BtnI5.Enabled = true;
                    break;
                case "8-18":
                    BtnI4.Enabled = true;
                    BtnJ4.Enabled = true;
                    BtnI5.Enabled = true;
                    BtnJ5.Enabled = true;
                    break;
                case "8-20":
                    BtnJ4.Enabled = true;
                    BtnK4.Enabled = true;
                    BtnJ5.Enabled = true;
                    BtnK5.Enabled = true;
                    break;
                case "10-6":
                    BtnC5.Enabled = true;
                    BtnD5.Enabled = true;
                    BtnC6.Enabled = true;
                    BtnD6.Enabled = true;
                    break;
                case "10-8":
                    BtnD5.Enabled = true;
                    BtnE5.Enabled = true;
                    BtnD6.Enabled = true;
                    BtnE6.Enabled = true;
                    break;
                case "10-10":
                    BtnE5.Enabled = true;
                    BtnF5.Enabled = true;
                    BtnE6.Enabled = true;
                    BtnF6.Enabled = true;
                    break;
                case "10-12":
                    BtnF5.Enabled = true;
                    BtnG5.Enabled = true;
                    BtnF6.Enabled = true;
                    BtnG6.Enabled = true;
                    break;
                case "10-14":
                    BtnG5.Enabled = true;
                    BtnH5.Enabled = true;
                    BtnG6.Enabled = true;
                    BtnH6.Enabled = true;
                    break;
                case "10-16":
                    BtnH5.Enabled = true;
                    BtnI5.Enabled = true;
                    BtnH6.Enabled = true;
                    BtnI6.Enabled = true;
                    break;
                case "10-18":
                    BtnI5.Enabled = true;
                    BtnJ5.Enabled = true;
                    BtnI6.Enabled = true;
                    BtnJ6.Enabled = true;
                    break;
                case "10-20":
                    BtnJ5.Enabled = true;
                    BtnK5.Enabled = true;
                    BtnJ6.Enabled = true;
                    BtnK6.Enabled = true;
                    break;
                case "12-6":
                    BtnC6.Enabled = true;
                    BtnD6.Enabled = true;
                    BtnC7.Enabled = true;
                    BtnD7.Enabled = true;
                    break;
                case "12-8":
                    BtnD6.Enabled = true;
                    BtnE6.Enabled = true;
                    BtnD7.Enabled = true;
                    BtnE7.Enabled = true;
                    break;
                case "12-10":
                    BtnE6.Enabled = true;
                    BtnF6.Enabled = true;
                    BtnE7.Enabled = true;
                    BtnF7.Enabled = true;
                    break;
                case "12-12":
                    BtnF6.Enabled = true;
                    BtnG6.Enabled = true;
                    BtnF7.Enabled = true;
                    BtnG7.Enabled = true;
                    break;
                case "12-14":
                    BtnG6.Enabled = true;
                    BtnH6.Enabled = true;
                    BtnG7.Enabled = true;
                    BtnH7.Enabled = true;
                    break;
                case "12-16":
                    BtnH6.Enabled = true;
                    BtnI6.Enabled = true;
                    BtnH7.Enabled = true;
                    BtnI7.Enabled = true;
                    break;
                case "12-18":
                    BtnI6.Enabled = true;
                    BtnJ6.Enabled = true;
                    BtnI7.Enabled = true;
                    BtnJ7.Enabled = true;
                    break;
                case "12-20":
                    BtnJ6.Enabled = true;
                    BtnK6.Enabled = true;
                    BtnJ7.Enabled = true;
                    BtnK7.Enabled = true;
                    break;
                case "14-6":
                    BtnC7.Enabled = true;
                    BtnD7.Enabled = true;
                    BtnC8.Enabled = true;
                    BtnD8.Enabled = true;
                    break;
                case "14-8":
                    BtnD7.Enabled = true;
                    BtnE7.Enabled = true;
                    BtnD8.Enabled = true;
                    BtnE8.Enabled = true;
                    break;
                case "14-10":
                    BtnE7.Enabled = true;
                    BtnF7.Enabled = true;
                    BtnE8.Enabled = true;
                    BtnF8.Enabled = true;
                    break;
                case "14-12":
                    BtnF7.Enabled = true;
                    BtnG7.Enabled = true;
                    BtnF8.Enabled = true;
                    BtnG8.Enabled = true;
                    break;
                case "14-14":
                    BtnG7.Enabled = true;
                    BtnH7.Enabled = true;
                    BtnG8.Enabled = true;
                    BtnH8.Enabled = true;
                    break;
                case "14-16":
                    BtnH7.Enabled = true;
                    BtnI7.Enabled = true;
                    BtnH8.Enabled = true;
                    BtnI8.Enabled = true;
                    break;
                case "14-18":
                    BtnI7.Enabled = true;
                    BtnJ7.Enabled = true;
                    BtnI8.Enabled = true;
                    BtnJ8.Enabled = true;
                    break;
                case "14-20":
                    BtnJ7.Enabled = true;
                    BtnK7.Enabled = true;
                    BtnJ8.Enabled = true;
                    BtnK8.Enabled = true;
                    break;
                case "16-6":
                    BtnC8.Enabled = true;
                    BtnD8.Enabled = true;
                    BtnC9.Enabled = true;
                    BtnD9.Enabled = true;
                    break;
                case "16-8":
                    BtnD8.Enabled = true;
                    BtnE8.Enabled = true;
                    BtnD9.Enabled = true;
                    BtnE9.Enabled = true;
                    break;
                case "16-10":
                    BtnE8.Enabled = true;
                    BtnF8.Enabled = true;
                    BtnE9.Enabled = true;
                    BtnF9.Enabled = true;
                    break;
                case "16-12":
                    BtnF8.Enabled = true;
                    BtnG8.Enabled = true;
                    BtnF9.Enabled = true;
                    BtnG9.Enabled = true;
                    break;
                case "16-14":
                    BtnG8.Enabled = true;
                    BtnH8.Enabled = true;
                    BtnG9.Enabled = true;
                    BtnH9.Enabled = true;
                    break;
                case "16-16":
                    BtnH8.Enabled = true;
                    BtnI8.Enabled = true;
                    BtnH9.Enabled = true;
                    BtnI9.Enabled = true;
                    break;
                case "16-18":
                    BtnI8.Enabled = true;
                    BtnJ8.Enabled = true;
                    BtnI9.Enabled = true;
                    BtnJ9.Enabled = true;
                    break;
                case "16-20":
                    BtnJ8.Enabled = true;
                    BtnK8.Enabled = true;
                    BtnJ9.Enabled = true;
                    BtnK9.Enabled = true;
                    break;
                case "18-6":
                    BtnC9.Enabled = true;
                    BtnD9.Enabled = true;
                    BtnC10.Enabled = true;
                    BtnD10.Enabled = true;
                    break;
                case "18-8":
                    BtnD9.Enabled = true;
                    BtnE9.Enabled = true;
                    BtnD10.Enabled = true;
                    BtnE10.Enabled = true;
                    break;
                case "18-10":
                    BtnE9.Enabled = true;
                    BtnF9.Enabled = true;
                    BtnE10.Enabled = true;
                    BtnF10.Enabled = true;
                    break;
                case "18-12":
                    BtnF9.Enabled = true;
                    BtnG9.Enabled = true;
                    BtnF10.Enabled = true;
                    BtnG10.Enabled = true;
                    break;
                case "18-14":
                    BtnG9.Enabled = true;
                    BtnH9.Enabled = true;
                    BtnG10.Enabled = true;
                    BtnH10.Enabled = true;
                    break;
                case "18-16":
                    BtnH9.Enabled = true;
                    BtnI9.Enabled = true;
                    BtnH10.Enabled = true;
                    BtnI10.Enabled = true;
                    break;
                case "18-18":
                    BtnI9.Enabled = true;
                    BtnJ9.Enabled = true;
                    BtnI10.Enabled = true;
                    BtnJ10.Enabled = true;
                    break;
                case "18-20":
                    BtnJ9.Enabled = true;
                    BtnK9.Enabled = true;
                    BtnJ10.Enabled = true;
                    BtnK10.Enabled = true;
                    break;
                case "20-6":
                    BtnC10.Enabled = true;
                    BtnD10.Enabled = true;
                    BtnC11.Enabled = true;
                    BtnD11.Enabled = true;
                    break;
                case "20-8":
                    BtnD10.Enabled = true;
                    BtnE10.Enabled = true;
                    BtnD11.Enabled = true;
                    BtnE11.Enabled = true;
                    break;
                case "20-10":
                    BtnE10.Enabled = true;
                    BtnF10.Enabled = true;
                    BtnE11.Enabled = true;
                    BtnF11.Enabled = true;
                    break;
                case "20-12":
                    BtnF10.Enabled = true;
                    BtnG10.Enabled = true;
                    BtnF11.Enabled = true;
                    BtnG11.Enabled = true;
                    break;
                case "20-14":
                    BtnG10.Enabled = true;
                    BtnH10.Enabled = true;
                    BtnG11.Enabled = true;
                    BtnH11.Enabled = true;
                    break;
                case "20-16":
                    BtnH10.Enabled = true;
                    BtnI10.Enabled = true;
                    BtnH11.Enabled = true;
                    BtnI11.Enabled = true;
                    break;
                case "20-18":
                    BtnI10.Enabled = true;
                    BtnJ10.Enabled = true;
                    BtnI11.Enabled = true;
                    BtnJ11.Enabled = true;
                    break;
                case "20-20":
                    BtnJ10.Enabled = true;
                    BtnK10.Enabled = true;
                    BtnJ11.Enabled = true;
                    BtnK11.Enabled = true;
                    break;
               

            }
            
        }
        

        protected void BtnJ1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS1_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(0, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(0, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(0, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(0, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS2_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(1, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(1, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(1, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(1, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS3_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(2, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(2, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(2, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(2, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS4_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(3, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(3, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(3, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(3, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS5_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(4, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(4, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(4, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(4, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS6_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(5, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(5, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(5, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(5, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS7_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(6, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(6, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(6, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(6, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS8_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(7, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(7, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(7, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(7, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9,13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10,16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11,8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15,19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17,18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnI20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 8);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 8);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 8);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 8);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnJ20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 9);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 9);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 9);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 9);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnK20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 10);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 10);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 10);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 10);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnL20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 11);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 11);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 11);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 11);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnM20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 12);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 12);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 12);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 12);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnN20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 13);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 13);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 13);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 13);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnÑ20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 14);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 14);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 14);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 14);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnO20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 15);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 15);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 15);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 15);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnP20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 16);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 16);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 16);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 16);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnQ20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 17);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 17);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 17);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 17);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnR20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 18);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 18);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 18);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 18);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnS20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 19);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 19);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 19);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 19);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void ButtonModalidad_Click(object sender, EventArgs e)
        {
            string modo = DropDownListModalidad.SelectedValue;
            //true = normal,false = inversa
            if(modo == "Normal")
            {
                modalidaJuego = true;
            }
            else if(modo == "Inversa")
            {
                modalidaJuego = false;
            }
        }

        protected void ButtonEmpezar_Click(object sender, EventArgs e)
        {
            
          
            LabelIndicadorTurno.Text = "Jugador 1";
            turnoJ1 = false;
            turnoJ2 = true;
            //meotodo
            informacionFinal();
            turnoJ1 = true;
            turnoJ2 = false;
            //habilita la parte del metodo informacionFina()
            //para realizar las capturas
            llaveCaptura = true;

            //llave general tiempo
            llaveTiempoGeneral = true;

            //llave par empezar a contar
            llaveTiempo1 = true;
        }

        public void pintarJ1(int x, int y)
        {

            if (cambio1 == contadorColorj1)
            {
                cambio1 = 0;
            }

            if (arrayJugador1[cambio1].ToString() == "Rojo")
            {
                tableroColor[x, y].BackColor = Color.Red;
                tableroInterno[x, y] = "1";
                cambio1++;
            }
            else if(arrayJugador1[cambio1].ToString() == "Amarillo")
            {
                tableroColor[x, y].BackColor = Color.Yellow;
                tableroInterno[x, y] = "1";
                cambio1++;
            }
            else if (arrayJugador1[cambio1].ToString() == "Azul")
            {
                tableroColor[x, y].BackColor = Color.Blue;
                tableroInterno[x, y] = "1";
                cambio1++;
            }
            else if (arrayJugador1[cambio1].ToString() == "Anaranjado")
            {
                tableroColor[x, y].BackColor = Color.Orange;
                tableroInterno[x, y] = "1";
                cambio1++;
            }
            else if (arrayJugador1[cambio1].ToString() == "Verde")
            {
                tableroColor[x, y].BackColor = Color.Green;
                tableroInterno[x, y] = "1";
                cambio1++;
            }
            else if (arrayJugador1[cambio1].ToString() == "Violeta")
            {
                tableroColor[x, y].BackColor = Color.Violet;
                tableroInterno[x, y] = "1";
                cambio1++;
            }
            else if (arrayJugador1[cambio1].ToString() == "Blanco")
            {
                tableroColor[x, y].BackColor = Color.White;
                tableroInterno[x, y] = "1";
                cambio1++;
            }
            else if (arrayJugador1[cambio1].ToString() == "Negro")
            {
                tableroColor[x, y].BackColor = Color.Black;
                tableroInterno[x, y] = "1";
                cambio1++;
            }
            else if (arrayJugador1[cambio1].ToString() == "Celeste")
            {
                tableroColor[x, y].BackColor = Color.LightBlue;
                tableroInterno[x, y] = "1";
                cambio1++;
            }
            else if (arrayJugador1[cambio1].ToString() == "Gris")
            {
                tableroColor[x, y].BackColor = Color.Gray;
                tableroInterno[x, y] = "1";
                cambio1++;
            }

            
            
            //contador guia
        }

        public void pintarJ2(int x, int y)
        {

            if (cambio2 == contadorColorj2)
            {
                cambio2 = 0;
            }

            if (arrayJugador2[cambio2].ToString() == "Rojo")
            {
                tableroColor[x, y].BackColor = Color.Red;
                tableroInterno[x, y] = "0";
                cambio2++;
            }
            else if (arrayJugador2[cambio2].ToString() == "Amarillo")
            {
                tableroColor[x, y].BackColor = Color.Yellow;
                tableroInterno[x, y] = "0";
                cambio2++;
            }
            else if (arrayJugador2[cambio2].ToString() == "Azul")
            {
                tableroColor[x, y].BackColor = Color.Blue;
                tableroInterno[x, y] = "0";
                cambio2++;
            }
            else if (arrayJugador2[cambio2].ToString() == "Anaranjado")
            {
                tableroColor[x, y].BackColor = Color.Orange;
                tableroInterno[x, y] = "0";
                cambio2++;
            }
            else if (arrayJugador2[cambio2].ToString() == "Verde")
            {
                tableroColor[x, y].BackColor = Color.Green;
                tableroInterno[x, y] = "0";
                cambio2++;
            }
            else if (arrayJugador2[cambio2].ToString() == "Violeta")
            {
                tableroColor[x, y].BackColor = Color.Violet;
                tableroInterno[x, y] = "0";
                cambio2++;
            }
            else if (arrayJugador2[cambio2].ToString() == "Blanco")
            {
                tableroColor[x, y].BackColor = Color.White;
                tableroInterno[x, y] = "0";
                cambio2++;
            }
            else if (arrayJugador2[cambio2].ToString() == "Negro")
            {
                tableroColor[x, y].BackColor = Color.Black;
                tableroInterno[x, y] = "0";
                cambio2++;
            }
            else if (arrayJugador2[cambio2].ToString() == "Celeste")
            {
                tableroColor[x, y].BackColor = Color.LightBlue;
                tableroInterno[x, y] = "0";
                cambio2++;
            }
            else if (arrayJugador2[cambio2].ToString() == "Gris")
            {
                tableroColor[x, y].BackColor = Color.Gray;
                tableroInterno[x, y] = "0";
                cambio2++;
            }


        }

        protected void BtnA9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 0);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 1);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 3);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH9_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(8, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(8, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(8, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(8, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 0);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 1);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 3);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH10_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(9, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(9, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(9, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(9, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 0);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 1);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 3);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH11_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(10, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(10, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(10, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(10, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 0);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 1);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11,2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 3);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH12_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(11, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(11, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(11, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(11, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 0);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 1);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 3);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH13_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(12, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(12, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(12, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(12, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 0);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 1);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 3);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH14_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(13, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(13, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(13, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(13, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 0);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14,1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 1);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 3);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH15_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(14, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(14, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(14, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(14, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 0);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 1);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 3);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH16_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(15, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(15, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(15, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(15, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 0);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 1);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 3);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH17_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(16, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(16, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(16, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(16, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 0);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 1);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 3);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH18_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(17, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(17, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(17, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(17, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 0);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 1);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 3);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH19_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(18, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(18, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(18, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(18, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnA20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 0);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 0);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 0);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 0);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnB20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 1);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 1);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 1);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 1);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnC20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 2);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 2);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 2);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 2);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnD20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 3);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 3);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 3);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 3);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnE20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 4);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 4);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 4);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 4);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnF20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 5);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 5);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 5);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 5);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnG20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 6);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 6);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 6);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 6);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }

        protected void BtnH20_Click(object sender, EventArgs e)
        {
            if (turnoJ1 == true)
            {
                pintarJ1(19, 7);
                LabelIndicadorTurno.Text = "Jugador 2";
                if (llaveCaptura == true)
                {
                    capturaFichaJ1(19, 7);
                    informacionFinal();
                }
                turnoJ1 = false;
                turnoJ2 = true;
                llaveTiempo1 = false;
                llaveTiempo2 = true;

            }
            else if (turnoJ2 == true)
            {
                pintarJ2(19, 7);
                LabelIndicadorTurno.Text = "Jugador 1";
                if (llaveCaptura == true)
                {
                    capturaFichaJ2(19, 7);
                    informacionFinal();
                }
                turnoJ1 = true;
                turnoJ2 = false;
                llaveTiempo1 = true;
                llaveTiempo2 = false;
            }
        }
    }
}