<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="./loginn.css" rel="stylesheet" runat="server"/>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500&display=swap" rel="stylesheet" />
    <link rel="icon" type="image/png" href="img\logob.png"/ >
    <title>Login</title>

</head>

<body>  
    <form id="form1" runat="server">
        <div class="login">
           <asp:Image ID="img" runat="server" ImageUrl="img\Login.png" CssClass ="imglogin"/>

            <div class="esq">
            </div>
            <div class="dir">
                <h1>Login</h1>
                <div class="group">
                    <asp:TextBox ID="txtEmail" runat="server" required="required" />
                    <span class="highlight"></span>
                    <span class="bar"></span>
                    <label>Email</label>
                </div>
                <div class="group">
                    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" required="required" />
                    <span class="highlight"></span>
                    <span class="bar"></span>
                    <label>Senha</label>
                </div>
                <div>
                  
                <asp:Button ID="entrar" runat="server" Text="Entrar" CssClass="entrar" OnClick="entrar_Click" /> 
                <asp:LinkButton ID="LinkButton1" CssClass="cadastrar" runat="server" Text="Cadastrar" OnClick="cadastrar_Click"></asp:LinkButton>
                </div>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html> 