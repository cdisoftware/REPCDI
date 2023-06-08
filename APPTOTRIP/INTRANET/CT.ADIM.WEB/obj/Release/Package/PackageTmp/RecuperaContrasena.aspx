<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperaContrasena.aspx.cs" Inherits="CT.ADIM.WEB.RecuperaContrasena" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>App Tp Trip - Recupera Contraseña</title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.6.3/css/font-awesome.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src=" https://unpkg.com/popper.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script src="MEDIA/JS/jquery.min.js"></script>
    <script src="MEDIA/JS/bootstrap.bundle.min.js"></script>
    <script src="MEDIA/JS/local.js"></script>

    <link href="MEDIA/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/bootstrap-select.css" rel="stylesheet" />
    <link href="MEDIA/CSS/thumbnail-gallery.css" rel="stylesheet" />
    <link href="MEDIA/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/local.css" rel="stylesheet" />
    <link href="MEDIA/CSS/style.css" rel="stylesheet" />
    <link href="MEDIA/CSS/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="MEDIA/CSS/PersonalizadoBPM.css" rel="stylesheet" />
    <script>
        function openModalMsg() {
            $('#myModalMsg').modal('show');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="width: 50%; padding: 10px">
            <div class="row" style="border: 1px solid #999999; border-radius: 10px 10px">
                <div class="col-sm-12">
                    <div class="row">
                        <div class="col-sm-12">
                            Recuperar Contraseña
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Nueva Contraseña"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtRepPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Repetir Contraseña"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row div-center">
                        <div class="col-sm-6 text-right">
                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                        </div>
                        <div class="col-sm-6 text-left">
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal" id="myModalMsg">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <h5 class="modal-title">Recuperar Contraseña</h5>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div style="padding-top: 10px" class="col-sm-12">
                            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="modal-footer div-center">
                        <div style="display: table-cell">
                            <asp:Button ID="btnRecuperaPass" runat="server" Text="Aceptar" CssClass="btn btn-secondary btn-user btn-block" OnClick="btnRecuperaPass_Click" Width="100px" Visible="true" />
                        </div>
                        <div style="display: table-cell">
                            <button type="button" class="btn btn-secondary btn-user btn-block" data-dismiss="modal" style="width: 100px">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
