<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PROYECTO1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <section class="form-inicio">
      
        <asp:Label ID="Label1" class="datos" runat="server" Text="Label">Nombre Usuario</asp:Label>
        <asp:TextBox ID="TextBoxUsername"  class="controles" runat="server" style="text-align:center"></asp:TextBox>

        <asp:Label ID="Label2" class="datos" runat="server" Text="Label">Contraseña</asp:Label>
        <asp:TextBox ID="TextBoxPass"  type="password" class="controles" runat="server" style="text-align:center"></asp:TextBox>
        <asp:Button ID="ButtonIniciar" CssClass="botones" runat="server" Text="Iniciar Sesión" />

    </section>
   
</asp:Content>
