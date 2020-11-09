<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grafica.aspx.cs" Inherits="PROYECTO1.Grafica" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="Styles/estiloGrafica.css" rel="stylesheet" type="text/css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button CssClass="btnRegresar" ID="ButtonRegresar" runat="server" Text="Regresar" OnClick="ButtonRegresar_Click" />
            <table class="tabla-grafica">

  <tr>

    <td><asp:Label Width="150px" CssClass="grafica" ID="A8LabelEquipo1" runat="server" Text="Equipo 1"></asp:Label> </td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td><asp:Label Width="150px" CssClass="grafica" ID="B8LabelEquipo1" runat="server" Text="Equipo 1"></asp:Label> </td>

  </tr>
  <tr>

    <td></td>
    <td><asp:Label Width="150px" CssClass="grafica" ID="A4LabelEquipo1" runat="server" Text="Equipo 1"></asp:Label></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td><asp:Label Width="150px" CssClass="grafica" ID="B4LabelEquipo1" runat="server" Text="Equipo 1"></asp:Label></td>
    <td></td>

  </tr>
  <tr>

    <td><asp:Label Width="150px" CssClass="grafica" ID="A8LabelEquipo2" runat="server" Text="Equipo 2"></asp:Label> </td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td><asp:Label Width="150px" CssClass="grafica" ID="B8LabelEquipo2" runat="server" Text="Equipo 2"></asp:Label></td>

  </tr>
  <tr>

    <td></td>
    <td></td>
    <td><asp:Label Width="150px" CssClass="grafica" ID="A2LabelEquipo1" runat="server" Text="Equipo 1"></asp:Label> </td>
    <td></td>
    <td></td>
    <td></td>
    <td><asp:Label Width="150px" CssClass="grafica" ID="B2LabelEquipo1" runat="server" Text="Equipo 1"></asp:Label> </td>
    <td></td>
    <td></td>

  </tr>
  <tr>

    <td> <asp:Label Width="150px" CssClass="grafica" ID="A8LabelEquipo3" runat="server" Text="Equipo 3"></asp:Label></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="B8LabelEquipo3" runat="server" Text="Equipo 3"></asp:Label></td>

  </tr>
  <tr>

    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="A4LabelEquipo2" runat="server" Text="Equipo 2"></asp:Label></td>
    <td></td>
    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="LabelGanador" runat="server" Text="Ganador"></asp:Label></td>
    <td></td>
    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="B4LabelEquipo2" runat="server" Text="Equipo 2"></asp:Label></td>
    <td></td>

  </tr>
  <tr>

    <td> <asp:Label Width="150px" CssClass="grafica" ID="A8LabelEquipo4" runat="server" Text="Equipo 4"></asp:Label></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="B8LabelEquipo4" runat="server" Text="Equipo 4"></asp:Label></td>

  </tr>
  <tr>

    <td></td>
    <td></td>
    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="A1LabelEquipo1" runat="server" Text="Equipo 1"></asp:Label></td>
    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="B1LabelEquipo1" runat="server" Text="Equipo 1"></asp:Label></td>
    <td></td>
    <td></td>
    <td></td>

  </tr>
  <tr>

    <td> <asp:Label Width="150px" CssClass="grafica" ID="A8LabelEquipo5" runat="server" Text="Equipo 5"></asp:Label></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="B8LabelEquipo5" runat="server" Text="Equipo 5"></asp:Label></td>

  </tr>
  <tr>

    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="A4LabelEquipo3" runat="server" Text="Equipo 3"></asp:Label></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="B4LabelEquipo3" runat="server" Text="Equipo 3"></asp:Label></td>
    <td></td>

  </tr>
  <tr>

    <td> <asp:Label Width="150px" CssClass="grafica" ID="A8LabelEquipo6" runat="server" Text="Equipo 6"></asp:Label></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="B8LabelEquipo6" runat="server" Text="Equipo 6"></asp:Label></td>

  </tr>
  <tr>

    <td></td>
    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="A2LabelEquipo2" runat="server" Text="Equipo 2"></asp:Label></td>
    <td></td>
    <td></td>
    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="B2LabelEquipo2" runat="server" Text="Equipo 2"></asp:Label></td>
    <td></td>
    <td></td>

  </tr>
  <tr>

    <td> <asp:Label Width="150px" CssClass="grafica" ID="A8LabelEquipo7" runat="server" Text="Equipo 7"></asp:Label></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="B8LabelEquipo7" runat="server" Text="Equipo 7"></asp:Label></td>

  </tr>
  <tr>

    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="A4LabelEquipo4" runat="server" Text="Equipo 4"></asp:Label></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="B4LabelEquipo4" runat="server" Text="Equipo 4"></asp:Label></td>
    <td></td>

  </tr>
  <tr>

    <td> <asp:Label Width="150px" CssClass="grafica" ID="A8LabelEquipo8" runat="server" Text="Equipo 8"></asp:Label></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td> <asp:Label Width="150px" CssClass="grafica" ID="B8LabelEquipo8" runat="server" Text="Equipo 8"></asp:Label></td>

  </tr>

 
</table>

        </div>
    </form>
</body>
</html>
