<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Xtream.aspx.cs" Inherits="PROYECTO1.Xtream" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         
    <link href="Styles/estiloXtream.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:ScriptManager ID="ScriptManager1" runat="server" />
            
            <asp:Timer ID="Timer1" OnTick="Timer1_Tick"  Interval="1000" runat="server"/>
             <asp:UpdatePanel ID="TimeJ1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" />
        </Triggers>
        <ContentTemplate>
             <asp:Label CssClass="tiempojugador1" ID="LabelTiempoJ1" runat="server" Text="0:0"></asp:Label>
             <asp:Label CssClass="tiempojugador2" ID="LabelTiempoJ2" runat="server" Text="0:0"></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>



            
            
            <asp:DropDownList CssClass="listamodalidad" ID="DropDownListModalidad" runat="server">
                <asp:ListItem>Elegir</asp:ListItem>
                <asp:ListItem>Normal</asp:ListItem>
                <asp:ListItem>Inversa</asp:ListItem>
             </asp:DropDownList>
            <asp:Button CssClass="btnmodalidad" ID="ButtonModalidad" runat="server" Text="Modalidad" OnClick="ButtonModalidad_Click" />
            <asp:Button CssClass="btnempezar" ID="ButtonEmpezar" runat="server" Text="Empezar" OnClick="ButtonEmpezar_Click" />
            <asp:Label CssClass="titulojugador2" ID="Label87" runat="server" Text="Jugador 2"></asp:Label>
            <asp:Label CssClass="titulojugador1" ID="Label86" runat="server" Text="Jugador 1"></asp:Label>
            <asp:Label CssClass="tituloCronometro" ID="Label85" runat="server" Text="Cronometro"></asp:Label>
            <asp:Label CssClass="estadoturno" ID="LabelIndicadorTurno" runat="server" Text="No Disponible"></asp:Label>
            <asp:Label CssClass="tituloturno" ID="LabelTurnos" runat="server" Text="Turno:"></asp:Label>
            <asp:Label CssClass="filaTamaño" ID="Labelfila" runat="server" Text="Fila"></asp:Label>
            <asp:Label CssClass="columnaTamaño" ID="Labelcolumna" runat="server" Text="Columna"></asp:Label>
            <asp:Label CssClass="tituloTamaño" ID="Labeltamaño" runat="server" Text="Tamaño Tablero"></asp:Label>
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
            <asp:Label Cssclass="movimientosinvitado" ID="LabelJugador2" runat="server" Text="Jugador 2"></asp:Label>
            <asp:Label Cssclass="movimientosusuario" ID="LabelJugador1" runat="server" Text="Jugador 1"></asp:Label>
            <asp:Label Cssclass="contadorinvitado" ID="LabelContadorJ2" runat="server" Text="0"></asp:Label>
            <asp:Label Cssclass="contadorusuario" ID="LabelContadorJ1" runat="server" Text="0"></asp:Label>
            <asp:Label Cssclass="seleccion1" ID="LabelSeleccionJugador1" runat="server" Text="Color Jugador 1:"></asp:Label>
            <asp:Label Cssclass="labelestado" ID="Labelestado" runat="server" Text="Estado"></asp:Label>
            <asp:Label CssClass="tituloestado" ID="LabelTituloEstado" runat="server" Text="Estado Partida:"></asp:Label>
               <asp:TextBox Cssclass="caja" ID="TextBoxCarga" runat="server"></asp:TextBox>
             <asp:Button Cssclass="btn1" ID="ButtonCarga" runat="server" Text="Cargar" OnClick="ButtonCarga_Click1" />
              <asp:Button Cssclass="btn2" ID="ButtonDescarga" runat="server" Text="Descargar" OnClick="ButtonDescarga_Click" />
              <asp:Button Cssclass="btn3" ID="ButtonSalir" runat="server"  href="~/Opciones" Text="Regresar" OnClick="ButtonSalir_Click" />
               <asp:Label Cssclass="labeltitulo" ID="LabelTitulo" runat="server" Text=" "></asp:Label>
              
                
           
 <section class="form-tablero">
     
  <table id="TableroCompleto" class="xtream" runat="server" >

  <tr>

       <td><asp:Label ID="Label10" runat="server" Text=" "></asp:Label></td>
       <td><asp:Label ID="LabelAS" runat="server" Text="A"></asp:Label></td>
       <td><asp:Label ID="LabelBS" runat="server" Text="B"></asp:Label></td>
       <td><asp:Label ID="LabelCS" runat="server" Text="C"></asp:Label></td>
       <td><asp:Label ID="LabelDS" runat="server" Text="D"></asp:Label></td>
       <td><asp:Label ID="LabelES" runat="server" Text="E"></asp:Label></td>
       <td><asp:Label ID="LabelFS" runat="server" Text="F"></asp:Label></td>
       <td><asp:Label ID="LabelGS" runat="server" Text="G"></asp:Label></td>
       <td><asp:Label ID="LabelHS" runat="server" Text="H"></asp:Label></td>
       <td><asp:Label ID="LabelIS" runat="server" Text="I"></asp:Label></td>
       <td><asp:Label ID="LabelJS" runat="server" Text="J"></asp:Label></td>
       <td><asp:Label ID="LabelKS" runat="server" Text="K"></asp:Label></td>
       <td><asp:Label ID="LabelLS" runat="server" Text="L"></asp:Label></td>
       <td><asp:Label ID="LabelMS" runat="server" Text="M"></asp:Label></td>
       <td><asp:Label ID="LabelNS" runat="server" Text="N"></asp:Label></td>
       <td><asp:Label ID="LabelÑS" runat="server" Text="Ñ"></asp:Label></td>
       <td><asp:Label ID="LabelOS" runat="server" Text="O"></asp:Label></td>
       <td><asp:Label ID="LabelPS" runat="server" Text="P"></asp:Label></td>
       <td><asp:Label ID="LabelQS" runat="server" Text="Q"></asp:Label></td>
       <td><asp:Label ID="LabelRS" runat="server" Text="R"></asp:Label></td>
       <td><asp:Label ID="LabelSS" runat="server" Text="S"></asp:Label></td>
       <td><asp:Label ID="Label9" runat="server" Text=" "></asp:Label></td>
      
    

  </tr>
     <tr>

      <td><asp:Label ID="LabelI1" runat="server" Text="1 "></asp:Label></td>
      <td><asp:Button Cssclass="cuadros" ID="BtnA1" runat="server" Text="" OnClick="BtnA1_Click" /></td>
      <td><asp:Button  ID="BtnB1" runat="server" Text="" OnClick="BtnB1_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC1" runat="server" Text="" OnClick="BtnC1_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD1" runat="server" Text="" OnClick="BtnD1_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE1" runat="server" Text="" OnClick="BtnE1_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF1" runat="server" Text="" OnClick="BtnF1_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG1" runat="server" Text="" OnClick="BtnG1_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH1" runat="server" Text="" OnClick="BtnH1_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI1" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI1_Click" /></td>
      <td><asp:Button  ID="BtnJ1" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ1_Click" /></td>
      <td><asp:Button  ID="BtnK1" runat="server" Text="" CssClass="cuadros" OnClick="BtnK1_Click" /></td>
      <td><asp:Button  ID="BtnL1" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL1_Click" /></td>
      <td><asp:Button  ID="BtnM1" runat="server" Text="" CssClass="cuadros" OnClick="BtnM1_Click" /></td>
      <td><asp:Button  ID="BtnN1" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN1_Click" /></td>
      <td><asp:Button  ID="BtnÑ1" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ1_Click" /></td>
      <td><asp:Button  ID="BtnO1" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO1_Click" /></td>
      <td><asp:Button  ID="BtnP1" runat="server" Text="" CssClass="cuadros" OnClick="BtnP1_Click" /></td>
      <td><asp:Button  ID="BtnQ1" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ1_Click" /></td>
      <td><asp:Button  ID="BtnR1" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR1_Click" /></td>
      <td><asp:Button  ID="BtnS1" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS1_Click" /></td>
      <td><asp:Label ID="LabelD1" runat="server" Text="1"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="LabelI2" runat="server" Text="2 "></asp:Label></td>
      <td><asp:Button  ID="BtnA2" runat="server" Text="" OnClick="BtnA2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB2" runat="server" Text="" OnClick="BtnB2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC2" runat="server" Text="" OnClick="BtnC2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD2" runat="server" Text="" OnClick="BtnD2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE2" runat="server" Text="" OnClick="BtnE2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF2" runat="server" Text="" OnClick="BtnF2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG2" runat="server" Text="" OnClick="BtnG2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH2" runat="server" Text="" OnClick="BtnH2_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI2" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI2_Click" /></td>
      <td><asp:Button  ID="BtnJ2" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ2_Click" /></td>
      <td><asp:Button  ID="BtnK2" runat="server" Text="" CssClass="cuadros" OnClick="BtnK2_Click" /></td>
      <td><asp:Button  ID="BtnL2" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL2_Click" /></td>
      <td><asp:Button  ID="BtnM2" runat="server" Text="" CssClass="cuadros" OnClick="BtnM2_Click" /></td>
      <td><asp:Button  ID="BtnN2" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN2_Click" /></td>
      <td><asp:Button  ID="BtnÑ2" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ2_Click" /></td>
      <td><asp:Button  ID="BtnO2" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO2_Click" /></td>
      <td><asp:Button  ID="BtnP2" runat="server" Text="" CssClass="cuadros" OnClick="BtnP2_Click" /></td>
      <td><asp:Button  ID="BtnQ2" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ2_Click" /></td>
      <td><asp:Button  ID="BtnR2" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR2_Click" /></td>
      <td><asp:Button  ID="BtnS2" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS2_Click" /></td>
      <td><asp:Label ID="LabelD2" runat="server" Text="2"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="LabelI3" runat="server" Text="3 "></asp:Label></td>
      <td><asp:Button  ID="BtnA3" runat="server" Text="" OnClick="BtnA3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB3" runat="server" Text="" OnClick="BtnB3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC3" runat="server" Text="" OnClick="BtnC3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD3" runat="server" Text="" OnClick="BtnD3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE3" runat="server" Text="" OnClick="BtnE3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF3" runat="server" Text="" OnClick="BtnF3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG3" runat="server" Text="" OnClick="BtnG3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH3" runat="server" Text="" OnClick="BtnH3_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI3" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI3_Click" /></td>
      <td><asp:Button  ID="BtnJ3" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ3_Click" /></td>
      <td><asp:Button  ID="BtnK3" runat="server" Text="" CssClass="cuadros" OnClick="BtnK3_Click" /></td>
      <td><asp:Button  ID="BtnL3" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL3_Click" /></td>
      <td><asp:Button  ID="BtnM3" runat="server" Text="" CssClass="cuadros" OnClick="BtnM3_Click" /></td>
      <td><asp:Button  ID="BtnN3" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN3_Click" /></td>
      <td><asp:Button  ID="BtnÑ3" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ3_Click" /></td>
      <td><asp:Button  ID="BtnO3" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO3_Click" /></td>
      <td><asp:Button  ID="BtnP3" runat="server" Text="" CssClass="cuadros" OnClick="BtnP3_Click" /></td>
      <td><asp:Button  ID="BtnQ3" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ3_Click" /></td>
      <td><asp:Button  ID="BtnR3" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR3_Click" /></td>
      <td><asp:Button  ID="BtnS3" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS3_Click" /></td>
      <td><asp:Label ID="LabelD3" runat="server" Text="3"></asp:Label></td>

  </tr>
     <tr>

    <td><asp:Label ID="LabelI4" runat="server" Text="4 "></asp:Label></td>
      <td><asp:Button  ID="BtnA4" runat="server" Text="" OnClick="BtnA4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB4" runat="server" Text="" OnClick="BtnB4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC4" runat="server" Text="" OnClick="BtnC4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD4" runat="server" Text="" OnClick="BtnD4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE4" runat="server" Text="" OnClick="BtnE4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF4" runat="server" Text="" OnClick="BtnF4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG4" runat="server" Text="" OnClick="BtnG4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH4" runat="server" Text="" OnClick="BtnH4_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI4" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI4_Click" /></td>
      <td><asp:Button  ID="BtnJ4" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ4_Click" /></td>
      <td><asp:Button  ID="BtnK4" runat="server" Text="" CssClass="cuadros" OnClick="BtnK4_Click" /></td>
      <td><asp:Button  ID="BtnL4" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL4_Click" /></td>
      <td><asp:Button  ID="BtnM4" runat="server" Text="" CssClass="cuadros" OnClick="BtnM4_Click" /></td>
      <td><asp:Button  ID="BtnN4" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN4_Click" /></td>
      <td><asp:Button  ID="BtnÑ4" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ4_Click" /></td>
      <td><asp:Button  ID="BtnO4" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO4_Click" /></td>
      <td><asp:Button  ID="BtnP4" runat="server" Text="" CssClass="cuadros" OnClick="BtnP4_Click" /></td>
      <td><asp:Button  ID="BtnQ4" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ4_Click" /></td>
      <td><asp:Button  ID="BtnR4" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR4_Click" /></td>
      <td><asp:Button  ID="BtnS4" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS4_Click" /></td>
      <td><asp:Label  ID="LabelD4" runat="server" Text="4"></asp:Label></td>

  </tr>
     <tr>

    <td><asp:Label ID="LabelI5" runat="server" Text="5 "></asp:Label></td>
      <td><asp:Button ID="BtnA5" runat="server" Text="" OnClick="BtnA5_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB5" runat="server" Text="" OnClick="BtnB5_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC5" runat="server" Text="" OnClick="BtnC5_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD5" runat="server" Text="" OnClick="BtnD5_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE5" runat="server" Text="" OnClick="BtnE5_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF5" runat="server" Text="" OnClick="BtnF5_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG5" runat="server" Text="" OnClick="BtnG5_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH5" runat="server" Text="" OnClick="BtnH5_Click" CssClass="cuadros" /></td>
       <td><asp:Button  ID="BtnI5" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI5_Click" /></td>
      <td><asp:Button  ID="BtnJ5" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ5_Click" /></td>
      <td><asp:Button  ID="BtnK5" runat="server" Text="" CssClass="cuadros" OnClick="BtnK5_Click" /></td>
      <td><asp:Button  ID="BtnL5" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL5_Click" /></td>
      <td><asp:Button  ID="BtnM5" runat="server" Text="" CssClass="cuadros" OnClick="BtnM5_Click" /></td>
      <td><asp:Button  ID="BtnN5" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN5_Click" /></td>
      <td><asp:Button  ID="BtnÑ5" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ5_Click" /></td>
      <td><asp:Button  ID="BtnO5" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO5_Click" /></td>
      <td><asp:Button  ID="BtnP5" runat="server" Text="" CssClass="cuadros" OnClick="BtnP5_Click" /></td>
      <td><asp:Button  ID="BtnQ5" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ5_Click" /></td>
      <td><asp:Button  ID="BtnR5" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR5_Click" /></td>
      <td><asp:Button  ID="BtnS5" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS5_Click" /></td>
      <td><asp:Label ID="LabelD5" runat="server" Text="5"></asp:Label></td>
  </tr>
     <tr>

    <td><asp:Label ID="LabelI6" runat="server" Text="6 "></asp:Label></td>
      <td><asp:Button ID="BtnA6" runat="server" Text="" OnClick="BtnA6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB6" runat="server" Text="" OnClick="BtnB6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC6" runat="server" Text="" OnClick="BtnC6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD6" runat="server" Text="" OnClick="BtnD6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE6" runat="server" Text="" OnClick="BtnE6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF6" runat="server" Text="" OnClick="BtnF6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG6" runat="server" Text="" OnClick="BtnG6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH6" runat="server" Text="" OnClick="BtnH6_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI6" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI6_Click" /></td>
      <td><asp:Button  ID="BtnJ6" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ6_Click" /></td>
      <td><asp:Button  ID="BtnK6" runat="server" Text="" CssClass="cuadros" OnClick="BtnK6_Click" /></td>
      <td><asp:Button  ID="BtnL6" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL6_Click" /></td>
      <td><asp:Button  ID="BtnM6" runat="server" Text="" CssClass="cuadros" OnClick="BtnM6_Click" /></td>
      <td><asp:Button  ID="BtnN6" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN6_Click" /></td>
      <td><asp:Button  ID="BtnÑ6" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ6_Click" /></td>
      <td><asp:Button  ID="BtnO6" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO6_Click" /></td>
      <td><asp:Button  ID="BtnP6" runat="server" Text="" CssClass="cuadros" OnClick="BtnP6_Click" /></td>
      <td><asp:Button  ID="BtnQ6" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ6_Click" /></td>
      <td><asp:Button  ID="BtnR6" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR6_Click" /></td>
      <td><asp:Button  ID="BtnS6" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS6_Click" /></td>
      <td><asp:Label ID="LabelD6" runat="server" Text="6"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="LabelI7" runat="server" Text="7 "></asp:Label></td>
      <td><asp:Button  ID="BtnA7" runat="server" Text="" OnClick="BtnA7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB7" runat="server" Text="" OnClick="BtnB7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC7" runat="server" Text="" OnClick="BtnC7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD7" runat="server" Text="" OnClick="BtnD7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE7" runat="server" Text="" OnClick="BtnE7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF7" runat="server" Text="" OnClick="BtnF7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG7" runat="server" Text="" OnClick="BtnG7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH7" runat="server" Text="" OnClick="BtnH7_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI7" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI7_Click" /></td>
      <td><asp:Button  ID="BtnJ7" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ7_Click" /></td>
      <td><asp:Button  ID="BtnK7" runat="server" Text="" CssClass="cuadros" OnClick="BtnK7_Click" /></td>
      <td><asp:Button  ID="BtnL7" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL7_Click" /></td>
      <td><asp:Button  ID="BtnM7" runat="server" Text="" CssClass="cuadros" OnClick="BtnM7_Click" /></td>
      <td><asp:Button  ID="BtnN7" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN7_Click" /></td>
      <td><asp:Button  ID="BtnÑ7" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ7_Click" /></td>
      <td><asp:Button  ID="BtnO7" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO7_Click" /></td>
      <td><asp:Button  ID="BtnP7" runat="server" Text="" CssClass="cuadros" OnClick="BtnP7_Click" /></td>
      <td><asp:Button  ID="BtnQ7" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ7_Click" /></td>
      <td><asp:Button  ID="BtnR7" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR7_Click" /></td>
      <td><asp:Button  ID="BtnS7" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS7_Click" /></td>
      <td><asp:Label ID="LabelD7" runat="server" Text="7"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="LabelI8" runat="server" Text="8 "></asp:Label></td>
      <td><asp:Button  ID="BtnA8" runat="server" Text="" OnClick="BtnA8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnB8" runat="server" Text="" OnClick="BtnB8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnC8" runat="server" Text="" OnClick="BtnC8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnD8" runat="server" Text="" OnClick="BtnD8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnE8" runat="server" Text="" OnClick="BtnE8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnF8" runat="server" Text="" OnClick="BtnF8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnG8" runat="server" Text="" OnClick="BtnG8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnH8" runat="server" Text="" OnClick="BtnH8_Click" CssClass="cuadros" /></td>
      <td><asp:Button  ID="BtnI8" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI8_Click" /></td>
      <td><asp:Button  ID="BtnJ8" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ8_Click" /></td>
      <td><asp:Button  ID="BtnK8" runat="server" Text="" CssClass="cuadros" OnClick="BtnK8_Click" /></td>
      <td><asp:Button  ID="BtnL8" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL8_Click" /></td>
      <td><asp:Button  ID="BtnM8" runat="server" Text="" CssClass="cuadros" OnClick="BtnM8_Click" /></td>
      <td><asp:Button  ID="BtnN8" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN8_Click" /></td>
      <td><asp:Button  ID="BtnÑ8" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ8_Click" /></td>
      <td><asp:Button  ID="BtnO8" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO8_Click" /></td>
      <td><asp:Button  ID="BtnP8" runat="server" Text="" CssClass="cuadros" OnClick="BtnP8_Click" /></td>
      <td><asp:Button  ID="BtnQ8" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ8_Click" /></td>
      <td><asp:Button  ID="BtnR8" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR8_Click" /></td>
      <td><asp:Button  ID="BtnS8" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS8_Click" /></td>
      <td><asp:Label ID="LabelD8" runat="server" Text="8"></asp:Label></td>

  </tr>
     
 <tr>

     <td><asp:Label ID="LabelI9" runat="server" Text="9 "></asp:Label></td>
      <td><asp:Button  ID="BtnA9" runat="server" Text="" CssClass="cuadros" OnClick="BtnA9_Click" /></td>
      <td><asp:Button  ID="BtnB9" runat="server" Text=""  CssClass="cuadros" OnClick="BtnB9_Click" /></td>
      <td><asp:Button  ID="BtnC9" runat="server" Text=""  CssClass="cuadros" OnClick="BtnC9_Click" /></td>
      <td><asp:Button  ID="BtnD9" runat="server" Text=""  CssClass="cuadros" OnClick="BtnD9_Click" /></td>
      <td><asp:Button  ID="BtnE9" runat="server" Text=""  CssClass="cuadros" OnClick="BtnE9_Click" /></td>
      <td><asp:Button  ID="BtnF9" runat="server" Text="" CssClass="cuadros" OnClick="BtnF9_Click" /></td>
      <td><asp:Button  ID="BtnG9" runat="server" Text=""  CssClass="cuadros" OnClick="BtnG9_Click" /></td>
      <td><asp:Button  ID="BtnH9" runat="server" Text=""  CssClass="cuadros" OnClick="BtnH9_Click" /></td>
      <td><asp:Button  ID="BtnI9" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI9_Click" /></td>
      <td><asp:Button  ID="BtnJ9" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ9_Click" /></td>
      <td><asp:Button  ID="BtnK9" runat="server" Text="" CssClass="cuadros" OnClick="BtnK9_Click" /></td>
      <td><asp:Button  ID="BtnL9" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL9_Click" /></td>
      <td><asp:Button  ID="BtnM9" runat="server" Text="" CssClass="cuadros" OnClick="BtnM9_Click" /></td>
      <td><asp:Button  ID="BtnN9" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN9_Click" /></td>
      <td><asp:Button  ID="BtnÑ9" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ9_Click" /></td>
      <td><asp:Button  ID="BtnO9" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO9_Click" /></td>
      <td><asp:Button  ID="BtnP9" runat="server" Text="" CssClass="cuadros" OnClick="BtnP9_Click" /></td>
      <td><asp:Button  ID="BtnQ9" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ9_Click" /></td>
      <td><asp:Button  ID="BtnR9" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR9_Click" /></td>
      <td><asp:Button  ID="BtnS9" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS9_Click" /></td>
      <td><asp:Label ID="LabelD9" runat="server" Text="9"></asp:Label></td>

  </tr>

   <tr>

     <td><asp:Label ID="LabelI10" runat="server" Text="10 "></asp:Label></td>
      <td><asp:Button  ID="BtnA10" runat="server" Text="" CssClass="cuadros" OnClick="BtnA10_Click" /></td>
      <td><asp:Button  ID="BtnB10" runat="server" Text=""  CssClass="cuadros" OnClick="BtnB10_Click" /></td>
      <td><asp:Button  ID="BtnC10" runat="server" Text=""  CssClass="cuadros" OnClick="BtnC10_Click" /></td>
      <td><asp:Button  ID="BtnD10" runat="server" Text=""  CssClass="cuadros" OnClick="BtnD10_Click" /></td>
      <td><asp:Button  ID="BtnE10" runat="server" Text=""  CssClass="cuadros" OnClick="BtnE10_Click" /></td>
      <td><asp:Button  ID="BtnF10" runat="server" Text="" CssClass="cuadros" OnClick="BtnF10_Click" /></td>
      <td><asp:Button  ID="BtnG10" runat="server" Text=""  CssClass="cuadros" OnClick="BtnG10_Click" /></td>
      <td><asp:Button  ID="BtnH10" runat="server" Text=""  CssClass="cuadros" OnClick="BtnH10_Click" /></td>
      <td><asp:Button  ID="BtnI10" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI10_Click" /></td>
      <td><asp:Button  ID="BtnJ10" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ10_Click" /></td>
      <td><asp:Button  ID="BtnK10" runat="server" Text="" CssClass="cuadros" OnClick="BtnK10_Click" /></td>
      <td><asp:Button  ID="BtnL10" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL10_Click" /></td>
      <td><asp:Button  ID="BtnM10" runat="server" Text="" CssClass="cuadros" OnClick="BtnM10_Click" /></td>
      <td><asp:Button  ID="BtnN10" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN10_Click" /></td>
      <td><asp:Button  ID="BtnÑ10" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ10_Click" /></td>
      <td><asp:Button  ID="BtnO10" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO10_Click" /></td>
      <td><asp:Button  ID="BtnP10" runat="server" Text="" CssClass="cuadros" OnClick="BtnP10_Click" /></td>
      <td><asp:Button  ID="BtnQ10" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ10_Click" /></td>
      <td><asp:Button  ID="BtnR10" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR10_Click" /></td>
      <td><asp:Button  ID="BtnS10" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS10_Click" /></td>
      <td><asp:Label ID="LabelD10" runat="server" Text="10"></asp:Label></td>

  </tr>
<tr>

     <td><asp:Label ID="LabelI11" runat="server" Text="11 "></asp:Label></td>
      <td><asp:Button  ID="BtnA11" runat="server" Text="" CssClass="cuadros" OnClick="BtnA11_Click" /></td>
      <td><asp:Button  ID="BtnB11" runat="server" Text=""  CssClass="cuadros" OnClick="BtnB11_Click" /></td>
      <td><asp:Button  ID="BtnC11" runat="server" Text=""  CssClass="cuadros" OnClick="BtnC11_Click" /></td>
      <td><asp:Button  ID="BtnD11" runat="server" Text=""  CssClass="cuadros" OnClick="BtnD11_Click" /></td>
      <td><asp:Button  ID="BtnE11" runat="server" Text=""  CssClass="cuadros" OnClick="BtnE11_Click" /></td>
      <td><asp:Button  ID="BtnF11" runat="server" Text="" CssClass="cuadros" OnClick="BtnF11_Click" /></td>
      <td><asp:Button  ID="BtnG11" runat="server" Text=""  CssClass="cuadros" OnClick="BtnG11_Click" /></td>
      <td><asp:Button  ID="BtnH11" runat="server" Text=""  CssClass="cuadros" OnClick="BtnH11_Click" /></td>
      <td><asp:Button  ID="BtnI11" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI11_Click" /></td>
      <td><asp:Button  ID="BtnJ11" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ11_Click" /></td>
      <td><asp:Button  ID="BtnK11" runat="server" Text="" CssClass="cuadros" OnClick="BtnK11_Click" /></td>
      <td><asp:Button  ID="BtnL11" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL11_Click" /></td>
      <td><asp:Button  ID="BtnM11" runat="server" Text="" CssClass="cuadros" OnClick="BtnM11_Click" /></td>
      <td><asp:Button  ID="BtnN11" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN11_Click" /></td>
      <td><asp:Button  ID="BtnÑ11" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ11_Click" /></td>
      <td><asp:Button  ID="BtnO11" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO11_Click" /></td>
      <td><asp:Button  ID="BtnP11" runat="server" Text="" CssClass="cuadros" OnClick="BtnP11_Click" /></td>
      <td><asp:Button  ID="BtnQ11" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ11_Click" /></td>
      <td><asp:Button  ID="BtnR11" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR11_Click" /></td>
      <td><asp:Button  ID="BtnS11" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS11_Click" /></td>
      <td><asp:Label ID="LabelD11" runat="server" Text="11"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="LabelI12" runat="server" Text="12 "></asp:Label></td>
      <td><asp:Button  ID="BtnA12" runat="server" Text="" CssClass="cuadros" OnClick="BtnA12_Click" /></td>
      <td><asp:Button  ID="BtnB12" runat="server" Text=""  CssClass="cuadros" OnClick="BtnB12_Click" /></td>
      <td><asp:Button  ID="BtnC12" runat="server" Text=""  CssClass="cuadros" OnClick="BtnC12_Click" /></td>
      <td><asp:Button  ID="BtnD12" runat="server" Text=""  CssClass="cuadros" OnClick="BtnD12_Click" /></td>
      <td><asp:Button  ID="BtnE12" runat="server" Text=""  CssClass="cuadros" OnClick="BtnE12_Click" /></td>
      <td><asp:Button  ID="BtnF12" runat="server" Text="" CssClass="cuadros" OnClick="BtnF12_Click" /></td>
      <td><asp:Button  ID="BtnG12" runat="server" Text=""  CssClass="cuadros" OnClick="BtnG12_Click" /></td>
      <td><asp:Button  ID="BtnH12" runat="server" Text=""  CssClass="cuadros" OnClick="BtnH12_Click" /></td>
      <td><asp:Button  ID="BtnI12" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI12_Click" /></td>
      <td><asp:Button  ID="BtnJ12" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ12_Click" /></td>
      <td><asp:Button  ID="BtnK12" runat="server" Text="" CssClass="cuadros" OnClick="BtnK12_Click" /></td>
      <td><asp:Button  ID="BtnL12" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL12_Click" /></td>
      <td><asp:Button  ID="BtnM12" runat="server" Text="" CssClass="cuadros" OnClick="BtnM12_Click" /></td>
      <td><asp:Button  ID="BtnN12" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN12_Click" /></td>
      <td><asp:Button  ID="BtnÑ12" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ12_Click" /></td>
      <td><asp:Button  ID="BtnO12" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO12_Click" /></td>
      <td><asp:Button  ID="BtnP12" runat="server" Text="" CssClass="cuadros" OnClick="BtnP12_Click" /></td>
      <td><asp:Button  ID="BtnQ12" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ12_Click" /></td>
      <td><asp:Button  ID="BtnR12" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR12_Click" /></td>
      <td><asp:Button  ID="BtnS12" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS12_Click" /></td>
      <td><asp:Label ID="LabelD12" runat="server" Text="12"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="LabelI13" runat="server" Text="13 "></asp:Label></td>
      <td><asp:Button  ID="BtnA13" runat="server" Text="" CssClass="cuadros" OnClick="BtnA13_Click" /></td>
      <td><asp:Button  ID="BtnB13" runat="server" Text=""  CssClass="cuadros" OnClick="BtnB13_Click" /></td>
      <td><asp:Button  ID="BtnC13" runat="server" Text=""  CssClass="cuadros" OnClick="BtnC13_Click" /></td>
      <td><asp:Button  ID="BtnD13" runat="server" Text=""  CssClass="cuadros" OnClick="BtnD13_Click" /></td>
      <td><asp:Button  ID="BtnE13" runat="server" Text=""  CssClass="cuadros" OnClick="BtnE13_Click" /></td>
      <td><asp:Button  ID="BtnF13" runat="server" Text="" CssClass="cuadros" OnClick="BtnF13_Click" /></td>
      <td><asp:Button  ID="BtnG13" runat="server" Text=""  CssClass="cuadros" OnClick="BtnG13_Click" /></td>
      <td><asp:Button  ID="BtnH13" runat="server" Text=""  CssClass="cuadros" OnClick="BtnH13_Click" /></td>
      <td><asp:Button  ID="BtnI13" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI13_Click" /></td>
      <td><asp:Button  ID="BtnJ13" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ13_Click" /></td>
      <td><asp:Button  ID="BtnK13" runat="server" Text="" CssClass="cuadros" OnClick="BtnK13_Click" /></td>
      <td><asp:Button  ID="BtnL13" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL13_Click" /></td>
      <td><asp:Button  ID="BtnM13" runat="server" Text="" CssClass="cuadros" OnClick="BtnM13_Click" /></td>
      <td><asp:Button  ID="BtnN13" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN13_Click" /></td>
      <td><asp:Button  ID="BtnÑ13" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ13_Click" /></td>
      <td><asp:Button  ID="BtnO13" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO13_Click" /></td>
      <td><asp:Button  ID="BtnP13" runat="server" Text="" CssClass="cuadros" OnClick="BtnP13_Click" /></td>
      <td><asp:Button  ID="BtnQ13" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ13_Click" /></td>
      <td><asp:Button  ID="BtnR13" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR13_Click" /></td>
      <td><asp:Button  ID="BtnS13" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS13_Click" /></td>
      <td><asp:Label ID="LabelD13" runat="server" Text="13"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="LabelI14" runat="server" Text="14 "></asp:Label></td>
      <td><asp:Button  ID="BtnA14" runat="server" Text="" CssClass="cuadros" OnClick="BtnA14_Click" /></td>
      <td><asp:Button  ID="BtnB14" runat="server" Text=""  CssClass="cuadros" OnClick="BtnB14_Click" /></td>
      <td><asp:Button  ID="BtnC14" runat="server" Text=""  CssClass="cuadros" OnClick="BtnC14_Click" /></td>
      <td><asp:Button  ID="BtnD14" runat="server" Text=""  CssClass="cuadros" OnClick="BtnD14_Click" /></td>
      <td><asp:Button  ID="BtnE14" runat="server" Text=""  CssClass="cuadros" OnClick="BtnE14_Click" /></td>
      <td><asp:Button  ID="BtnF14" runat="server" Text="" CssClass="cuadros" OnClick="BtnF14_Click" /></td>
      <td><asp:Button  ID="BtnG14" runat="server" Text=""  CssClass="cuadros" OnClick="BtnG14_Click" /></td>
      <td><asp:Button  ID="BtnH14" runat="server" Text=""  CssClass="cuadros" OnClick="BtnH14_Click" /></td>
      <td><asp:Button  ID="BtnI14" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI14_Click" /></td>
      <td><asp:Button  ID="BtnJ14" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ14_Click" /></td>
      <td><asp:Button  ID="BtnK14" runat="server" Text="" CssClass="cuadros" OnClick="BtnK14_Click" /></td>
      <td><asp:Button  ID="BtnL14" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL14_Click" /></td>
      <td><asp:Button  ID="BtnM14" runat="server" Text="" CssClass="cuadros" OnClick="BtnM14_Click" /></td>
      <td><asp:Button  ID="BtnN14" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN14_Click" /></td>
      <td><asp:Button  ID="BtnÑ14" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ14_Click" /></td>
      <td><asp:Button  ID="BtnO14" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO14_Click" /></td>
      <td><asp:Button  ID="BtnP14" runat="server" Text="" CssClass="cuadros" OnClick="BtnP14_Click" /></td>
      <td><asp:Button  ID="BtnQ14" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ14_Click" /></td>
      <td><asp:Button  ID="BtnR14" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR14_Click" /></td>
      <td><asp:Button  ID="BtnS14" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS14_Click" /></td>
      <td><asp:Label ID="LabelD14" runat="server" Text="14"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="LabelI15" runat="server" Text="15 "></asp:Label></td>
      <td><asp:Button  ID="BtnA15" runat="server" Text="" CssClass="cuadros" OnClick="BtnA15_Click" /></td>
      <td><asp:Button  ID="BtnB15" runat="server" Text=""  CssClass="cuadros" OnClick="BtnB15_Click" /></td>
      <td><asp:Button  ID="BtnC15" runat="server" Text=""  CssClass="cuadros" OnClick="BtnC15_Click" /></td>
      <td><asp:Button  ID="BtnD15" runat="server" Text=""  CssClass="cuadros" OnClick="BtnD15_Click" /></td>
      <td><asp:Button  ID="BtnE15" runat="server" Text=""  CssClass="cuadros" OnClick="BtnE15_Click" /></td>
      <td><asp:Button  ID="BtnF15" runat="server" Text="" CssClass="cuadros" OnClick="BtnF15_Click" /></td>
      <td><asp:Button  ID="BtnG15" runat="server" Text=""  CssClass="cuadros" OnClick="BtnG15_Click" /></td>
      <td><asp:Button  ID="BtnH15" runat="server" Text=""  CssClass="cuadros" OnClick="BtnH15_Click" /></td>
      <td><asp:Button  ID="BtnI15" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI15_Click" /></td>
      <td><asp:Button  ID="BtnJ15" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ15_Click" /></td>
      <td><asp:Button  ID="BtnK15" runat="server" Text="" CssClass="cuadros" OnClick="BtnK15_Click" /></td>
      <td><asp:Button  ID="BtnL15" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL15_Click" /></td>
      <td><asp:Button  ID="BtnM15" runat="server" Text="" CssClass="cuadros" OnClick="BtnM15_Click" /></td>
      <td><asp:Button  ID="BtnN15" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN15_Click" /></td>
      <td><asp:Button  ID="BtnÑ15" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ15_Click" /></td>
      <td><asp:Button  ID="BtnO15" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO15_Click" /></td>
      <td><asp:Button  ID="BtnP15" runat="server" Text="" CssClass="cuadros" OnClick="BtnP15_Click" /></td>
      <td><asp:Button  ID="BtnQ15" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ15_Click" /></td>
      <td><asp:Button  ID="BtnR15" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR15_Click" /></td>
      <td><asp:Button  ID="BtnS15" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS15_Click" /></td>
      <td><asp:Label ID="LabelD15" runat="server" Text="15"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="LabelI16" runat="server" Text="16 "></asp:Label></td>
      <td><asp:Button  ID="BtnA16" runat="server" Text="" CssClass="cuadros" OnClick="BtnA16_Click" /></td>
      <td><asp:Button  ID="BtnB16" runat="server" Text=""  CssClass="cuadros" OnClick="BtnB16_Click" /></td>
      <td><asp:Button  ID="BtnC16" runat="server" Text=""  CssClass="cuadros" OnClick="BtnC16_Click" /></td>
      <td><asp:Button  ID="BtnD16" runat="server" Text=""  CssClass="cuadros" OnClick="BtnD16_Click" /></td>
      <td><asp:Button  ID="BtnE16" runat="server" Text=""  CssClass="cuadros" OnClick="BtnE16_Click" /></td>
      <td><asp:Button  ID="BtnF16" runat="server" Text="" CssClass="cuadros" OnClick="BtnF16_Click" /></td>
      <td><asp:Button  ID="BtnG16" runat="server" Text=""  CssClass="cuadros" OnClick="BtnG16_Click" /></td>
      <td><asp:Button  ID="BtnH16" runat="server" Text=""  CssClass="cuadros" OnClick="BtnH16_Click" /></td>
      <td><asp:Button  ID="BtnI16" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI16_Click" /></td>
      <td><asp:Button  ID="BtnJ16" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ16_Click" /></td>
      <td><asp:Button  ID="BtnK16" runat="server" Text="" CssClass="cuadros" OnClick="BtnK16_Click" /></td>
      <td><asp:Button  ID="BtnL16" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL16_Click" /></td>
      <td><asp:Button  ID="BtnM16" runat="server" Text="" CssClass="cuadros" OnClick="BtnM16_Click" /></td>
      <td><asp:Button  ID="BtnN16" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN16_Click" /></td>
      <td><asp:Button  ID="BtnÑ16" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ16_Click" /></td>
      <td><asp:Button  ID="BtnO16" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO16_Click" /></td>
      <td><asp:Button  ID="BtnP16" runat="server" Text="" CssClass="cuadros" OnClick="BtnP16_Click" /></td>
      <td><asp:Button  ID="BtnQ16" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ16_Click" /></td>
      <td><asp:Button  ID="BtnR16" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR16_Click" /></td>
      <td><asp:Button  ID="BtnS16" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS16_Click" /></td>
      <td><asp:Label ID="LabelD16" runat="server" Text="16"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="LabelI17" runat="server" Text="17 "></asp:Label></td>
      <td><asp:Button  ID="BtnA17" runat="server" Text="" CssClass="cuadros" OnClick="BtnA17_Click" /></td>
      <td><asp:Button  ID="BtnB17" runat="server" Text=""  CssClass="cuadros" OnClick="BtnB17_Click" /></td>
      <td><asp:Button  ID="BtnC17" runat="server" Text=""  CssClass="cuadros" OnClick="BtnC17_Click" /></td>
      <td><asp:Button  ID="BtnD17" runat="server" Text=""  CssClass="cuadros" OnClick="BtnD17_Click" /></td>
      <td><asp:Button  ID="BtnE17" runat="server" Text=""  CssClass="cuadros" OnClick="BtnE17_Click" /></td>
      <td><asp:Button  ID="BtnF17" runat="server" Text="" CssClass="cuadros" OnClick="BtnF17_Click" /></td>
      <td><asp:Button  ID="BtnG17" runat="server" Text=""  CssClass="cuadros" OnClick="BtnG17_Click" /></td>
      <td><asp:Button  ID="BtnH17" runat="server" Text=""  CssClass="cuadros" OnClick="BtnH17_Click" /></td>
      <td><asp:Button  ID="BtnI17" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI17_Click" /></td>
      <td><asp:Button  ID="BtnJ17" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ17_Click" /></td>
      <td><asp:Button  ID="BtnK17" runat="server" Text="" CssClass="cuadros" OnClick="BtnK17_Click" /></td>
      <td><asp:Button  ID="BtnL17" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL17_Click" /></td>
      <td><asp:Button  ID="BtnM17" runat="server" Text="" CssClass="cuadros" OnClick="BtnM17_Click" /></td>
      <td><asp:Button  ID="BtnN17" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN17_Click" /></td>
      <td><asp:Button  ID="BtnÑ17" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ17_Click" /></td>
      <td><asp:Button  ID="BtnO17" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO17_Click" /></td>
      <td><asp:Button  ID="BtnP17" runat="server" Text="" CssClass="cuadros" OnClick="BtnP17_Click" /></td>
      <td><asp:Button  ID="BtnQ17" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ17_Click" /></td>
      <td><asp:Button  ID="BtnR17" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR17_Click" /></td>
      <td><asp:Button  ID="BtnS17" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS17_Click" /></td>
      <td><asp:Label ID="LabelD17" runat="server" Text="17"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="LabelI18" runat="server" Text="18 "></asp:Label></td>
      <td><asp:Button  ID="BtnA18" runat="server" Text="" CssClass="cuadros" OnClick="BtnA18_Click" /></td>
      <td><asp:Button  ID="BtnB18" runat="server" Text=""  CssClass="cuadros" OnClick="BtnB18_Click" /></td>
      <td><asp:Button  ID="BtnC18" runat="server" Text=""  CssClass="cuadros" OnClick="BtnC18_Click" /></td>
      <td><asp:Button  ID="BtnD18" runat="server" Text=""  CssClass="cuadros" OnClick="BtnD18_Click" /></td>
      <td><asp:Button  ID="BtnE18" runat="server" Text=""  CssClass="cuadros" OnClick="BtnE18_Click" /></td>
      <td><asp:Button  ID="BtnF18" runat="server" Text="" CssClass="cuadros" OnClick="BtnF18_Click" /></td>
      <td><asp:Button  ID="BtnG18" runat="server" Text=""  CssClass="cuadros" OnClick="BtnG18_Click" /></td>
      <td><asp:Button  ID="BtnH18" runat="server" Text=""  CssClass="cuadros" OnClick="BtnH18_Click" /></td>
      <td><asp:Button  ID="BtnI18" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI18_Click" /></td>
      <td><asp:Button  ID="BtnJ18" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ18_Click" /></td>
      <td><asp:Button  ID="BtnK18" runat="server" Text="" CssClass="cuadros" OnClick="BtnK18_Click" /></td>
      <td><asp:Button  ID="BtnL18" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL18_Click" /></td>
      <td><asp:Button  ID="BtnM18" runat="server" Text="" CssClass="cuadros" OnClick="BtnM18_Click" /></td>
      <td><asp:Button  ID="BtnN18" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN18_Click" /></td>
      <td><asp:Button  ID="BtnÑ18" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ18_Click" /></td>
      <td><asp:Button  ID="BtnO18" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO18_Click" /></td>
      <td><asp:Button  ID="BtnP18" runat="server" Text="" CssClass="cuadros" OnClick="BtnP18_Click" /></td>
      <td><asp:Button  ID="BtnQ18" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ18_Click" /></td>
      <td><asp:Button  ID="BtnR18" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR18_Click" /></td>
      <td><asp:Button  ID="BtnS18" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS18_Click" /></td>
      <td><asp:Label ID="LabelD18" runat="server" Text="18"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="LabelI19" runat="server" Text="19 "></asp:Label></td>
      <td><asp:Button  ID="BtnA19" runat="server" Text="" CssClass="cuadros" OnClick="BtnA19_Click" /></td>
      <td><asp:Button  ID="BtnB19" runat="server" Text=""  CssClass="cuadros" OnClick="BtnB19_Click" /></td>
      <td><asp:Button  ID="BtnC19" runat="server" Text=""  CssClass="cuadros" OnClick="BtnC19_Click" /></td>
      <td><asp:Button  ID="BtnD19" runat="server" Text=""  CssClass="cuadros" OnClick="BtnD19_Click" /></td>
      <td><asp:Button  ID="BtnE19" runat="server" Text=""  CssClass="cuadros" OnClick="BtnE19_Click" /></td>
      <td><asp:Button  ID="BtnF19" runat="server" Text="" CssClass="cuadros" OnClick="BtnF19_Click" /></td>
      <td><asp:Button  ID="BtnG19" runat="server" Text=""  CssClass="cuadros" OnClick="BtnG19_Click" /></td>
      <td><asp:Button  ID="BtnH19" runat="server" Text=""  CssClass="cuadros" OnClick="BtnH19_Click" /></td>
      <td><asp:Button  ID="BtnI19" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI19_Click" /></td>
      <td><asp:Button  ID="BtnJ19" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ19_Click" /></td>
      <td><asp:Button  ID="BtnK19" runat="server" Text="" CssClass="cuadros" OnClick="BtnK19_Click" /></td>
      <td><asp:Button  ID="BtnL19" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL19_Click" /></td>
      <td><asp:Button  ID="BtnM19" runat="server" Text="" CssClass="cuadros" OnClick="BtnM19_Click" /></td>
      <td><asp:Button  ID="BtnN19" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN19_Click" /></td>
      <td><asp:Button  ID="BtnÑ19" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ19_Click" /></td>
      <td><asp:Button  ID="BtnO19" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO19_Click" /></td>
      <td><asp:Button  ID="BtnP19" runat="server" Text="" CssClass="cuadros" OnClick="BtnP19_Click" /></td>
      <td><asp:Button  ID="BtnQ19" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ19_Click" /></td>
      <td><asp:Button  ID="BtnR19" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR19_Click" /></td>
      <td><asp:Button  ID="BtnS19" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS19_Click" /></td>
      <td><asp:Label ID="LabelD19" runat="server" Text="19"></asp:Label></td>

  </tr>
 <tr>

     <td><asp:Label ID="LabelI20" runat="server" Text="20 "></asp:Label></td>
      <td><asp:Button  ID="BtnA20" runat="server" Text="" CssClass="cuadros" OnClick="BtnA20_Click" /></td>
      <td><asp:Button  ID="BtnB20" runat="server" Text=""  CssClass="cuadros" OnClick="BtnB20_Click" /></td>
      <td><asp:Button  ID="BtnC20" runat="server" Text=""  CssClass="cuadros" OnClick="BtnC20_Click" /></td>
      <td><asp:Button  ID="BtnD20" runat="server" Text=""  CssClass="cuadros" OnClick="BtnD20_Click" /></td>
      <td><asp:Button  ID="BtnE20" runat="server" Text=""  CssClass="cuadros" OnClick="BtnE20_Click" /></td>
      <td><asp:Button  ID="BtnF20" runat="server" Text="" CssClass="cuadros" OnClick="BtnF20_Click" /></td>
      <td><asp:Button  ID="BtnG20" runat="server" Text=""  CssClass="cuadros" OnClick="BtnG20_Click" /></td>
      <td><asp:Button  ID="BtnH20" runat="server" Text=""  CssClass="cuadros" OnClick="BtnH20_Click" /></td>
      <td><asp:Button  ID="BtnI20" runat="server" Text=""  CssClass="cuadros" OnClick="BtnI20_Click" /></td>
      <td><asp:Button  ID="BtnJ20" runat="server" Text="" CssClass="cuadros" OnClick="BtnJ20_Click" /></td>
      <td><asp:Button  ID="BtnK20" runat="server" Text="" CssClass="cuadros" OnClick="BtnK20_Click" /></td>
      <td><asp:Button  ID="BtnL20" runat="server" Text=""  CssClass="cuadros" OnClick="BtnL20_Click" /></td>
      <td><asp:Button  ID="BtnM20" runat="server" Text="" CssClass="cuadros" OnClick="BtnM20_Click" /></td>
      <td><asp:Button  ID="BtnN20" runat="server" Text=""  CssClass="cuadros" OnClick="BtnN20_Click" /></td>
      <td><asp:Button  ID="BtnÑ20" runat="server" Text=""  CssClass="cuadros" OnClick="BtnÑ20_Click" /></td>
      <td><asp:Button  ID="BtnO20" runat="server" Text=""  CssClass="cuadros" OnClick="BtnO20_Click" /></td>
      <td><asp:Button  ID="BtnP20" runat="server" Text="" CssClass="cuadros" OnClick="BtnP20_Click" /></td>
      <td><asp:Button  ID="BtnQ20" runat="server" Text=""  CssClass="cuadros" OnClick="BtnQ20_Click" /></td>
      <td><asp:Button  ID="BtnR20" runat="server" Text=""  CssClass="cuadros" OnClick="BtnR20_Click" /></td>
      <td><asp:Button  ID="BtnS20" runat="server" Text=""  CssClass="cuadros" OnClick="BtnS20_Click" /></td>
      <td><asp:Label ID="LabelD20" runat="server" Text="20"></asp:Label></td>

  </tr>
   <tr>

       <td><asp:Label ID="Label27" runat="server" Text=" "></asp:Label></td>
       <td><asp:Label ID="LabelAI" runat="server" Text="A"></asp:Label></td>
       <td><asp:Label ID="LabelBI" runat="server" Text="B"></asp:Label></td>
       <td><asp:Label ID="LabelCI" runat="server" Text="C"></asp:Label></td>
       <td><asp:Label ID="LabelDI" runat="server" Text="D"></asp:Label></td>
       <td><asp:Label ID="LabelEI" runat="server" Text="E"></asp:Label></td>
       <td><asp:Label ID="LabelFI" runat="server" Text="F"></asp:Label></td>
       <td><asp:Label ID="LabelGI" runat="server" Text="G"></asp:Label></td>
       <td><asp:Label ID="LabelHI" runat="server" Text="H"></asp:Label></td>
        <td><asp:Label ID="LabelII" runat="server" Text="I"></asp:Label></td>
        <td><asp:Label ID="LabelJI" runat="server" Text="J"></asp:Label></td>
        <td><asp:Label ID="LabelKI" runat="server" Text="K"></asp:Label></td>
        <td><asp:Label ID="LabelLI" runat="server" Text="L"></asp:Label></td>
        <td><asp:Label ID="LabelMI" runat="server" Text="M"></asp:Label></td>
        <td><asp:Label ID="LabelNI" runat="server" Text="N"></asp:Label></td>
        <td><asp:Label ID="LabelÑI" runat="server" Text="Ñ"></asp:Label></td>
        <td><asp:Label ID="LabelOI" runat="server" Text="O"></asp:Label></td>
        <td><asp:Label ID="LabelPI" runat="server" Text="P"></asp:Label></td>
        <td><asp:Label ID="LabelQI" runat="server" Text="Q"></asp:Label></td>
        <td><asp:Label ID="LabelRI" runat="server" Text="R"></asp:Label></td>
        <td><asp:Label ID="LabelSI" runat="server" Text="S"></asp:Label></td>
       <td><asp:Label ID="Label36" runat="server" Text=" "></asp:Label></td>
      
    

  </tr>

</table>
               

             </section>
        </div>
    </form>
</body>
</html>
