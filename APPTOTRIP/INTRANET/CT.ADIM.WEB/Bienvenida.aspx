<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bienvenida.aspx.cs" Inherits="CT.ADIM.WEB.Bienvenida" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ATT - Bienvenido</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="MEDIA/JS/jquery.min.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script src="MEDIA/JS/bootstrap.bundle.min.js"></script>
    <script src="MEDIA/JS/local.js"></script>
    <link href="MEDIA/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/portfolio-item.css" rel="stylesheet" />
    <link href="MEDIA/CSS/thumbnail-gallery.css" rel="stylesheet" />
    <link href="MEDIA/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/local.css" rel="stylesheet" />
   <%-- <link href="~/Media/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/Media/css/PersonalizadoBPM.css" rel="stylesheet" />--%>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-gradient-primary fixed-top">
            <div class="container" style="padding-top: 10px">
                <div style="position: fixed; z-index: 10000;">
                    <asp:Image ID="Image1" runat="server" CssClass="circ" ImageUrl="~/MEDIA/IMG/Logo.png" />
                </div>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarResponsive">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item">
                            <asp:LinkButton ID="btnValidaUsuario" runat="server" CssClass="nav-link" OnClick="btnValidaUsuario_Click" Visible="false">Activar Cuentas</asp:LinkButton>
                            <asp:LinkButton ID="btnPerfil" runat="server" CssClass="nav-link" Visible="false">Mi Cuenta</asp:LinkButton>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="btnAyuda" runat="server" CssClass="nav-link" Visible="false">Ayuda</asp:LinkButton>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="btnSalir" runat="server" CssClass="nav-link" Visible="false" OnClick="btnSalir_Click">Salir</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div id="cntBotones" runat="server" class="container">
            <br />
            <br />
            <br />
            <div class="row div-center text-lg-left">
                <div align="center">
                    <h1>EN MANTENIMIENTO!</h1>
                </div>
            </div>
        </div>
    </form>
    <footer class="bg-gradient-primary fixed-bottom" style="height: 40px">
        <div class="container" style="height: 20px">
            <p class="m-0 text-center text-white">Copyright &copy; C.D.I Software 2018</p>
        </div>
        <!-- /.container -->
    </footer>
</body>
</html>
