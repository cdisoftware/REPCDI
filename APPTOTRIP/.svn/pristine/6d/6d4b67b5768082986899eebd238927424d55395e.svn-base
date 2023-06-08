<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sitio.aspx.cs" Inherits="CT.ADIM.WEB.Sitio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ATT - Bienvenido</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="MEDIA/JS/jquery.min.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script src="MEDIA/JS/bootstrap.bundle.min.js"></script>
    <script src=" https://unpkg.com/popper.js"></script>
    <script src="MEDIA/JS/local.js"></script>
    <link href="MEDIA/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/portfolio-item.css" rel="stylesheet" />
    <link href="MEDIA/CSS/thumbnail-gallery.css" rel="stylesheet" />
    <link href="MEDIA/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/local.css" rel="stylesheet" />
    <link href="~/Media/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/Media/css/PersonalizadoBPM.css" rel="stylesheet" />
    <script>
        function irMapa() {
            window.location = 'Mapa.aspx';
        }

        function validarCantCar(frm) {
            if (frm.txt.value.length != 10) {
                frm.txt.focus();
                return false;
            }
        }

        function fileupload(file) {

            if (file != null) {
                file = file.split('\\');
                var nombreArchivo = file[file.length - 1];
                document.getElementById("txtNombreArchivo").value = nombreArchivo;
                document.getElementById("divDescImagen").style.visibility = "visible";
            }
        }

        function EditValues(control) {
            var Editados = document.getElementById("hdEdit").value;
            document.getElementById("hdEdit").value = Editados + " " + control.name
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

        $(document).ready(function () {
            $('.cargando').click(function (event) {
                alert('hola');
                if (Page_ClientValidate()) { $('#p').show(); }
            })

            $('.cargando1').click(function (event) {
                $('#p').show();
            })
        });

        function openModalLogin() {
            $('#myModalLogin').modal('show');
        }

        function openModalErr() {
            $('#myModalErr').modal('show');
        }

        function openModalImg() {
            $('#myModalImg').modal('show');
        }
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

    <style>
        #myModalImg .myModalImg-dialog {
            width: 80%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="p" style="position: fixed; background-color: white; width: 100%; height: 100%; z-index: 2; top: 1PX; left: 1px; display: none; text-align: center; vertical-align: central;">
            <div style="display: inline-block; padding-top: 15%">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/MEDIA/IMG/spinner2.gif" />
            </div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container" style="width:100%">
            <nav class="navbar navbar-expand-lg navbar-dark bg-info fixed-top">
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
                    <div class="row">
                        <div style="display: table-cell">
                            <h3>
                                <asp:Label ID="lblTtlCircuitoSitio" runat="server" ForeColor="#333333"></asp:Label></h3>
                        </div>
                        <div style="display: table-cell; padding-top: 8px; padding-left: 10px">
                            <asp:LinkButton ID="btnVerSitio" runat="server" OnClick="btnVerSitio_Click" CssClass="cargando1">Volver a mis circuitos.</asp:LinkButton>
                        </div>
                    </div>
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
                            <asp:Label ID="lblTtlCircuitoNuevo" runat="server" ForeColor="#666666"></asp:Label></h3>
                        <div style="width: 100%"></div>
                        <h5>
                            <asp:Label ID="lblTtlSitioDtll" runat="server" ForeColor="#17A2B8"></asp:Label>
                        </h5>
                    </div>
                    <div style="width: 100%; height: 5px"></div>
                    <div style="width: 100%" align="center">
                        <asp:UpdatePanel ID="upnlGeneral" runat="server">
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnVerMapa" />
                                <asp:PostBackTrigger ControlID="btnImagenesSitio" />
                            </Triggers>
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div style="display: table-cell">
                                            <table style="background-color: whitesmoke; border-radius: 10px; width: 100%; padding: 5px">
                                                <tr>
                                                    <td style="padding: 10px; vertical-align: middle">Titulo(*)
                                        
                                            <td colspan="5">
                                                <asp:TextBox ID="txtNombreSitio" runat="server" CssClass="form-control form-control-user" Width="95%" onBlur="EditValues(this)"></asp:TextBox>
                                            </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 10px">Dirección(*)</td>
                                                    <td>
                                                        <asp:TextBox ID="txtIDireccionSitio" runat="server" CssClass="form-control form-control-user" Width="200px" onBlur="EditValues(this)"></asp:TextBox>
                                                    </td>

                                                    <td style="padding: 10px">Teléfono(*)</td>
                                                    <td>
                                                        <asp:TextBox ID="txtTelefonoSitio" runat="server" CssClass="form-control form-control-user" Width="200px" onBlur="EditValues(this)"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 10px">Horario(*)</td>
                                                    <td>
                                                        <asp:TextBox ID="txtHorarioSitio" runat="server" CssClass="form-control form-control-user" Width="200px" onBlur="EditValues(this)"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 10px">Costo</td>
                                                    <td>
                                                        <div style="width: 50%; display: table-cell; padding: 1px">
                                                            <asp:TextBox ID="txtCostoSitio" runat="server" CssClass="form-control form-control-user" onkeypress="return soloNumeros(event)" Width="120px" onBlur="EditValues(this)"></asp:TextBox>
                                                        </div>
                                                        <div style="width: 50%; display: table-cell; padding: 1px">
                                                            <asp:DropDownList ID="ddlMoneda" runat="server" CssClass="form-control form-control-user obl" Width="80px">
                                                            </asp:DropDownList>
                                                        </div>

                                                    </td>

                                                    <td style="padding: 10px">Duración(*)</td>
                                                    <td>
                                                        <div style="width: 50%; display: table-cell; padding: 1px; text-align: left">
                                                            <asp:TextBox ID="txtTiempoSitio" runat="server" CssClass="form-control form-control-user" Width="120px" onkeypress="return soloNumeros(event)" onBlur="EditValues(this)"></asp:TextBox>
                                                        </div>
                                                        <div style="width: 50%; display: table-cell; padding: 1px; text-align: left">
                                                            <asp:DropDownList ID="ddlUniTiempo" runat="server" CssClass="form-control form-control-user obl" Width="120px">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td style="padding: 10px">Fotos</td>
                                                    <td>
                                                        <asp:ImageButton ID="btnImagenesSitio" CssClass="cargando1" runat="server" ImageUrl="~/MEDIA/IMG/Btn_ImagenesSitio.png" OnClick="btnImagenesSitio_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 10px">Ubicación(*)</td>
                                                    <td>
                                                        <asp:TextBox ID="txtLatSitio" runat="server" CssClass="form-control form-control-user" Width="200px" placeholder="Latitud" ToolTip="Latitud" onBlur="EditValues(this)" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <td colspan="2">
                                                        <div style="display: table-cell">
                                                            <asp:TextBox ID="txtLongSitio" runat="server" CssClass="form-control form-control-user" Width="200px" placeholder="Longitud" ToolTip="Longitud" onBlur="EditValues(this)" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                        <div style="display: table-cell; padding-left: 15px">
                                                            <asp:LinkButton ID="btnVerMapa" runat="server" OnClick="btnVerMapa_Click">Ver Mapa</asp:LinkButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 10px" colspan="3">Equipamento
                                <asp:TextBox ID="txtEquipamentoSitio" runat="server" CssClass="form-control form-control-user" Width="100%" TextMode="MultiLine" onkeyup="countChars(this);" onBlur="EditValues(this)"></asp:TextBox>
                                                        <p id="charNumEquip" class="lblCountCarc">3000 caracteres permitidos</p>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEquipamentoSitio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                    <td style="padding-left: 10px" colspan="3">Recomendaciones
                                <asp:TextBox ID="txtRecomendacionesSitio" runat="server" CssClass="form-control form-control-user" Width="95%" TextMode="MultiLine" onkeyup="countChars(this);" onBlur="EditValues(this)"></asp:TextBox>
                                                        <p id="charNumRecom" class="lblCountCarc">3000 caracteres permitidos</p>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtRecomendacionesSitio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 10px;" colspan="3">IRA(*)
                                
                                                <asp:TextBox ID="txtIra" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine" onkeyup="countChars(this);" onBlur="EditValues(this)"></asp:TextBox>
                                                        <p id="charNumIra" class="lblCountCarc">3000 caracteres permitidos</p>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">Sinopsis(*)
                                
                                                <asp:TextBox ID="txtDescCortaSitio" runat="server" CssClass="form-control form-control-user" Width="95%" TextMode="MultiLine" onkeyup="countCharsDC(this);" onBlur="EditValues(this)"></asp:TextBox>
                                                        <p id="charNumSinopSitio" class="lblCountCarc">100 caracteres permitidos</p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 10px;" colspan="6">Descripción(*)
                                                    <asp:TextBox ID="txtDescripcionSitio" runat="server" CssClass="form-control form-control-user" Width="98%" TextMode="MultiLine" MaxLength="4000" onkeyup="countChars(this);" onBlur="EditValues(this)"></asp:TextBox>
                                                        <p id="charNumStDesc" class="lblCountCarc">3000 caracteres permitidos</p>
                                                    </td>

                                                </tr>
                                            </table>
                                        </div>
                                        <div style="display: table-cell">
                                            <div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="txtNombreSitio" ValidationGroup="Guardar">-Titulo Obligatorio</asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="txtIDireccionSitio" ValidationGroup="Guardar">-Dirección Obligatorio</asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="txtTelefonoSitio" ValidationGroup="Guardar">-Teléfono Obligatorio</asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="txtHorarioSitio" ValidationGroup="Guardar">- Horario Obligatorio</asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="txtTiempoSitio" ValidationGroup="Guardar">-Duración Obligatorio</asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="txtLatSitio" ValidationGroup="Guardar">-Latitud Obligatorio</asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="txtLongSitio" ValidationGroup="Guardar">-Longitud Obligatorio</asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="txtIra" ValidationGroup="Guardar">- I.R.A Obligatorio</asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="txtDescCortaSitio" ValidationGroup="Guardar">- Sinópsis Obligatorio</asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="txtDescripcionSitio" ValidationGroup="Guardar">-Descripción Obligatorio</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div style="display: table-row; padding: 10px">
                            <div style="display: table-cell; padding: 10px">
                                <asp:Button ID="btnGuardarSitio" runat="server" Text="Guardar" CssClass="btn btn-secondary btn-user btn-block cargando" OnClick="btnGuardarSitio_Click" ValidationGroup="Guardar" />
                            </div>
                            <div style="display: table-cell; padding: 10px">
                                <asp:Button ID="btnEliminarSitio" runat="server" Text="Eliminar" CssClass="btn btn-secondary btn-user btn-block" OnClick="btnEliminarSitio_Click" />
                            </div>
                            <div style="display: table-cell; padding: 10px">
                                <asp:Button ID="btnVolver1" runat="server" CssClass="btn btn-secondary btn-user btn-block cargando1" Text="Volver" OnClick="btnVolver1_Click" />
                                <%--<asp:Button ID="btnVolverSitio" runat="server" Text="Volver" CssClass="btn btn-primary btn-user btn-block" OnClick="btnVolverSitio_Click" />--%>
                            </div>
                        </div>

                        <br />
                        <br />
                        <div style="width: 100%; height: 50px"></div>
                        <input type="text" id="txtValidaCarac" class="oculto" />
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
                                        <asp:Button ID="btnSubirImagen" runat="server" Text="Subir" CssClass="btn btn-secondary btn-user btn-block" OnClick="btnSubirImagen_Click" />
                                    </div>
                                </div>
                            </div>
                            <div style="display: table-cell; width: 50%; vertical-align: middle; border-left: 1px solid #999; padding: 20px">
                                <asp:Label ID="lblMensajeImg" runat="server" Text="No hay archivos seleccionados."></asp:Label>
                                <asp:GridView ID="gvImagenes" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvImagenes_RowCommand" DataKeyNames="id_imagen_sitio,UrlTemp,Nombre,Orden,urlBD" OnRowDataBound="gvImagenes_RowDataBound">
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
                                        <asp:TemplateField HeaderText="Eliminar" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEliminarImagen" runat="server" Height="20px" Width="20px" ImageUrl="~/MEDIA/IMG/deleteOpaco.png" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CommandName="Eliminar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <div style="width: 100%; height: 2px"></div>
                                <asp:Button ID="btnGuardarImagenes" runat="server" Text="Actualizar Orden" CssClass="btn btn-primary btn-user btn-block" OnClick="btnGuardarImagenes_Click" Visible="true" />
                            </div>

                        </div>
                    </div>
                </asp:Panel>
                <a class="popup-cerrar" style="background-color:#999999" onclick="cerrarpopup();">X</a>
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
            <asp:HiddenField ID="hdEdit" Value="" runat="server" />

            <div class="modal fade" id="myModalLogin" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true" data-keyboard="false" data-backdrop="static">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="row">
                                <div class="col-sm-4">
                                    <%--<img src="Media/img/AtencionPeq.png" />--%>
                                </div>
                                <div class="col-sm-8 div-center">
                                    <h5 class="modal-title" id="exampleModalLongLogin">Atención!</h5>
                                </div>
                            </div>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <h6>Tu sesión ha expirado!.</h6>
                                    <br />
                                    Serás redireccionado a la página de ingreso.
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <%--<button type="button" class="btn btn-secondary" data-dismiss="modal"><a href="Login.aspx"></a>Aceptar</button>--%>
                            <input type="button" class="btn btn-secondary" onclick="location.href = 'Login.aspx';" value="Aceptar" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal fade" id="myModalErr" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="row">
                                <div class="col-sm-8 div-center">
                                    <h5 class="modal-title" id="exampleModalLongError">Atención!</h5>
                                </div>
                            </div>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:Label ID="lblError" runat="server" Text="Este servicio esta en mantenimiento, disculpe la molestia."></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <footer class="bg-info fixed-bottom" style="height: 40px">
        <div class="container" style="height: 20px">
            <p class="m-0 text-center text-white">Copyright &copy; C.D.I Software 2018</p>
        </div>
        <!-- /.container -->
    </footer>
</body>
</html>
