<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CT.ADIM.WEB.Index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ATT - Bienvenido</title>
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" />--%>
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
    <%--<link href="MEDIA/CSS/portfolio-item.css" rel="stylesheet" />--%>
    <link href="MEDIA/CSS/thumbnail-gallery.css" rel="stylesheet" />
    <link href="MEDIA/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/local.css" rel="stylesheet" />
    <link href="~/Media/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/Media/css/PersonalizadoBPM.css" rel="stylesheet" />
    <style>
        .form-control-obligatorio {
            color: #ff0000;
            background-color: #fff;
            border-color: #ff7676;
            outline: 0;
        }

        .div-center {
            align-items: center;
            display: flex;
            justify-content: center
        }
    </style>

    <script>
        $(document).ready(function () {
            $('.cargando').click(function (event) {
                if (Page_ClientValidate()) { $('#p').show(); }
            })

            $('.cargando1').click(function (event) {
                $('#p').show();
            })
        });

        function openModalBt() {
            $('#myModal').modal('show');
        }

        function openModalMsg() {
            $('#myModalMsg').modal('show');
        }

        function openModalImg() {
            $('#myModalImg').modal('show');
        }

        function openModalErr() {
            $('#myModalErr').modal('show');
        }

        function openModalNot() {
            $('#myModalNot').modal('show');
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

        function valObl(control) {
            if (control.value != '') {
                control.className = 'valTrue';
            }
            else {
                control.className = 'valFalse'
            }

        }

        function Validar(obj) {
            //alert('hola');
            //if (control = 'ddlCiudad') {
            //    if (obj.value = 'Ciudad...') {
            //        obj.className = 'form-control form-control-obligatorio';
            //        ValidatorEnable(document.getElementById("RequiredFieldValidator2"), true);
            //    }
            //}
            //else {
            if (obj.value == '') {
                if (control = 'txtNombre') {
                    obj.className = 'form-control form-control-obligatorio';
                    ValidatorEnable(document.getElementById("RequiredFieldValidator1"), true);
                }

                if (control = 'txtDescCortaCircuito') {
                    obj.className = 'form-control form-control-obligatorio';
                    ValidatorEnable(document.getElementById("RequiredFieldValidator5"), true);
                }
                if (control = 'txtDescripcion') {
                    obj.className = 'form-control form-control-obligatorio';
                    ValidatorEnable(document.getElementById("RequiredFieldValidator6"), true);
                }

            }
            else {
                obj.className = 'form-control';
            }
            //}

        }

        function openModalOrden() {
            $('#myModalOrden').modal('show');
        }

        function openModalLogin() {
            $('#myModalLogin').modal('show');
        }
    </script>

    <style>
        .validar {
            /*background-color: #ff4081;*/
            border-color: #ff4081;
        }

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
            background-color: White;
            border-width: 1px;
            border-color: #333;
            border-style: solid;
            padding: 10px;
            border-radius: 15px;
            overflow-x: hidden;
            overflow-y: hidden;
        }

        .txt-hidden {
            visibility: hidden;
        }

        .form {
            text-align: center
        }

        .td {
            text-align: left;
        }
        /*.valFalse {
            border:1px solid lightcoral;
        }

        .valTrue {
            border: 1px solid lightcoral;
        }*/
    </style>

</head>
<body class="bg-body">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="p" style="position: fixed; background-color: white; width: 100%; height: 100%; z-index: 2; top: 1PX; left: 1px; display: none; text-align: center; vertical-align: central;">
            <div style="display: inline-block; padding-top: 15%">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/MEDIA/IMG/spinner2.gif" />
            </div>
        </div>
       <%-- <div class="container" style="width:100%">--%>

            <nav class="navbar navbar-expand-lg bg-info navbar-dark fixed-top">
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
                                <asp:LinkButton ID="btnPerfil" runat="server" CssClass="nav-link" OnClick="btnPerfil_Click" Visible="false">Mi Cuenta</asp:LinkButton>
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
            <div id="cntBotones" runat="server" class="container">
                <br />
                <br />
                <br />
                <div class="row text-center text-lg-left">
                    <div class="col-lg-3 col-md-4 col-xs-6">
                        <asp:ImageButton ID="btnCircuitos" runat="server" CssClass="img-fluid img-thumbnail" ImageUrl="~/MEDIA/IMG/Btn_Cicuitos.png" OnClick="btnCircuitos_Click" />
                    </div>
                </div>
            </div>
            <br />
            <div id="divTtlCircuitos" class="container" runat="server" visible="false">
                <h3>Tus Circuitos.</h3>
                Espacio para crear todos los circuitos que desees y modificar los que creaste anteriormente, ten en cuenta que el exito de tus recorridos depende de la 
            calidad de la información con que los describas.
            </div>
            <br />
            <div id="cntCircuitos" class="container" runat="server">
                <div class="row text-center text-lg-left">
                </div>
            </div>
            <div id="cntCircuitoDtlle" class="container" runat="server" visible="false">
                <div class="container">
                    <div class="row">
                        <%--<div class="col-sm-6 td" style="color: #666">--%>
                        <div style="display: table-cell">
                            <h4>
                                <asp:Label ID="lblTituloCircuito" runat="server" ForeColor="#333333"></asp:Label></h4>
                        </div>
                        <div style="display: table-cell; padding-left: 20px;">
                            <div class="btn-group">
                                <%-- <button type="button" class="btn btn-info dropdown-toggle"
                                    data-toggle="dropdown">
                                    Acciones <span class="caret"></span>
                                </button>--%>
                                <button type="button" style="border: none; background-color: white"
                                    data-toggle="dropdown">
                                    <img src="MEDIA/IMG/menu.fw.png" />
                                </button>
                                <ul class="dropdown-menu" role="menu">
                                    <li>
                                        <asp:LinkButton ID="btnVerSitio" runat="server" OnClick="btnVerSitio_Click" CssClass="btn cargando1" Visible="true">Ver Sitios</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="btnOrdenarSitios" runat="server" OnClick="btnOrdenarSitios_Click" CssClass="btn cargando1" Visible="true">Ordenar</asp:LinkButton></a></li>
                                    <li>
                                        <asp:LinkButton ID="btnImagen" runat="server" OnClick="btnImagen_Click" CssClass="btn cargando1" Visible="true">Agregar Imágen</asp:LinkButton></li>
                                    <%--<li class="divi"></li>--%>
                                    <li>
                                        <asp:LinkButton ID="btnActivar" runat="server" OnClick="btnActivar_Click" CssClass="btn cargando1" Visible="true">Activar</asp:LinkButton></li>
                                </ul>
                            </div>
                        </div>
                        <%--</div>--%>
                    </div>
                    <div style="display: table-cell; padding: 5px" align="left">
                    </div>
                    <div class="container form" style="width: 100%;">
                        <div style="display: table-row;">
                            <div style="display: table-cell; width: 90%; background-color: whitesmoke; border-radius: 2%; padding: 5px">

                                <div class="row">
                                    <div class="col-1 td">
                                        <label>Titulo</label>
                                    </div>
                                    <div class="col-11 td">
                                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control form-control-user" OnBlur="Validar(this);" autocomplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-1 td">
                                        <label>Categoria</label>
                                    </div>
                                    <div class="col-sm-3 td">
                                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control form-control-user obl"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-1 td">
                                        <label>Costo</label>
                                    </div>
                                    <div class="col-sm-3 td">
                                        <div style="display: table-cell">
                                            <asp:TextBox ID="txtCostoCliente" runat="server" CssClass="form-control form-control-user" onkeypress="return soloNumeros(event)" autocomplete="off"></asp:TextBox>
                                        </div>
                                        <div style="display: table-cell; padding-left: 2px">
                                            <asp:DropDownList ID="ddlMoneda" runat="server" CssClass="form-control form-control-user obl" Width="80px">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-1 td">
                                        <label>Pais</label>
                                    </div>
                                    <div class="col-sm-3 td">
                                        <asp:DropDownList ID="ddlPais" runat="server" CssClass="form-control form-control-user" AutoPostBack="true" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-1 td">
                                        <label>Ciudad</label>
                                    </div>
                                    <div class="col-3 td">
                                        <asp:DropDownList ID="ddlCiudad" runat="server" CssClass="form-control form-control-user" onchange="Validar(this)"></asp:DropDownList>
                                    </div>
                                    <div class="col-1 td">
                                        <label>Duración</label>
                                    </div>
                                    <div class="col-3 td">
                                        <div style="display: table-cell">
                                            <asp:TextBox ID="txtTiempoEstimado" runat="server" CssClass="form-control form-control-user" onkeypress="return soloNumeros(event)" autocomplete="off"></asp:TextBox>
                                        </div>
                                        <div style="display: table-cell; padding-left: 2px">
                                            <asp:DropDownList ID="ddlUniTiempo" runat="server" CssClass="form-control form-control-user obl" Width="120px">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-1 td">
                                        <label>Edad</label>
                                    </div>
                                    <div class="col-3 td">
                                        <asp:DropDownList ID="ddlEdad" runat="server" CssClass="form-control form-control-user"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 td">
                                        <label>Equipamento</label>
                                        <asp:TextBox ID="txtEquipamentos" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine" MaxLength="1000" onkeyup="countChars(this);"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6 td">
                                        <label>Recomendaciones</label>
                                        <asp:TextBox ID="txtRecomendaciones" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine" MaxLength="3000" onkeyup="countChars(this);"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 td">
                                        <p id="charNumEquip" class="lblCountCarc">3000 caracteres permitidos</p>
                                    </div>
                                    <div class="col-sm-6 td">
                                        <p id="charNumRecom" class="lblCountCarc">3000 caracteres permitidos</p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-6 td">
                                        <label>Sinopsis</label>
                                        <asp:TextBox ID="txtDescCortaCircuito" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine" MaxLength="3000" onkeyup="countCharsDC(this);" onblur="Validar(this);"></asp:TextBox>
                                    </div>
                                    <div class="col-6 td">
                                        <label>Contexto</label>
                                        <asp:TextBox ID="txtContexto" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine" MaxLength="3000" onkeyup="countChars(this);"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-6 td">
                                        <p id="charNumSinopCircuito" class="lblCountCarc">100 caracteres permitidos</p>
                                    </div>
                                    <div class="col-6 td">
                                        <p id="charNumContextoCircuito" class="lblCountCarc">3000 caracteres permitidos</p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12 td">
                                        <label>Descripción</label>
                                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control form-control-user" CausesValidation="true" TextMode="MultiLine" MaxLength="3000" onkeyup="countChars(this);" OnBlur="Validar(this)"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div style="display: table-cell; padding: 5px" align="left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="txtNombre" ValidationGroup="Guardar">- Titulo Obligatorio</asp:RequiredFieldValidator>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="ddlCategoria" ValidationGroup="Guardar" InitialValue="Categoria...">- Categoria Obligatorio</asp:RequiredFieldValidator>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="ddlCiudad" InitialValue="Ciudad..." ValidationGroup="Guardar">- Ciudad Obligatorio</asp:RequiredFieldValidator>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="ddlEdad" ValidationGroup="Guardar" InitialValue="Edad...">- Edad Obligatorio</asp:RequiredFieldValidator>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="txtDescCortaCircuito" ValidationGroup="Guardar">- Sinopsis Obligatorio</asp:RequiredFieldValidator>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="txtDescripcion" ValidationGroup="Guardar">- Descripción Obligatorio</asp:RequiredFieldValidator>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="" ForeColor="LightCoral" ControlToValidate="txtCostoCliente" ValidationGroup="Guardar">- Costo Obligatorio</asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-10 div-center">
                            <div style="padding-right: 5px">
                                <asp:Button ID="btnGuardarCircuito" runat="server" Text="Guardar" CssClass="btn btn-secondary btn-user btn-block cargando" OnClick="btnGuardarCircuito_Click" ValidationGroup="Guardar" />
                            </div>
                            <div style="padding-right: 5px; padding-left: 5px">
                                <asp:Button ID="btnEliminarCircuito" runat="server" Text="Eliminar" CssClass="btn btn-secondary btn-user btn-block" OnClick="btnEliminarCircuito_Click" Visible="false" />
                            </div>
                            <div style="padding-left: 5px;">
                                <asp:Button ID="btnVOlver" CssClass="btn btn-secondary btn-user btn-block cargando1" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                            </div>

                        </div>
                    </div>
                </div>

                <div style="display: table-cell; width: 150px;"></div>
                <asp:HiddenField ID="hdIdc" runat="server" />
                <asp:HiddenField ID="hdIds" runat="server" />

                <asp:TextBox ID="txtValidaCategoria" runat="server" Text="" CssClass="txt-hidden"></asp:TextBox>
                <asp:TextBox ID="txtValidaPais" runat="server" Text="" CssClass="txt-hidden"></asp:TextBox>
                <asp:TextBox ID="txtValidaCiudad" runat="server" Text="" CssClass="txt-hidden"></asp:TextBox>
                <asp:TextBox ID="txtValidaEdad" runat="server" Text="" CssClass="txt-hidden"></asp:TextBox>
                <input type="text" id="txtValidaCarac" class="oculto" />
            </div>

            <div class="modal" id="myModalOrden">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="row">
                                <h3 class="modal-title">Ordenar Sitios!</h3>
                            </div>
                        </div>
                        <div class="modal-body div-center">
                            <div style="display: table-row">
                                <div style="padding-top: 10px">
                                    <asp:Label ID="lblMensajeOrden" runat="server" ForeColor="#ff5050" Text=""></asp:Label>
                                    <asp:GridView ID="gvSitios" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="table table-striped" DataKeyNames="id_sitio,orden">
                                        <Columns>
                                            <asp:BoundField HeaderText="Nombre" DataField="nombre_sitio" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:TemplateField HeaderText="Orden" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOrden" runat="server" Text='<%# Bind("orden") %>' CssClass="form-control form-control-user" Width="50px" Height="20px"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="modal-footer div-center">
                                    <div style="display: table-cell">
                                        <button type="button" class="btn btn-secondary btn-user btn-block" data-dismiss="modal" style="width: 100px">Cerrar</button>
                                    </div>
                                    <div style="display: table-cell">
                                        <asp:Button ID="btnGuardarOrden" runat="server" Text="Guardar" CssClass="btn btn-secondary btn-user btn-block" Width="100px" OnClick="btnGuardarOrden_Click" Visible="true" />
                                    </div>
                                </div>

                            </div>
                            <%--<a class="popup-cerrar" onclick="cerrarpopup();">X</a>--%>
                        </div>
                    </div>
                </div>
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
            <div class="modal fade" id="myModal">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header" align="center">
                            <h3 class="modal-title">Elije una imágen para tu circuito!</h3>
                        </div>
                        <div class="modal-body">
                            <div style="padding-top: 40px" align="center">
                                <label class="file-upload">
                                    <asp:FileUpload ID="fulImagenes" runat="server" AllowMultiple="false" OnChange="fileupload(this.value)"></asp:FileUpload>
                                </label>
                            </div>
                        </div>
                        <div class="modal-footer div-center">
                            <div style="display: table-cell">
                                <button type="button" class="btn btn-primary btn-user btn-block" data-dismiss="modal" style="width: 100px">Cerrar</button>
                            </div>
                            <div style="display: table-cell">
                                <asp:Button ID="btnGuardarImagen" runat="server" class="btn btn-primary btn-user btn-block" Text="Guardar" Width="100px" OnClick="btnGuardarImagen_Click" />
                            </div>


                        </div>
                    </div>
                </div>
            </div>

            <div class="modal fade" id="myModalMsg">
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

            <div class="modal fade" id="myModalImg" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="row">
                                <div class="col-sm-4">
                                    <img src="../Media/img/AtencionPeq.png" />
                                </div>
                                <div class="col-sm-8 div-center">
                                    <h5 class="modal-title" id="exampleModalLongTitle">Atención!</h5>
                                </div>
                            </div>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <h6>Los siguientes sitios no tienen niguna imágen.</h6>
                                    <br />
                                    <asp:Label ID="lblMensajeImg" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal fade" id="myModalErr" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="row">
                                <div class="col-sm-4">
                                    <%--<img src="Media/img/AtencionPeq.png" />--%>
                                </div>
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
                                    <h6>ATENCIÓN!.</h6>
                                    <br />
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

            <div class="modal fade" id="myModalNot" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true" data-keyboard="false" data-backdrop="static">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="row">
                                <div class="col-sm-4">
                                    <%--<img src="Media/img/AtencionPeq.png" />--%>
                                </div>
                                <div class="col-sm-8 div-center">
                                    <h5 class="modal-title" id="exampleModalLongNot">Atención!</h5>
                                </div>
                            </div>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:Label ID="lblMensajeNot" runat="server">prueba</asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <input type="button" class="btn btn-secondary" onclick="location.href = 'Index.aspx?ini=1';" value="Aceptar" />
                        </div>
                    </div>
                </div>
            </div>
        <%--</div>--%>
    </form>
    <footer class="bg-gradient-info fixed-bottom" style="height: 40px">
        <div class="container" style="height: 20px; position: absolute">
            <p class="m-0 text-center text-white">Copyright &copy; C.D.I Software 2018</p>
        </div>
        <!-- /.container -->
    </footer>
</body>
</html>
