<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Xtream.aspx.cs" Inherits="PROYECTO1.Xtream" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles/estiloTablero.css" rel="stylesheet" type="text/css"/>
     <link href="Styles/MenuSolitario.css" rel="stylesheet" type="text/css"/>
     <link href="Styles/estiloLabelSolitario.css" rel="stylesheet" type="text/css"/>
    <link href="Styles/estiloXtream.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button CssClass="botongenerar" ID="ButtonGenerar" runat="server" Text="Generar" OnClick="ButtonGenerar_Click1" />
            <asp:DropDownList Cssclass="listaFila" ID="DropDownListFila" runat="server">
                <asp:ListItem>Elegir</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList CssClass="listaColumna" ID="DropDownListColumna" runat="server">
                <asp:ListItem>Elegir</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
            </asp:DropDownList>
            <asp:Button Cssclass="btnseleccionar2" ID="ButtonSeleccionar2" runat="server" Text="seleccionar" OnClick="ButtonSeleccionar2_Click" />
            <asp:Button Cssclass="btnseleccionar1" ID="ButtonSeleccionar1" runat="server" Text="Seleccionar" OnClick="ButtonSeleccionar1_Click" />
            <asp:DropDownList Cssclass="listaficha1" ID="DropDownListFicha1" runat="server" OnSelectedIndexChanged="DropDownListFicha_SelectedIndexChanged">
                <asp:ListItem>Elegir</asp:ListItem>
                <asp:ListItem Value="1">Rojo</asp:ListItem>
                <asp:ListItem Value="2">Amarillo</asp:ListItem>
                 <asp:ListItem Value="3">Azul</asp:ListItem>
                <asp:ListItem Value="4">Anaranjado</asp:ListItem>
                 <asp:ListItem Value="5">Verde</asp:ListItem>
                <asp:ListItem Value="6">Violeta</asp:ListItem>
                 <asp:ListItem Value="7">Blanco</asp:ListItem>
                <asp:ListItem Value="8">Negro</asp:ListItem>
                 <asp:ListItem Value="9">Celeste</asp:ListItem>
                <asp:ListItem Value="10">Gris</asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList Cssclass="listaficha2" ID="DropDownListFicha2" runat="server">
                <asp:ListItem>Elegir</asp:ListItem>
                <asp:ListItem Value="1">Rojo</asp:ListItem>
                <asp:ListItem Value="2">Amarillo</asp:ListItem>
                 <asp:ListItem Value="3">Azul</asp:ListItem>
                <asp:ListItem Value="4">Anaranjado</asp:ListItem>
                 <asp:ListItem Value="5">Verde</asp:ListItem>
                <asp:ListItem Value="6">Violeta</asp:ListItem>
                 <asp:ListItem Value="7">Blanco</asp:ListItem>
                <asp:ListItem Value="8">Negro</asp:ListItem>
                 <asp:ListItem Value="9">Celeste</asp:ListItem>
                <asp:ListItem Value="10">Gris</asp:ListItem>
            </asp:DropDownList>
            <asp:Label CssClass="seleccion2" ID="LabelSeleccionJugador2" runat="server" Text="Color Jugador 2:"></asp:Label>
             <asp:Label Cssclass="movimientos" ID="LabeMovimienntos" runat="server" Text="Movimientos"></asp:Label>
            <asp:Label Cssclass="movimientosmaquina" ID="LabelMaquina" runat="server" Text="Invitado"></asp:Label>
            <asp:Label Cssclass="movimientosjugador" ID="LabelJugador" runat="server" Text="Usuario"></asp:Label>
            <asp:Label Cssclass="contadormaquina" ID="LabelContadorInvitado" runat="server" Text="0"></asp:Label>
            <asp:Label Cssclass="contadorjugador" ID="LabelContadorUsuario" runat="server" Text="0"></asp:Label>
            <asp:Label Cssclass="labelseleccion" ID="LabelSeleccionJugador1" runat="server" Text="Color Jugador 1:"></asp:Label>
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
       <td><asp:Label ID="Label37" runat="server" Text="I"></asp:Label></td>
       <td><asp:Label ID="Label38" runat="server" Text="J"></asp:Label></td>
       <td><asp:Label ID="Label39" runat="server" Text="K"></asp:Label></td>
       <td><asp:Label ID="Label40" runat="server" Text="L"></asp:Label></td>
       <td><asp:Label ID="Label41" runat="server" Text="M"></asp:Label></td>
       <td><asp:Label ID="Label42" runat="server" Text="N"></asp:Label></td>
       <td><asp:Label ID="Label43" runat="server" Text="Ñ"></asp:Label></td>
       <td><asp:Label ID="Label44" runat="server" Text="O"></asp:Label></td>
       <td><asp:Label ID="Label45" runat="server" Text="P"></asp:Label></td>
       <td><asp:Label ID="Label46" runat="server" Text="Q"></asp:Label></td>
       <td><asp:Label ID="Label47" runat="server" Text="R"></asp:Label></td>
       <td><asp:Label ID="Label48" runat="server" Text="S"></asp:Label></td>
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
      <td><asp:Button  ID="BtnI1" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ1" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK1" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL1" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM1" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN1" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ1" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO1" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP1" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ1" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR1" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS1" runat="server" Text=""  CssClass="cuadros" /></td>
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
      <td><asp:Button  ID="BtnI2" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ2" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnK2" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL2" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM2" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN2" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ2" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO2" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP2" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ2" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR2" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS2" runat="server" Text=""  CssClass="cuadros" /></td>
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
      <td><asp:Button  ID="BtnI3" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ3" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK3" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL3" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM3" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN3" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ3" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO3" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP3" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ3" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR3" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS3" runat="server" Text=""  CssClass="cuadros" /></td>
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
      <td><asp:Button  ID="BtnI4" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ4" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK4" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL4" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM4" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN4" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ4" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO4" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP4" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ4" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR4" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS4" runat="server" Text=""  CssClass="cuadros" /></td>
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
       <td><asp:Button  ID="BtnI5" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ5" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK5" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL5" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM5" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN5" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ5" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO5" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP5" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ5" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR5" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS5" runat="server" Text=""  CssClass="cuadros" /></td>
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
      <td><asp:Button  ID="BtnI6" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ6" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK6" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL6" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM6" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN6" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ6" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO6" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP6" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ6" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR6" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS6" runat="server" Text=""  CssClass="cuadros" /></td>
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
      <td><asp:Button  ID="BtnI7" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ7" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK7" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL7" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM7" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN7" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ7" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO7" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP7" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ7" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR7" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS7" runat="server" Text=""  CssClass="cuadros" /></td>
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
      <td><asp:Button  ID="BtnI8" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ8" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK8" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL8" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM8" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN8" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ8" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO8" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP8" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ8" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR8" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS8" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Label ID="Label26" runat="server" Text="8"></asp:Label></td>

  </tr>
     
 <tr>

     <td><asp:Label ID="Label61" runat="server" Text="9 "></asp:Label></td>
      <td><asp:Button  ID="BtnA9" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB9" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC9" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD9" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE9" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF9" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG9" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH9" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI9" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ9" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK9" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL9" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM9" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN9" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ9" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO9" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP9" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ9" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR9" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS9" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Label ID="Label62" runat="server" Text="9"></asp:Label></td>

  </tr>

   <tr>

     <td><asp:Label ID="Label63" runat="server" Text="10 "></asp:Label></td>
      <td><asp:Button  ID="BtnA10" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB10" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC10" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD10" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE10" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF10" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG10" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH10" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI10" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ10" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK10" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL10" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM10" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN10" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ10" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO10" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP10" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ10" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR10" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS10" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Label ID="Label64" runat="server" Text="10"></asp:Label></td>

  </tr>
<tr>

     <td><asp:Label ID="Label65" runat="server" Text="11 "></asp:Label></td>
      <td><asp:Button  ID="BtnA11" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB11" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC11" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD11" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE11" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF11" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG11" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH11" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI11" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ11" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK11" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL11" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM11" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN11" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ11" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO11" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP11" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ11" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR11" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS11" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Label ID="Label66" runat="server" Text="11"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="Label67" runat="server" Text="12 "></asp:Label></td>
      <td><asp:Button  ID="BtnA12" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB12" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC12" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD12" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE12" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF12" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG12" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH12" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI12" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ12" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK12" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL12" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM12" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN12" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ12" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO12" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP12" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ12" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR12" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS12" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Label ID="Label68" runat="server" Text="12"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="Label69" runat="server" Text="13 "></asp:Label></td>
      <td><asp:Button  ID="BtnA13" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB13" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC13" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD13" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE13" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF13" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG13" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH13" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI13" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ13" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK13" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL13" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM13" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN13" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ13" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO13" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP13" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ13" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR13" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS13" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Label ID="Label70" runat="server" Text="13"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="Label71" runat="server" Text="14 "></asp:Label></td>
      <td><asp:Button  ID="BtnA14" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB14" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC14" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD14" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE14" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF14" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG14" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH14" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI14" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ14" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK14" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL14" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM14" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN14" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ14" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO14" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP14" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ14" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR14" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS14" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Label ID="Label72" runat="server" Text="14"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="Label73" runat="server" Text="15 "></asp:Label></td>
      <td><asp:Button  ID="BtnA15" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB15" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC15" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD15" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE15" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF15" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG15" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH15" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI15" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ15" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK15" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL15" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM15" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN15" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ15" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO15" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP15" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ15" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR15" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS15" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Label ID="Label74" runat="server" Text="15"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="Label75" runat="server" Text="16 "></asp:Label></td>
      <td><asp:Button  ID="BtnA16" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB16" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC16" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD16" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE16" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF16" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG16" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH16" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI16" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ16" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK16" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL16" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM16" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN16" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ16" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO16" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP16" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ16" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR16" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS16" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Label ID="Label76" runat="server" Text="16"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="Label77" runat="server" Text="17 "></asp:Label></td>
      <td><asp:Button  ID="BtnA17" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB17" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC17" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD17" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE17" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF17" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG17" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH17" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI17" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ17" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK17" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL17" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM17" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN17" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ17" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO17" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP17" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ17" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR17" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS17" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Label ID="Label78" runat="server" Text="17"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="Label79" runat="server" Text="18 "></asp:Label></td>
      <td><asp:Button  ID="BtnA18" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB18" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC18" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD18" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE18" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF18" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG18" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH18" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI18" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ18" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK18" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL18" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM18" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN18" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ18" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO18" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP18" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ18" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR18" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS18" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Label ID="Label80" runat="server" Text="18"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="Label81" runat="server" Text="19 "></asp:Label></td>
      <td><asp:Button  ID="BtnA19" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB19" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC19" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD19" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE19" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF19" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG19" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH19" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI19" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ19" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK19" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL19" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM19" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN19" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ19" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO19" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP19" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ19" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR19" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS19" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Label ID="Label82" runat="server" Text="19"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="Label83" runat="server" Text="20 "></asp:Label></td>
      <td><asp:Button  ID="BtnA20" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB20" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC20" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD20" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE20" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF20" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG20" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH20" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI20" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnJ20" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtbK20" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnL20" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnM20" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnN20" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnÑ20" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnO20" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnP20" runat="server" Text="" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnQ20" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnR20" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnS20" runat="server" Text=""  CssClass="cuadros" /></td>
      <td><asp:Label ID="Label84" runat="server" Text="20"></asp:Label></td>

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
        <td><asp:Label ID="Label49" runat="server" Text="I"></asp:Label></td>
        <td><asp:Label ID="Label50" runat="server" Text="J"></asp:Label></td>
        <td><asp:Label ID="Label51" runat="server" Text="K"></asp:Label></td>
        <td><asp:Label ID="Label52" runat="server" Text="L"></asp:Label></td>
        <td><asp:Label ID="Label53" runat="server" Text="M"></asp:Label></td>
        <td><asp:Label ID="Label54" runat="server" Text="N"></asp:Label></td>
        <td><asp:Label ID="Label55" runat="server" Text="Ñ"></asp:Label></td>
        <td><asp:Label ID="Label56" runat="server" Text="O"></asp:Label></td>
        <td><asp:Label ID="Label57" runat="server" Text="P"></asp:Label></td>
        <td><asp:Label ID="Label58" runat="server" Text="Q"></asp:Label></td>
        <td><asp:Label ID="Label59" runat="server" Text="R"></asp:Label></td>
        <td><asp:Label ID="Label60" runat="server" Text="S"></asp:Label></td>
       <td><asp:Label ID="Label36" runat="server" Text=" "></asp:Label></td>
      
    

  </tr>

</table>
               

             </section>
        </div>
    </form>
</body>
</html>
