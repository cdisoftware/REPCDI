<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CT.ADIM.WEB.Registro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrate</title>
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />
    <link href="MEDIA/CSS/all.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <link href="MEDIA/CSS/local.css" rel="stylesheet" />
    <script src="MEDIA/JS/jquery.min.js"></script>
    <script src="MEDIA/JS/bootstrap.bundle.min.js"></script>
    <script src="MEDIA/JS/jquery.easing.min.js"></script>
    <script src="MEDIA/JS/sb-admin-2.min.js"></script>
    <script src="MEDIA/JS/local.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script>
        function confirmaclave(conf) {
            var clave = document.getElementById("txtClave").value;
            if (clave != conf) {
                document.getElementById("txtClaveConf").value = "";
                document.getElementById("txtClaveConf").placeholder = "Los valores no coinciden";
            }
        }

        function validacorreo(texto) {

        }
    </script>
    <style>
        .txt-width {
            width: 250px;
        }

        .cell-padd {
            padding: 5px;
        }

        .txt-hidden {
            visibility: hidden;
        }
    </style>
</head>
<body class="bg-body">
    <form id="Form" runat="server" class="user">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div align="center" style="height: 100%; padding-top: 30px">
            <div align="center" style="width: 50%; background-color: whitesmoke; padding: 20px; border-radius: 15px">
                <div class="text-center">
                    <div style="display: table; width: 100%">
                        <div style="display: table-row">
                            <div style="display: table-cell" align="center">
                                <h4>Serás un nuevo guia DIGITAL!</h4>
                            </div>
                        </div>
                        <div style="display: table-row">
                            <div style="display: table-cell" align="center">
                                <h6>Ingresa tus datos y haz parte del universo AppToTrip.</h6>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="display: table; width: 100%">
                    <div style="display: table-row">
                        <div style="display: table-cell;" align="right">
                        </div>
                        <div style="display: table-cell; padding-right: 25px" align="right">
                            <a href="Login.aspx">
                                <asp:Label ID="lblRegresar" runat="server" Text="Ya tengo una cuenta." Font-Size="Small"></asp:Label></a>
                        </div>
                    </div>
                </div>
                <asp:UpdatePanel ID="upnlForm" runat="server">
                    <ContentTemplate>
                        <div style="display: table; width: 100%">
                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell">
                                    <div class="form-group">
                                        <div style="display: table-row">
                                            <div style="display: table-cell">
                                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control  txt-width" placeholder="Nombres" ToolTip="Nombres" onkeypress="return soloLetras(event)" OnBlur="Validar(this);"></asp:TextBox>
                                            </div>
                                            <div style="display: table-cell; padding: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtNombre" Visible="false" ValidationGroup="Guardar1">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="cell-padd" style="display: table-cell">
                                    <div class="form-group">
                                        <div style="display: table-row">
                                            <div style="display: table-cell">
                                                <div style="display: table-row">
                                                    <div style="display: table-cell">
                                                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control txt-width" placeholder="Apellidos" onkeypress="return soloLetras(event)" OnBlur="Validar(this);"></asp:TextBox>
                                                    </div>
                                                    <div style="display: table-cell; padding: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtApellido" Visible="false" ValidationGroup="Guardar1">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell">
                                    <div class="form-group">
                                        <div style="display: table-row">
                                            <div style="display: table-cell">
                                                <asp:DropDownList ID="ddlTipoId" runat="server" CssClass="form-control txt-width" onblur="Validar(this);">
                                                </asp:DropDownList>
                                            </div>
                                            <div style="display: table-cell; padding: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlTipoId" Visible="false" InitialValue="Tipo Id..." ValidationGroup="Guardar1">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="cell-padd" style="display: table-cell">
                                    <div class="form-group">
                                        <div style="display: table-row">
                                            <div style="display: table-cell">
                                                <asp:TextBox ID="txtNumeroId" runat="server" CssClass="form-control txt-width" placeholder="Número Identificación" OnBlur="Validar(this);"></asp:TextBox>
                                            </div>
                                            <div style="display: table-cell; padding: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" Visible="false" ControlToValidate="txtNumeroId" ValidationGroup="Guardar1">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div style="display: table-row">
                                <div class="cell-padd" style="display: table-cell">
                                    <div class="form-group">
                                        <div style="display: table-row">
                                            <div style="display: table-cell">
                                                <asp:DropDownList ID="ddlPais" runat="server" CssClass="form-control txt-width" AutoPostBack="true" OnBlur="Validar(this);" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div style="display: table-cell; padding: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlPais" Visible="false" ValidationGroup="Guardar1" InitialValue="Pais...">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="cell-padd" style="display: table-cell">
                                    <div class="form-group">
                                        <div style="display: table-row">
                                            <div style="display: table-cell">
                                                <asp:DropDownList ID="ddlCiudad" runat="server" OnBlur="Validar(this);" CssClass="form-control txt-width">
                                                    <asp:ListItem Text="Ciudad..."></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div style="display: table-cell; padding: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="RequiredFieldValidator" Visible="false" ControlToValidate="ddlCiudad" InitialValue="Ciudad..." ValidationGroup="Guardar1">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div style="display: table; width: 100%">
                    <div style="display: table-row">
                        <div class="cell-padd" style="display: table-cell">
                            <div class="form-group">
                                <div style="display: table-row">
                                    <div style="display: table-cell">
                                        <asp:TextBox ID="txtFecNac" runat="server" CssClass="form-control txt-width" placeholder="Fecha de Nacimiento" OnBlur="Validar(this);" OnFocus="iniControlFecha(this)" type="date"></asp:TextBox>
                                    </div>
                                    <div style="display: table-cell; padding: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" Visible="false" ControlToValidate="txtFecNac" ValidationGroup="Guardar1">*</asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="cell-padd" style="display: table-cell">
                            <div class="form-group">
                                <div style="display: table-row">
                                    <div style="display: table-cell">
                                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control txt-width" placeholder="Email - Usuario" ToolTip="Este será tu nombre de usuario." OnBlur="Validar(this);"></asp:TextBox>
                                    </div>
                                    <div style="display: table-cell; padding: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" Visible="false" ControlToValidate="Email" ValidationGroup="Guardar1">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div style="display: table; width: 100%">
                    <div style="display: table-row">
                        <div class="cell-padd" style="display: table-cell">
                            <div class="form-group">
                                <div style="display: table-row">
                                    <div style="display: table-cell">
                                        <asp:TextBox ID="txtNumCert" runat="server" CssClass="form-control txt-width" placeholder="Numero Tarjeta Profesional"></asp:TextBox>
                                    </div>
                                    <div style="display: table-cell; padding: 5px">
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" Visible="false" ControlToValidate="txtNumCert" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="cell-padd" style="display: table-cell">
                            <div class="form-group">
                                <div style="display: table-row">
                                    <div style="display: table-cell">
                                        <asp:TextBox ID="txtVigCert" runat="server" CssClass="form-control txt-width" placeholder="Vigencia del Certificado" OnFocus="iniControlFecha(this)"></asp:TextBox>
                                    </div>
                                    <div style="display: table-cell; padding: 5px">
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" Visible="false" ControlToValidate="txtEmail" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="display: table-row">
                        <div class="cell-padd" style="display: table-cell">
                            <div class="form-group">
                                <div style="display: table-row">
                                    <div style="display: table-cell">
                                        <asp:TextBox ID="txtClave" runat="server" CssClass="form-control txt-width" placeholder="Clave" OnBlur="Validar(this);"></asp:TextBox>
                                    </div>
                                    <div style="display: table-cell; padding: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" Visible="false" ControlToValidate="txtClave" ValidationGroup="Guardar1">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="cell-padd" style="display: table-cell">
                            <div class="form-group">
                                <div style="display: table-row">
                                    <div style="display: table-cell">
                                        <asp:TextBox ID="txtClaveConf" runat="server" CssClass="form-control txt-width" placeholder="Confirmar Clave" onblur="confirmaclave(this.value)"></asp:TextBox>
                                    </div>
                                    <div style="display: table-cell; padding: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" Visible="false" ControlToValidate="txtClaveConf" ValidationGroup="Guardar1">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div style="display: table-row">
                        <div class="cell-padd" style="display: table-cell">
                            Imágen de Perfil
                                                        <br />
                            <div class="file-upload-tin" style="border: none; height: 100px;">
                                <asp:Image ID="imgPerfil" runat="server" CssClass="circ" Width="100px" Height="100px" Visible="false" />
                                <label style="width: 100%; height: 100%; cursor: pointer">
                                    <asp:FileUpload ID="fulImgPerfil" runat="server" AllowMultiple="false" OnChange="fileupload(this.value)"></asp:FileUpload>
                                </label>
                            </div>
                            <div style="height: 4px"></div>
                            <asp:LinkButton ID="btnSubirImgPerfil" runat="server" OnClick="btnSubirImgPerfil_Click">Aceptar</asp:LinkButton>
                            <asp:LinkButton ID="btnCanImgPerfil" runat="server" OnClick="btnCanImgPerfil_Click" Visible="false">Cancelar</asp:LinkButton>
                        </div>
                        <div class="cell-padd" style="display: table-cell">
                            <asp:Label ID="lblImgCertificado" runat="server" Text="Imágen de Certificado"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="whitesmoke" ControlToValidate="txtImgCertificado" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                            <br />
                            <div class="file-upload-tin" style="border: none; height: 100px;">
                                <asp:Image ID="imgCrt" runat="server" CssClass="circ" Width="100px" Height="100px" Visible="false" />
                                <label style="width: 100%; height: 100%; cursor: pointer">
                                    <asp:FileUpload ID="fulImgCertificado" runat="server" AllowMultiple="false" OnChange="fileupload(this.value)"></asp:FileUpload>
                                </label>
                            </div>
                            <div style="height: 4px"></div>
                            <asp:LinkButton ID="btnSubirImgCert" runat="server" OnClick="btnSubirImgCert_Click">Aceptar</asp:LinkButton>
                            <asp:LinkButton ID="btnCanImgCert" runat="server" OnClick="btnCanImgCert_Click" Visible="false">Cancelar</asp:LinkButton>
                        </div>
                    </div>

                    <div style="display: table-row">
                        <div class="cell-padd" style="display: table-cell">
                            <asp:Button ID="btnGuardar1" runat="server" Text="Guardar" CssClass="btn btn-primary btn-user btn-block" OnClick="btnGuardar_Click" OnClientClick="ValidarBtnRegistro();" ValidationGroup="Guardar1" />
                            <%--<asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary btn-user btn-block" OnClick="btnGuardar_Click" OnClientClick="ValidarBtnRegistro();" ValidationGroup="Guardar" />--%>
                        </div>
                        <div class="cell-padd" style="display: table-cell">
                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-primary btn-user btn-block" OnClick="btnLimpiar_Click" />
                        </div>
                    </div>
                </div>
                <asp:TextBox ID="txtImgCertificado" runat="server" Text="test" CssClass="txt-hidden"></asp:TextBox>
                <asp:TextBox ID="txtTipoId" runat="server" Text="" CssClass="txt-hidden"></asp:TextBox>
                <asp:TextBox ID="txtCiudad" runat="server" Text="" CssClass="txt-hidden"></asp:TextBox>
                <asp:TextBox ID="txtPais" runat="server" Text="" CssClass="txt-hidden"></asp:TextBox>
            </div>
        </div>
        <div class="modal fade" id="myModal">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title">¡Atención!</h3>
                    </div>
                    <div class="modal-body">
                        <div class="div-center" style="width: 100%; height: 100%;">
                            <div style="display: table; width: 100%; height: 100%;">
                                <div style="display: table-row">
                                    <div style="display: table-cell">
                                        <%--<img src="Media/img/AtencionPeq.png" />--%>
                                    </div>
                                    <div style="display: table-cell; padding-left: 20px">
                                        <asp:Label ID="lblMensajePU" CssClass="lblMensajePU" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" id="btnCerrar" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>


</body>
</html>
