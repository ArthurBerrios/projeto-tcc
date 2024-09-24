<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreadoCliente.aspx.cs" Inherits="Login.AreadoCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="AreaCliente.css" rel="stylesheet" />
    <script type="text/javascript" src="AreaCliente.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblBemvindo" runat="server" Text=""></asp:Label><br />
            <br />
            <asp:Image ID="imgCliente" runat="server" ImageUrl ="img/imgcliente.png" Width="144px" />
            <asp:FileUpload ID="flpAlterarimg" runat="server" />


           
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />


           
            <br />
            <asp:Label ID="Label1" runat="server" Text="Nome:"></asp:Label><br />
            <asp:Label ID="lblNome" runat="server" Text=""></asp:Label>     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnAlterarN" runat="server" Text="ALTERAR"  OnClick="btnAlterarN_Click"/><br />
            <asp:Label ID="Label3" runat="server" Text="CPF cadastrado:"></asp:Label><br />
            <asp:Label ID="lblcpf" runat="server" Text=""></asp:Label> <br />
            <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label><br />
            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label> <asp:Button ID="btnAlterarEmail" runat="server" Text="ALTERAR" OnClick="btnAlterarEmail_Click" /><br />&nbsp;&nbsp;&nbsp;&nbsp<br />
            <asp:Label ID="Label4" runat="server" Text="Senha:"></asp:Label><br />
            <asp:Label ID="lblSenha" runat="server" Text=""></asp:Label> <asp:Button ID="AlterarSenha" runat="server" Text="ALTERAR" OnClick="AlterarSenha_Click" /><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
            <br /><br /><br /><br />
             <asp:Label ID="Label5" runat="server" Text="Reservas feitas"></asp:Label> 
            <asp:GridView ID="grvReservas" runat="server"  >
               <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="chkCancelar" runat="server"  AutoPostBack="true" />
            </ItemTemplate>
        </asp:TemplateField>
       
    </Columns>
            </asp:GridView>
            <asp:Button runat="server" ID="btnCancelarReserva" Text="Cancelar reserva" OnClick="btnCancelarReserva_Click"></asp:Button>&nbsp;&nbsp; <asp:Button runat="server" Text="Fazer mais reservas" ID="btnMaisReservas" OnClick="btnMaisReservas_Click"></asp:Button>
          










            <br />
            <asp:Button runat="server" Text="Fazer avaliação" ID="btnFazerAvaliacao" OnClick="btnFazerAvaliacao_Click"></asp:Button>
          










        </div>
      



    </form>
</body>
</html>

