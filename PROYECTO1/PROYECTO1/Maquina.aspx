<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maquina.aspx.cs" Inherits="PROYECTO1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="Styles/estiloTablero.css" rel="stylesheet" type="text/css"/>
     <link href="Styles/MenuSolitario.css" rel="stylesheet" type="text/css"/>
     <link href="Styles/estiloLabelSolitario.css" rel="stylesheet" type="text/css"/>
    
    
     
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        
        <div >

            <asp:Button Cssclass="btnaletoria" ID="ButtonRandom" runat="server" Text="Aleatoria" OnClick="ButtonRandom_Click" />
            <asp:Button Cssclass="btnseleccionar" ID="ButtonSeleccionar" runat="server" Text="Seleccionar" OnClick="ButtonSeleccionar_Click" />
            <asp:DropDownList CssClass="listaficha" ID="DropDownListFicha" runat="server">
                <asp:ListItem Value="X">Negro</asp:ListItem>
                <asp:ListItem Value="O">Blanco</asp:ListItem>
            </asp:DropDownList>
            <asp:Label Cssclass="jugador" ID="LabJugador" runat="server" Text="Jugador:"></asp:Label>
            <asp:Label Cssclass="maquina" ID="LabMaquina" runat="server" Text="Máquina:"></asp:Label>
            <asp:Label Cssclass="movimientos" ID="LabeMovimienntos" runat="server" Text="Movimientos"></asp:Label>
            <asp:Label Cssclass="movimientosmaquina" ID="LabelMaquina" runat="server" Text="Máquina"></asp:Label>
            <asp:Label Cssclass="movimientosjugador" ID="LabelJugador" runat="server" Text="Jugador"></asp:Label>
            <asp:Label Cssclass="contadormaquina" ID="LabelContadorMaquina" runat="server" Text="0"></asp:Label>
            <asp:Label Cssclass="contadorjugador" ID="LabelContadorJugador" runat="server" Text="0"></asp:Label>
            <asp:Label Cssclass="labelseleccion" ID="LabelSeleccion" runat="server" Text="Seleccionar Ficha:"></asp:Label>
            <asp:Label Cssclass="labelturno" ID="LabelTurno" runat="server" Text="Estado partida:"></asp:Label>
               <asp:TextBox Cssclass="caja" ID="TextBoxCarga" runat="server"></asp:TextBox>
             <asp:Button Cssclass="btn1" ID="ButtonCarga" runat="server" Text="Cargar" OnClick="ButtonCarga_Click1" />
              <asp:Button Cssclass="btn2" ID="ButtonDescarga" runat="server" Text="Descargar" OnClick="ButtonDescarga_Click" />
              <asp:Button Cssclass="btn3" ID="ButtonSalir" runat="server"  href="~/Opciones" Text="Regresar" OnClick="ButtonSalir_Click" />
               <asp:Label Cssclass="labeltitulo" ID="LabelTitulo" runat="server" Text=" "></asp:Label>
              
                
           
 <section class="form-tabla">
           
<table class="egt" >

  <tr>

       <td><asp:Label ID="Label10" runat="server" Text=" "></asp:Label></td>
       <td><asp:Label ID="Label1" runat="server" Text="A"></asp:Label></td>
       <td><asp:Label ID="Label2" runat="server" Text="B"></asp:Label></td>
       <td><asp:Label ID="Label3" runat="server" Text="C"></asp:Label></td>
       <td><asp:Label ID="Label4" runat="server" Text="D"></asp:Label></td>
       <td><asp:Label ID="Label5" runat="server" Text="E"></asp:Label></td>
       <td><asp:Label ID="Label6" runat="server" Text="F"></asp:Label></td>
       <td><asp:Label ID="Label7" runat="server" Text="G"></asp:Label></td>
       <td><asp:Label ID="Label8" runat="server" Text="H"></asp:Label></td>
       <td><asp:Label ID="Label9" runat="server" Text=" "></asp:Label></td>
      
    

  </tr>
     <tr>

      <td><asp:Label ID="Label11" runat="server" Text="1 "></asp:Label></td>
      <td><asp:Button Cssclass="cuadros" ID="BtnA1" runat="server" Text="" OnClick="BtnA1_Click" /></td>
      <td><asp:Button  ID="BtnB1" runat="server" Text="" OnClick="BtnB1_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC1" runat="server" Text="" OnClick="BtnC1_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD1" runat="server" Text="" OnClick="BtnD1_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE1" runat="server" Text="" OnClick="BtnE1_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF1" runat="server" Text="" OnClick="BtnF1_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG1" runat="server" Text="" OnClick="BtnG1_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH1" runat="server" Text="" OnClick="BtnH1_Click" CssClass="cuadros" /></td>
      <td><asp:Label ID="Label12" runat="server" Text="1"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="Label13" runat="server" Text="2 "></asp:Label></td>
      <td><asp:Button  ID="BtnA2" runat="server" Text="" OnClick="BtnA2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB2" runat="server" Text="" OnClick="BtnB2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC2" runat="server" Text="" OnClick="BtnC2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD2" runat="server" Text="" OnClick="BtnD2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE2" runat="server" Text="" OnClick="BtnE2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF2" runat="server" Text="" OnClick="BtnF2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG2" runat="server" Text="" OnClick="BtnG2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH2" runat="server" Text="" OnClick="BtnH2_Click" CssClass="cuadros" /></td>
      <td><asp:Label ID="Label14" runat="server" Text="2"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="Label15" runat="server" Text="3 "></asp:Label></td>
      <td><asp:Button  ID="BtnA3" runat="server" Text="" OnClick="BtnA3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB3" runat="server" Text="" OnClick="BtnB3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC3" runat="server" Text="" OnClick="BtnC3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD3" runat="server" Text="" OnClick="BtnD3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE3" runat="server" Text="" OnClick="BtnE3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF3" runat="server" Text="" OnClick="BtnF3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG3" runat="server" Text="" OnClick="BtnG3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH3" runat="server" Text="" OnClick="BtnH3_Click" CssClass="cuadros" /></td>
      <td><asp:Label ID="Label16" runat="server" Text="3"></asp:Label></td>

  </tr>
     <tr>

    <td><asp:Label ID="Label17" runat="server" Text="4 "></asp:Label></td>
      <td><asp:Button  ID="BtnA4" runat="server" Text="" OnClick="BtnA4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB4" runat="server" Text="" OnClick="BtnB4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC4" runat="server" Text="" OnClick="BtnC4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD4" runat="server" Text="" OnClick="BtnD4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE4" runat="server" Text="" OnClick="BtnE4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF4" runat="server" Text="" OnClick="BtnF4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG4" runat="server" Text="" OnClick="BtnG4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH4" runat="server" Text="" OnClick="BtnH4_Click" CssClass="cuadros" /></td>
      <td><asp:Label  ID="Label18" runat="server" Text="4"></asp:Label></td>

  </tr>
     <tr>

    <td><asp:Label ID="Label19" runat="server" Text="5 "></asp:Label></td>
      <td><asp:Button ID="BtnA5" runat="server" Text="" OnClick="BtnA5_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB5" runat="server" Text="" OnClick="BtnB5_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC5" runat="server" Text="" OnClick="BtnC5_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD5" runat="server" Text="" OnClick="BtnD5_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE5" runat="server" Text="" OnClick="BtnE5_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF5" runat="server" Text="" OnClick="BtnF5_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG5" runat="server" Text="" OnClick="BtnG5_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH5" runat="server" Text="" OnClick="BtnH5_Click" CssClass="cuadros" /></td>
      <td><asp:Label ID="Label20" runat="server" Text="5"></asp:Label></td>
  </tr>
     <tr>

    <td><asp:Label ID="Label21" runat="server" Text="6 "></asp:Label></td>
      <td><asp:Button ID="BtnA6" runat="server" Text="" OnClick="BtnA6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB6" runat="server" Text="" OnClick="BtnB6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC6" runat="server" Text="" OnClick="BtnC6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD6" runat="server" Text="" OnClick="BtnD6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE6" runat="server" Text="" OnClick="BtnE6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF6" runat="server" Text="" OnClick="BtnF6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG6" runat="server" Text="" OnClick="BtnG6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH6" runat="server" Text="" OnClick="BtnH6_Click" CssClass="cuadros" /></td>
      <td><asp:Label ID="Label22" runat="server" Text="6"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="Label23" runat="server" Text="7 "></asp:Label></td>
      <td><asp:Button  ID="BtnA7" runat="server" Text="" OnClick="BtnA7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB7" runat="server" Text="" OnClick="BtnB7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC7" runat="server" Text="" OnClick="BtnC7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD7" runat="server" Text="" OnClick="BtnD7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE7" runat="server" Text="" OnClick="BtnE7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF7" runat="server" Text="" OnClick="BtnF7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG7" runat="server" Text="" OnClick="BtnG7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH7" runat="server" Text="" OnClick="BtnH7_Click" CssClass="cuadros" /></td>
      <td><asp:Label ID="Label24" runat="server" Text="7"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="Label25" runat="server" Text="8 "></asp:Label></td>
      <td><asp:Button  ID="BtnA8" runat="server" Text="" OnClick="BtnA8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB8" runat="server" Text="" OnClick="BtnB8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC8" runat="server" Text="" OnClick="BtnC8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD8" runat="server" Text="" OnClick="BtnD8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE8" runat="server" Text="" OnClick="BtnE8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF8" runat="server" Text="" OnClick="BtnF8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG8" runat="server" Text="" OnClick="BtnG8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH8" runat="server" Text="" OnClick="BtnH8_Click" CssClass="cuadros" /></td>
      <td><asp:Label ID="Label26" runat="server" Text="8"></asp:Label></td>

  </tr>

   <tr>

       <td><asp:Label ID="Label27" runat="server" Text=" "></asp:Label></td>
       <td><asp:Label ID="Label28" runat="server" Text="A"></asp:Label></td>
       <td><asp:Label ID="Label29" runat="server" Text="B"></asp:Label></td>
       <td><asp:Label ID="Label30" runat="server" Text="C"></asp:Label></td>
       <td><asp:Label ID="Label31" runat="server" Text="D"></asp:Label></td>
       <td><asp:Label ID="Label32" runat="server" Text="E"></asp:Label></td>
       <td><asp:Label ID="Label33" runat="server" Text="F"></asp:Label></td>
       <td><asp:Label ID="Label34" runat="server" Text="G"></asp:Label></td>
       <td><asp:Label ID="Label35" runat="server" Text="H"></asp:Label></td>
       <td><asp:Label ID="Label36" runat="server" Text=" "></asp:Label></td>
      
    

  </tr>

</table>
             </section>
        </div>
    </form>
</body>
</html>
