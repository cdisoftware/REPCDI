<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CT.ADIM.WEB.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>INTRANET</title>
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.6.3/css/font-awesome.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src=" https://unpkg.com/popper.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <link href="MEDIA/CSS/all.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/local.css" rel="stylesheet" />

    <script src="MEDIA/JS/jquery.min.js"></script>
    <script src="MEDIA/JS/bootstrap.bundle.min.js"></script>
    <script src="MEDIA/JS/jquery.easing.min.js"></script>
    <script src="MEDIA/JS/sb-admin-2.min.js"></script>
    <script src="MEDIA/JS/local.js"></script>
    <script>
        function openModalRecPass() {
            $('#myModalPass').modal('show');
        }
    </script>
</head>
<body class="bg-gradient-primary" style="background-image: url(MEDIA/IMG/bg-login.jpg)">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-xl-10 col-lg-12 col-md-9">
                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">
                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                            <div class="col-lg-6">
                                <div class="p-5" style="opacity: 1">
                                    <div class="text-center">
                                        <h1 class="h4 text-gray-900 mb-4">Ingresa y registra tu historia!</h1>
                                        <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                    <form id="Form" runat="server" class="user">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control form-control-user" placeholder="Usuario..."></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtClave" runat="server" CssClass="form-control form-control-user" placeholder="Contraseña..." TextMode="Password"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <div class="custom-control custom-checkbox small">
                                                <input type="checkbox" class="custom-control-input" id="customCheck">
                                                <label class="custom-control-label" for="customCheck">Recordarme!</label>
                                            </div>
                                        </div>
                                        <asp:Button ID="botonLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-user btn-block" OnClick="botonLogin_Click" />
                                        <div class="modal-contenedor" id="divContenedor" onclick="cerrarpopup();">
                                        </div>

                                        <div class="modal-msg" id="divMensaje" align="center">
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

                                        <div class="modal" id="myModalPass">
                                            <div class="modal-dialog modal-dialog-centered">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <div class="row">
                                                            <h5 class="modal-title">Recuperar Contraseña</h5>
                                                        </div>
                                                    </div>
                                                    <div class="modal-body">
                                                        <asp:Label ID="lblMensajeRec" runat="server" Text=" Enviaremos a tu correo electrónico el link para recuperar tu contraseña."></asp:Label>

                                                        <div style="padding-top: 10px" class="col-sm-12">
                                                            <asp:TextBox ID="txtMail" runat="server" CssClass="form-control" placeholder="Correo Electrónico"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="modal-footer div-center">
                                                        <div style="display: table-cell">
                                                            <%--<button type="button" class="btn btn-secondary btn-user btn-block" onclick="volverLogin()" data-dismiss="modal" style="width: 100px">Cerrar</button>--%>
                                                        <asp:Button ID="btnSalir" runat="server" Text="Cerrar" CssClass="btn btn-secondary btn-user btn-block" OnClick="btnSalir_Click" Width="100px" Visible="true" />
                                                        </div>
                                                        <div style="display: table-cell">
                                                            <asp:Button ID="btnRecuperaPass" runat="server" Text="Enviar" CssClass="btn btn-secondary btn-user btn-block" OnClick="btnRecuperaPass_Click" Width="100px" Visible="true" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </form>
                                    <div class="text-center">
                                        <%--<a class="small" href="forgot-password.html">Recuperar contraseña!</a>--%>
                                    </div>
                                    <div class="text-center">
                                        <a class="small" href="Registro.aspx">Crear cuenta</a>
                                        <br />
                                        <a class="small" href="Login.aspx?pass=1">Olvidé mi contraseña!</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
