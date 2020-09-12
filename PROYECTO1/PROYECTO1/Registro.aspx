<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PROYECTO1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <section class="form-inicio">
      
         <asp:Label ID="Label1" class="datos" runat="server" Text="Label">Nombres</asp:Label>
         <asp:TextBox ID="TextBoxNombres"  class="controles"  runat="server"></asp:TextBox>

         <asp:Label ID="Label2" class="datos" runat="server" Text="Label">Apellidos</asp:Label>
         <asp:TextBox ID="TextBoxApellidos"  class="controles" runat="server"></asp:TextBox>

         <asp:Label ID="Label3" class="datos" runat="server" Text="Label">Nombre de usuario</asp:Label>
         <asp:TextBox ID="TextBoxNombreUsuario"  class="controles" runat="server"></asp:TextBox>

         <asp:Label ID="Label4" class="datos"  runat="server" Text="Label">Contraseña</asp:Label>
         <asp:TextBox ID="TextBoxContraseña"   type="password" class="controles" runat="server"></asp:TextBox>

         <asp:Label ID="Label5" class="datos" runat="server" Text="Label">Fecha de Nacimiento</asp:Label>
         <asp:DropDownList ID="DropDownListAño"  class="controles" runat="server">

              <asp:listitem text="Año" ></asp:listitem>
             <asp:listitem text="2020" ></asp:listitem>
             <asp:listitem text="2019" ></asp:listitem>
             <asp:listitem text="2018" ></asp:listitem>
             <asp:listitem text="2017"></asp:listitem>
             <asp:listitem text="2016" ></asp:listitem>
             <asp:listitem text="2015" ></asp:listitem>
             <asp:listitem text="2014" ></asp:listitem>
             <asp:listitem text="2013" ></asp:listitem>
             <asp:listitem text="2012" ></asp:listitem>
             <asp:listitem text="2011" ></asp:listitem>
             <asp:listitem text="2010" ></asp:listitem>
             <asp:listitem text="2009"></asp:listitem>
             <asp:listitem text="2008" ></asp:listitem>
             <asp:listitem text="2007" ></asp:listitem>
             <asp:listitem text="2006" ></asp:listitem>
             <asp:listitem text="2005"></asp:listitem>
             <asp:listitem text="2004" ></asp:listitem>
             <asp:listitem text="2003" ></asp:listitem>
             <asp:listitem text="2002" ></asp:listitem>
             <asp:listitem text="2001" ></asp:listitem>
             <asp:listitem text="2000" ></asp:listitem>
             <asp:listitem text="1999" ></asp:listitem>
             <asp:listitem text="1998" ></asp:listitem>
             <asp:listitem text="1997"></asp:listitem>
             <asp:listitem text="1996" ></asp:listitem>
             <asp:listitem text="1995" ></asp:listitem>
             <asp:listitem text="1994" ></asp:listitem>
             <asp:listitem text="1993"></asp:listitem>
             <asp:listitem text="1992" ></asp:listitem>
             <asp:listitem text="1991" ></asp:listitem>
             <asp:listitem text="1990" ></asp:listitem>
         </asp:DropDownList>
         
       

         <asp:DropDownList ID="DropDownListMes"  class="controles" runat="server">
             <asp:listitem text="Mes" ></asp:listitem>
             <asp:listitem text="Enero" value="1"></asp:listitem>
             <asp:listitem text="Febrero" value="2"></asp:listitem>
             <asp:listitem text="Marzo" value="3"></asp:listitem>
             <asp:listitem text="Abril" value="4"></asp:listitem>
             <asp:listitem text="Mayo" value="5"></asp:listitem>
             <asp:listitem text="Junio" value="6"></asp:listitem>
             <asp:listitem text="Julio" value="7"></asp:listitem>
             <asp:listitem text="Agosto" value="8"></asp:listitem>
             <asp:listitem text="Septiembre" value="9"></asp:listitem>
             <asp:listitem text="Octubre" value="10"></asp:listitem>
             <asp:listitem text="Noviembre" value="11"></asp:listitem>
             <asp:listitem text="Diciembre" value="12"></asp:listitem>
         </asp:DropDownList>
         
         <asp:DropDownList ID="DropDownListDia" class="controles" runat="server">

             <asp:listitem text="Día" ></asp:listitem>
             <asp:listitem text="1" ></asp:listitem>
             <asp:listitem text="2" ></asp:listitem>
             <asp:listitem text="3" ></asp:listitem>
             <asp:listitem text="4"></asp:listitem>
             <asp:listitem text="5" ></asp:listitem>
             <asp:listitem text="6" ></asp:listitem>
             <asp:listitem text="7" ></asp:listitem>
             <asp:listitem text="8" ></asp:listitem>
             <asp:listitem text="9" ></asp:listitem>
             <asp:listitem text="10" ></asp:listitem>
             <asp:listitem text="11" ></asp:listitem>
             <asp:listitem text="12"></asp:listitem>
             <asp:listitem text="13" ></asp:listitem>
             <asp:listitem text="14" ></asp:listitem>
             <asp:listitem text="15" ></asp:listitem>
             <asp:listitem text="16"></asp:listitem>
             <asp:listitem text="17" ></asp:listitem>
             <asp:listitem text="18" ></asp:listitem>
             <asp:listitem text="19" ></asp:listitem>
             <asp:listitem text="20" ></asp:listitem>
             <asp:listitem text="21" ></asp:listitem>
             <asp:listitem text="22" ></asp:listitem>
             <asp:listitem text="23" ></asp:listitem>
             <asp:listitem text="24"></asp:listitem>
             <asp:listitem text="25" ></asp:listitem>
             <asp:listitem text="26" ></asp:listitem>
             <asp:listitem text="27" ></asp:listitem>
             <asp:listitem text="28"></asp:listitem>
             <asp:listitem text="29" ></asp:listitem>
             <asp:listitem text="30" ></asp:listitem>
             <asp:listitem text="31" ></asp:listitem>
            
         </asp:DropDownList>

         <asp:Label ID="Label6" class="datos" runat="server" Text="Label">Pais</asp:Label>
         <asp:TextBox ID="TextBoxPais"  class="controles" runat="server"></asp:TextBox>

         <asp:Label ID="Label7" class="datos" runat="server" Text="Label">Correo electrónico</asp:Label>
         <asp:TextBox ID="TextBoxCorreo"  class="controles" runat="server"></asp:TextBox>

         <asp:Button ID="ButtonRegistrarse" runat="server" CssClass="botones" Text="Registrarse" OnClick="ButtonRegistrarse_Click" />
    </section>
</asp:Content>
