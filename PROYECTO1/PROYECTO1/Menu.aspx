<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="PROYECTO1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="Styles/estiloTabla.css" rel="stylesheet" type="text/css">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div >
           <section class="form-boton">
               <asp:FileUpload  ID="FileUpload1" runat="server" />
             <asp:Button Cssclass="bot" ID="ButtonCarga" runat="server" Text="Cargar" OnClick="ButtonCarga_Click1" />
              <asp:Button Cssclass="bot" ID="ButtonDescarga" runat="server" Text="Descargar" />
              <asp:Button Cssclass="bot" ID="ButtonSalir" runat="server"  href="~/Default" Text="Salir" OnClick="ButtonSalir_Click" />
           </section>
                
           
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
      <td><asp:Button class="cuadros" ID="BtnB1" runat="server" Text="" OnClick="BtnB1_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnC1" runat="server" Text="" OnClick="BtnC1_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnD1" runat="server" Text="" OnClick="BtnD1_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnE1" runat="server" Text="" OnClick="BtnE1_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnF1" runat="server" Text="" OnClick="BtnF1_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnG1" runat="server" Text="" OnClick="BtnG1_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnH1" runat="server" Text="" OnClick="BtnH1_Click" /></td>
      <td><asp:Label ID="Label12" runat="server" Text="1"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="Label13" runat="server" Text="2 "></asp:Label></td>
      <td><asp:Button class="cuadros" ID="BtnA2" runat="server" Text="" OnClick="BtnA2_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnB2" runat="server" Text="" OnClick="BtnB2_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnC2" runat="server" Text="" OnClick="BtnC2_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnD2" runat="server" Text="" OnClick="BtnD2_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnE2" runat="server" Text="" OnClick="BtnE2_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnF2" runat="server" Text="" OnClick="BtnF2_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnG2" runat="server" Text="" OnClick="BtnG2_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnH2" runat="server" Text="" OnClick="BtnH2_Click" /></td>
      <td><asp:Label ID="Label14" runat="server" Text="2"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="Label15" runat="server" Text="3 "></asp:Label></td>
      <td><asp:Button class="cuadros" ID="BtnA3" runat="server" Text="" OnClick="BtnA3_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnB3" runat="server" Text="" OnClick="BtnB3_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnC3" runat="server" Text="" OnClick="BtnC3_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnD3" runat="server" Text="" OnClick="BtnD3_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnE3" runat="server" Text="" OnClick="BtnE3_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnF3" runat="server" Text="" OnClick="BtnF3_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnG3" runat="server" Text="" OnClick="BtnG3_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnH3" runat="server" Text="" OnClick="BtnH3_Click" /></td>
      <td><asp:Label ID="Label16" runat="server" Text="3"></asp:Label></td>

  </tr>
     <tr>

    <td><asp:Label ID="Label17" runat="server" Text="4 "></asp:Label></td>
      <td><asp:Button class="cuadros" ID="BtnA4" runat="server" Text="" OnClick="BtnA4_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnB4" runat="server" Text="" OnClick="BtnB4_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnC4" runat="server" Text="" OnClick="BtnC4_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnD4" runat="server" Text="" OnClick="BtnD4_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnE4" runat="server" Text="" OnClick="BtnE4_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnF4" runat="server" Text="" OnClick="BtnF4_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnG4" runat="server" Text="" OnClick="BtnG4_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnH4" runat="server" Text="" OnClick="BtnH4_Click" /></td>
      <td><asp:Label  ID="Label18" runat="server" Text="4"></asp:Label></td>

  </tr>
     <tr>

    <td><asp:Label ID="Label19" runat="server" Text="5 "></asp:Label></td>
      <td><asp:Button class="cuadros" ID="BtnA5" runat="server" Text="" OnClick="BtnA5_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnB5" runat="server" Text="" OnClick="BtnB5_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnC5" runat="server" Text="" OnClick="BtnC5_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnD5" runat="server" Text="" OnClick="BtnD5_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnE5" runat="server" Text="" OnClick="BtnE5_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnF5" runat="server" Text="" OnClick="BtnF5_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnG5" runat="server" Text="" OnClick="BtnG5_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnH5" runat="server" Text="" OnClick="BtnH5_Click" /></td>
      <td><asp:Label ID="Label20" runat="server" Text="5"></asp:Label></td>
  </tr>
     <tr>

    <td><asp:Label ID="Label21" runat="server" Text="6 "></asp:Label></td>
      <td><asp:Button class="cuadros" ID="BtnA6" runat="server" Text="" OnClick="BtnA6_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnB6" runat="server" Text="" OnClick="BtnB6_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnC6" runat="server" Text="" OnClick="BtnC6_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnD6" runat="server" Text="" OnClick="BtnD6_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnE6" runat="server" Text="" OnClick="BtnE6_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnF6" runat="server" Text="" OnClick="BtnF6_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnG6" runat="server" Text="" OnClick="BtnG6_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnH6" runat="server" Text="" OnClick="BtnH6_Click" /></td>
      <td><asp:Label ID="Label22" runat="server" Text="6"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="Label23" runat="server" Text="7 "></asp:Label></td>
      <td><asp:Button class="cuadros" ID="BtnA7" runat="server" Text="" OnClick="BtnA7_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnB7" runat="server" Text="" OnClick="BtnB7_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnC7" runat="server" Text="" OnClick="BtnC7_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnD7" runat="server" Text="" OnClick="BtnD7_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnE7" runat="server" Text="" OnClick="BtnE7_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnF7" runat="server" Text="" OnClick="BtnF7_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnG7" runat="server" Text="" OnClick="BtnG7_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnH7" runat="server" Text="" OnClick="BtnH7_Click" /></td>
      <td><asp:Label ID="Label24" runat="server" Text="7"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="Label25" runat="server" Text="8 "></asp:Label></td>
      <td><asp:Button class="cuadros" ID="BtnA8" runat="server" Text="" OnClick="BtnA8_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnB8" runat="server" Text="" OnClick="BtnB8_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnC8" runat="server" Text="" OnClick="BtnC8_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnD8" runat="server" Text="" OnClick="BtnD8_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnE8" runat="server" Text="" OnClick="BtnE8_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnF8" runat="server" Text="" OnClick="BtnF8_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnG8" runat="server" Text="" OnClick="BtnG8_Click" /></td>
      <td><asp:Button class="cuadros" ID="BtnH8" runat="server" Text="" OnClick="BtnH8_Click" /></td>
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
