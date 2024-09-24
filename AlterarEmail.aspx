<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterarEmail.aspx.cs" Inherits="Login.AlterarEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Digite seu novo Email:"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
&nbsp;&nbsp;
            <asp:Button ID="Salvar" runat="server" Text="Salvar" OnClick="Salvar_Click" />
        </div>
    </form>
</body>
</html>
