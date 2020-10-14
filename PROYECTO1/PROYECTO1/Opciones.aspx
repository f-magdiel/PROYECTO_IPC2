<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Opciones.aspx.cs" Inherits="PROYECTO1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles/estiloMenu.css" rel="stylesheet" type="text/css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <section class="form-menu">
            <asp:Button class="opcion" ID="ButtonMaquina" runat="server" Text="Jugador vs Jugador" OnClick="ButtonMaquina_Click" />
            <asp:Button class= "opcion" ID="ButtonSolitario" runat="server" Text="Contra Máquina" OnClick="ButtonSolitario_Click" />
            <asp:Button class= "opcion" ID="ButtonTorneo" runat="server" Text="Torneo" />
            <asp:Button class =" opcion" ID="ButtonReporte" runat="server" Text="Reporte" />

        </section>
        </div>
    </form>
</body>
</html>
