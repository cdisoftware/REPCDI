<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sitios.aspx.cs" Inherits="CT.ADIM.WEB.Sitios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="MEDIA/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/portfolio-item.css" rel="stylesheet" />
    <link href="MEDIA/CSS/thumbnail-gallery.css" rel="stylesheet" />
    <link href="MEDIA/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/local.css" rel="stylesheet" />
    <script src="MEDIA/JS/jquery.min.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script src="MEDIA/JS/bootstrap.bundle.min.js"></script>
    <script src="MEDIA/JS/local.js"></script>

    <script>

        function irMapa() {
            window.location = 'Mapa.aspx';
        }
        function fileupload(file) {
            if (file != null) {
                file = file.split('\\');
                var nombreArchivo = file[file.length - 1];
                document.getElementById("txtNombreArchivo").value = nombreArchivo;
                document.getElementById("divDescImagen").style.visibility = "visible";
            }
        }

        $(function () {
            $("#dialogimg").dialog({
                autoOpen: false,
                show: {
                    effect: "blind",
                    duration: 1000
                },
                hide: {
                    effect: "explode",
                    duration: 1000
                }
            });

            $(".lblNombreCls").hover(function () {
                $("#dialogimg").dialog("open");
            });
        });
    </script>

    <style>
        .oculto {
            visibility: hidden;
        }

        .modalBackground {
            filter: alpha(opacity=50);
            opacity: 0.5;
            background-color: rgb(6, 6, 6);
        }

        .modalPnl {
            display: block;
            width: 30%;
            height: 30%;
            background-color: white;
            border-width: 1px;
            border-color: #333;
            border-style: solid;
            padding: 10px;
            border-radius: 15px;
            overflow-x: hidden;
            overflow-y: hidden;
        }
    </style>

</head>
<body class="bg-body">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                            <asp:LinkButton ID="btnAyuda" runat="server" CssClass="nav-link">Ayuda</asp:LinkButton>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="btnSalir" runat="server" CssClass="nav-link" OnClick="btnSalir_Click">Salir</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div style="width: 100%; height: 50px"></div>
        <asp:Panel ID="pnlListaSitios" runat="server" Visible="true">
            <div class="container" style="padding: 20px; border-radius: 20px">
                <table>
                    <tr>
                        <td>
                            <h3>
                                <asp:Label ID="lblTtlCircuitoSitio" runat="server"></asp:Label>
                            </h3>
                        </td>
                        <td style="width: 30px" align="center">|
                        </td>
                        <td>
                            <asp:LinkButton ID="btnVerSitio" runat="server" OnClick="btnVerSitio_Click">Volver a mis circuitos.</asp:LinkButton></td>
                    </tr>
                </table>

            </div>
            <div id="cntSitiosXCircuito" class="container" runat="server" style="padding: 20px; border-radius: 20px">
                <div runat="server" class="row text-center text-lg-left">
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlDetalleSitios" runat="server" Visible="false">
            <div id="divSitiosForm" class="container" runat="server">
                <div>
                    <h3>
                        <asp:Label ID="lblTtlCircuitoNuevo" runat="server"></asp:Label></h3>
                    <div style="width: 100%"></div>
                    <h5>
                        <asp:Label ID="lblTtlSitioDtll" runat="server"></asp:Label>
                    </h5>
                </div>
                <div style="width: 100%; height: 5px"></div>
                <div style="width: 100%" align="center">
                    <table style="background-color: whitesmoke; border-radius: 10px; width: 100%; padding: 5px">
                        <tr>
                            <td style="padding: 10px; vertical-align: middle">Nombre (*)</td>
                            <td>
                                <asp:TextBox ID="txtNombreSitio" runat="server" CssClass="form-control form-control-user" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtNombreSitio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                            </td>

                            <td style="padding: 10px">Dirección (*)</td>
                            <td>
                                <asp:TextBox ID="txtIDireccionSitio" runat="server" CssClass="form-control form-control-user" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtIDireccionSitio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                            </td>

                            <td style="padding: 10px">Teléfono (*)</td>
                            <td>
                                <asp:TextBox ID="txtTelefonoSitio" runat="server" CssClass="form-control form-control-user" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtTelefonoSitio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>

                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 10px">Costo</td>
                            <td>
                                <asp:TextBox ID="txtCostoSitio" runat="server" CssClass="form-control form-control-user" Width="200px"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCostoSitio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>--%>
                            </td>

                            <td style="padding: 10px">Duración (*)</td>
                            <td>
                                <asp:TextBox ID="txtTiempoSitio" runat="server" CssClass="form-control form-control-user" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtTiempoSitio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                            </td>

                            <td style="padding: 10px">Horario (*)</td>
                            <td>
                                <asp:TextBox ID="txtHorarioSitio" runat="server" CssClass="form-control form-control-user" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtHorarioSitio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 10px">Ubicación (*)</td>
                            <td>
                                <asp:TextBox ID="txtLatSitio" runat="server" CssClass="form-control form-control-user" Width="200px" placeholder="Latitud" ToolTip="Latitud"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtLatSitio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                            </td>
                            <td>Fotos</td>
                            <td>
                                <asp:ImageButton ID="btnImagenesSitio" runat="server" ImageUrl="~/MEDIA/IMG/Btn_ImagenesSitio.png" OnClick="btnImagenesSitio_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:TextBox ID="txtLongSitio" runat="server" CssClass="form-control form-control-user" Width="200px" placeholder="Longitud" ToolTip="Longitud"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtLongSitio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="padding: 10px" align="left" colspan="3">
                                <asp:LinkButton ID="btnVerMapa" runat="server" OnClick="btnVerMapa_Click">Ver Mapa</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>

                            <td style="padding-left: 10px" colspan="3">Equipamento
                                <asp:TextBox ID="txtEquipamentoSitio" runat="server" CssClass="form-control form-control-user" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEquipamentoSitio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="padding-left: 10px" colspan="3">Recomendaciones
                                <asp:TextBox ID="txtRecomendacionesSitio" runat="server" CssClass="form-control form-control-user" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtRecomendacionesSitio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px;" colspan="6">IRA
                        <asp:TextBox ID="txtIra" runat="server" CssClass="form-control form-control-user" Width="90%" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtIra" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px;" colspan="6">Descripción (*)
                                <asp:TextBox ID="txtDescripcionSitio" runat="server" CssClass="form-control form-control-user" Width="90%" TextMode="MultiLine" MaxLength="4000"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtDescripcionSitio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                            </td>

                        </tr>
                    </table>
                    <div style="display: table-row; padding: 10px">
                        <div style="display: table-cell; padding: 10px">
                            <asp:Button ID="btnGuardarSitio" runat="server" Text="Guardar" CssClass="btn btn-primary btn-user btn-block" OnClick="btnGuardarSitio_Click" ValidationGroup="Guardar" />
                        </div>
                        <div style="display: table-cell; padding: 10px">
                            <asp:Button ID="btnEliminarSitio" runat="server" Text="Eliminar" CssClass="btn btn-primary btn-user btn-block" OnClick="btnEliminarSitio_Click" />
                        </div>
                        <div style="display: table-cell; padding: 10px">
                            <asp:Button ID="btnVolverSitio" runat="server" ValidationGroup="Guardar" Text="Volver" CssClass="btn btn-primary btn-user btn-block" OnClick="btnVolverSitio_Click" />
                        </div>
                    </div>

                    <br />
                    <br />
                    <div style="width: 100%; height: 50px"></div>
                </div>
            </div>
            <div class="modal-contenedor" id="divContenedor" onclick="cerrarpopup();">
            </div>
            <div class="modal-msg-img" id="divMensaje" align="center" style="width: 85%; height: 75%; overflow-y: scroll" align="center">
                <asp:Panel ID="pnlImagenes" runat="server" Visible="false">
                    <div style="display: table; background-color: white; width: 95%; height: 92%; position: absolute">
                        <div style="display: table-row">
                            <div style="display: table-cell; width: 50%; border-right: 1px solid #666">
                                <h3>Agregar Imágenes</h3>
                                <div style="padding-top: 40px">
                                    <label class="file-upload">
                                        <asp:FileUpload ID="fulImagenes" runat="server" AllowMultiple="false" OnChange="fileupload(this.value)"></asp:FileUpload>
                                    </label>
                                </div>
                                <div id="divDescImagen" style="display: table-row; visibility: hidden">
                                    <div style="display: table-cell; padding: 20px">
                                        <asp:TextBox ID="txtNombreArchivo" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:Label ID="lblExtImagen" runat="server"></asp:Label>
                                    </div>
                                    <div style="display: table-cell; padding: 20px">
                                        <asp:Button ID="btnSubirImagen" runat="server" Text="Subir" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSubirImagen_Click" />
                                    </div>
                                </div>
                            </div>
                            <div style="display: table-cell; width: 50%; vertical-align: middle; border-left: 1px solid #999; padding: 20px">
                                <asp:Label ID="lblMensajeImg" runat="server" Text="No hay archivos seleccionados."></asp:Label>
                                <asp:GridView ID="gvImagenes" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvImagenes_RowCommand" DataKeyNames="id_imagen_sitio,UrlTemp,Nombre,Orden,imagen_img" OnRowDataBound="gvImagenes_RowDataBound">
                                    <Columns>
                                        <%--<asp:BoundField HeaderText="Nombre" DataField="Nombre" HeaderStyle-HorizontalAlign="Center" />--%>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Image ID="imgPrevia" Width="100px" Height="100px" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Orden" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtOrden" runat="server" Text='<%# Bind("Orden") %>' CssClass="form-control form-control-user" Width="50px" Height="20px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Perfil" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:RadioButton ID="rbPerfil" runat="server" GroupName="perfil" AutoPostBack="true" OnCheckedChanged="rbPerfil_CheckedChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        <%-- <asp:TemplateField HeaderText="Ver" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnVerImagen" runat="server" ImageUrl="~/MEDIA/IMG/editar.png" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CommandName="Ver" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eliminar" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEliminarImagen" runat="server" Height="20px" Width="20px" ImageUrl="~/MEDIA/IMG/deleteOpaco.png" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CommandName="Eliminar" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                                <div style="width: 100%; height: 2px"></div>
                                <asp:Button ID="btnGuardarImagenes" runat="server" Text="Guardar" CssClass="btn btn-primary btn-user btn-block" OnClick="btnGuardarImagenes_Click" Visible="false" />
                            </div>

                        </div>
                    </div>
                </asp:Panel>
                <a class="popup-cerrar" onclick="cerrarpopup();">X</a>
            </div>
        </asp:Panel>

        <div class="modal-msg-img" id="divMapa" align="center" style="width: 85%; height: 75%" align="center">
            <asp:Panel ID="Panel2" runat="server" Visible="false">
            </asp:Panel>
        </div>

        <asp:Panel ID="mpAyudaUsuario" runat="server" CssClass="modalPnl">
            <div align="right">
                <asp:ImageButton ID="OKButtonFuncionario" runat="server" ImageUrl="~/Media/img/close.png" />
            </div>
            <div style="width: 50%; height: 20px"></div>
            <div align="center">
                <div style="width: 60%">
                    <asp:Label ID="lblEliminar" runat="server" Text=""></asp:Label>
                </div>
                <div style="width: 50%; height: 10px"></div>
                <div style="display: table">
                    <div style="display: table-row">
                        <div style="display: table-cell; padding: 5px">
                            <asp:Button ID="btnAceptarEliminar" runat="server" Text="Aceptar" OnClick="btnAceptarEliminar_Click" CssClass="btn btn-primary btn-user btn-block" />
                        </div>
                        <div style="display: table-cell; padding: 5px">
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary btn-user btn-block" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:ImageButton ID="btnModalFuncionario" runat="server" CssClass="oculto" />
        <cc1:ModalPopupExtender ID="mpeUsuario" runat="server" TargetControlID="btnModalFuncionario" PopupControlID="mpAyudaUsuario" BehaviorID="programmaticModalPopupBehaviorFunc"
            OkControlID="OKButtonFuncionario" BackgroundCssClass="modalBackground" RepositionMode="None" />

        <asp:ImageButton ID="btnModalMapa" runat="server" CssClass="oculto" />
        <cc1:ModalPopupExtender ID="mpeMapa" runat="server" TargetControlID="btnModalMapa" PopupControlID="pnlMapa" BehaviorID="programmaticModalPopupBehaviorFunc"
            OkControlID="okBotonMapa" BackgroundCssClass="modalBackground" RepositionMode="None" />
    </form>
    <div id="pnlMapa">
        <div align="right">
            <input id="okBotonMapa" type="button" value="button" />
        </div>
        <div id="map"></div>
    </div>

    <footer class="bg-gradient-primary fixed-bottom" style="height: 40px">
        <div class="container" style="height: 20px">
            <p class="m-0 text-center text-white">Copyright &copy; C.D.I Software 2018</p>
        </div>
        <!-- /.container -->
    </footer>
</body>
</html>
