<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="CT.ADIM.WEB.PerfilUsuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />
    <link href="MEDIA/CSS/all.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/local.css" rel="stylesheet" />

    <script src="MEDIA/JS/jquery.min.js"></script>
    <script src="MEDIA/JS/bootstrap.bundle.min.js"></script>
    <script src="MEDIA/JS/jquery.easing.min.js"></script>
    <script src="MEDIA/JS/sb-admin-2.min.js"></script>
    <script src="MEDIA/JS/local.js"></script>
    <style>
      
    </style>
</head>
<body class="bg-body">
    <form id="form1" runat="server" class="user">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <nav class="navbar navbar-expand-lg navbar-dark bg-gradient-primary fixed-top">
            <div class="container" style="padding-top: 10px">
                <div style="position: fixed; z-index: 10000;">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/MEDIA/IMG/Logo.png" />
                </div>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarResponsive">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item">
                            <asp:LinkButton ID="btnPerfil" runat="server" CssClass="nav-link" Enabled="false" Visible="false">Mi Cuenta</asp:LinkButton>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="btnAyuda" runat="server" CssClass="nav-link">Ayuda</asp:LinkButton>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="btnSalir" runat="server" CssClass="nav-link" OnClick="btnSalir_Click">Salir</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <br />
        <br />
        <br />
        <%--<asp:UpdatePanel runat="server">
            <ContentTemplate>--%>
                <div align="center" style="height: 100%; padding-top: 30px">
                    <div style="width: 50%; background-color: whitesmoke; padding: 20px; border-radius: 15px">
                        <div class="text-center">
                            <h4>Información Personal</h4>
                            <h6>Es muy importante mantener tu información al dia.</h6>
                        </div>
                        <div style="display: table; width: 80%">
                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    Foto de Perfil
                                </div>
                                <div class="cell-padd" style="display: table-cell; border-radius: 50%">
                                    <asp:Image ID="imgPrfl" runat="server" CssClass="circ" Height="100px" Width="100px" />
                                </div>
                                <div class="file-upload-edit" style="display: table-cell; padding: 5px">
                                    <label style="width: 100%; height: 100%">
                                        <asp:FileUpload ID="fulImgperfil" runat="server" AllowMultiple="true" OnChange=""></asp:FileUpload>
                                    </label>
                                    <asp:ImageButton ID="btnEditarDatos" runat="server" ValidationGroup="ImgPrfl" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditarDatos_Click" />
                                </div>
                            </div>
                            <div style="display: table-row; padding: 5px">
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    Nombres
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    <asp:Label ID="lblNombre" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control  txt-width" placeholder="Nombres" Visible="false"></asp:TextBox>
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px">
                                    <asp:ImageButton ID="btnNombres" runat="server" ValidationGroup="btnNombres" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditarDatos_Click" />
                                </div>
                            </div>
                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    Apellidos
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    <asp:Label ID="lblApellido" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control txt-width" placeholder="Apellido" Visible="false"></asp:TextBox>
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px">
                                    <asp:ImageButton ID="ImageButton2" runat="server" ValidationGroup="btnApellidos" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditarDatos_Click" />
                                </div>
                            </div>
                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    Tipo Identificación
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    <asp:Label ID="lblTipoId" runat="server"></asp:Label>
                                    <asp:DropDownList ID="ddlTipoId" CssClass="form-control txt-width" runat="server" Visible="false"></asp:DropDownList>
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px">
                                    <asp:ImageButton ID="ImageButton9" runat="server" ValidationGroup="btnTipoId" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditarDatos_Click" />
                                </div>
                            </div>
                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    Número Identificación
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    <asp:Label ID="lblNumeroId" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtNumeroId" runat="server" CssClass="form-control txt-width" placeholder="Apellido" Visible="false"></asp:TextBox>
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px">
                                    <asp:ImageButton ID="ImageButton11" runat="server" ValidationGroup="btnNumeroId" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditarDatos_Click" />
                                </div>
                            </div>
                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    Pais
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    <asp:Label ID="lblPais" runat="server"></asp:Label>
                                    <asp:DropDownList ID="ddlPais" runat="server" CssClass="form-control txt-width" AutoPostBack="true" Visible="false">
                                    </asp:DropDownList>
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px">
                                    <asp:ImageButton ID="ImageButton3" runat="server" ValidationGroup="btnPais" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditarDatos_Click" />
                                </div>
                            </div>
                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    Ciudad
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    <asp:Label ID="lblCiudad" runat="server"></asp:Label>
                                    <asp:DropDownList ID="ddlCiudad" runat="server" CssClass="form-control txt-width" Visible="false">
                                        <asp:ListItem Text="Ciudad..."></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px">
                                    <asp:ImageButton ID="ImageButton4" runat="server" ValidationGroup="btnCiudad" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditarDatos_Click" />
                                </div>
                            </div>
                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    Certificado
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    <asp:Label ID="lblNumCert" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtNumCert" runat="server" CssClass="form-control txt-width" placeholder="Certificado de Guia" Visible="false"></asp:TextBox>
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px">
                                    <asp:ImageButton ID="ImageButton5" runat="server" ValidationGroup="btnNumCert" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditarDatos_Click" />
                                </div>
                            </div>
                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    Vigencia Certificado
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    <asp:Label ID="lblVigCert" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtVigCert" runat="server" CssClass="form-control txt-width" placeholder="Vigencia del Certificado" Visible="false"></asp:TextBox>
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px">
                                    <asp:ImageButton ID="ImageButton6" runat="server" ValidationGroup="btnVigCert" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditarDatos_Click" />
                                </div>
                            </div>
                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell" align="left">
                                    Imagen Certificado
                                </div>
                                <div class="cell-padd" style="display: table-cell">
                                    <asp:Image ID="imgCertificado" runat="server" CssClass="circ" Height="100px" Width="100px" ImageUrl="~/MEDIA/IMG/Logo.png" />
                                </div>
                                <div class="file-upload-edit" style="display: table-cell; padding: 5px">
                                    <label style="width: 100%; height: 100%">
                                        <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" OnChange="fileupload(this.value)"></asp:FileUpload>
                                    </label>
                                    <asp:ImageButton ID="ImageButton7" runat="server" ValidationGroup="btnImgCertificado" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditarDatos_Click" />
                                </div>
                            </div>
                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    Fecha Nacimiento
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    <asp:Label ID="lblFecNac" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtFecNac" runat="server" CssClass="form-control txt-width" placeholder="Fecha de Nacimiento" Visible="false"></asp:TextBox>
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px">
                                    <asp:ImageButton ID="ImageButton8" runat="server" ValidationGroup="btnFecNac" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditarDatos_Click" />
                                </div>
                            </div>
                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell" align="left">
                                    Email
                                </div>
                                <div class="cell-padd" style="display: table-cell" align="left">
                                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/MEDIA/IMG/editar.png" Visible="false" />
                                </div>
                            </div>
                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    Contraseña
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px" align="left">
                                    <asp:Label ID="lblClave" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtClave" runat="server" CssClass="form-control txt-width" placeholder="Clave" Visible="false"></asp:TextBox>
                                </div>
                                <div class="cell-padd" style="display: table-cell; padding: 5px">
                                    <asp:ImageButton ID="ImageButton10" runat="server" ValidationGroup="btnContrasena" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditarDatos_Click" />
                                </div>
                            </div>

                        </div>
                        <div style="display: table">
                            <div style="display: table-row">
                                <div style="display: table-cell; padding: 5px">
                                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Guardar" Width="150px" OnClick="btnGuardar_Click" />
                                </div>
                                <div style="display: table-cell; padding: 5px">
                                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Cancelar" Width="150px" OnClick="btnCancelar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
        <div class="modal-contenedor" id="divContenedor" onclick="cerrarpopup();">
        </div>
        <div class="modal-msg-img" id="divMensaje" align="center">
            <table border="0" style="width: 100%">
                <tr>
                    <td align="left">
                        <img src="MEDIA/IMG/AtencionPeq.png" /></td>
                    <td align="center">
                        <h2>Atención!</h2>
                        <%--<asp:Label ID="lblMensajePU" CssClass="lblMensajePU" runat="server"></asp:Label>--%>
                        <asp:Label ID="lblResultadoLogin" runat="server" Text="" CssClass="lblMensajePU"></asp:Label>
                    </td>
                </tr>
            </table>
            <a class="popup-cerrar" onclick="cerrarpopup();">X</a>
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
