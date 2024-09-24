<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="Login.cadastro" %>

<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500&display=swap" rel="stylesheet" />
    <link href="cadastroo.css" rel="stylesheet" runat="server" />
    <link rel="icon" type="image/png" href="img\logob.png"/>
    <title>Cadastrar-se</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cadastrar">
            <img src="img\Login.png" />
            <div class="esq">
            </div>
            <div class="dir">
                <h1>Cadastre-se</h1>
                <div class="group">
                    <asp:TextBox ID="txtNome" runat="server" required="required" />
                    <span class="highlight"></span>
                    <span class="bar"></span>
                    <label>Nome</label>
                </div>
                <div class="group">
                    <asp:TextBox ID="txtCPF" runat="server" required="required" />
                    <span class="highlight"></span>
                    <span class="bar"></span>
                    <label>CPF</label>
                </div>
                <div class="group">
                    <asp:TextBox ID="txtTelefone" runat="server" required="required" />
                    <span class="highlight"></span>
                    <span class="bar"></span>
                    <label>Telefone</label>
                </div>
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
                <asp:Button ID="concluir" runat="server" Text="Concluir" CssClass="concluir" OnClick="entrar_Click" />
                <asp:Label ID="Label1" runat="server" Text="" CssClass ="lblcadastro"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>