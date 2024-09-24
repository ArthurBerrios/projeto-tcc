<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterarNome.aspx.cs" Inherits="Login.AlterarNome" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>


        </div>
        <asp:Label ID="Label1" runat="server" Text="Digite seu novo nome:"></asp:Label><br />
        <asp:TextBox ID="txtNome" runat="server" ></asp:TextBox><br /><br />

        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        &nbsp;
        <asp:Button ID="Salvar" runat="server" Text="Salvar" OnClick="Salvar_Click" />
    </form>
</body>
</html>
