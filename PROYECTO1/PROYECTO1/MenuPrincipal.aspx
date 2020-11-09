<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="PROYECTO1.WebForm2" %>

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
            <asp:Button class="opcion" ID="ButtonXtream" runat="server" Text="Xtream" OnClick="ButtonXtream_Click" />
            <asp:Button class="opcion" ID="ButtonMaquinaInverso" runat="server" Text="Máquina Inverso" OnClick="ButtonMaquinaInverso_Click" />
            <asp:Button class="opcion" ID="ButtonSolitarioInverso" runat="server" Text="1 vs 1 Inverso" OnClick="ButtonSolitarioInverso_Click" />
            <asp:Button class="opcion" ID="ButtonMaquina" runat="server" Text="1 vs 1 Normal" OnClick="ButtonMaquina_Click" />
            <asp:Button class= "opcion" ID="ButtonSolitario" runat="server" Text="Máquina Normal" OnClick="ButtonSolitario_Click" />
            <asp:Button class= "opcion" ID="ButtonTorneo" runat="server" Text="Torneo" OnClick="ButtonTorneo_Click" />
            <asp:Button class =" opcion" ID="ButtonReporte" runat="server" Text="Grafica" OnClick="ButtonReporte_Click" />

        </section>
        </div>
    </form>
</body>
</html>
