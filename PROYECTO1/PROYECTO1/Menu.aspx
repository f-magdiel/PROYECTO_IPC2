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
              <asp:Button Cssclass="bot" ID="ButtonCarga" runat="server" Text="Cargar" />
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
      <td><asp:Button Cssclass="cuadros" ID="Button2" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button3" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button4" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button5" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button6" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button7" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button8" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button9" runat="server" Text="" /></td>
      <td><asp:Label ID="Label12" runat="server" Text="1"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="Label13" runat="server" Text="2 "></asp:Label></td>
      <td><asp:Button class="cuadros" ID="Button1" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button10" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button11" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button12" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button13" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button14" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button15" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button16" runat="server" Text="" /></td>
      <td><asp:Label ID="Label14" runat="server" Text="2"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="Label15" runat="server" Text="3 "></asp:Label></td>
      <td><asp:Button class="cuadros" ID="Button17" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button18" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button19" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button20" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button21" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button22" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button23" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button24" runat="server" Text="" /></td>
      <td><asp:Label ID="Label16" runat="server" Text="3"></asp:Label></td>

  </tr>
     <tr>

    <td><asp:Label ID="Label17" runat="server" Text="4 "></asp:Label></td>
      <td><asp:Button class="cuadros" ID="Button25" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button26" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button27" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button28" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button29" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button30" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button31" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button32" runat="server" Text="" /></td>
      <td><asp:Label  ID="Label18" runat="server" Text="4"></asp:Label></td>

  </tr>
     <tr>

    <td><asp:Label ID="Label19" runat="server" Text="5 "></asp:Label></td>
      <td><asp:Button class="cuadros" ID="Button33" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button34" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button35" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button36" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button37" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button38" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button39" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button40" runat="server" Text="" /></td>
      <td><asp:Label ID="Label20" runat="server" Text="5"></asp:Label></td>
  </tr>
     <tr>

    <td><asp:Label ID="Label21" runat="server" Text="6 "></asp:Label></td>
      <td><asp:Button class="cuadros" ID="Button41" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button42" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button43" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button44" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button45" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button46" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button47" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button48" runat="server" Text="" /></td>
      <td><asp:Label ID="Label22" runat="server" Text="6"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="Label23" runat="server" Text="7 "></asp:Label></td>
      <td><asp:Button class="cuadros" ID="Button49" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button50" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button51" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button52" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button53" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button54" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button55" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button56" runat="server" Text="" /></td>
      <td><asp:Label ID="Label24" runat="server" Text="7"></asp:Label></td>

  </tr>
     <tr>

     <td><asp:Label ID="Label25" runat="server" Text="8 "></asp:Label></td>
      <td><asp:Button class="cuadros" ID="Button57" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button58" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button59" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button60" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button61" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button62" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button63" runat="server" Text="" /></td>
      <td><asp:Button class="cuadros" ID="Button64" runat="server" Text="" /></td>
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
