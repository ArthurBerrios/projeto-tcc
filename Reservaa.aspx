<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservaa.aspx.cs" Inherits="Login.Reservaa" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Fazer reserva</title>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100&display=swap" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500&display=swap" rel="stylesheet" />
    <link href="./reservas.css" rel="stylesheet" />
    <link rel="icon" type="image/png" href="img\logob.png" />
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;&nbsp;&nbsp;
        <nav class="navbar">
            <asp:Image ID="logobImage" runat="server" ImageUrl="img\logob.png" CssClass="logob" />
            <a class="logo" id="logo" href="paginainicial.html">Hot Rolls Club</a>
        </nav>
        <div class="maior">
            <div class="esquerda">
                <p class="andar">1º andar</p>
               <nav class ="mesa">
                   <asp:ImageButton ID="mesa1Button" CssClass ="mesa1" runat="server" ImageUrl ="img/mesa1.png" OnClick="mesa1Button_Click"  Enabled ="false"/>
                     <asp:ImageButton ID="mesa2Button" CssClass ="mesa2" runat="server" ImageUrl ="img/mesa2.png" OnClick="mesa2Button_Click" />
                        <asp:ImageButton ID="mesa3Button" CssClass ="mesa3" runat="server" ImageUrl ="img/mesa3.png" OnClick="mesa3Button_Click" />
                    
                    <br /><br />
                     <asp:ImageButton ID="mesa4Button" CssClass ="mesa4" runat="server" ImageUrl ="img/mesa4.png" OnClick="mesa4Button_Click" />
                    <asp:ImageButton ID="mesa5Button" CssClass ="mesa5" runat="server" ImageUrl ="img/mesa5.png" OnClick="mesa5Button_Click" />
                    <asp:ImageButton ID="mesa6Button" CssClass ="mesa6" runat="server" ImageUrl ="img/mesa6.png" OnClick="mesa6Button_Click" />
                    <br /><br />
                     <asp:ImageButton ID="mesa7Button" CssClass ="mesa7" runat="server" ImageUrl ="img/mesa7.png" OnClick="mesa7Button_Click" />
                    <asp:ImageButton ID="mesa8Button" CssClass ="mesa8" runat="server" ImageUrl ="img/mesa8.png" OnClick="mesa8Button_Click" />
                    <asp:ImageButton ID="mesa9Button" CssClass ="mesa9" runat="server" ImageUrl ="img/mesa9.png" OnClick="mesa9Button_Click" />
                    <!-- Add more buttons for other tables as needed -->
                   </nav>
       </div>
            <div class="direito">
                <h1>Faça sua reserva</h1>
                     <asp:Label ID="lblhorarios" runat="server" CssClass="horario" ForeColor="White" Text ="Selecione a data que deseja primeiro"></asp:Label><br /><br /><br />
                            <div class="group">
                                 <asp:TextBox ID="txtNome" runat="server" CssClass="nome" Visible="false"></asp:TextBox>
                                 <span class="highlight"></span>
                                 <span class="bar"></span>
                                <label id="lblNome" class="nome" runat="server">Nome</label>
                             </div>
                
                    <asp:Label ID="Lbllugar" runat="server" Text="Quantidade de cadeiras:" CssClass ="lugar" Visible="false"></asp:Label>
                        <asp:DropDownList ID="dpcadeiras" runat="server" AppendDataBoundItems="true" CssClass="mais" Visible="false" > </asp:DropDownList>
                         <br /><br />
                
                             <asp:DropDownList ID="dpHorario" CssClass="dphorario" runat="server" Visible="false"></asp:DropDownList>
                <asp:TextBox ID="txtData" runat="server" TextMode="Date" CssClass="data" OnTextChanged="txtData_TextChanged" ></asp:TextBox>
                                 <br />  <br />
                                    <asp:Button ID="reservarButton" runat="server" CssClass="reservar" Text="Reservar" OnClick="reservarButton_Click"  Visible="false" > </asp:Button>
                        
            </div>
            
      </div>
        
    </form>
</body>
</html>