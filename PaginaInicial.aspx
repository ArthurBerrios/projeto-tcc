<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaInicial.aspx.cs" Inherits="Login.PaginaInicial" %>

<!DOCTYPE html>
<html lang="en">



<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <title>Hot Rolls Club</title>
  <link rel="preconnect" href="https://fonts.googleapis.com" />
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
  <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500&display=swap" rel="stylesheet" />
  <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100&display=swap" rel="stylesheet">
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Libre+Franklin:wght@100&family=Montserrat:wght@100&family=Roboto:wght@500&display=swap" rel="stylesheet">
  <link href="./styles.css" rel="stylesheet" />
  <link rel="icon" type="image/png" href="Logo.png"/>
  <script type="text/javascript" src="main.js"></script>

   
    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>

   
</head>

<body>

        <form id="form1" runat="server">
  <nav class="navbar">
    <div class="navbar-overlay" onclick="toggleMenuOpen()"></div>

    <button type="button" class="navbar-burger" onclick="toggleMenuOpen()">
      <span class="material-icons">menu</span>
    </button>
    <a class="logo" id="logo" href="index.html">Hot Rolls Club</a>
      
    <nav class="navbar-menu">
      <asp:HyperLink ID="hyperLinkInicio" runat="server" NavigateUrl="#Inicio">
                <asp:Button ID="buttonInicio" runat="server" CssClass="hover-underline-animation active" Text="Inicio" />
            </asp:HyperLink>

            <asp:HyperLink ID="hyperLinkSobreNos" runat="server" NavigateUrl="#Sobrenos">
                <asp:Button ID="buttonSobreNos" runat="server" CssClass="hover-underline-animation" Text="Sobre nós" />
            </asp:HyperLink>

            <asp:HyperLink ID="hyperLinkAvaliacoes" runat="server" NavigateUrl="#Avaliacoes">
                <asp:Button ID="buttonAvaliacoes" runat="server" CssClass="hover-underline-animation" Text="Avaliações" />
            </asp:HyperLink>

            <asp:HyperLink ID="hyperLinkCardapio" runat="server" NavigateUrl="#Cardapio">
                <asp:Button ID="buttonCardapio" runat="server" CssClass="hover-underline-animation" Text="Cardápio" />
            </asp:HyperLink>

            <asp:HyperLink ID="hyperLinkContatos" runat="server" NavigateUrl="#Contatos">
                <asp:Button ID="buttonContatos" runat="server" CssClass="hover-underline-animation" Text="Contatos" />
            </asp:HyperLink>
        <asp:Button ID="btnLogin" runat="server" Text="Fazer Reserva" CssClass="entrar" OnClick="btnLogin_Click1" />
        </nav>
  </nav>
 


 <div class="carousel">
  <div class="carousel-item">
    <img src="img\Banner Sushi.png" alt="Imagem 1" class="auto-style1">
  </div>
  <div class="carousel-item">
    <img src="img\Gifanuncio.gif" alt="Imagem 2">
  </div>
  <div class="carousel-item">
    <img src="img\Banner Sushi.png" alt="Imagem 3">
  </div>
</div>

      
    

 <a href="#Sobrenos"><div class="icon-default" id="Sobrenos"> <img src="img\cardapio.png"></div></a>

<div class="sobrenosmaior" id="Sobrenos">
   <div class="sobrenos">
<h1>Sobre nós</h1>
<p>
  Nossos pratos são admirados por sua delicadeza, sabor e apresentação impecável. É caracterizada por ingredientes frescos e de alta qualidade, e pela habilidade em harmonizar diferentes sabores e texturas.
</p>

  

  <asp:Button runat="server" ID="btnFazerReserva" Text="Fazer Reserva" CssClass="btn btn-one"></asp:Button>
 

   </div>

  <div class="sobrenosimgmaior">
  <div class="sobrenosimg">

    
    <a href="cardapio.html"> <div class="sobrenoszoom">   <img src="img\prato1.png" ><div class="texto-oculto">Veja nosso cardápio!</div> </div></a>
    <a href="cardapio.html"> <div class="sobrenoszoom"> <img src="img\prato1.png" ><div class="texto-oculto">Veja nosso cardápio!</div></div></a>
  </div>


  <div class="sobrenosimg2">
    <a href="cardapio.html"><div class="sobrenoszoom">   <img src="img\prato1.png" ><div class="texto-oculto">Veja nosso cardápio!</div> </div></a>
    <a href="cardapio.html"><div class="sobrenoszoom"> <img src="img\prato1.png" ><div class="texto-oculto">Veja nosso cardápio!</div></div></a>
  </div>
  </div>
  <div class="icon-default2" id="Sobrenos"> <a href="#Sobrenos"><img src="img\chat.png"></div></a>
</div> 

<div class="avalia">
 

  <h1>Avaliações</h1>

    <div class="div-redonda">
    <img src="img\neymarcomflor.jpg">
  </div>

  <div class="h2Ney" id="ney"><h2>Neymar Jr</h2></div>

<div class="p1">  <p>Excelente comida, e um pedido rápido</p> </div>
 

    <div class="estrelasAval"><img src="img\estrelas.png"></div>
 <div class="p2"><p>Gostei muito da comida, atendimento incrível, pedido facilitador! Adorei!</p></div>
 <div class="btn btn-two">
  <span>Faça sua avaliação!</span>
</div>

<div class="icon-default3" id="Funcionamento"> <a href="#Funcionameto"><img src="img\almoco.png"></div></a>
  </div>

 
  <div class="funci"> 


    <p> Domingo à Sábado - 10:30h às 00:00h</p>
  </div>
  <div class="footer">
    <div class="contain">
      <div class="col" >
        <h1>&nbsp;&nbsp;&nbsp;Desenvolvedores</h1>
        <ul>
          <a href="https://www.instagram.com/rodrigo_cotrin/" target="_blank"><li>&nbsp;&nbsp;&nbsp;Rodrigo Cotrin</li></a>
          <a href="https://github.com/RaphaelOSB" target="_blank"> <li>&nbsp;&nbsp;&nbsp;Raphael Oliveira</li></a>
          <a href="https://www.instagram.com/theo_littig/" target="_blank"><li>&nbsp;&nbsp;&nbsp;Théo Littig</li></a>
          <a href="https://www.instagram.com/vitao_mariano/" target="_blank"><li>&nbsp;&nbsp;&nbsp;Victor Augusto</li></a>
          <a href="https://www.instagram.com/arthur_berrios/" target="_blank"><li>&nbsp;&nbsp;&nbsp;Arthur Berrios</li></a>
     
        </ul>
      </div>
      <div class="col">
        <h1>Softwares</h1>
        <ul>
          <li>Cardápio Digital</li>
          <li>Aplicações de Gerenciamento</li>
        </ul>
      </div>
      <div class="col">
        <h1>Sites</h1>
        <ul>
          <a href="https://www.instagram.com/ortech__/" target="_blank"><li>Ortech</li></a>
          <li>Hot Rolls Club</li>
        </ul>
      </div>
      <div class="col">
        <h1>Contato</h1>
        <ul>
          <li>Mande um Email</li>
          <li>Nosso número</li>
        </ul>
      </div>
      <div class="col social">
        <h1>Social</h1>
        <ul>
          <li class="face"><img src="img\1.png" width="32" style="width: 32px;"></li>
          <a href="https://www.instagram.com/ortech__/" target="_blank"><li class="instagram"><img src="img\2.png" width="32" style="width: 32px;"></li></a>
          <li class="twitter"><img src="img\3.png" width="32" style="width: 32px;"></li>

        </ul>
      </div>
      <div class="clearfix"></div>
      <footer class="foot">
        <p> Copyright © 2023 All rights Reserved - Hot Rolls Club</p>
      </footer>
    </div>

  </div>
     </form>
</body>

</html>