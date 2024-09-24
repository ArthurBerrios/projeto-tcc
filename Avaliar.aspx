<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Avaliar.aspx.cs" Inherits="Login.Avaliar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button runat="server" Text="" ID="btnEstrela1" OnClick="btnEstrela1_Click"></asp:Button><asp:Button runat="server" Text="" ID="btnEstrela2" OnClick="btnEstrela2_Click"></asp:Button><asp:Button runat="server" Text="" id="btnEstrela3" OnClick="btnEstrela3_Click"></asp:Button><asp:Button runat="server" ID="btnEstrela4" Text="" OnClick="btnEstrela4_Click"></asp:Button><asp:Button runat="server" ID ="btnEstrela5" Text="" OnClick="btnEstrela5_Click"></asp:Button><br />
            <asp:TextBox ID="txtComentario" runat="server" Height="156px" MaxLength="255" Width="674px"></asp:TextBox><br />
            <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" /><br />
        <asp:Label ID="lblresultado" runat="server" Text=""></asp:Label>
        </div>
        
    </form>
</body>
</html>
