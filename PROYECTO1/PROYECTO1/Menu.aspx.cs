using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Drawing;

namespace PROYECTO1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static bool banderaNegra = false;
        public static bool banderaBlanca = true;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void ButtonCarga_Click1(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string extension = System.IO.Path.GetExtension(FileUpload1.FileName);
                
            }
            else {
                Response.Write("Seleccione un archivo");
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